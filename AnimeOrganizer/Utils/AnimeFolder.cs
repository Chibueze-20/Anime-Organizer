using System.Collections.Generic;
using System.IO;

namespace AnimeOrganizer
{
    public class AnimeFolder : BaseAnimeDirectory
    {


        override
        public HashSet<string> SearchSet
        {
            get
            {
                string[] set = Name.Split('_', '-', ':', ';', '.', ' ');
                HashSet<string> searchSet = new HashSet<string>();
                foreach (string s in set)
                {
                    if (!UtillExtensions.IsNumeric(s) && !UtillExtensions.IsRedundantString(s))
                    {
                        searchSet.Add(s.Trim());
                    }
                }
                return searchSet;
            }
        }
    }
}
