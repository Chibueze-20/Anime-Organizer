using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnimeOrganizerCommon;

namespace AnimeOrganizerUnitTest.AnimeOrganizerCommon
{
    [TestClass]
    public class AnimeFolderTests
    {
        [TestMethod]
        public void AnimeFolder_AddProposedFile()
        {
            AnimeFolder folder = new AnimeFolder();
            MoveableAnimeFile file = new MoveableAnimeFile();
            file.Name = "Test";

            folder.AddProposedFile(file);

            Assert.AreEqual(1, folder.ProposedFileCount);
        }

        [TestMethod]
        public void AnimeFolder_AddMultipleProposedFiles()
        {
            AnimeFolder folder = new AnimeFolder();

            for (int i = 0; i < 5; i++)
            {
                MoveableAnimeFile file = new MoveableAnimeFile();
                file.Name = "Test" + i;
                folder.AddProposedFile(file);
            }

            Assert.AreEqual(5, folder.ProposedFileCount);
        }

        [TestMethod]
        public void AnimeFolder_GetProposedFileByIndex()
        {
            AnimeFolder folder = new AnimeFolder();
            MoveableAnimeFile file1 = new MoveableAnimeFile();
            file1.Name = "File1";
            MoveableAnimeFile file2 = new MoveableAnimeFile();
            file2.Name = "File2";

            folder.AddProposedFile(file1);
            folder.AddProposedFile(file2);

            Assert.AreEqual(file1, folder.GetProposedFileByIndex(0));
            Assert.AreEqual(file2, folder.GetProposedFileByIndex(1));
        }

        [TestMethod]
        public void AnimeFolder_GetProposedFileByIndex_InvalidIndex_ReturnsNull()
        {
            AnimeFolder folder = new AnimeFolder();

            Assert.IsNull(folder.GetProposedFileByIndex(0));
            Assert.IsNull(folder.GetProposedFileByIndex(-1));
        }

        [TestMethod]
        public void AnimeFolder_RemoveProposedFileByIndex()
        {
            AnimeFolder folder = new AnimeFolder();
            MoveableAnimeFile file1 = new MoveableAnimeFile();
            file1.Name = "File1";
            MoveableAnimeFile file2 = new MoveableAnimeFile();
            file2.Name = "File2";

            folder.AddProposedFile(file1);
            folder.AddProposedFile(file2);

            folder.RemoveProposedFileByIndex(0);

            Assert.AreEqual(1, folder.ProposedFileCount);
            Assert.AreEqual(file2, folder.GetProposedFileByIndex(0));
        }

        [TestMethod]
        public void AnimeFolder_RemoveProposedFileByIndex_InvalidIndex()
        {
            AnimeFolder folder = new AnimeFolder();
            MoveableAnimeFile file = new MoveableAnimeFile();
            folder.AddProposedFile(file);

            folder.RemoveProposedFileByIndex(5);
            folder.RemoveProposedFileByIndex(-1);

            Assert.AreEqual(1, folder.ProposedFileCount);
        }

        [TestMethod]
        public void AnimeFolder_ProposedFileCount_Empty()
        {
            AnimeFolder folder = new AnimeFolder();
            Assert.AreEqual(0, folder.ProposedFileCount);
        }
    }
}
