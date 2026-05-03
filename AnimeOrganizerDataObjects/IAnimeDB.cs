using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeOrganizerDataObjects
{
    public interface IAnimeDB: IEnumerable<string>
    {
        AnimeRecord this[string title] { get; }
        bool Contains(string title);
        IList<string> Titles();
        void Create(AnimeRecord record);
        void Update(AnimeRecord record, bool isSoftUpdate = true);
        void Delete(AnimeRecord record);
        void Save();
        void Warmup();


    }
}
