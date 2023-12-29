using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeOrganizer.Database
{
    public interface IAnimeDB: IEnumerable<string>
    {
        bool Contains(string title);
        IList<string> Titles();
        void Create(AnimeRecord record);
        void Update(AnimeRecord record);
        void Delete(AnimeRecord record);
        void Save();


    }
}
