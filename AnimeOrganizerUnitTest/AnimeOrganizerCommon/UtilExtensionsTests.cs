using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnimeOrganizerCommon;

namespace AnimeOrganizerUnitTest.AnimeOrganizerCommon
{
    [TestClass]
    public class UtilExtensionsTests
    {
        [TestMethod]
        public void IsNumeric_WithValidNumbers_ReturnsTrue()
        {
            Assert.IsTrue(UtillExtensions.IsNumeric("123"));
            Assert.IsTrue(UtillExtensions.IsNumeric("0"));
            Assert.IsTrue(UtillExtensions.IsNumeric("999"));
        }

        [TestMethod]
        public void IsNumeric_WithNonNumbers_ReturnsFalse()
        {
            Assert.IsFalse(UtillExtensions.IsNumeric("abc"));
            Assert.IsFalse(UtillExtensions.IsNumeric("12a"));
            Assert.IsFalse(UtillExtensions.IsNumeric("1.5"));
        }

        [TestMethod]
        public void IsNumeric_WithNullOrEmpty_ReturnsFalse()
        {
            Assert.IsFalse(UtillExtensions.IsNumeric(null));
            Assert.IsFalse(UtillExtensions.IsNumeric(""));
        }

        [TestMethod]
        public void GenerateFileName_WithDashSeparator_ReturnsCorrectFormat()
        {
            string result = UtillExtensions.GenerateFileName("Attack on Titan", 5, Seperator.dash, false);
            Assert.AreEqual("Attack on Titan - 05", result);
        }

        [TestMethod]
        public void GenerateFileName_WithEpisodeSeparator_ReturnsCorrectFormat()
        {
            string result = UtillExtensions.GenerateFileName("Attack on Titan", 5, Seperator.episode, false);
            Assert.AreEqual("Attack on Titan Episode 5", result);
        }

        [TestMethod]
        public void GenerateFileName_WithPoint5_IncludesPoint5Suffix()
        {
            string result = UtillExtensions.GenerateFileName("Attack on Titan", 5, Seperator.dash, true);
            Assert.AreEqual("Attack on Titan - 05.5", result);
        }

        [TestMethod]
        public void GenerateFileName_WithEpisodeAbove10_NoLeadingZero()
        {
            string result = UtillExtensions.GenerateFileName("Attack on Titan", 15, Seperator.dash, false);
            Assert.AreEqual("Attack on Titan - 15", result);
        }

        [TestMethod]
        public void VideoExtensions_ContainsCommonFormats()
        {
            Assert.IsTrue(UtillExtensions.videoExtensions.Contains(".mp4"));
            Assert.IsTrue(UtillExtensions.videoExtensions.Contains(".mkv"));
        }
    }
}
