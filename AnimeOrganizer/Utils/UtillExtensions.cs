using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AnimeOrganizer
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
               if (s == null) return false;
               if (s.Length == 0) return false;
               try
               {
                    int.Parse(s);
                    return true;
               }
               catch (Exception)
               {

                    return false;
               }
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

          public static string GenerateFileName(string name, int episode, Seperator sep)
          {
               switch (sep)
               {
                    case Seperator.dash:
                         return name + " - " + (episode >= 10 ? episode + "" : "0" + episode);
                    case Seperator.episode:
                         return name + " Episode " + episode;
                    default:
                         return name + " Episode " + episode;
               }
          }
          public static List<KeyValuePair<string,object>> GetCbxDataSourceFromEnum<TEnum>()
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
        public static string GetZeddDirectory()
        {
            return Properties.Settings.Default.zeddPath;
        }
        public static string ShortenString32(string input)
        {
            if (input.Length<=32)
            {
                return input;
            }
            return input.Substring(0, 32)+"...";
        }

        public static string getSeason()
        {
            int month = DateTime.Now.Month;
            if (month >= 1 && month <= 3)
            {
                return "Winter";   
            } else if (month >= 4 && month <= 6)
            {
                return "Spring";
            }else if (month >= 7 && month <= 9)
            {
                return "Summer";
            } else if (month >= 10 && month <= 12)
            {
                return "Fall";
            } else { 
                return ""; 
            }
        }
     }
}
