namespace AnimeOrganizer
{
    public class AnimeFile: BaseAnimeDirectory
     {
          private int episode;
          
          public int Episode
          {
               set
               {
                    episode = value;
               }
               get
               {
                    return episode;
               }
          }
     }
}
