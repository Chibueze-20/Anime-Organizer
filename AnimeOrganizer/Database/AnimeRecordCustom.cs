using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeOrganizer.Database
{
    public partial class AnimeRecord
    {
        public AnimeRecord()
        {
            title = null;
            numberOfEpisodes = 0;
            lastUpdate = DateTime.Now;
        }
        public AnimeRecord(string title, int episodes)
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
            if (values[5] != "")
            {
                record.Year = Convert.ToInt32(values[5]);
            }
            record.Description = Convert.ToString(values[1]);
            if (values[2] != "")
            {
                record.Rating = Convert.ToInt32(values[2]);
            }
            return record;
        }
        public static AnimeRecord Clone(AnimeRecord currentRecord, string newTitle)
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
                else
                {
                    return description;
                }
            }
            set { description = value; }
        }
        public int Year
        {
            get
            {
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
