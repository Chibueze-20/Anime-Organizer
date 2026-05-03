using System.Collections.Generic;
using System.IO;

namespace AnimeOrganizerCommon
{
    public class AnimeFolder : BaseAnimeDirectory
    {

        private List<MoveableAnimeFile> _proposedFiles;

        public int FileCount
        {
            get
            {
                if (!Directory.Exists(Path))
                {
                    return 0;
                }
                // Get only video files in the top directory, not in subdirectories and count them
                string[] files = Directory.GetFiles(Path);
                int count = 0;
                foreach (string file in files)
                {
                    string extension = System.IO.Path.GetExtension(file).ToLower();
                    if (UtillExtensions.videoExtensions.Contains(extension))
                    {
                        count++;
                    }
                }
                return count;

            }
        }

        public void InitializeFolder()
        {
            //create directory if it does not exist
            if (!Directory.Exists(Path))
            {
                Directory.CreateDirectory(Path);
            }
        }

        // Methods for managing proposed files
        public void AddProposedFile(MoveableAnimeFile file)
        {
            if (_proposedFiles == null)
            {
                _proposedFiles = new List<MoveableAnimeFile>();
            }
            _proposedFiles.Add(file);
        }

        public void RemoveProposedFileByIndex(int index)
        {
            if (_proposedFiles != null && index >= 0 && index < _proposedFiles.Count)
            {
                _proposedFiles.RemoveAt(index);
            }
        }

        public int ProposedFileCount
        {
            get
            {
                return _proposedFiles != null ? _proposedFiles.Count : 0;
            }
        }

        public MoveableAnimeFile GetProposedFileByIndex(int index)
        {
            if (_proposedFiles != null && index >= 0 && index < _proposedFiles.Count)
            {
                return _proposedFiles[index];
            }
            return null;
        }

        public void SwapProposedFiles(int index1, int index2)
        {
            if (_proposedFiles != null && index1 >= 0 && index1 < _proposedFiles.Count && index2 >= 0 && index2 < _proposedFiles.Count)
            {
                MoveableAnimeFile temp = _proposedFiles[index1];
                _proposedFiles[index1] = _proposedFiles[index2];
                _proposedFiles[index2] = temp;
            }
        }

        // Methods for managing proposed files end

        override
        public List<string> SearchSet
        {
            get
            {
                string[] set = Name.Split('_', '-', ':', ';', '.', ' ');
                List<string> searchSet = new List<string>();
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

        // override object.Equals
        public override bool Equals(object obj)
        {
            //       
            // See the full list of guidelines at
            //   http://go.microsoft.com/fwlink/?LinkID=85237  
            // and also the guidance for operator== at
            //   http://go.microsoft.com/fwlink/?LinkId=85238
            //

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            // TODO: write your implementation of Equals() here
            bool isEqual = Path == ((AnimeFolder)obj).Path;
            // return true only when isEqual is true
            return isEqual;
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            // Same hash code when Path is the same, otherwise different hash code
            return Path.GetHashCode();
        }
    }
}
