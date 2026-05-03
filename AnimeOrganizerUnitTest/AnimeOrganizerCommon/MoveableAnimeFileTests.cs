using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnimeOrganizerCommon;

namespace AnimeOrganizerUnitTest.AnimeOrganizerCommon
{
    [TestClass]
    public class MoveableAnimeFileTests
    {
        [TestMethod]
        public void MoveableAnimeFile_SetTargetFolder()
        {
            MoveableAnimeFile file = new MoveableAnimeFile();
            AnimeFolder folder = new AnimeFolder();
            folder.Name = "Test Folder";

            file.TargetFolder = folder;

            Assert.AreEqual(folder, file.TargetFolder);
        }

        [TestMethod]
        public void MoveableAnimeFile_MarkAsPoint5Episode()
        {
            MoveableAnimeFile file = new MoveableAnimeFile();
            file.Name = "Attack on Titan";
            file.Episode = 5;
            file.Seperator = Seperator.dash;

            file.MarkAsPoint5Episode();

            Assert.IsTrue(file.IsPoint5Episode);
            Assert.AreEqual("Attack on Titan - 05.5", file.NewFileName);
        }

        [TestMethod]
        public void MoveableAnimeFile_UpdateEpisodeNumber_IncrementEpisode()
        {
            MoveableAnimeFile file = new MoveableAnimeFile();
            file.Name = "Test Anime";
            file.Episode = 5;
            file.Seperator = Seperator.dash;
            file.UpdateEpisodeNumber(3);

            Assert.AreEqual(8, file.Episode);
        }

        [TestMethod]
        public void MoveableAnimeFile_UpdateEpisodeNumber_DecrementEpisode()
        {
            MoveableAnimeFile file = new MoveableAnimeFile();
            file.Name = "Test Anime";
            file.Episode = 10;
            file.Seperator = Seperator.dash;
            file.UpdateEpisodeNumber(-2);

            Assert.AreEqual(8, file.Episode);
        }

        [TestMethod]
        public void MoveableAnimeFile_UpdateEpisodeNumber_UnmarksPoint5()
        {
            MoveableAnimeFile file = new MoveableAnimeFile();
            file.Name = "Test Anime";
            file.Episode = 5;
            file.Seperator = Seperator.dash;
            file.MarkAsPoint5Episode();

            Assert.IsTrue(file.IsPoint5Episode);

            file.UpdateEpisodeNumber(1);

            Assert.IsFalse(file.IsPoint5Episode);
            Assert.AreEqual(6, file.Episode);
        }
    }
}
