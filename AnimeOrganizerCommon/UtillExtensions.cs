using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

namespace AnimeOrganizerCommon
{
    public static class UtillExtensions
    {
        // use serializable RedundantStringSet for redundant strings
        private static RedundantStringSet redundantStrings = RedundantStringSet.LoadFromDefaultLocation();

        public static IEnumerable<string> RedundantStringItems => redundantStrings.Items;

        // mutable sets with defaults for globalFolders and excludeFolders
        private static readonly string GlobalFoldersFile = "global_folders.xml";
        private static readonly string ExcludeFoldersFile = "exclude_folders.xml";

        private static MutableDefaultStringSet globalFoldersSet = MutableDefaultStringSet.LoadFromDefaultLocation(new[] { "movies and ova", "dump" }, GlobalFoldersFile);
        private static MutableDefaultStringSet excludeFoldersSet = MutableDefaultStringSet.LoadFromDefaultLocation(new[] { "temp", "Done", "Summer", "Fall", "Winter", "Spring" }, ExcludeFoldersFile);

        public static IEnumerable<string> GlobalFolders => globalFoldersSet.Items;
        public static IEnumerable<string> ExcludeFolders => excludeFoldersSet.Items;

        // Backwards-compatible aliases (original field names)
        public static IEnumerable<string> globalFolders => GlobalFolders;
        public static IEnumerable<string> excludeFolders => ExcludeFolders;

        // Add to global folders (only persists user-added items)
        public static bool AddGlobalFolder(string s)
        {
            var added = globalFoldersSet.Add(s);
            if (added) globalFoldersSet.SaveToDefaultLocation();
            return added;
        }

        // Remove only user-added global folders
        public static bool RemoveGlobalFolder(string s)
        {
            var removed = globalFoldersSet.Remove(s);
            if (removed) globalFoldersSet.SaveToDefaultLocation();
            return removed;
        }

        // Add to exclude folders
        public static bool AddExcludeFolder(string s)
        {
            var added = excludeFoldersSet.Add(s);
            if (added) excludeFoldersSet.SaveToDefaultLocation();
            return added;
        }

        // Remove only user-added exclude folders
        public static bool RemoveExcludeFolder(string s)
        {
            var removed = excludeFoldersSet.Remove(s);
            if (removed) excludeFoldersSet.SaveToDefaultLocation();
            return removed;
        }

        // an index aware intersection check between two search sets
        public static List<string> IndexedListIntersect(List<string> searchSetA, List<string> searchSetB)
        {
            List<string> result = new List<string>();
            List<string> longSet = searchSetA.Count > searchSetB.Count ? searchSetA : searchSetB;
            List<string> shortSet = searchSetA.Count > searchSetB.Count ? searchSetB : searchSetA;

            //loop shortSet and check if any item is in longSet, if so add the index of the item in longSet to the result list
            for (int i = 0; i < shortSet.Count; i++)
            {
                if (longSet[i].Equals(shortSet[i]))
                {
                    result.Add(shortSet[i]);
                }
            }

            return result;
        }

        public static bool IsIndexedListIntersectPerfect(List<string> searchSetA, List<string> searchSetB)
        {
            int matchCount = 0;
            if (searchSetA.Count != searchSetB.Count) return false;

            //loop shortSet and check if any item is in longSet, if so add the index of the item in longSet to the result list
            for (int i = 0; i < searchSetA.Count; i++)
            {
                if (searchSetB[i].Equals(searchSetA[i]))
                {
                   matchCount++;
                }
            }

            return (matchCount == searchSetA.Count) && (matchCount == searchSetB.Count);
        }

        public static bool IsNotMatchingDefaultGlobalFoler(string item, string input)
        {
            return globalFoldersSet.ItemIsUserAddedAndEqualToInput(item, input);
        }

        public static bool IsNotMatchingDefaultExcludedFoler(string item, string input)
        {
            return excludeFoldersSet.ItemIsUserAddedAndEqualToInput(item, input);
        }

        public static bool IsDefaultGlobalFolder(string input)
        {
            return globalFoldersSet.IsDefault(input);
        }

        public static bool IsDefaultExcludedFolder(string input)
        {
            return excludeFoldersSet.IsDefault(input);
        }

        public static List<string> videoExtensions = new List<string>
          {
              ".mp4",
              ".mkv"
          };
        public static bool IsNumeric(string s)
        {
            string numberChars = "0123456789";
            if (s == null) return false;
            if (s.Length == 0) return false;
            foreach (char c in s.Trim())
            {
                if (!numberChars.Contains(c)) return false;
            }
            return true;

        }
        public static bool IsRedundantString(string s)
        {
            return redundantStrings.Contains(s) || string.IsNullOrWhiteSpace(s);
        }

        // Add a redundant string and persist
        public static bool AddRedundantString(string s)
        {
            var added = redundantStrings.Add(s);
            if (added) redundantStrings.SaveToDefaultLocation();
            return added;
        }

        // Remove a redundant string and persist
        public static bool RemoveRedundantString(string s)
        {
            var removed = redundantStrings.Remove(s);
            if (removed) redundantStrings.SaveToDefaultLocation();
            return removed;
        }

        public static string GenerateFileName(string name, int episode, Seperator sep, bool isPoint5 = false)
        {
            string postFix = isPoint5 ? ".5" : string.Empty;
            switch (sep)
            {
                case Seperator.dash:
                    return name + " - " + (episode >= 10 ? episode + "" : "0" + episode) + postFix;
                case Seperator.episode:
                    return name + " Episode " + episode + postFix;
                default:
                    return name + " Episode " + episode + postFix;
            }
        }
        
        public static List<KeyValuePair<string, object>> GetCbxDataSourceFromEnum<TEnum>()
        {
            var enumType = typeof(TEnum);
            var fields = enumType.GetMembers().OfType<FieldInfo>()
                                              .Where(p => p.MemberType == MemberTypes.Field)
                                              .Where(p => p.IsLiteral)
                                              .ToList();
            var entries = new Dictionary<string, object>();
            foreach (var field in fields)
            {
                var val = (int)field.GetValue(null);
                var description = field.Name;
                entries[description] = val;
            }
            return entries.ToList();
        }
        public static string RemoveCommas(string input)
        {
            return input.Replace(",", ";");
        }

        // Store the Zedd path - should be set by the main application on startup
        public static string ZeddPath { get; set; }

        public static string GetZeddDirectory()
        {
            return ZeddPath;
        }

        public static string ShortenString32(string input)
        {
            if (input.Length <= 32)
            {
                return input;
            }
            return input.Substring(0, 32) + "...";
        }

        public static string GetSeason()
        {
            int month = DateTime.Now.Month;
            if (month >= 1 && month <= 3)
            {
                return "Winter";
            } else if (month >= 4 && month <= 6)
            {
                return "Spring";
            } else if (month >= 7 && month <= 9)
            {
                return "Summer";
            } else if (month >= 10 && month <= 12)
            {
                return "Fall";
            } else {
                return "";
            }
        }

        public static AnimeFolder[] BuildDirectoryTree()
        {
            var zeddPath = @"C:\Users\blazi\Videos"; //GetZeddDirectory();
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


        public static Seperator GetSeparatorForDirectory(AnimeFolder folder)
        {
            if (globalFolders.Contains(folder.Name))
            {
                return Seperator.none;
            }
            // Get the first file in the directory
            try
            {
                var files = Directory.GetFiles(folder.Path);
                if (files.Length > 0)
                {
                    var firstFile = new FileInfo(files[0]);
                    // if the file name contains "episode", return episode separator
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
                    return Seperator.none;
                }
            }
            catch (Exception)
            {
                return Seperator.none;
            }
        }

        /// <summary>
        /// Converts an AnimeFile to a MoveableAnimeFile with the specified target folder.
        /// </summary>
        /// <remarks>
        /// This method creates a MoveableAnimeFile instance by copying the properties from the provided AnimeFile
        /// and associating it with the target folder. The method also determines the appropriate separator format
        /// (dash or episode) based on existing files in the target directory.
        /// </remarks>
        /// <param name="animeFile">The source AnimeFile to be converted. Contains information such as name and episode number.</param>
        /// <param name="targetFolder">The destination AnimeFolder where the file will be moved. Used to determine the separator format and set as the target.</param>
        /// <returns>
        /// A MoveableAnimeFile instance populated with:
        /// <list type="bullet">
        /// <item><description>OriginalFile: Reference to the source animeFile</description></item>
        /// <item><description>TargetFolder: The destination folder</description></item>
        /// <item><description>Seperator: Determined from existing files in the target folder</description></item>
        /// <item><description>Name: Copied from the source file</description></item>
        /// <item><description>Episode: Copied from the source file</description></item>
        /// <item><description>NewFileName: Generated based on the file name, episode number, and separator format</description></item>
        /// <item><description>IsPoint5Episode: Initialized to false</description></item>
        /// </list>
        /// </returns>
        public static MoveableAnimeFile ConvertToMovableFile(AnimeFile animeFile, AnimeFolder targetFolder)
        {
            var separator = GetSeparatorForDirectory(targetFolder);
            
            return new MoveableAnimeFile
            {
                OriginalFile = animeFile,
                TargetFolder = targetFolder,
                Seperator = separator,
                Name = animeFile.Name,
                Episode = animeFile.Episode,
                IsPoint5Episode = false
            };
        }

    }
}
