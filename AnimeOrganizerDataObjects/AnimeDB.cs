using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AnimeOrganizerDataObjects;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core.Objects.DataClasses;

namespace AnimeOrganizerDataObjects
{
     
     public class AnimeDB: IAnimeDB
     {
        private AnimeDatabaseEntities animeDatabase;
        private AnimeRecord defaultRecord = new AnimeRecord();

          public AnimeDB()
          {
            animeDatabase = new AnimeDatabaseEntities();
          }

          public static AnimeOrganizerCommon.Statistic GetStatistic()
          {
            // TODO: Use DI
            AnimeDatabaseEntities db = new AnimeDatabaseEntities();
            int total = db.AnimeRecords.Count();
            int tens = db.AnimeRecords.Count((rec)=>rec.rating.HasValue && rec.rating>=10);
            int lows = db.AnimeRecords.Count((rec)=>rec.rating.HasValue&&rec.rating<=5);
            int rated = db.AnimeRecords.Count((rec) => rec.rating.HasValue);
            int sum = (int)db.AnimeRecords.Where((rec)=>rec.rating.HasValue).Sum((rec) => rec.rating);
            return new AnimeOrganizerCommon.Statistic(total, tens, lows, rated, sum);
          }

          public void Warmup()
          {
            Sort().Any();
          }
          
          public AnimeRecord this[string title]
          {
               get {
                var query = animeDatabase.AnimeRecords.Where(x => x.title == title);
                bool found = query.Any();
                if (found)
                {
                    return query.FirstOrDefault();
                } else {
                    return defaultRecord;
                }
               }
          }
          public bool Contains(string title)
          {
               return this[title].title != null;
          }
          public IList<string> Titles()
          {
               return Sort().ToList();
          }
          public void Create(AnimeRecord record)
        {
            animeDatabase.AnimeRecords.Add(record);
            animeDatabase.Entry(record).State = System.Data.Entity.EntityState.Added;
        }
        
          public void Update(AnimeRecord record, bool isSoftUpdate = true)
          {
            AnimeRecord animeRecord = this[record.title];
            animeRecord.lastUpdate = DateTime.Now;
            animeRecord.numberOfEpisodes = record.numberOfEpisodes;
            animeRecord.description = record.description;
            animeRecord.SafeSetYear(record.year);
            animeRecord.rating = record.rating;
            animeRecord.SafeSetSeason(record.season);
            animeDatabase.Entry(animeRecord).State = System.Data.Entity.EntityState.Modified;
            if (!isSoftUpdate)
            {
                animeDatabase.SaveChanges();
            }
        }
          public void Delete(AnimeRecord record)
          {
               if (Contains(record.title)) {
                AnimeRecord animeRecord = this[record.title];
                animeDatabase.AnimeRecords.Remove(animeRecord);
            }
          }
        public void Save()
        {
            animeDatabase.SaveChanges();
        }
        private IQueryable<string> Sort()
        {
            IQueryable<string> values = from AnimeRecord in animeDatabase.AnimeRecords 
                                   orderby AnimeRecord.title ascending
                                   select AnimeRecord.title;
            return values;
        }
          public IEnumerator<string> GetEnumerator()
          {
               return Sort().GetEnumerator();
          }

          IEnumerator IEnumerable.GetEnumerator()
          {
               return Sort().GetEnumerator();
          }
          
     }
}
