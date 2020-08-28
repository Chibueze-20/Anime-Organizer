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
     public struct AnimeFile
     {
          private string title;
          private Seperator seprator;
          private int episode;
          public string Title
          {
               set
               {
                    title = value;
               }
               get
               {
                    return title == null ? "" : title;
               }
          }
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
          public Seperator EpisodeSeperator
          {
               get
               {
                    return seprator;
               }
               set
               {
                    seprator = value;
               }
          }
          private string seperate()
          {
               switch (seprator)
               {
                    case Seperator.dash:
                         return "- " + (episode >= 10 ? episode + "" : "0" + episode);
                    case Seperator.episode:
                         return "Episode " + episode;
                    default:
                         return "Episode " + episode;
               }
          }
          public override string ToString()
          {
               return title + " " + seperate();
          }
     }
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
