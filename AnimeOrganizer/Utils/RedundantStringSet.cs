using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace AnimeOrganizer
{
    [Serializable]
    [XmlRoot("RedundantStringSet")]
    public class RedundantStringSet
    {
        private const string FileName = "redundant_strings.xml";

        // backing set with case-insensitive comparison
        private HashSet<string> set;

        public RedundantStringSet()
        {
            set = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        }

        [XmlArray("Items")]
        [XmlArrayItem("Item")]
        public List<string> Items
        {
            get { return set.ToList(); }
            set { set = new HashSet<string>(value ?? new List<string>(), StringComparer.OrdinalIgnoreCase); }
        }

        public bool Contains(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return false;
            return set.Contains(s.Trim());
        }

        public bool Add(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return false;
            var t = s.Trim();
            if (set.Contains(t)) return false;
            set.Add(t);
            return true;
        }

        public bool Remove(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return false;
            return set.Remove(s.Trim());
        }

        public void SaveToDefaultLocation()
        {
            var path = GetDefaultPath();
            try
            {
                var dir = Path.GetDirectoryName(path);
                if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
                using (var fs = File.Open(path, FileMode.Create, FileAccess.Write))
                {
                    var ser = new XmlSerializer(typeof(RedundantStringSet));
                    ser.Serialize(fs, this);
                }
            }
            catch (Exception ex)
            {
                {
                    // ignore IO errors for now
                    Console.WriteLine("Failed to write to serialised file, path: " + path +
                        "Exception Message: " + ex.Message);
                }
            }
        }

        public static RedundantStringSet LoadFromDefaultLocation()
        {
            var path = GetDefaultPath();
            if (File.Exists(path))
            {
                try
                {
                    using (var fs = File.OpenRead(path))
                    {
                        var ser = new XmlSerializer(typeof(RedundantStringSet));
                        var obj = ser.Deserialize(fs) as RedundantStringSet;
                        if (obj != null) return obj;
                    }
                }
                catch
                {
                    // fall through to return defaults
                }
            }

            var def = new RedundantStringSet();
            var defaults = new[]
            {
                "mp4", "mkv", "animepahe", "720p", "360p", "subsplease", "ttga",
                "netflix", "crunchyroll", "disney", "animechap", "1080p",
                "720p","amazon","bd","pog42","max","hbo","plus","erai","raws"
            };
            foreach (var d in defaults)
            {
                def.Add(d);
            }

            // Persist the seeded defaults so the file exists for subsequent runs
            def.SaveToDefaultLocation();

            return def;
        }

        private static string GetDefaultPath()
        {
            var appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var dir = Path.Combine(appData, "AnimeOrganizer");
            return Path.Combine(dir, FileName);
        }
    }
}
