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
               rating = 0;
               description = "";
               lastUpdate = DateTime.Now;
               year = null;
               season = "unknown";
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
