using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core.Objects.DataClasses;

namespace AnimeOrganizer
{
     
     public class AnimeDB: IEnumerable<string>
     {
        private AnimeDatabaseEntities animeDatabase;
        private AnimeRecord defaultRecord = new AnimeRecord();

          public AnimeDB()
          {
            animeDatabase = new AnimeDatabaseEntities();
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
               return Sort();
          }
          public void Create(AnimeRecord record)
        {
            animeDatabase.AnimeRecords.Add(record);
            animeDatabase.SaveChanges();
        }
          public void Update(AnimeRecord record)
          {
               if (Contains(record.title))
               {
                AnimeRecord animeRecord = this[record.title];
                animeRecord.lastUpdate = DateTime.Now;
                animeRecord.numberOfEpisodes = record.numberOfEpisodes;
                animeRecord.Description = record.Description;
                animeRecord.Year = record.Year;
                animeRecord.Rating = record.Rating;
                animeRecord.Season = record.Season;
                animeDatabase.Entry(animeRecord).State = System.Data.Entity.EntityState.Modified;
               }
               else
               {
                    animeDatabase.AnimeRecords.Add(record);
               }
               animeDatabase.SaveChanges();
          }
          public void Delete(AnimeRecord record)
          {
               if (Contains(record.title)) {
                AnimeRecord animeRecord = this[record.title];
                animeDatabase.AnimeRecords.Remove(animeRecord);
                animeDatabase.SaveChanges();
            }
          }
          private IList<string> Sort()
        {
            IQueryable<string> values = from AnimeRecord in animeDatabase.AnimeRecords 
                                   orderby AnimeRecord.title ascending
                                   select AnimeRecord.title;
            return values.ToList();
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
