using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeOrganizerCommon
{
    public class MoveableAnimeFile : AnimeFile
    {
        public AnimeFolder TargetFolder { get; set; }
        public AnimeFile OriginalFile { get; set; }
        public string NewFileName { get
            {
                return UtillExtensions.GenerateFileName(Name, Episode, Seperator, IsPoint5Episode);
            }
        }
        public Seperator Seperator { get; set; }
        public bool IsPoint5Episode { get; set; }

        private string GetFileExtension()
        {
            return System.IO.Path.GetExtension(OriginalFile.Path);
        }

        private string GetNewFilePath()
        {
            return System.IO.Path.Combine(TargetFolder.Path, NewFileName + GetFileExtension());
        }

        public void UpdateEpisodeNumber(int diff)
        {
            // get the episode number from the new file name, add the diff to it and update the new file name with the new episode number
            int episodeNumber = Episode;
            episodeNumber += diff;
            Episode = episodeNumber < 0 ? 0 : episodeNumber;
            if (IsPoint5Episode) 
                UnmarkAsPoint5Episode();
        }

        public void MarkAsPoint5Episode()
        {
            IsPoint5Episode = true;
        }

        private void UnmarkAsPoint5Episode()
        {
            IsPoint5Episode = false;
        }

        public new string Path
        {
            get { return GetNewFilePath(); }
        }

        public void MoveFile()
        {
            TargetFolder.InitializeFolder();
            System.IO.File.Move(OriginalFile.Path, Path);
        }
        // Overload to move file to a specific destination path
        public void MoveFile(string destinationPath)
        {
            System.IO.File.Move(OriginalFile.Path, destinationPath);
        }

    }
}
