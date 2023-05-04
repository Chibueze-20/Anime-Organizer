using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace AnimeOrganizer
{
     [Serializable]
     public class AnimeDB: IEnumerable<string>
     {
          private Dictionary<string, AnimeRecord> db;
          private static IFormatter serializerFormatter = new BinaryFormatter();
          public static AnimeDB Deserialize()
          {
               Stream dbFileStream = null;
               try
               {
                    dbFileStream = new FileStream("database.ani", FileMode.Open, FileAccess.Read, FileShare.Read);
                    return (AnimeDB)serializerFormatter.Deserialize(dbFileStream);
                   
               }
               catch (Exception)
               {

                    return new AnimeDB();
               }
               finally
               {
                    if (dbFileStream != null)
                    {
                         dbFileStream.Close();
                    }
               }
          }
          public void Serialize()
          {
               Stream dbFileStream = new FileStream("database.ani", FileMode.Create, FileAccess.Write, FileShare.None);
               serializerFormatter.Serialize(dbFileStream, this);
               dbFileStream.Close();
          }

          public AnimeDB()
          {
               db = new Dictionary<string, AnimeRecord>();
          }
          
          public AnimeRecord this[string title]
          {
               get {
                    return db[title];
               }
          }
          public bool Contains(string title)
          {
               return db.ContainsKey(title);
          }
          public IList<string> Titles()
          {
               return db.Keys.ToList();
          }
          public void Update(AnimeRecord record)
          {
               record.LastUpdated = DateTime.Now;
               if (db.Keys.Contains(record.Title))
               {
                    db[record.Title] = record;
               }
               else
               {
                    db.Add(record.Title, record);
               }
          }
          public void Delete(AnimeRecord record)
          {
               db.Remove(record.Title);
          }

          public IEnumerator<string> GetEnumerator()
          {
               return db.Keys.GetEnumerator();
          }

          IEnumerator IEnumerable.GetEnumerator()
          {
               return db.Keys.GetEnumerator();
          }
     }
}
