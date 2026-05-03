using AnimeOrganizerCommon;
using AnimeOrganizerDataObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimeOrganizer.Forms
{
    // TODOS
    // 1. Implement the database feature to update record after moving files
    // 2. Dry run the organizer on a test folder and fix any bugs that arise
    // 3. Add a information dialog that shows the changes have been made
    // Done. 4. Add option to remove a file from the proposed list and not consider it for organization (such as if it's a non-anime file or a duplicate file that the user doesn't want to keep)
    // Done. 5. For excess files, when files is clicked it is added to the proposed list for the current folder, 
    //       5.1 If active queue is exhausted and excess files are remaining dump the excess files into a specific folder such as "C:\Users\blazi\Videos\ExcessFiles" to keep them organized.
    // Done. 6. If a new folder is proposed for a file but that file is a global folder file, and we move it to a global folder and no other files are proposed for the new folder, we should clean up the DAG, hash map and any other data structures to remove the proposed folder since it is no longer needed and we don't want to keep proposing that folder for other files in the future since it will just add clutter and confusion to the organizer
    public partial class QuickOrganizerV2 : BaseForm
    {
        private Queue<AnimeFolder> _activeAnimeFolderQueue;
        private AnimeDirectoryGraph directoryGraph;
        private Dictionary<string, int> _directoryEpisodeCountCache;
        public HashSet<string> _setOfTouchedFolders;
        private string rootPath;
        private readonly string dumpFolderName = @"dump";
        private readonly IAnimeDB db;
        Button skipBtn = new Button(); // button to skip the current file and move it to the hold section
        private const string EventLogSourceName = "AnimeOrganizerService";
        List<Button> fileActionButtons = new List<Button>(); // list to hold the file action buttons for easy management

        #region 1. Constructor and Initialization

        /// <summary>
        /// Safely writes to the event log without crashing if permissions are insufficient.
        /// This handles cases where the application isn't running with administrator privileges.
        /// </summary>
        private void SafeWriteEventLog(string message, EventLogEntryType entryType = EventLogEntryType.Information)
        {
            try
            {
                EventLog.WriteEntry(EventLogSourceName, message, entryType);
            }
            catch (System.Security.SecurityException)
            {
                // Silently ignore - application continues without event log
                // In production, you could also log to a file as fallback
            }
            catch (Exception ex)
            {
                // Log to console as fallback for other exceptions
                Console.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {entryType}: {message}");
            }
        }

        public QuickOrganizerV2() : this(Program.database)
        {
        }

        public QuickOrganizerV2(IAnimeDB db)
        {
            _formIndex = 1;
            this.db = db;
            rootPath = UtillExtensions.GetZeddDirectory();
            _setOfTouchedFolders = new HashSet<string>();
            _activeAnimeFolderQueue = new Queue<AnimeFolder>();
            InitializeComponent();
            SetUpMenuStrip();
            FirstTimeDisables();
            RegisterHandlers();
            RefreshDirectories();
            RefreshViews();
        }

        private void FirstTimeDisables()
        {
            plusBtn.Enabled = false;
            minusBtn.Enabled = false;
            point5btn.Enabled = false;
        }

        private void disableFileActionButtons()
        {
            foreach (var button in fileActionButtons)
            {
                button.Enabled = false;
            }
        }

        private void enableFileActionButtons()
        {
            foreach (var button in fileActionButtons)
            {
                button.Enabled = true;
            }
        }

        private void SetUpMenuStrip()
        {
            // add menu strip options to custom menu control, with oprions "Open Database", "Open Organizer"

            menu1.AddOpenMenuOption("Open Database", OpenDatabaseEvent);
            menu1.AddOpenMenuOption("Open Organizer", OpenOrganizerEvent);
        }

        #endregion

        #region 2. UI Setup Methods

        private void setUpGlobalMoveButtons(List<AnimeFolder> globalFolders)
        {
            // create a button to skip organization for the current folder
            var skipOrganizationBtn = new Button();
            skipOrganizationBtn.Size = new Size(210, 75);
            skipOrganizationBtn.Text = "Skip Folder";
            skipOrganizationBtn.Click += SkipOrganizationBtn_Click;
            actionBtnFlp.Controls.Add(skipOrganizationBtn);

            // create a button for each anime folder in the global list and add it to the flow layout panel, with size 210x75 with text in the patthern "Move to [folder name]"

            foreach (var folder in globalFolders)
            {
                var button = new Button();
                button.Size = new Size(210, 75);
                button.Text = $"Move to {folder.Name}";
                button.Click += (sender, e) => MoveSelectedItemToFolder(folder);
                actionBtnFlp.Controls.Add(button);
                fileActionButtons.Add(button);
            }
            // add last button to remove item from list view and move it to the hold section

            skipBtn.Size = new Size(210, 75);
            skipBtn.Text = "Skip (Move to Hold)";
            actionBtnFlp.Controls.Add(skipBtn);
            fileActionButtons.Add(skipBtn);
            // when clicked it should skip organization for the current folder and move to the next folder in the queue
            disableFileActionButtons(); // disable the buttons until a file is selected

        }

        #endregion

        #region 3. Directory and File Discovery

        private void RefreshDirectories()
        {
            // rebuild directory graph and cache global folders
            List<AnimeFolder> globalFolders = new List<AnimeFolder>();
            DirectoryInfo directoryInfo = new DirectoryInfo(rootPath);
            foreach (DirectoryInfo folder in directoryInfo.EnumerateDirectories())
            {
                // only add global folders
                if (UtillExtensions.globalFolders.Contains(folder.Name))
                {
                    AnimeFolder animeFolder = new AnimeFolder();
                    animeFolder.Name = folder.Name;
                    animeFolder.Path = folder.FullName;
                    globalFolders.Add(animeFolder);
                }
            }
            directoryGraph = new AnimeDirectoryGraph(UtillExtensions.BuildDirectoryTree());
            SafeWriteEventLog($"Directory graph built for root path: {rootPath}. Global folders found: {string.Join(", ", globalFolders.Select(f => f.Name))}.");

            // set up buttons for global folders
            setUpGlobalMoveButtons(globalFolders);
            // get files in the root directory and propose organization using the directory graph
            GetFilesAndAutoOrganize();

        }

        private void GetFilesAndAutoOrganize()
        {
            SafeWriteEventLog($"Starting directory refresh for root path: {rootPath}.");
            Dictionary<string, AnimeFolder> _animeFolderHashMap = new Dictionary<string, AnimeFolder>();
            Dictionary<string, AnimeFolder> _dagSearchCache = new Dictionary<string, AnimeFolder>(); // cache for DAG search results to improve performance by avoiding redundant searches for files with the same search set

            // Iterate through all filies in the root folder, ensure we get only the files with the extensions that are supported.

            DirectoryInfo directoryInfo = new DirectoryInfo(rootPath);

            foreach (FileInfo fileInfo in directoryInfo.EnumerateFiles())
            {

                // check if the file extension is supported
                if (!UtillExtensions.videoExtensions.Contains(fileInfo.Extension)) { continue; }

                // create anime file object
                AnimeFile animeFile = new AnimeFile()
                {
                    Name = Path.GetFileNameWithoutExtension(fileInfo.FullName),
                    Path = fileInfo.FullName
                };

                // find the proposed folder for the file using the directory graph
                AnimeFolder proposedFolder;
                AnimeFolder directoryGraphproposedFolder;
                var searchSetKey = string.Join("+", animeFile.SearchSet);
                if (_dagSearchCache.ContainsKey(searchSetKey))
                {
                    directoryGraphproposedFolder = _dagSearchCache[searchSetKey];
                    SafeWriteEventLog($"DAG search cache hit for file {animeFile.Name} with search set {string.Join(", ", animeFile.SearchSet)}. Proposed folder: {(directoryGraphproposedFolder != null ? directoryGraphproposedFolder.Name : "null")}.");
                }
                else
                {
                    directoryGraphproposedFolder = directoryGraph.SearchGraph(animeFile.SearchSet);
                    SafeWriteEventLog($"DAG search performed for file {animeFile.Name} with search set {string.Join(", ", animeFile.SearchSet)}. Proposed folder: {(directoryGraphproposedFolder != null ? directoryGraphproposedFolder.Name : "null")}.");
                    if (directoryGraphproposedFolder == null)
                    {
                        directoryGraphproposedFolder = new AnimeFolder()
                        {
                            Name = string.Join(" ", animeFile.SearchSet),
                            Path = rootPath + @"\" + string.Join(" ", animeFile.SearchSet),
                            IsNew = true
                        };
                    }
                    _dagSearchCache[searchSetKey] = directoryGraphproposedFolder; // cache the result of the DAG search for this search set
                }
                // cache the proposed folder for the file
                if (_animeFolderHashMap.ContainsKey(directoryGraphproposedFolder.Path))
                {
                    proposedFolder = _animeFolderHashMap[directoryGraphproposedFolder.Path];
                }
                else
                {
                    //copy by value the directory graph proposed folder to a new anime folder object and add it to the hash map
                    proposedFolder = new AnimeFolder()
                    {
                        Name = directoryGraphproposedFolder.Name,
                        Path = directoryGraphproposedFolder.Path,
                        IsNew = directoryGraphproposedFolder.IsNew
                    };
                    _animeFolderHashMap[proposedFolder.Path] = proposedFolder;
                }
                // propose epidode separator and episode number using regex and add it to the proposed folder
                Seperator existingSeperator = UtillExtensions.GetSeparatorForDirectory(proposedFolder);
                Seperator proposedSeperator = Seperator.dash; //existingSeperator != Seperator.none ? existingSeperator : getSeperatorFromSettings();
                int proposedEpisodeNumber = proposedFolder.FileCount + 1;

                // if the folder has cached episode count, use that instead
                if (_directoryEpisodeCountCache != null && _directoryEpisodeCountCache.ContainsKey(proposedFolder.Path))
                {
                    proposedEpisodeNumber = _directoryEpisodeCountCache[proposedFolder.Path] + 1;
                }
                else
                {
                    // initialize the cache if it doesn't exist
                    if (_directoryEpisodeCountCache == null)
                    {
                        _directoryEpisodeCountCache = new Dictionary<string, int>();
                    }
                }
                _directoryEpisodeCountCache[proposedFolder.Path] = proposedEpisodeNumber; // cache the episode count

                // create a moveable anime file object and add it to the proposed folder
                var proposedFileName = UtillExtensions.GenerateFileName(proposedFolder.Name, proposedEpisodeNumber, proposedSeperator);
                MoveableAnimeFile moveableAnimeFile = new MoveableAnimeFile()
                {
                    OriginalFile = animeFile,
                    TargetFolder = proposedFolder,
                    Episode = proposedEpisodeNumber,
                    Seperator = proposedSeperator,
                    Name = proposedFolder.Name

                };

                // add the moveable anime file to the proposed folder
                _animeFolderHashMap[proposedFolder.Path].AddProposedFile(moveableAnimeFile);

            }
            // enqueue the proposed folders to the active queue based on the order they were added to the hash map (which is based on the order the files were processed in the root directory)
            foreach (var folder in _animeFolderHashMap.Values)
            {
                _activeAnimeFolderQueue.Enqueue(folder);
            }
            SafeWriteEventLog($"Directory refresh complete. {_activeAnimeFolderQueue.Count} folders proposed for organization.");
        }

        #endregion

        #region 4. Episode Number Management

        private void UpdateEpisodeNumbersForCurrentFolder()
        {
            // get the current folder from the front of the queue and update the episode numbers for all proposed files in that folder
            // to be in the correct order based on their position in the list view
            AnimeFolder currentFolder = _activeAnimeFolderQueue.Peek();
            int proposedFileCount = currentFolder.ProposedFileCount;
            int actualFileCount = currentFolder.FileCount;
            for (int i = 1; i <= proposedFileCount; i++)
            {
                MoveableAnimeFile proposedFile = currentFolder.GetProposedFileByIndex(i-1);
                if (!proposedFile.IsPoint5Episode)
                {
                    proposedFile.Episode = actualFileCount + i; // update episode number to be in the correct order
                }
                else {
                    proposedFile.Episode = actualFileCount + i - 1; // if it's a point5 episode, it should have the same episode number as the previous episode, so we subtract 1 from the episode number to keep it in the correct order
                }

            }
            RefreshListView();
        }

        private void IncreaseEpisodeNumberForSelectedItem(ListViewItem listViewItem)
        {
            var itemIndex = (int)listViewItem.Tag;
            //var newItemIndex = itemIndex + 1;
            _activeAnimeFolderQueue.Peek().GetProposedFileByIndex(itemIndex).UpdateEpisodeNumber(1); // increase episode number
            //_activeAnimeFolderQueue.Peek().GetProposedFileByIndex(newItemIndex).UpdateEpisodeNumber(-1); // decrease episode number of the next item to swap their positions
            // swap the item with the next item in the proposed files list to reflect the change in episode number
            //_activeAnimeFolderQueue.Peek().SwapProposedFiles(itemIndex, newItemIndex);
            RefreshListView();
            SafeWriteEventLog($"Increased episode number for file {_activeAnimeFolderQueue.Peek().GetProposedFileByIndex(itemIndex).OriginalFile.Name} in folder {_activeAnimeFolderQueue.Peek().Name}.");

        }

        private void DecreaseEpisodeNumberForSelectedItem(ListViewItem listViewItem)
        {
            var itemIndex = (int)listViewItem.Tag;
            //var newItemIndex = itemIndex - 1;
            _activeAnimeFolderQueue.Peek().GetProposedFileByIndex(itemIndex).UpdateEpisodeNumber(-1); // decrease episode number
            //_activeAnimeFolderQueue.Peek().GetProposedFileByIndex(newItemIndex).UpdateEpisodeNumber(1); // increase episode number of the previous item to swap their positions
            // swap the item with the next item in the proposed files list to reflect the change in episode number
            //_activeAnimeFolderQueue.Peek().SwapProposedFiles(itemIndex, newItemIndex);
            RefreshListView();
            SafeWriteEventLog($"Decreased episode number for file {_activeAnimeFolderQueue.Peek().GetProposedFileByIndex(itemIndex).OriginalFile.Name} in folder {_activeAnimeFolderQueue.Peek().Name}.");

        }

        private void MarkAsPoint5EpisodeForSelectedItem(ListViewItem listViewItem)
        {
            _activeAnimeFolderQueue.Peek().GetProposedFileByIndex((int)listViewItem.Tag).MarkAsPoint5Episode();
            UpdateEpisodeNumbersForCurrentFolder(); // ensure the point5 episode is in the correct order with the rest of the episodes
            SafeWriteEventLog($"Marked file {_activeAnimeFolderQueue.Peek().GetProposedFileByIndex((int)listViewItem.Tag).OriginalFile.Name} as a point5 episode for folder {_activeAnimeFolderQueue.Peek().Name}.");
        }

        #endregion

        #region 5. UI Refresh and ListView Management

        private void RefreshViews()
        {
            if (_activeAnimeFolderQueue.Count == 0)
            {
                // TODO 5.1: If there are excess files remaining, dump them to the excess files folder before closing
                if (excessFLP.Controls.Count > 0)
                {
                    DumpRemainingExcessFilesToFolder();
                }

                MessageBox.Show("Organization complete! " + _setOfTouchedFolders.Count + " unique anime(s) arranged.");
                try
                {
                    db.Save();
                }
                catch (Exception ex)
                {
                    SafeWriteEventLog($"Error saving database: {ex.Message}", EventLogEntryType.Error);
                    MessageBox.Show($"Error saving database", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                Close();
                return;
            }

            AnimeFolder currentFolder = _activeAnimeFolderQueue.Peek();
            folderLbl.Text = currentFolder.Name + (currentFolder.IsNew ? " (New)" : "");
            RefreshListView();
        }

        private new void Close()
        {
            new Organizer().Show();
            this.Hide();
        }

        private void RefreshListView()
        {
            animelv.BeginUpdate();
            animelv.Items.Clear();
            animelv.Columns.Clear();
            // Add columns
            animelv.Columns.Add("New Name", 500);
            animelv.Columns.Add("Current Name", 600);
            animelv.Columns.Add("Episode", 100);

            AnimeFolder currentFolder = _activeAnimeFolderQueue.Peek();
            String currentFolderPath = currentFolder.Path;
            int filesToProposeCount = currentFolder.ProposedFileCount;
            for (int i = 0; i < filesToProposeCount; i++)
            {
                var animeFile = currentFolder.GetProposedFileByIndex(i);

                ListViewItem listViewItem = GetListViewItemForMoveableAnimeFile(animeFile, i);
                animelv.Items.Add(listViewItem);
            }
            // Auto-select the first item
            if (animelv.Items.Count > 0)
            {
                animelv.Items[0].Selected = true;
                animelv.Items[0].Focused = true;
                animelv.EnsureVisible(0);
            }
            animelv.EndUpdate();
            SafeWriteEventLog($"List view refreshed for folder {currentFolder.Name} with {filesToProposeCount} proposed files.");
        }

        private ListViewItem GetListViewItemForMoveableAnimeFile(MoveableAnimeFile moveableAnimeFile, int indexHash)
        {
            var listViewItem = new ListViewItem(moveableAnimeFile.NewFileName);
            listViewItem.SubItems.Add(moveableAnimeFile.OriginalFile.Name);
            listViewItem.SubItems.Add(moveableAnimeFile.Episode.ToString());
            listViewItem.Tag = indexHash; // store the index hash in the tag for later retrieval
            return listViewItem;
        }

        private void animelv_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                //var itemIndex = (int)e.Item.Tag;
                plusBtn.Enabled = true;
                    //itemIndex < _activeAnimeFolderQueue.Peek().ProposedFileCount - 1;
                minusBtn.Enabled = true; 
                    //itemIndex > 0;
                enableFileActionButtons();
            }
            else
            {
                plusBtn.Enabled = false;
                minusBtn.Enabled = false;
                disableFileActionButtons();

            }
        }

        #endregion

        #region 6. Excess File Management

        private void AddToExcessFLP(MoveableAnimeFile moveableAnimeFile) 
        {
            // create a button for the moveable anime file and add it to the excess flow layout panel, with text in the pattern "[File name]"
            // and dialog text in the pattern "Click to add [File name] to [Current folder name]"
            Button btn = new Button();
            btn.AutoSize = true;
            btn.Text = moveableAnimeFile.OriginalFile.Name;
            btn.Height = 58;
            btn.MinimumSize = new Size(210, 58);
            btn.MaximumSize = new Size(300, 58);
            btn.AutoEllipsis = true;
            btn.Tag = moveableAnimeFile.OriginalFile; // store the original file in the tag for later retrieval
            // when clicked, it should add the file to the current folder proposed files and remove the button from the excess flow layout panel
            btn.Click += (sender, e) =>
            {
                //check if the tag is an AnimeFile object
                //if (!((sender as Control).Tag is MoveableAnimeFile tag)) return;
                if (!((sender as Control).Tag is AnimeFile animeFile)) return;
                Seperator existingSeprator = UtillExtensions.GetSeparatorForDirectory(_activeAnimeFolderQueue.Peek());
                Seperator proposedSeperator = existingSeprator != Seperator.none ? existingSeprator : getSeperatorFromSettings();
                MoveableAnimeFile newProposedFile = new MoveableAnimeFile()
                {
                    OriginalFile = animeFile,
                    TargetFolder = _activeAnimeFolderQueue.Peek(),
                    Name = _activeAnimeFolderQueue.Peek().Name,
                    Seperator = proposedSeperator,
                    Episode = _activeAnimeFolderQueue.Peek().ProposedFileCount + 1 // set the episode number to be last in the proposed files list for the current folder
                };

                excessFLP.Controls.Remove(btn);
                _activeAnimeFolderQueue.Peek().AddProposedFile(newProposedFile);
                UpdateEpisodeNumbersForCurrentFolder();
            };
            var folderName = _activeAnimeFolderQueue.Count > 0 ? _activeAnimeFolderQueue.Peek().Name : "No Active Folder";
            toolTip1.SetToolTip(btn, $"Click to add {moveableAnimeFile.OriginalFile.Name} to {folderName}");

            excessFLP.Controls.Add(btn);
            SafeWriteEventLog($"File {moveableAnimeFile.OriginalFile.Name} added to excess files.");
        }

        #endregion

        #region 7. Event Handlers

        private void RegisterHandlers()
        {
            plusBtn.Click += (s, ev) =>
            {
                if (animelv.SelectedItems.Count > 0)
                    IncreaseEpisodeNumberForSelectedItem(animelv.SelectedItems[0]);
            };
            minusBtn.Click += (s, ev) =>
            {
                if (animelv.SelectedItems.Count > 0)
                    DecreaseEpisodeNumberForSelectedItem(animelv.SelectedItems[0]);
            };
            point5btn.Click += (s, ev) =>
            {
                if (animelv.SelectedItems.Count > 0)
                    MarkAsPoint5EpisodeForSelectedItem(animelv.SelectedItems[0]);
            };
            nextBtn.Click += (s, ev) =>
            {
                if (_activeAnimeFolderQueue.Count == 0) return; // TODO: handle this case better, maybe disable the next button when there are no more folders to propose
                _setOfTouchedFolders.Add(_activeAnimeFolderQueue.Peek().Path); // track the current folder as touched before moving the files
                MoveAllProposedFilesForCurrentFolder();
                
            };
            skipBtn.Click += SkipBtn_Click;
        }

        private void SkipOrganizationBtn_Click(object sender, EventArgs e)
        {
            if (_activeAnimeFolderQueue.Count == 0) return; // TODO: handle this case better, maybe disable the skip button when there are no more folders to propose
            CleanUp(); // clean up the current folder from the queue and other data structures since we are skipping organization for this folder
            RefreshViews(); // refresh the views to show the next folder and its proposed files
        }

        private void SkipBtn_Click(object sender, EventArgs e)
        {
            // get selected item in the list view
            var selectedItem = animelv.SelectedItems[0];
            MoveableAnimeFile selectedProposedFile = _activeAnimeFolderQueue.Peek().GetProposedFileByIndex((int)selectedItem.Tag);
            AnimeFolder originalProposedFolder = selectedProposedFile.TargetFolder; // TODO 6: Store the original folder before removing

            // remove the proposed file from the current folder
            _activeAnimeFolderQueue.Peek().RemoveProposedFileByIndex((int)selectedItem.Tag);

            // every time we remove or add a proposed file to a folder,
            // we should update the proposed episode numbers for the remaining proposed files in that folder to ensure they are in the correct order
            // and there are no duplicates.
            // So we should update the episode numbers for the remaining proposed files in the current folder.
            UpdateEpisodeNumbersForCurrentFolder();


            AddToExcessFLP(selectedProposedFile);

           
            MoveOn(originalProposedFolder); // if there are no more proposed files for the current folder after skipping, move on to the next folder and clean up the current folder from the queue and other data structures

            SafeWriteEventLog($"File {selectedProposedFile.OriginalFile.Name} skipped for folder {originalProposedFolder.Name} and added to excess files.");

            RefreshViews();
            
        }

        private void RemoveBtn_Click(object sender, EventArgs e)
        {
            // get selected item in the list view
            var selectedItem = animelv.SelectedItems[0];
            MoveableAnimeFile selectedProposedFile = _activeAnimeFolderQueue.Peek().GetProposedFileByIndex((int)selectedItem.Tag);
            AnimeFolder originalProposedFolder = selectedProposedFile.TargetFolder; // TODO 6: Store the original folder before removing

            // remove the proposed file from the current folder
            _activeAnimeFolderQueue.Peek().RemoveProposedFileByIndex((int)selectedItem.Tag);

            // every time we remove or add a proposed file to a folder,
            // we should update the proposed episode numbers for the remaining proposed files in that folder to ensure they are in the correct order
            // and there are no duplicates.
            // So we should update the episode numbers for the remaining proposed files in the current folder.
            UpdateEpisodeNumbersForCurrentFolder();

            //Check if the proposed folder should be cleaned up after skipping
            MoveOn(originalProposedFolder);

            RefreshViews();
        }

        private void QuickOrganizerV2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                try
                {
                    db.Save();
                }
                catch (Exception ex)
                {
                    SafeWriteEventLog($"Error saving database: {ex.Message}", EventLogEntryType.Error);
                    MessageBox.Show($"Error saving database", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                finally
                {
                    Application.Exit();
                }
            }
        }

        #endregion

        #region 8. File Movement Operations

        // Used when moving a file to a global folder, where keeping the original file name is expected.
        private void MoveSelectedItemToFolder(AnimeFolder targetFolder)
        {
            var selectedCount = animelv.SelectedItems.Count;
            if (selectedCount <= 0)
            {
                MessageBox.Show("Please select a file to move.", "No File Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
                return;
            }
            
            ListViewItem selectedItem = animelv.SelectedItems[0];
            MoveableAnimeFile selectedProposedFile = _activeAnimeFolderQueue.Peek().GetProposedFileByIndex((int)selectedItem.Tag);
            // original proposed folder should be the same as the head of the queue, a check is done to assert this.
            AnimeFolder originalProposedFolder = selectedProposedFile.TargetFolder; //Store the original folder before changing target
            if (_activeAnimeFolderQueue.Peek() != originalProposedFolder)
            {
                Console.WriteLine("WARNING: The original proposed folder for the selected file is not the current folder at the head of the queue. Original proposed folder: " + originalProposedFolder.Path + ", Current folder at head of queue: " + _activeAnimeFolderQueue.Peek().Path);
                SafeWriteEventLog($"The original proposed folder for the selected file is not the current folder at the head of the queue. Original proposed folder: {originalProposedFolder.Path}, Current folder at head of queue: {_activeAnimeFolderQueue.Peek().Path}", EventLogEntryType.Warning);
            }

            var targetDirPath = targetFolder.Path;
            var extension = Path.GetExtension(selectedProposedFile.OriginalFile.Path);
            var newFilePath = Path.Combine(targetDirPath, selectedProposedFile.OriginalFile.Name + extension);
            //overwite the move file logic and move to specific destination path since global folders expect the original file name to be kept.
            selectedProposedFile.MoveFile(newFilePath); 
            SafeWriteEventLog($"Moved file {selectedProposedFile.OriginalFile.Name} to {targetFolder.Name} at path {newFilePath}.");

            // remove the proposed file from the current folder
            _activeAnimeFolderQueue.Peek().RemoveProposedFileByIndex((int)selectedItem.Tag);

            //If the file was moved to a global folder from a new proposed folder, check for cleanup
            if (IsGlobalFolder(targetFolder))
            {
                MoveOn(originalProposedFolder);
            }

            //track the touched folders
            _setOfTouchedFolders.Add(targetFolder.Path);

            // refresh the views to reflect the changes
            RefreshViews();
        }
        //Used to move all files to the current proposed folder when the user is done organizing.
        private void MoveAllProposedFilesForCurrentFolder()
        {
            AnimeFolder currentFolder = _activeAnimeFolderQueue.Peek();
            int proposedFileCount = currentFolder.ProposedFileCount;
            for (int i = 0; i < proposedFileCount; i++)
            {
                MoveableAnimeFile proposedFile = currentFolder.GetProposedFileByIndex(i);
                proposedFile.MoveFile();
            }
            //database updates
            AnimeRecord record = db[currentFolder.Name];
            if (AnimeRecord.IsEmpty(record))
            {
                record.numberOfEpisodes += proposedFileCount;
                record.lastUpdate = DateTimeOffset.Now;
                db.Update(record);
                SafeWriteEventLog($"Moved {proposedFileCount} files to {currentFolder.Name}. Database record updated with {record.numberOfEpisodes} episodes.");
            } else
            {
                // if the record doesn't exist, create a new one with the proposed number of episodes and current date as last update
                record = new AnimeRecord()
                {
                    title = currentFolder.Name,
                    numberOfEpisodes = proposedFileCount,
                    lastUpdate = DateTimeOffset.Now,
                    year = DateTime.Now.Year,
                    season = UtillExtensions.GetSeason(),
                    description = "Anime Name: " + currentFolder.Name
                };
                db.Create(record);
                SafeWriteEventLog($"Moved {proposedFileCount} files to {currentFolder.Name}. Database record created with {record.numberOfEpisodes} episodes.");
            }
            
            CleanUp();
            // Refresh the views to show the next folder and its proposed files
            RefreshViews();
        }

        #endregion

        #region 8 Clean up operations
        private void CleanUp()
        {
            // remove the first element in the _animeFolderHashMap and clear the episode count cache for that directory.
            if (_activeAnimeFolderQueue.Count <= 0) return;
            AnimeFolder folderToRemove = _activeAnimeFolderQueue.Dequeue();
            string folderPathToRemove = folderToRemove.Path;
            _directoryEpisodeCountCache.Remove(folderPathToRemove);
        }

        /// <summary>
        /// Checks if a folder is a global folder by comparing its name with the list of global folders.
        /// </summary>
        private bool IsGlobalFolder(AnimeFolder folder)
        {
           return UtillExtensions.globalFolders.Contains(folder.Name);
        }


        private void MoveOn(AnimeFolder folder)
        {
            if (folder.ProposedFileCount > 0)
            {
                return; // Don't move on if there are still proposed files in the folder
            }
            if (folder.IsNew)
            {
                CheckAndCleanupProposedFolder(folder); // If it's a new proposed folder, check if it should be cleaned up after skipping
            }
            CleanUp(); // Clean up the current folder from the queue and other data structures
        }

        /// <summary>
        /// Cleans up a proposed folder from the ADG, hash map, and other data structures
        /// when it no longer has any proposed files.
        /// </summary>
        private void CleanupProposedFolder(AnimeFolder proposedFolder)
        {
            // Implement cleanup logic for proposed folders
            // Steps:
            // 1. Check if the proposed folder has no proposed files
            if (proposedFolder.ProposedFileCount > 0)
            {
                return; // Don't clean up if there are still proposed files
            }

            // 2. Check if the proposed folder is marked as new (IsNew == true)
            if (!proposedFolder.IsNew)
            {
                return; // Don't clean up existing folders
            }

            // 3. get folder path

            string folderPath = proposedFolder.Path;

            // 4. Remove from episode count cache
            if (_directoryEpisodeCountCache != null && _directoryEpisodeCountCache.ContainsKey(folderPath))
            {
                _directoryEpisodeCountCache.Remove(folderPath);
            }

            // 5. Remove from active folder queue (if present)
            // dequeue, as current folder should be at the front of the queue, but we should check to be safe
            if (_activeAnimeFolderQueue.Count > 0 && _activeAnimeFolderQueue.Peek().Path == folderPath)
            {
                _activeAnimeFolderQueue.Dequeue();
            }
            else
            {
                // if it's not at the front, that is unexpected and likely an error in logic, post a warning log.
                Console.WriteLine("WARNING: Current folder: " + folderPath + "is not head/first of active queue");
                SafeWriteEventLog($"Attempted to clean up proposed folder {folderPath} but it was not at the head of the active queue. This may indicate a logic error in managing the active queue.", EventLogEntryType.Warning);
            }

            // 6. Remove from AnimeDirectoryGraph ADG
            // TODO 6: Implement logic to remove the node from the DAG, may not be necessary if the DAG is only used for searching and doesn't need to be modified after initialization,
            // but if we want to keep it updated we should remove the node for the proposed folder from the DAG as well to prevent it from being proposed again in the future.
            // This may require adding a RemoveNode method to AnimeDirectoryGraph
            // directoryGraph.RemoveNode(proposedFolder);
        }

        /// <summary>
        /// Checks if cleanup is needed after a file is moved away from a proposed folder
        /// and performs cleanup if conditions are met.
        /// </summary>
        private void CheckAndCleanupProposedFolder(AnimeFolder proposedFolder)
        {
            // TODO 6: Skeleton for checking and performing cleanup
            // This method should be called after removing a file from a proposed folder
            if (proposedFolder != null && proposedFolder.ProposedFileCount == 0 && proposedFolder.IsNew)
            {
                CleanupProposedFolder(proposedFolder);
            }
        }

        /// <summary>
        /// Dumps all remaining excess files to the excess files folder.
        /// Extracts AnimeFile objects from the excess FLP buttons and moves them to the dump folder.
        /// </summary>
        private void DumpRemainingExcessFilesToFolder()
        {
            try
            {
                var dumpFolderPath = Path.Combine(rootPath, dumpFolderName);
                // TODO: Ensure the dump folder exists, create if necessary
                if (!Directory.Exists(dumpFolderPath))
                {
                    Directory.CreateDirectory(dumpFolderPath);
                }
                DirectoryInfo dumpDirectoryInfo = new DirectoryInfo(dumpFolderPath);

                AnimeFolder excessDumpFolder = new AnimeFolder()
                {
                    Name = dumpDirectoryInfo.Name,
                    Path = dumpDirectoryInfo.FullName
                };

                // Collect all AnimeFile objects from the excess FLP button tags
                List<AnimeFile> excessFilesToDump = new List<AnimeFile>();
                foreach (Control control in excessFLP.Controls)
                {
                    if (control is Button btn && btn.Tag is AnimeFile animeFile)
                    {
                        excessFilesToDump.Add(animeFile);
                    }
                }

                // Move each file to the dump folder
                int successfulMoves = 0;
                int failedMoves = 0;
                foreach (AnimeFile file in excessFilesToDump)
                {
                    // Make a moveable anime file for each excess file to utilize the existing MoveFile logic
                    MoveableAnimeFile moveableFile = UtillExtensions.ConvertToMovableFile(file, excessDumpFolder);
                    var targetPath = Path.Combine(dumpDirectoryInfo.FullName, Path.GetFileName(file.Path));

                    try
                    {
                        moveableFile.MoveFile(targetPath);
                        successfulMoves++;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"WARNING: Failed to move excess file {file.Name} to dump folder: {ex.Message}");
                        SafeWriteEventLog($"Failed to move excess file {file.Name} to dump folder: {ex.Message}", EventLogEntryType.Warning);
                        failedMoves++;
                    }
                }

                //Clear the excess FLP after dumping
                excessFLP.Controls.Clear();
                ShowExcessFilesDumpSummary(successfulMoves, failedMoves, dumpFolderName);
            }
            catch (Exception ex)
            {
                SafeWriteEventLog($"Error dumping excess files: {ex.Message}", EventLogEntryType.Error);
                MessageBox.Show($"Error dumping excess files: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Shows a summary dialog of the excess files dump operation.
        /// </summary>
        private void ShowExcessFilesDumpSummary(int successCount, int failCount, string dumpPath)
        {
            // TODO 5.1: Create a summary message showing how many files were successfully moved and how many failed
            string summary = $"Excess Files Dump Summary\n\n" +
                           $"Successfully moved: {successCount} files\n" +
                           $"Failed to move: {failCount} files\n\n" +
                           $"Dump folder: {dumpPath}";
            SafeWriteEventLog($"Excess files dumped to {dumpPath}. Success: {successCount}, Failed: {failCount}");
            MessageBox.Show(summary, "Excess Files Dumped", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion
    }
}
