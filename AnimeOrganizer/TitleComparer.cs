using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeOrganizer
{
     [Serializable]
     public class TitleComparer : IEqualityComparer<string>
     {
          public bool Equals(string x, string y)
          {
               if (x.Length == y.Length)
               {
                    for (int i = 0; i < x.Length; i++)
                    {
                         if (x[i] != y[i])
                         {
                              return false;
                         }
                    }
                    return true;
               }
               else
               {
                    return false;
               }
          }

          public int GetHashCode(string obj)
          {
               return obj.GetHashCode();
          }
     }
}
