using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AnimeOrganizer
{
     [Serializable]
     public class DataStore
     {
          private ISet<string> ongoing;
          private ISet<string> plan;
          public DataStore()
          {
               ongoing = new HashSet<string>(new TitleComparer());
               plan = new HashSet<string>(new TitleComparer());
          }
          public void index(string path, bool rootPrefix)
          {
               DirectoryInfo directory = new DirectoryInfo(path);
               if (directory.Exists)
               {
                    if (directory.GetDirectories().Length == 0)
                    {

                         ongoing.Add(directory.Name);
                    }
                    else
                    {
                         foreach (DirectoryInfo item in directory.GetDirectories())
                         {
                              ongoing.Add(rootPrefix ? directory.Name + " " + item.Name : item.Name);
                         }
                    }
               }
          }
          public IList<string> Ongoing
          {
               get
               {
                    return ongoing.ToList();
               }
          }
          public IList<string> Planning
          {
               get
               {
                    return plan.ToList();
               }
          }


     }
}
