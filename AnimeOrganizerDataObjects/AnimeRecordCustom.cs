using AnimeOrganizerCommon;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeOrganizerDataObjects
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
            this.description = title;
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

        public static bool IsEmpty(AnimeRecord record)
        {
            if (record == null) return true;
            return record.title == null;
        }

        protected int Rating { get { return rating.GetValueOrDefault(0); } set { rating = value; } }
        protected string Description
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
        protected int Year
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
        public void SafeSetYear(int? value)
        {
            if (!value.HasValue)
            {
                year = null;
                return;
            }
            if (value < 1917)
            {
                year = null;
            }
            else
            {
                year = value;
            }
        }
        protected string Season
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
        public void SafeSetSeason(string value)
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

        public override int GetHashCode()
        {
            return title.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is AnimeRecord)
            {
                AnimeRecord other = (AnimeRecord)obj;
                return this.title.Equals(other.title);
            }
            return false;
        }
    }
}
