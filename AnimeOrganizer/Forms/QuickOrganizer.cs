using AnimeOrganizerCommon;
using AnimeOrganizerDataObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AnimeOrganizer
{
    public partial class QuickOrganizer : Form
    {
        private DirectoryInfo directoryInfo;
        private readonly Queue<MoveableAnimeFile> filesToArrage;
        private Dictionary<string, int> directoryEpisodeCountCache;
        private readonly HashSet<string> updatedFolders;
        private readonly List<AnimeFolder> globalAnimeFolders;
        private AnimeDirectoryGraph directoryGraph;
        private MoveableAnimeFile currentMoveableFile;
        private readonly IAnimeDB db;
        private readonly string rootPath;
        private bool useDefaultSeason;
        
        public QuickOrganizer() : this(Program.database)
        {
        }

        public QuickOrganizer(IAnimeDB db)
        {
            this.db = db;
            this.useDefaultSeason = true;
            this.rootPath = UtillExtensions.ZeddPath;
            filesToArrage = new Queue<MoveableAnimeFile>();
            globalAnimeFolders = new List<AnimeFolder>();
            updatedFolders = new HashSet<string>();
            InitializeComponent();
            autoSeason_cbx.Checked = true;
            menu1.AddOpenMenuOption("Database", OpenDatabaseEvent);
            menu1.AddOpenMenuOption("Organizer", OpenOrganizerEvent);
            try
            {
                GetFiles(rootPath);
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message, "Info");
                Close();
            }
            Next();
        }
        private void OpenDatabaseEvent(object sender, EventArgs e)
        {

            new DatabaseForm().Show();
            this.Hide();
        }
        private void OpenOrganizerEvent(object sender, EventArgs e)
        {
            new Organizer().Show();
            this.Hide();
        }

        private void GetFiles(string rootPath)
        {
            RefreshDirectories();
            directoryInfo = new DirectoryInfo(rootPath);
            filesToArrage.Clear(); //clear previous files to arrange
            foreach (FileInfo file in directoryInfo.EnumerateFiles())
            {
                if (!UtillExtensions.videoExtensions.Contains(file.Extension))
                {
                    continue;
                }
                AnimeFile animeFile = new AnimeFile() { 
                    Name = file.Name,
                    Path = file.FullName
                };

                AnimeFolder proposedFolder =  directoryGraph.SearchGraph(animeFile.SearchSet);
                //If a proposed folder is not found, create a MoveableAnimeFile to a new folder
                if (proposedFolder == null)
                {
                   proposedFolder = new AnimeFolder()
                    {
                        Name = string.Join(" ", animeFile.SearchSet),
                        Path = rootPath + @"\" + string.Join(" ", animeFile.SearchSet)
                    };
                }
                Seperator existingSeperator =  UtillExtensions.GetSeparatorForDirectory(proposedFolder);
                Seperator proposedSeperator = existingSeperator != Seperator.none ? existingSeperator : getSeperatorFromSettings();
                int proposedEpisodeNumber = proposedFolder.FileCount + 1;
                // if the folder has cached episode count, use that instead
                if (directoryEpisodeCountCache != null && directoryEpisodeCountCache.ContainsKey(proposedFolder.Path))
                {
                    proposedEpisodeNumber = directoryEpisodeCountCache[proposedFolder.Path] + 1;
                }
                else
                {
                    // initialize the cache if it doesn't exist
                    if (directoryEpisodeCountCache == null)
                    {
                        directoryEpisodeCountCache = new Dictionary<string, int>();
                    }
                    directoryEpisodeCountCache[proposedFolder.Path] = proposedEpisodeNumber; // cache the episode count
                }
                var proposedFileName = UtillExtensions.GenerateFileName(proposedFolder.Name, proposedEpisodeNumber, proposedSeperator);
                MoveableAnimeFile moveableAnimeFile = new MoveableAnimeFile()
                {
                    OriginalFile = animeFile,
                    TargetFolder = proposedFolder,
                    Episode = proposedEpisodeNumber,
                    Name = proposedFolder.Name,
                    Seperator = proposedSeperator

                };
                filesToArrage.Enqueue(moveableAnimeFile);
            }
            
            if (filesToArrage.Count < 1)
            {
                throw new Exception("No files to be arranged");
            }

        }
        private void RefreshDirectories()
        {
            // rebuild directory graph and cache global folders
           
            globalAnimeFolders.Clear();
            directoryInfo = new DirectoryInfo(rootPath);
            foreach (DirectoryInfo folder in directoryInfo.EnumerateDirectories())
            {
                // only add global folders
                if (UtillExtensions.globalFolders.Contains(folder.Name))
                {
                    AnimeFolder animeFolder = new AnimeFolder();
                    animeFolder.Name = folder.Name;
                    animeFolder.Path = folder.FullName;
                    globalAnimeFolders.Add(animeFolder);
                }
            }
            directoryGraph = new AnimeDirectoryGraph(UtillExtensions.BuildDirectoryTree());
            
            
        }
       
        private Seperator getSeperatorFromSettings()
        {
            Console.WriteLine("Getting seperator from settings: " + Properties.Settings.Default.episodeSep.ToString());
            try
            {
                return (Seperator)Enum.Parse(typeof(Seperator), Properties.Settings.Default.episodeSep.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("Sep convert Exception: " + e.Message);
                return Seperator.none;
            }
        }
        private new void Close()
        {
            new Organizer().Show();
            this.Hide();
        }
        // Display the current file to be arranged in UI
        private void ShowFile()
        {
            mainDisplay.Text = currentMoveableFile.OriginalFile.Name;
            DisplayOptions();
        }

        // Select the next file to arrange
        private void Next()
        {
            if (filesToArrage.Count > 0)
            {
                currentMoveableFile = filesToArrage.Dequeue();
                ShowFile();
            }
            else
            { 
                MessageBox.Show("No more files to auto organize, Folders Updated: " 
                    + updatedFolders.Count, "Info");


                UpdateRecord();
                Close();
            }

        }
        private void OptionBtn_click(object sender, EventArgs e)
        {
            if (!((sender as Control).Tag is MoveableAnimeFile tag)) return; //if Tag is MoveableAnimeFile continue else return
            try
            {
                var file = tag;
                file.MoveFile();
                updatedFolders.Add(file.TargetFolder.Path);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error moving file: " + ex.Message, "Info");
            } finally
            {
                Next();
            }
        }
        // Get AnimeRecord by folder path
        private AnimeRecord GetAnimeRecord(string path)
        {
            //check if path exists in system
            if (!Directory.Exists(path))
            {
                return null;
            }

            AnimeFolder animeFolder = new AnimeFolder()
            {
                Name = new DirectoryInfo(path).Name,
                Path = path
            };
            AnimeRecord animeRecord = db[animeFolder.Name];
            if (animeRecord.title == null)
            {
                int fileCount = animeFolder.FileCount;
                animeRecord = new AnimeRecord(animeFolder.Name, fileCount) { 
                 season = useDefaultSeason ? UtillExtensions.GetSeason() : "Unknown",
                 year = useDefaultSeason ? DateTime.Now.Year : 0 // set year to 0 if not using default season
                };
            }
            return animeRecord;
        }
        // Update database records for all moved files
        private void UpdateRecord()
        {
            foreach (var path in updatedFolders)
            {
                AnimeRecord record = GetAnimeRecord(path);
                if (record == null || UtillExtensions.globalFolders.Contains(record.title))
                {
                    continue;
                }
                if (db.Contains(record.title))
                {
                    db.Update(record);
                }
                else
                {
                    db.Create(record);
                }
            }
            db.Save();
        }

        private void DisplayOptions()
        {
            optionsBox.Controls.Clear();
            // create button for proposed folder
            optionsBox.Controls.Add(GetButton(currentMoveableFile, false));

            // for each global folder, create a movable file 
            foreach (AnimeFolder folder in globalAnimeFolders)
            {
                MoveableAnimeFile moveableAnimeFile = new MoveableAnimeFile()
                {
                    OriginalFile = currentMoveableFile.OriginalFile,
                    TargetFolder = folder,
                    Name = currentMoveableFile.OriginalFile.Name,
                    Episode = currentMoveableFile.Episode,
                    Seperator = currentMoveableFile.Seperator
                };
                optionsBox.Controls.Add(GetButton(moveableAnimeFile, true));

            }
            VScrollBar scrollBar = new VScrollBar();
            scrollBar.Dock = DockStyle.Right;
            optionsBox.Controls.Add(scrollBar);
        }

        private Button GetButton (MoveableAnimeFile animeFile, bool isGlobal)
        {
            var butttonText = isGlobal ? "Move to " + animeFile.TargetFolder.Name : "Move to " + animeFile.TargetFolder.Name + " as Ep " + animeFile.Episode;
            Button button = new Button();
            button.Text = butttonText;
            button.Size = new Size(222, 88);
            button.Font = new Font("Segoe UI", 15f, FontStyle.Regular, GraphicsUnit.Pixel);
            button.TextAlign = ContentAlignment.MiddleCenter;
            button.AutoEllipsis = true;
            button.Tag = animeFile;
            button.Click += OptionBtn_click;
            button.Visible = true;
            button.Name = animeFile.NewFileName;
            return button;
        }

        private void skipBtn_Click(object sender, EventArgs e)
        {
            Next();
        }


        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                UpdateRecord();
                Application.Exit();
            }
        }

        private void mainDisplay_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(currentMoveableFile.OriginalFile.Name);
        }

        private void autoSeason_cbx_CheckedChanged(object sender, EventArgs e)
        {
            if (autoSeason_cbx.Checked)
            {
                this.useDefaultSeason = true;
            }
            else
            {
                this.useDefaultSeason = false;
            }
        }

        private void refresh_btn_Click(object sender, EventArgs e)
        {
            if (this.rootPath != null)
            {
                try
                {
                    GetFiles(rootPath);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Info");
                    Close();
                }
                Next();
            }
        }
    }
}
