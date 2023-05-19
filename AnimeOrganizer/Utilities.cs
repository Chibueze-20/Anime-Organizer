using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Forms;

namespace AnimeOrganizer
{
     public enum OpenMode
     {
          Folder,
          Files
     }
     public static class UtillExtensions
     {
          private static List<string> badStrings = new List<string>()
          {
               "mp4", "mkv", "animepahe", "720p", "360p", "subsplease", "ttga",
               "netflix", "crunchyroll", "disney", "animechap", " ", ""
          };
        public static List<string> globalFolders = new List<string>
          {
               "movies and ova"
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
     }
     public abstract class BaseAnimeDirectory
     {
          private string name;
          private string path;
          private int weight = int.MinValue;
          public int Weight
          {
               get { return weight; }
               set { weight = value; }
          }
          public string Name
          {
               set { name = value; }
               get { return name; }
          }
          public string Path
          {
               get { return path; }
               set { path = value; }
          }
          public static bool operator > (BaseAnimeDirectory a, BaseAnimeDirectory b) { 
               if(a == null) return false;
               if(b == null) return true;
               return a.Weight > b.Weight;
          }

          public static bool operator < (BaseAnimeDirectory a, BaseAnimeDirectory b)
          {
               if (a == null) return true;
               if (b == null) return false;
               return a.Weight < b.Weight;
          }
          public virtual HashSet<string> SearchSet
          {
               get
               {
                    string[] set = name.Split('_', '-', ':', ';', '.');
                    HashSet<string> searchSet = new HashSet<string>();
                    foreach (string s in set)
                    {
                         if (!UtillExtensions.IsNumeric(s) && ! UtillExtensions.IsRedundantString(s))
                         {
                              searchSet.Add(s.Trim());
                         }
                    }
                    return searchSet;
               }
          }
          override
          public string ToString()
          {
               return name;
          }
     }
     public class AnimeFile: BaseAnimeDirectory
     {
          private int episode;
          
          public int Episode
          {
               set
               {
                    episode = value;
               }
               get
               {
                    return episode;
               }
          }
     }
     public class AnimeFolder: BaseAnimeDirectory { 
    
        override
        public HashSet<string> SearchSet
        {
            get
            {
                string[] set = Name.Split('_', '-', ':', ';', '.',' ');
                HashSet<string> searchSet = new HashSet<string>();
                foreach (string s in set)
                {
                    if (!UtillExtensions.IsNumeric(s) && !UtillExtensions.IsRedundantString(s))
                    {
                        searchSet.Add(s.Trim());
                    }
                }
                return searchSet;
            }
        }
    }
     public enum Seperator
     {
          dash,
          episode,
          none
     }
     
     public partial class AnimeRecord
     {
            public AnimeRecord()
        {
            title = null;
            numberOfEpisodes =0;
            lastUpdate = DateTime.Now;
        }
          public AnimeRecord(string title,int episodes)
          {
               this.title = title;
               this.numberOfEpisodes = episodes;
            this.lastUpdate = DateTime.Now;
          }
          public static AnimeRecord FromCsv(string csvLine)
          {
            //Title,Description,Rating,Episode Count,Season,Year,Last Updated
                string[] values = csvLine.Split(',');
               AnimeRecord record = new AnimeRecord(Convert.ToString(values[0]), Convert.ToInt32(values[3]));
               record.Season = Convert.ToString(values[4]);
               if (values[5]!="")
               {
                    record.Year = Convert.ToInt32(values[5]);
               }
               record.Description = Convert.ToString(values[1]);
            if (values[2]!="")
            {
                record.Rating = Convert.ToInt32(values[2]);
            }
               return record;
          }
          public static AnimeRecord Clone(AnimeRecord currentRecord,string newTitle)
          {
               AnimeRecord rec = new AnimeRecord(newTitle, currentRecord.numberOfEpisodes);
               rec.Description = currentRecord.Description;
               rec.Rating = currentRecord.Rating;
               rec.Season = currentRecord.Season;
               rec.Year = currentRecord.Year;
               return rec;
          }
       
          public int Rating { get { return rating.GetValueOrDefault(0); } set { rating = value; } }
          public string Description
          {
               get
               {
                    if (description == "")
                    {
                         return "No description provided";
                    }
                    else {
                         return description;
                    }
               }
               set { description = value; }
          }
          public int Year
          {
               get {
                if (year.HasValue)
                {
                    return year.Value;
                }
                return 0;
            }
               set
               {
                    if (value < 1917)
                    {
                         year = null;
                    }
                    else
                    {
                    year = value;
                    }
               }
          }
          public string Season
          {
               get { return season; }
               set
               {

                    if (("winter,spring,summer,fall".Split(',')).Contains(value.ToLower()))
                    {
                         season = value.ToLower();
                    }
                    else
                    {
                         season = "unknown";
                    }
               }
          }
        public override string ToString()
        {
            string value = "";
            value += "[Title]: " + title;
            value += ";[Episode Count]: " + numberOfEpisodes;
            value += ";[Rating]: " + Rating;
            value += ";[Description]: " + UtillExtensions.ShortenString32(Description);
            value += ";[Season]: " + Season;
            value += ";[Year]: " + Year;
            value += ";[Updated]: " + lastUpdate;

            return value;
        }
    }
}
