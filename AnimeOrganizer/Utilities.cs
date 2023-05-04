using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
               "netflix", "crunchyroll", "disney", "animechap"
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
          public HashSet<string> SearchSet
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
     public class AnimeFolder: BaseAnimeDirectory { }
     public enum Seperator
     {
          dash,
          episode,
          none
     }
     [Serializable]
     public struct AnimeRecord
     {
          private string title;
          private int numberOfEpisodes;
          private int rating;
          private string description;
          private DateTime lastUpdate;
          private int? year; //1917 above
          private string season;

          public AnimeRecord(string title,int episodes)
          {
               this.title = title;
               numberOfEpisodes = episodes;
               rating = 1;
               description = "";
               lastUpdate = DateTime.Now;
               year = null;
               season = "unknown";
          }
          public static AnimeRecord FromCsv(string csvLine)
          {
               //Title,Episodes Downloaded,Season,Description,Rating
               string[] values = csvLine.Split(',');
               AnimeRecord record = new AnimeRecord(Convert.ToString(values[0]), Convert.ToInt32(values[1]));
               record.Season = Convert.ToString(values[2].Split(' ')[0]);
               if (values[2].Split(' ')[1]!="")
               {
                    record.Year = Convert.ToInt32(values[2].Split(' ')[1]);
               }
               record.Description = Convert.ToString(values[3]);
               record.Rating = Convert.ToInt32(values[4]);
               return record;
          }
          public static AnimeRecord Clone(AnimeRecord currentRecord,string newTitle)
          {
               AnimeRecord rec = new AnimeRecord(newTitle, currentRecord.EpisodeCount);
               rec.Description = currentRecord.Description;
               rec.Rating = currentRecord.Rating;
               rec.Season = currentRecord.Season;
               rec.Year = currentRecord.Year;
               return rec;
          }
          public string Title { get { return title; }}
          public int EpisodeCount { get { return numberOfEpisodes; } set { numberOfEpisodes = value; } }
          public int Rating { get { return rating; } set { rating = value; } }
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
          public DateTime LastUpdated {get { return lastUpdate; } set { lastUpdate = value; } }
          public int? Year
          {
               get { return year; }
               set
               {
                    if (!value.HasValue)
                    {
                         year = null;
                         return;
                    }
                    if (value.Value < 1917)
                    {
                         year = null;
                    }
                    else
                    {
                         year = value.Value;
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
     }
}
