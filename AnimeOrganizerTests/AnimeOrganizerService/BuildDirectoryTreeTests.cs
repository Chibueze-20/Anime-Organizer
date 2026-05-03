using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;
using AnimeOrganizerService;
using AnimeOrganizerCommon;

[assembly: Parallelize(Scope = ExecutionScope.MethodLevel)]
namespace AnimeOrganizerService.Tests
{
    [TestClass]
    public class BuildDirectoryTreeTests
    {
        private string testRootPath;
        private Service1 service;

        [TestInitialize]
        public void Setup()
        {
            // Create a temporary test directory
            testRootPath = Path.Combine(Path.GetTempPath(), "AnimeOrganizerTest_" + Guid.NewGuid().ToString());
            Directory.CreateDirectory(testRootPath);
        }

        [TestCleanup]
        public void Cleanup()
        {
            // Clean up temporary test directory
            if (Directory.Exists(testRootPath))
            {
                Directory.Delete(testRootPath, true);
            }
        }

        [TestMethod]
        public void BuildDirectoryTree_WithValidDirectories_ReturnsAlphabeticallySortedArray()
        {
            // Arrange
            Directory.CreateDirectory(Path.Combine(testRootPath, "Zebra Anime"));
            Directory.CreateDirectory(Path.Combine(testRootPath, "Apple Anime"));
            Directory.CreateDirectory(Path.Combine(testRootPath, "Mango Anime"));

            // Access the method through reflection since it's private
            var method = typeof(Service1).GetMethod("BuildDirectoryTree",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            service = new Service1();
            var zeddPathField = typeof(Service1).GetField("zeddPath",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            zeddPathField.SetValue(service, testRootPath);

            // Act
            var result = (AnimeFolder[])method.Invoke(service, null);

            // Assert
            Assert.HasCount(3, result);
            Assert.AreEqual("Apple Anime", result[0].Name);
            Assert.AreEqual("Mango Anime", result[1].Name);
            Assert.AreEqual("Zebra Anime", result[2].Name);
        }

        [TestMethod]
        public void BuildDirectoryTree_WithValidDirectories_WithGlobalAndExcludedDirectories_ReturnsAlphabeticallySortedArray()
        {
            // Arrange
            Directory.CreateDirectory(Path.Combine(testRootPath, "temp"));
            Directory.CreateDirectory(Path.Combine(testRootPath, "Zebra Anime"));
            Directory.CreateDirectory(Path.Combine(testRootPath, "Apple Anime"));
            Directory.CreateDirectory(Path.Combine(testRootPath, "Mango Anime"));
            Directory.CreateDirectory(Path.Combine(testRootPath, "dump"));

            // Access the method through reflection since it's private
            var method = typeof(Service1).GetMethod("BuildDirectoryTree",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            service = new Service1();
            var zeddPathField = typeof(Service1).GetField("zeddPath",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            zeddPathField.SetValue(service, testRootPath);

            // Act
            var result = (AnimeFolder[])method.Invoke(service, null);

            // Assert
            Assert.HasCount(3, result);
            Assert.AreEqual("Apple Anime", result[0].Name);
            Assert.AreEqual("Mango Anime", result[1].Name);
            Assert.AreEqual("Zebra Anime", result[2].Name);
        }

        [TestMethod]
        public void BuildDirectoryTree_WithEmptyDirectory_ReturnsEmptyArray()
        {
            // Arrange
            var method = typeof(Service1).GetMethod("BuildDirectoryTree",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            service = new Service1();
            var zeddPathField = typeof(Service1).GetField("zeddPath",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            zeddPathField.SetValue(service, testRootPath);

            // Act
            var result = (AnimeFolder[])method.Invoke(service, null);

            // Assert
            Assert.IsEmpty(result);
        }

        [TestMethod]
        public void BuildDirectoryTree_WithGlobalAndExcludedDirectories_ReturnsEmptyArray()
        {
            // Arrange
            Directory.CreateDirectory(Path.Combine(testRootPath, "temp"));
            Directory.CreateDirectory(Path.Combine(testRootPath, "movies and ova"));
            Directory.CreateDirectory(Path.Combine(testRootPath, "Done"));
            Directory.CreateDirectory(Path.Combine(testRootPath, "Summer"));
            Directory.CreateDirectory(Path.Combine(testRootPath, "dump"));

            // Access the method through reflection since it's private
            var method = typeof(Service1).GetMethod("BuildDirectoryTree",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            service = new Service1();
            var zeddPathField = typeof(Service1).GetField("zeddPath",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            zeddPathField.SetValue(service, testRootPath);

            // Act
            var result = (AnimeFolder[])method.Invoke(service, null);

            // Assert
            Assert.IsEmpty(result);
        }

        [TestMethod]
        public void BuildDirectoryTree_WithNonExistentPath_ThrowsDirectoryNotFoundException()
        {
            // Arrange
            var method = typeof(Service1).GetMethod("BuildDirectoryTree",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            service = new Service1();
            var zeddPathField = typeof(Service1).GetField("zeddPath",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            zeddPathField.SetValue(service, @"C:\NonExistent\Path\That\Does\Not\Exist");

            // Act
            Assert.Throws<System.Reflection.TargetInvocationException>(() =>
            {
                var result = method.Invoke(service, null);
            });
        }

        [TestMethod]
        public void BuildDirectoryTree_VerifiesCorrectPathsAssigned()
        {
            // Arrange
            var dir1 = Path.Combine(testRootPath, "Anime Series 1");
            var dir2 = Path.Combine(testRootPath, "Anime Series 2");
            Directory.CreateDirectory(dir1);
            Directory.CreateDirectory(dir2);

            var method = typeof(Service1).GetMethod("BuildDirectoryTree",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            service = new Service1();
            var zeddPathField = typeof(Service1).GetField("zeddPath",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            zeddPathField.SetValue(service, testRootPath);

            // Act
            var result = (AnimeFolder[])method.Invoke(service, null);

            // Assert
            Assert.IsTrue(result.All(f => !string.IsNullOrEmpty(f.Path)));
            Assert.EndsWith(result[0].Name, result[0].Path);
        }
    }
}