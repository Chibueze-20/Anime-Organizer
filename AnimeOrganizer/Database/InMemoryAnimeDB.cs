using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;

namespace AnimeOrganizer.Database
{
    // Debug-friendly in-memory implementation of IAnimeDB used when running under debugger.
    public class InMemoryAnimeDB : IAnimeDB
    {
        private readonly List<AnimeRecord> records = new List<AnimeRecord>();
        private readonly AnimeRecord defaultRecord = new AnimeRecord();

        private const string SeedFileName = "inmemory_db_seed.xml";
        private readonly string seedFilePath;

        public InMemoryAnimeDB()
        {
            seedFilePath = GetSeedFilePath();
            // Try load from seed file first
            if (!string.IsNullOrEmpty(seedFilePath) && File.Exists(seedFilePath))
            {
                try
                {
                    LoadFromFile(seedFilePath);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Failed to load InMemoryAnimeDB seed file: " + ex.Message);
                }
            }

            // If still empty, try seeding from the real DB (non-invasive read)
            if (!records.Any())
            {
                try
                {
                    var realDb = new AnimeDB();
                    foreach (var title in realDb)
                    {
                        var r = realDb[title];
                        if (r != null && r.title != null)
                        {
                            records.Add(CloneRecord(r));
                        }
                    }

                    // persist seed so subsequent debug runs reuse this file
                    if (records.Any())
                    {
                        try
                        {
                            SaveToFile(seedFilePath);
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine("Failed to save InMemoryAnimeDB seed file: " + ex.Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Failed to seed InMemoryAnimeDB from real DB: " + ex.Message);
                }
            }
        }

        public void Warmup()
        {
            // Ensure lazy operations run
            records.Any();
        }

        public AnimeRecord this[string title]
        {
            get
            {
                var rec = records.FirstOrDefault(r => r.title == title);
                return rec ?? defaultRecord;
            }
        }

        public bool Contains(string title)
        {
            return this[title].title != null;
        }

        public IList<string> Titles()
        {
            return records.OrderBy(r => r.title ?? string.Empty).Select(r => r.title ?? string.Empty).ToList();
        }

        public void Create(AnimeRecord record)
        {
            if (record == null) return;
            var copy = new AnimeRecord
            {
                title = record.title,
                numberOfEpisodes = record.numberOfEpisodes,
                Description = record.Description,
                Year = record.Year,
                Rating = record.Rating,
                Season = record.Season,
                lastUpdate = DateTime.Now
            };
            records.Add(copy);
        }

        public void Update(AnimeRecord record, bool isSoftUpdate = true)
        {
            if (record == null) return;
            var existing = records.FirstOrDefault(r => r.title == record.title);
            if (existing == null) return;
            existing.lastUpdate = DateTime.Now;
            existing.numberOfEpisodes = record.numberOfEpisodes;
            existing.Description = record.Description;
            existing.Year = record.Year;
            existing.Rating = record.Rating;
            existing.Season = record.Season;
        }

        public void Delete(AnimeRecord record)
        {
            if (record == null) return;
            var existing = records.FirstOrDefault(r => r.title == record.title);
            if (existing != null) records.Remove(existing);
        }

        public void Save()
        {
            try
            {
                if (!string.IsNullOrEmpty(seedFilePath))
                {
                    SaveToFile(seedFilePath);
                }
                Debug.WriteLine("InMemoryAnimeDB.Save() persisted to: " + seedFilePath);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("InMemoryAnimeDB.Save() failed: " + ex.Message);
            }
        }

        private IEnumerable<string> Sort()
        {
            return records.OrderBy(r => r.title ?? string.Empty).Select(r => r.title ?? string.Empty);
        }

        public IEnumerator<string> GetEnumerator()
        {
            return Sort().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Sort().GetEnumerator();
        }

        // --- Serialization helpers ---
        private void LoadFromFile(string path)
        {
            var ser = new XmlSerializer(typeof(List<SerializableAnimeRecord>));
            using (var fs = File.OpenRead(path))
            {
                var list = ser.Deserialize(fs) as List<SerializableAnimeRecord>;
                if (list != null)
                {
                    records.Clear();
                    foreach (var s in list)
                    {
                        records.Add(ToAnimeRecord(s));
                    }
                }
            }
        }

        private void SaveToFile(string path)
        {
            var ser = new XmlSerializer(typeof(List<SerializableAnimeRecord>));
            var list = records.Select(r => FromAnimeRecord(r)).ToList();
            var dir = Path.GetDirectoryName(path);
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
            using (var fs = File.Open(path, FileMode.Create, FileAccess.Write))
            {
                ser.Serialize(fs, list);
            }
        }

        private static AnimeRecord ToAnimeRecord(SerializableAnimeRecord s)
        {
            var r = new AnimeRecord();
            r.title = s.Title;
            r.numberOfEpisodes = s.NumberOfEpisodes;
            r.rating = s.Rating;
            r.description = s.Description;
            r.lastUpdate = s.LastUpdate;
            r.year = s.Year;
            r.season = s.Season;
            return r;
        }

        private static SerializableAnimeRecord FromAnimeRecord(AnimeRecord r)
        {
            return new SerializableAnimeRecord
            {
                Title = r.title,
                NumberOfEpisodes = r.numberOfEpisodes,
                Rating = r.rating,
                Description = r.description,
                LastUpdate = r.lastUpdate,
                Year = r.year,
                Season = r.season
            };
        }

        private static AnimeRecord CloneRecord(AnimeRecord r)
        {
            return new AnimeRecord
            {
                title = r.title,
                numberOfEpisodes = r.numberOfEpisodes,
                rating = r.rating,
                description = r.description,
                lastUpdate = r.lastUpdate,
                year = r.year,
                season = r.season
            };
        }

        private string GetSeedFilePath()
        {
            try
            {
                // Use the requested fixed path inside the project directory
                var projectDir = @"W:\Anime-Organizer\AnimeOrganizer";
                return Path.Combine(projectDir, SeedFileName);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("GetSeedFilePath failed: " + ex.Message);
            }

            // fallback to base directory
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, SeedFileName);
        }
    }

    [Serializable]
    public class SerializableAnimeRecord
    {
        public string Title { get; set; }
        public int NumberOfEpisodes { get; set; }
        public int? Rating { get; set; }
        public string Description { get; set; }
        public DateTimeOffset LastUpdate { get; set; }
        public int? Year { get; set; }
        public string Season { get; set; }
    }
}
