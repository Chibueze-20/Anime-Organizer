using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using AnimeOrganizerCommon;

namespace AnimeOrganizerUnitTest.AnimeOrganizerCommon
{
    [TestClass]
    public class SeperatorEnumTests
    {
        [TestMethod]
        public void Seperator_HasDashValue()
        {
            Assert.IsTrue(Enum.IsDefined(typeof(Seperator), Seperator.dash));
        }

        [TestMethod]
        public void Seperator_HasEpisodeValue()
        {
            Assert.IsTrue(Enum.IsDefined(typeof(Seperator), Seperator.episode));
        }

        [TestMethod]
        public void Seperator_HasNoneValue()
        {
            Assert.IsTrue(Enum.IsDefined(typeof(Seperator), Seperator.none));
        }
    }
}
