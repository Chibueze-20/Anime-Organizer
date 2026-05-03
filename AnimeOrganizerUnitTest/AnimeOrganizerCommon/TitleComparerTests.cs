using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnimeOrganizerCommon;

namespace AnimeOrganizerUnitTest.AnimeOrganizerCommon
{
    [TestClass]
    public class TitleComparerTests
    {
        [TestMethod]
        public void TitleComparer_Equals_SameStrings_ReturnsTrue()
        {
            var comparer = new TitleComparer();

            Assert.IsTrue(comparer.Equals("Attack on Titan", "Attack on Titan"));
        }

        [TestMethod]
        public void TitleComparer_Equals_DifferentStrings_ReturnsFalse()
        {
            var comparer = new TitleComparer();

            Assert.IsFalse(comparer.Equals("Attack on Titan", "Death Note"));
        }

        [TestMethod]
        public void TitleComparer_Equals_DifferentLength_ReturnsFalse()
        {
            var comparer = new TitleComparer();

            Assert.IsFalse(comparer.Equals("Attack on Titan", "Attack on"));
        }

        [TestMethod]
        public void TitleComparer_Equals_CaseSensitive()
        {
            var comparer = new TitleComparer();

            Assert.IsFalse(comparer.Equals("Attack", "attack"));
        }

        [TestMethod]
        public void TitleComparer_GetHashCode_ConsistentWithString()
        {
            var comparer = new TitleComparer();
            string test = "Attack on Titan";

            Assert.AreEqual(test.GetHashCode(), comparer.GetHashCode(test));
        }
    }
}
