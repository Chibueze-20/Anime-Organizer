using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AnimeOrganizerDataObjects;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Data.Entity;

namespace AnimeOrganizerDataObjects
{
     public class AnimeDB: IAnimeDB
     {
        private AnimeDatabaseEntities animeDatabase;
        private AnimeRecord defaultRecord = new AnimeRecord();
        private DatabaseRecoveryManager recoveryManager = new DatabaseRecoveryManager();

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
            // Attempt to recover from previous crash
            var recoveredOperations = recoveryManager.LoadRecoveryFile();
            if (recoveredOperations != null && recoveredOperations.Count > 0)
            {
                CompleteRecoveredOperations(recoveredOperations);
            }

            // Load the database to warm up the connection and cache
            animeDatabase.AnimeRecords.FirstOrDefault();
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
            if (!animeDatabase.ChangeTracker.HasChanges()) return;

            try
            {
                // Capture pending operations before attempting to save
                var operations = recoveryManager.CapturePendingOperations(animeDatabase.ChangeTracker);
                animeDatabase.SaveChanges();

                // Clear recovery file on successful save
                recoveryManager.ClearRecoveryFile();
            }
            catch (Exception ex)
            {
                // save changed entities to a file for debugging and recovery
                var operations = recoveryManager.CapturePendingOperations(animeDatabase.ChangeTracker);
                recoveryManager.SaveRecoveryFile(operations);
                throw ex;
            }
          }

        private void CompleteRecoveredOperations(List<RecoveryOperation> operations)
        {
            try
            {
                // Complete pending operations
                foreach (var operation in operations)
                {
                    switch (operation.OperationType)
                    {
                        case "Create":
                            Create(operation.Record);
                            break;
                        case "Update":
                            Update(operation.Record, isSoftUpdate: false);
                            break;
                        case "Delete":
                            Delete(operation.Record);
                            break;
                    }
                }

                // Attempt to save recovered operations
                try
                {
                    animeDatabase.SaveChanges();
                    recoveryManager.ClearRecoveryFile();
                    System.Diagnostics.Debug.WriteLine("Database recovery completed successfully.");
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Failed to save recovered operations: {ex.Message}");
                    // Keep recovery file for next attempt
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error during recovery: {ex.Message}");
            }
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
