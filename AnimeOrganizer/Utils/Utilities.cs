﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Forms;
using AnimeOrganizer.Database;
using System.IO;

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
        
        public DirectoryInfo DirectoryInfo { get; set; }
    
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

     
     

    public readonly struct Statistic
    {
        private readonly int total;
        private readonly int tens;
        private readonly int lows;
        private readonly int rated;
        private readonly int sum; //sum of all ratings >0

        public Statistic(int total, int tens, int lows, int rated, int sum)
        {
            this.total = total;
            this.tens = tens;
            this.lows = lows;
            this.rated = rated;
            this.sum = sum;
        }

        public int Mids()
        {
            return total - (tens + lows);
        }
        public int Unrated() {
            return total - rated;
        }

        public double AverageRating()
        {
            return (double)sum / rated;
        }
        public override string ToString()
        {
            string format_message = "Total Anime Organized:{0}\nNumber of Anime Rated:{1}\n" +
               "Number of Anime rated 10:{2}\nNumber of Anime rated below 6:{3}\n" +
               "Number of Anime rated between 6 and 9: {4}\nNumber of Anime unrated:{5}\n" +
               "Average Anime Rating:{6:N1}";
            string message = string.Format(format_message, total, rated, 
                tens, lows,Mids(), Unrated(), AverageRating());
            return message;
        }
    }
}
