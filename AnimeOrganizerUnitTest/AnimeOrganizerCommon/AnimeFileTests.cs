using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnimeOrganizerCommon;

namespace AnimeOrganizerUnitTest.AnimeOrganizerCommon
{
    [TestClass]
    public class AnimeFileTests
    {
        [TestMethod]
        public void AnimeFile_DefaultEpisodeValue()
        {
            AnimeFile file = new AnimeFile();
            Assert.AreEqual(0, file.Episode);
        }

        [TestMethod]
        public void AnimeFile_MultipleEpisodeChanges()
        {
            AnimeFile file = new AnimeFile();
            file.Episode = 1;
            Assert.AreEqual(1, file.Episode);

            file.Episode = 10;
            Assert.AreEqual(10, file.Episode);

            file.Episode = 100;
            Assert.AreEqual(100, file.Episode);
        }
    }
}
