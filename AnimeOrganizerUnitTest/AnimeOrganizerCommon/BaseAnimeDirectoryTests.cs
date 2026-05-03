using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using AnimeOrganizerCommon;

namespace AnimeOrganizerUnitTest.AnimeOrganizerCommon
{
    [TestClass]
    public class BaseAnimeDirectoryTests
    {
        [TestMethod]
        public void AnimeFile_SetAndGetEpisode()
        {
            AnimeFile file = new AnimeFile();
            file.Episode = 5;
            Assert.AreEqual(5, file.Episode);
        }

        [TestMethod]
        public void AnimeFile_SetAndGetName()
        {
            AnimeFile file = new AnimeFile();
            file.Name = "Attack on Titan";
            Assert.AreEqual("Attack on Titan", file.Name);
        }

        [TestMethod]
        public void AnimeFile_SetAndGetPath()
        {
            AnimeFile file = new AnimeFile();
            file.Path = "C:\\anime\\file.mkv";
            Assert.AreEqual("C:\\anime\\file.mkv", file.Path);
        }

        [TestMethod]
        public void AnimeFile_SetAndGetWeight()
        {
            AnimeFile file = new AnimeFile();
            file.Weight = 10;
            Assert.AreEqual(10, file.Weight);
        }

        [TestMethod]
        public void AnimeFile_SetAndGetIsNew()
        {
            AnimeFile file = new AnimeFile();
            file.IsNew = true;
            Assert.IsTrue(file.IsNew);
        }

        [TestMethod]
        public void AnimeFile_ToString_ReturnsName()
        {
            AnimeFile file = new AnimeFile();
            file.Name = "Test Anime";
            Assert.AreEqual("Test Anime", file.ToString());
        }

        [TestMethod]
        public void BaseAnimeDirectory_GreaterThanOperator_WithValidWeights()
        {
            AnimeFile file1 = new AnimeFile();
            file1.Weight = 20;
            AnimeFile file2 = new AnimeFile();
            file2.Weight = 10;

            Assert.IsTrue(file1 > file2);
            Assert.IsFalse(file2 > file1);
        }

        [TestMethod]
        public void BaseAnimeDirectory_LessThanOperator_WithValidWeights()
        {
            AnimeFile file1 = new AnimeFile();
            file1.Weight = 10;
            AnimeFile file2 = new AnimeFile();
            file2.Weight = 20;

            Assert.IsTrue(file1 < file2);
            Assert.IsFalse(file2 < file1);
        }

        [TestMethod]
        public void BaseAnimeDirectory_GreaterThanOperator_WithNullValues()
        {
            AnimeFile file1 = new AnimeFile();
            file1.Weight = 10;

            Assert.IsTrue(file1 > null);
            Assert.IsFalse(null > file1);
        }

        [TestMethod]
        public void BaseAnimeDirectory_LessThanOperator_WithNullValues()
        {
            AnimeFile file1 = new AnimeFile();
            file1.Weight = 10;

            Assert.IsTrue(null < file1);
            Assert.IsFalse(file1 < null);
        }

        [TestMethod]
        public void BaseAnimeDirectory_SearchSet_FiltersNumericAndRedundantStrings()
        {
            AnimeFile file = new AnimeFile();
            file.Name = "Attack_on_Titan_2013_Season_1";

            List<string> searchSet = file.SearchSet;

            Assert.IsTrue(searchSet.Contains("Attack"));
            Assert.IsTrue(searchSet.Contains("Titan"));
            Assert.IsFalse(searchSet.Contains("2013"));
            Assert.IsFalse(searchSet.Contains("1"));
        }
    }
}
