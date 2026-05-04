using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Xml.Serialization;

namespace AnimeOrganizerCommon
{
    [Serializable]
    [XmlRoot("MutableDefaultStringSet")]
    public class MutableDefaultStringSet
    {
        // serialized user-added items
        [XmlArray("UserAdded")]
        [XmlArrayItem("Item")]
        public List<string> UserAdded
        {
            get { return userAdded.ToList(); }
            set { userAdded = new HashSet<string>(value ?? new List<string>(), comparer ?? StringComparer.Ordinal); }
        }

        [XmlIgnore]
        public List<string> Defaults { get; private set; }

        [XmlIgnore]
        private HashSet<string> userAdded;

        [XmlIgnore]
        private string fileName;

        [XmlIgnore]
        private StringComparer comparer;

        public MutableDefaultStringSet()
        {
            // parameterless for xml serializer
            comparer = StringComparer.Ordinal; // default
            userAdded = new HashSet<string>(comparer);
            Defaults = new List<string>();
            fileName = "";
        }

        public MutableDefaultStringSet(IEnumerable<string> defaults, string fileName, StringComparer comparer = null) : this()
        {
            this.comparer = comparer ?? StringComparer.Ordinal;
            userAdded = new HashSet<string>(this.comparer);
            Defaults = defaults?.ToList() ?? new List<string>();
            this.fileName = fileName ?? string.Empty;
        }

        public IEnumerable<string> Items => Defaults.Concat(userAdded).Distinct(comparer ?? StringComparer.Ordinal);

        public bool ItemIsUserAddedAndEqualToInput(string item, string input)
        {
            // check if item and input are non-empty
            if (string.IsNullOrWhiteSpace(item) || string.IsNullOrWhiteSpace(input)) return false;
            // check if item is a valid item in the set
            if (!Items.Any(i => (comparer ?? StringComparer.Ordinal).Equals(i, item))) return false;
            // check if item is in userAdded
            bool isUserAdded = userAdded.Any(i => (comparer ?? StringComparer.Ordinal).Equals(i, item));
            //if item is user-added, check if it equals input
            if (isUserAdded)
            {
                return (comparer ?? StringComparer.Ordinal).Equals(item, input.Trim());
            }
            return false;

        }

        public bool IsDefault(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return false;
            var t = s.Trim();
            var comp = comparer ?? StringComparer.Ordinal;
            return Defaults.Any(d => comp.Equals(d, t));
        }

        public bool Contains(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return false;
            var t = s.Trim();
            var comp = comparer ?? StringComparer.Ordinal;
            return Defaults.Any(d => comp.Equals(d, t)) || userAdded.Contains(t);
        }

        // add only allowed if not in defaults
        public bool Add(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return false;
            var t = s.Trim();
            var comp = comparer ?? StringComparer.Ordinal;
            if (Defaults.Any(d => comp.Equals(d, t))) return false;
            if (userAdded.Contains(t)) return false;
            userAdded.Add(t);
            return true;
        }

        // remove only allowed from userAdded
        public bool Remove(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return false;
            var t = s.Trim();
            return userAdded.Remove(t);
        }

        public void SaveToDefaultLocation()
        {
            if (string.IsNullOrEmpty(fileName)) return;
            var path = GetDefaultPath(fileName);
            try
            {
                var dir = Path.GetDirectoryName(path);
                if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
                using (var fs = File.Open(path, FileMode.Create, FileAccess.Write))
                {
                    var ser = new XmlSerializer(typeof(MutableDefaultStringSet));
                    ser.Serialize(fs, this);
                }
            }
            catch
            {
                // ignore IO errors
            }
        }

        public static MutableDefaultStringSet LoadFromDefaultLocation(IEnumerable<string> defaults, string fileName, StringComparer comparer = null)
        {
            var path = GetDefaultPath(fileName);
            if (File.Exists(path))
            {
                try
                {
                    using (var fs = File.OpenRead(path))
                    {
                        var ser = new XmlSerializer(typeof(MutableDefaultStringSet));
                        var obj = ser.Deserialize(fs) as MutableDefaultStringSet;
                        if (obj != null)
                        {
                            obj.fileName = fileName;
                            // set comparer (default if null)
                            obj.comparer = comparer ?? StringComparer.Ordinal;
                            // ensure defaults are set and userAdded initialized using the chosen comparer
                            obj.Defaults = defaults?.ToList() ?? new List<string>();
                            var existingUserAdded = obj.userAdded != null ? obj.userAdded.ToList() : new List<string>();
                            obj.userAdded = new HashSet<string>(existingUserAdded, obj.comparer);
                            return obj;
                        }
                    }
                }
                catch
                {
                    // fall through to create new
                }
            }

            var inst = new MutableDefaultStringSet(defaults, fileName, comparer);
            // persist an initial empty user-added list so file exists
            try
            {
                inst.SaveToDefaultLocation();
            }
            catch
            {
                // ignore
            }
            return inst;
        }

        private static string GetDefaultPath(string fileName)
        {
            string baseAppData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "AnimeOrganizer");
#if DEBUG
            if (Debugger.IsAttached)
            {
                baseAppData = Path.Combine(baseAppData, "Debug");
                // Create the debug subfolder if it doesn't exist
                if (!Directory.Exists(baseAppData))
                {
                    Directory.CreateDirectory(baseAppData);
                }
            }
#endif
            return Path.Combine(baseAppData, fileName);

        }
    }
}
