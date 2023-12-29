using System.Collections.Generic;

namespace AnimeOrganizer
{
    public abstract class BaseAnimeDirectory
     {
          private string name;
          private string path;
          private int weight = int.MinValue;
          public int Weight
          {
               get { return weight; }
               set { weight = value; }
          }
          public string Name
          {
               set { name = value; }
               get { return name; }
          }
          public string Path
          {
               get { return path; }
               set { path = value; }
          }
          public static bool operator > (BaseAnimeDirectory a, BaseAnimeDirectory b) { 
               if(a == null) return false;
               if(b == null) return true;
               return a.Weight > b.Weight;
          }

          public static bool operator < (BaseAnimeDirectory a, BaseAnimeDirectory b)
          {
               if (a == null) return true;
               if (b == null) return false;
               return a.Weight < b.Weight;
          }
          public virtual HashSet<string> SearchSet
          {
               get
               {
                    string[] set = name.Split('_', '-', ':', ';', '.');
                    HashSet<string> searchSet = new HashSet<string>();
                    foreach (string s in set)
                    {
                         if (!UtillExtensions.IsNumeric(s) && ! UtillExtensions.IsRedundantString(s))
                         {
                              searchSet.Add(s.Trim());
                         }
                    }
                    return searchSet;
               }
          }
          override
          public string ToString()
          {
               return name;
          }
     }
}
