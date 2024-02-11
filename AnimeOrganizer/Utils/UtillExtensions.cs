using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace AnimeOrganizer
{
    public static class UtillExtensions
     {
          private static List<string> badStrings = new List<string>()
          {
               "mp4", "mkv", "animepahe", "720p", "360p", "subsplease", "ttga",
               "netflix", "crunchyroll", "disney", "animechap", " ", ""
          };
        public static List<string> globalFolders = new List<string>
          {
               "movies and ova",
               "dump"
          };
        public static List<string> excludeFolders = new List<string>
          {
              "temp",
              "Done"
          };
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
               return badStrings.Contains(s.ToLower());
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
