using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Timers;
using AnimeOrganizerCommon;

namespace AnimeOrganizerService
{
    public partial class Service1 : ServiceBase
    {
        private Queue<AnimeFile> taskQueue;
        private AnimeDirectoryGraph directoryGraph;
        private Dictionary<string, int> directoryEpisodeCountCache;
        private Dictionary<string, MoveableAnimeFile> pendingActions;
        private string zeddPath = @"C:\Users\blazi\Videos\zedd";
        private Timer timer;
        private object lockObject = new object();

        public Service1()
        {
            InitializeComponent();
            fileSystemWatcher.Path = zeddPath;
        }

        protected override void OnStart(string[] args)
        {
            if (taskQueue == null)
            {
                taskQueue = new Queue<AnimeFile>();
            }
            if (pendingActions == null)
            {
                pendingActions = new Dictionary<string, MoveableAnimeFile>();
            }
            // Build the directory tree
            directoryGraph = BuildDirectoryGraph();
            // Configure FileSystemWatcher
            fileSystemWatcher.Created += FileSystemWatcher_Created;
            fileSystemWatcher.EnableRaisingEvents = true;

            // Initialize and configure timer
            timer = new Timer();
            timer.Interval = 60000; // 1 minute
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            lock (lockObject)
            {
                while (taskQueue.Count > 0)
                {
                    AnimeFile file = taskQueue.Dequeue();
                    EventLog.WriteEntry("AnimeOrganizerService", "Processing file: " + file.Path);
                    AnimeFolder matchedFolder = SearchDirectoryGraph(file.SearchSet);
                    var separator = getSeparatorForDirectory(matchedFolder);
                    var proposedEpisodeNumber = matchedFolder.FileCount + 1;
                    // if the folder has cached episode count, use that instead
                    if (directoryEpisodeCountCache != null && directoryEpisodeCountCache.ContainsKey(matchedFolder.Path))
                    {
                        proposedEpisodeNumber = directoryEpisodeCountCache[matchedFolder.Path] + 1;
                    } else
                    {
                        // initialize the cache if it doesn't exist
                        if (directoryEpisodeCountCache == null)
                        {
                            directoryEpisodeCountCache = new Dictionary<string, int>();
                        }
                        directoryEpisodeCountCache[matchedFolder.Path] = proposedEpisodeNumber; // cache the episode count
                    }
                    var newFileName = UtillExtensions.GenerateFileName(matchedFolder.Name, proposedEpisodeNumber, separator);

                    var moveableFile =  new MoveableAnimeFile
                    {
                        OriginalFile = file,
                        TargetFolder = matchedFolder,
                        NewFileName = newFileName,
                        Episode = proposedEpisodeNumber,
                        
                    };
                    
                    // Send a windows notification to confirm the move
                    string notificationTitle = $"Move {file.Name}?";
                    string notificationMessage = $"Target: {matchedFolder.Name}\\{newFileName}";
                    string actionId = Guid.NewGuid().ToString();

                    //NotificationHelper.SendActionNotification(notificationTitle, notificationMessage, actionId);

                    // Store the moveableFile with the actionId for later processing when user responds
                    StorePendingAction(actionId, moveableFile);
                }
            }
        }

        private void FileSystemWatcher_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            lock (lockObject)
            {
                //Get the fileInfo object of the file
                FileInfo fileInfo = new FileInfo(e.FullPath);
                //Create an AnimeFile object from the fileInfo if it's a video file
                if (fileInfo.Exists && UtillExtensions.videoExtensions.Contains(fileInfo.Extension))
                {
                    AnimeFile animeFile = new AnimeFile
                    {
                        Name = fileInfo.Name,
                        Path = fileInfo.FullName,
                        Episode = 0 // Placeholder, actual episode extraction logic can be added
                    };

                    taskQueue.Enqueue(animeFile);
                    EventLog.WriteEntry("AnimeOrganizerService", "File added to queue: " + animeFile.Path);
                }
            }
        }

        protected override void OnStop()
        {
            if (timer != null)
            {
                timer.Stop();
                timer.Dispose();
                timer = null;
            }

            fileSystemWatcher.EnableRaisingEvents = false;
            fileSystemWatcher.Created -= FileSystemWatcher_Created;
            if (taskQueue != null)
            {
                lock (lockObject)
                {
                    taskQueue.Clear();
                    taskQueue = null;
                    directoryGraph = null;
                    if (pendingActions != null)
                    {
                        pendingActions.Clear();
                        pendingActions = null;
                    }
                }
            }
        }

        // build an ordered tree (alphabethical ordering) from the list of directories in the zeddPath
        private AnimeFolder[] BuildDirectoryTree()
        {
            DirectoryInfo rootDir = new DirectoryInfo(zeddPath);
            if (!rootDir.Exists)
            {
                EventLog.WriteEntry("AnimeOrganizerService", "Zedd path does not exist: " + zeddPath, EventLogEntryType.Error);
                throw new DirectoryNotFoundException("Zedd path does not exist: " + zeddPath);
            }
            var directories = rootDir.GetDirectories();
            // remove directories that are global or excluded
            directories = directories.Where(dir => !UtillExtensions.ExcludeFolders.Contains(dir.Name)
            && !UtillExtensions.GlobalFolders.Contains(dir.Name)
            ).ToArray();
            // sort directories alphabetically
            Array.Sort(directories, (x, y) => string.Compare(x.Name, y.Name));

            // convert to array of AnimeFolder
            AnimeFolder[] animeFolders = directories.Select(dir => new AnimeFolder
            {
                Name = dir.Name,
                Path = dir.FullName
            }).ToArray();

            return animeFolders;
        }

        //build a graph from the directory tree
        private AnimeDirectoryGraph BuildDirectoryGraph()
        {

            // get the ordered list of directories
            var animeFolders = BuildDirectoryTree();

            // sort the directory tree alphabetically

            return new AnimeDirectoryGraph(animeFolders);
        }

        //search the directoryGraph for a folder matching the searchSet, using a self-pruning BFS
        private AnimeFolder SearchDirectoryGraph(HashSet<string> searchSet)
        {
            var bestMatch = null as AnimeFolder;
            var bestMatchWeight = -1;

            // run a self-pruning BFS on the directory graph and find the best match
            var queue = new Queue<AnimeDirectoryGraph.Node>();
            foreach (var node in directoryGraph.RootNode.Children)
            {
                queue.Enqueue(node);
            }

            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();
                var matchWeight = currentNode.Self.SearchSet.Intersect(searchSet).Count();
                //perfect match found if the union of both sets is equal to the search set
                bool perfectMatch = currentNode.Self.SearchSet.Union(searchSet).Count() == searchSet.Count;
                if (perfectMatch)
                {
                    return currentNode.Self;
                }

                // Update best match if current match weight is better and greater than 0 i.e at least one tag matches
                if (matchWeight >= bestMatchWeight && matchWeight > 0)
                {
                    bestMatchWeight = matchWeight;
                    bestMatch = currentNode.Self;
                }
                // Enqueue all child nodes that are worth exploring i.e same or higher match weight than the current match weight
                foreach (var child in currentNode.Children)
                {
                    var childMatchWeight = child.Self.SearchSet.Intersect(searchSet).Count();
                    if (childMatchWeight >= matchWeight)
                    {
                        queue.Enqueue(child);
                    }

                }
            }
            // return the best match found or null if no match found
            return bestMatch;
        }

        private Seperator getSeparatorForDirectory(AnimeFolder folder)
        {
            // Get the first file in the directory
            var files = Directory.GetFiles(folder.Path);
            if (files.Length > 0)
            {
                var firstFile = new FileInfo(files[0]);
                // Placeholder logic: if the file name contains "episode", return episode separator
                if (firstFile.Name.ToLower().Contains("episode"))
                {
                    return Seperator.episode;
                }
                else
                {
                    return Seperator.dash;
                }
            }
            else
            {
                // Placeholder logic: return dash for all directories
                return Seperator.none;
            }
        }

        /// <summary>
        /// Stores a pending action awaiting user confirmation from the notification.
        /// </summary>
        private void StorePendingAction(string actionId, MoveableAnimeFile moveableFile)
        {
            lock (lockObject)
            {
                if (pendingActions != null)
                {
                    pendingActions[actionId] = moveableFile;
                    EventLog.WriteEntry("AnimeOrganizerService", 
                        $"Pending action stored: {actionId} - Move {moveableFile.OriginalFile.Name} to {moveableFile.TargetFolder.Name}");
                }
            }
        }

        /// <summary>
        /// Processes a pending action based on user response to the notification.
        /// </summary>
        public void ProcessPendingAction(string actionId, bool allowed)
        {
            lock (lockObject)
            {
                if (pendingActions != null && pendingActions.ContainsKey(actionId))
                {
                    MoveableAnimeFile moveableFile = pendingActions[actionId];
                    pendingActions.Remove(actionId);

                    if (allowed)
                    {
                        try
                        {
                            moveableFile.MoveFile();
                            EventLog.WriteEntry("AnimeOrganizerService", 
                                $"File moved successfully: {moveableFile.OriginalFile.Name} to {moveableFile.Path}");
                        }
                        catch (Exception ex)
                        {
                            EventLog.WriteEntry("AnimeOrganizerService", 
                                $"Failed to move file: {moveableFile.OriginalFile.Name} - {ex.Message}", 
                                EventLogEntryType.Error);
                        }
                    }
                    else
                    {
                        EventLog.WriteEntry("AnimeOrganizerService", 
                            $"File move denied by user: {moveableFile.OriginalFile.Name}");
                    }
                }
            }
        }
    }
}