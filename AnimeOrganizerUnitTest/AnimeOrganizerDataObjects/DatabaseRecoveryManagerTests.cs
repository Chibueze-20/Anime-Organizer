using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnimeOrganizerDataObjects;

namespace AnimeOrganizerUnitTest.AnimeOrganizerDataObjects
{
    [TestClass]
    public class DatabaseRecoveryManagerTests
    {
        private DatabaseRecoveryManager recoveryManager;
        private string testRecoveryPath;

        [TestInitialize]
        public void Setup()
        {
            // Create a temporary recovery file path for testing
            testRecoveryPath = Path.Combine(
                Path.GetTempPath(),
                $"AnimeOrganizerRecoveryTest_{Guid.NewGuid()}.bin"
            );

            recoveryManager = new DatabaseRecoveryManager(testRecoveryPath);

            // Clear any existing recovery file to ensure clean test state
            recoveryManager.ClearRecoveryFile();
        }

        [TestCleanup]
        public void Cleanup()
        {
            // Clean up recovery file after each test
            if (recoveryManager != null)
            {
                recoveryManager.ClearRecoveryFile();
            }

            // Remove temporary test file if it still exists
            try
            {
                if (!string.IsNullOrEmpty(testRecoveryPath) && File.Exists(testRecoveryPath))
                {
                    File.Delete(testRecoveryPath);
                }
            }
            catch
            {
                // Ignore cleanup errors
            }
        }

        #region CapturePendingOperations Tests

        [TestMethod]
        public void RecoveryOperation_CreatesValidInstance()
        {
            // Arrange & Act
            var operation = new RecoveryOperation
            {
                OperationType = "Create",
                Record = new AnimeRecord { title = "Test Anime", numberOfEpisodes = 12 },
                Timestamp = DateTime.Now
            };

            // Assert
            Assert.IsNotNull(operation);
            Assert.AreEqual("Create", operation.OperationType);
            Assert.AreEqual("Test Anime", operation.Record.title);
            Assert.AreEqual(12, operation.Record.numberOfEpisodes);
        }

        #endregion

        #region SaveRecoveryFile and LoadRecoveryFile Tests

        [TestMethod]
        public void SaveRecoveryFile_WithNullOperations_DoesNotThrow()
        {
            // Should handle null gracefully
            try
            {
                recoveryManager.SaveRecoveryFile(null);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Expected no exception, but {ex.GetType().Name} was thrown: {ex.Message}");
            }
        }

        [TestMethod]
        public void SaveRecoveryFile_WithEmptyList_DoesNotThrow()
        {
            // Should handle empty list gracefully
            var emptyOperations = new List<RecoveryOperation>();
            try
            {
                recoveryManager.SaveRecoveryFile(emptyOperations);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Expected no exception, but {ex.GetType().Name} was thrown: {ex.Message}");
            }
        }

        [TestMethod]
        public void SaveRecoveryFile_WithValidOperations_CreatesFile()
        {
            // Arrange
            var operations = new List<RecoveryOperation>
            {
                new RecoveryOperation
                {
                    OperationType = "Create",
                    Record = new AnimeRecord { title = "Naruto", numberOfEpisodes = 220 },
                    Timestamp = DateTime.Now
                }
            };

            // Verify file doesn't exist yet
            Assert.IsFalse(File.Exists(testRecoveryPath));

            // Act
            recoveryManager.SaveRecoveryFile(operations);

            // Assert - verify file was created
            Assert.IsTrue(File.Exists(testRecoveryPath), "Recovery file should have been created");
        }

        [TestMethod]
        public void SaveRecoveryFile_WithValidOperations_SavesSuccessfully()
        {
            // Arrange
            var operations = new List<RecoveryOperation>
            {
                new RecoveryOperation
                {
                    OperationType = "Create",
                    Record = new AnimeRecord { title = "Naruto", numberOfEpisodes = 220 },
                    Timestamp = DateTime.Now
                }
            };

            // Act
            recoveryManager.SaveRecoveryFile(operations);

            // Assert - verify file was created with data
            var loadedOps = recoveryManager.LoadRecoveryFile();
            Assert.IsNotNull(loadedOps);
            Assert.AreEqual(1, loadedOps.Count);
            Assert.AreEqual("Create", loadedOps[0].OperationType);
            Assert.AreEqual("Naruto", loadedOps[0].Record.title);
        }

        [TestMethod]
        public void LoadRecoveryFile_WhenFileDoesNotExist_ReturnsNull()
        {
            // Ensure no recovery file exists
            recoveryManager.ClearRecoveryFile();

            // Act
            var result = recoveryManager.LoadRecoveryFile();

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void LoadRecoveryFile_AfterSave_ReturnsCorrectData()
        {
            // Arrange
            var originalOps = new List<RecoveryOperation>
            {
                new RecoveryOperation
                {
                    OperationType = "Update",
                    Record = new AnimeRecord 
                    { 
                        title = "One Piece", 
                        numberOfEpisodes = 1000,
                        rating = 9,
                        description = "A great anime"
                    },
                    Timestamp = DateTime.Now.AddHours(-1)
                }
            };

            // Act
            recoveryManager.SaveRecoveryFile(originalOps);
            var loadedOps = recoveryManager.LoadRecoveryFile();

            // Assert
            Assert.IsNotNull(loadedOps);
            Assert.AreEqual(1, loadedOps.Count);
            Assert.AreEqual("Update", loadedOps[0].OperationType);
            Assert.AreEqual("One Piece", loadedOps[0].Record.title);
            Assert.AreEqual(1000, loadedOps[0].Record.numberOfEpisodes);
            Assert.AreEqual(9, loadedOps[0].Record.rating);
        }

        #endregion

        #region ClearRecoveryFile Tests

        [TestMethod]
        public void ClearRecoveryFile_WithExistingFile_DeletesSuccessfully()
        {
            // Arrange - save a recovery file first
            var operations = new List<RecoveryOperation>
            {
                new RecoveryOperation
                {
                    OperationType = "Delete",
                    Record = new AnimeRecord { title = "Test" },
                    Timestamp = DateTime.Now
                }
            };
            recoveryManager.SaveRecoveryFile(operations);

            // Verify file exists
            var existingOps = recoveryManager.LoadRecoveryFile();
            Assert.IsNotNull(existingOps);
            Assert.AreEqual(1, existingOps.Count);

            // Act
            recoveryManager.ClearRecoveryFile();

            // Assert
            var deletedOps = recoveryManager.LoadRecoveryFile();
            Assert.IsNull(deletedOps);
        }

        [TestMethod]
        public void ClearRecoveryFile_WhenFileDoesNotExist_DoesNotThrow()
        {
            // Ensure no file exists
            recoveryManager.ClearRecoveryFile();

            // Act & Assert - should not throw
            try
            {
                recoveryManager.ClearRecoveryFile();
            }
            catch (Exception ex)
            {
                Assert.Fail($"Expected no exception, but {ex.GetType().Name} was thrown: {ex.Message}");
            }
        }

        #endregion

        #region Recovery File Merge Tests

        [TestMethod]
        public void SaveRecoveryFile_MergesWithExistingFile_KeepsLatestTimestamp()
        {
            // Arrange - create initial operations
            var operation1 = new RecoveryOperation
            {
                OperationType = "Create",
                Record = new AnimeRecord { title = "Anime1", numberOfEpisodes = 12 },
                Timestamp = DateTime.Now.AddHours(-2)
            };

            var existingOps = new List<RecoveryOperation> { operation1 };
            recoveryManager.SaveRecoveryFile(existingOps);

            // Act - save new operations with the same title but newer timestamp
            var operation2 = new RecoveryOperation
            {
                OperationType = "Update",
                Record = new AnimeRecord { title = "Anime1", numberOfEpisodes = 24 },
                Timestamp = DateTime.Now
            };

            var newOps = new List<RecoveryOperation> { operation2 };
            recoveryManager.SaveRecoveryFile(newOps);

            // Assert - should keep the newer operation
            var loadedOps = recoveryManager.LoadRecoveryFile();
            Assert.IsNotNull(loadedOps);
            Assert.AreEqual(1, loadedOps.Count);
            Assert.AreEqual("Update", loadedOps[0].OperationType);
            Assert.AreEqual(24, loadedOps[0].Record.numberOfEpisodes);
        }

        [TestMethod]
        public void SaveRecoveryFile_MergesMultipleRecords_PreservesAll()
        {
            // Arrange - save initial operations for different records
            var operation1 = new RecoveryOperation
            {
                OperationType = "Create",
                Record = new AnimeRecord { title = "Anime1", numberOfEpisodes = 12 },
                Timestamp = DateTime.Now.AddHours(-2)
            };

            var existingOps = new List<RecoveryOperation> { operation1 };
            recoveryManager.SaveRecoveryFile(existingOps);

            // Act - save operations for a different record
            var operation2 = new RecoveryOperation
            {
                OperationType = "Create",
                Record = new AnimeRecord { title = "Anime2", numberOfEpisodes = 13 },
                Timestamp = DateTime.Now
            };

            var newOps = new List<RecoveryOperation> { operation2 };
            recoveryManager.SaveRecoveryFile(newOps);

            // Assert - both records should be preserved
            var loadedOps = recoveryManager.LoadRecoveryFile();
            Assert.IsNotNull(loadedOps);
            Assert.AreEqual(2, loadedOps.Count);

            var anime1 = loadedOps.FirstOrDefault(o => o.Record.title == "Anime1");
            var anime2 = loadedOps.FirstOrDefault(o => o.Record.title == "Anime2");

            Assert.IsNotNull(anime1);
            Assert.IsNotNull(anime2);
            Assert.AreEqual("Create", anime1.OperationType);
            Assert.AreEqual("Create", anime2.OperationType);
        }

        [TestMethod]
        public void SaveRecoveryFile_WithEqualTimestamps_PrioritizesDeleteOverUpdate()
        {
            // Arrange
            DateTime sameTime = DateTime.Now;

            var operation1 = new RecoveryOperation
            {
                OperationType = "Update",
                Record = new AnimeRecord { title = "Anime1", numberOfEpisodes = 12 },
                Timestamp = sameTime
            };

            var existingOps = new List<RecoveryOperation> { operation1 };
            recoveryManager.SaveRecoveryFile(existingOps);

            // Act - save Delete operation with same timestamp
            var operation2 = new RecoveryOperation
            {
                OperationType = "Delete",
                Record = new AnimeRecord { title = "Anime1" },
                Timestamp = sameTime
            };

            var newOps = new List<RecoveryOperation> { operation2 };
            recoveryManager.SaveRecoveryFile(newOps);

            // Assert - Delete should be prioritized over Update
            var loadedOps = recoveryManager.LoadRecoveryFile();
            Assert.IsNotNull(loadedOps);
            Assert.AreEqual(1, loadedOps.Count);
            Assert.AreEqual("Delete", loadedOps[0].OperationType);
        }

        [TestMethod]
        public void SaveRecoveryFile_WithEqualTimestamps_PrioritizesUpdateOverCreate()
        {
            // Arrange
            DateTime sameTime = DateTime.Now;

            var operation1 = new RecoveryOperation
            {
                OperationType = "Create",
                Record = new AnimeRecord { title = "Anime1", numberOfEpisodes = 12 },
                Timestamp = sameTime
            };

            var existingOps = new List<RecoveryOperation> { operation1 };
            recoveryManager.SaveRecoveryFile(existingOps);

            // Act - save Update operation with same timestamp
            var operation2 = new RecoveryOperation
            {
                OperationType = "Update",
                Record = new AnimeRecord { title = "Anime1", numberOfEpisodes = 24 },
                Timestamp = sameTime
            };

            var newOps = new List<RecoveryOperation> { operation2 };
            recoveryManager.SaveRecoveryFile(newOps);

            // Assert - Update should be prioritized over Create
            var loadedOps = recoveryManager.LoadRecoveryFile();
            Assert.IsNotNull(loadedOps);
            Assert.AreEqual(1, loadedOps.Count);
            Assert.AreEqual("Update", loadedOps[0].OperationType);
            Assert.AreEqual(24, loadedOps[0].Record.numberOfEpisodes);
        }

        [TestMethod]
        public void SaveRecoveryFile_ComplexMergeScenario_HandlesCorrectly()
        {
            // Arrange - initial state with 3 operations
            var initialOps = new List<RecoveryOperation>
            {
                new RecoveryOperation
                {
                    OperationType = "Create",
                    Record = new AnimeRecord { title = "Anime1", numberOfEpisodes = 12 },
                    Timestamp = DateTime.Now.AddHours(-3)
                },
                new RecoveryOperation
                {
                    OperationType = "Create",
                    Record = new AnimeRecord { title = "Anime2", numberOfEpisodes = 13 },
                    Timestamp = DateTime.Now.AddHours(-2)
                },
                new RecoveryOperation
                {
                    OperationType = "Create",
                    Record = new AnimeRecord { title = "Anime3", numberOfEpisodes = 14 },
                    Timestamp = DateTime.Now.AddHours(-1)
                }
            };

            recoveryManager.SaveRecoveryFile(initialOps);

            // Act - update Anime1 and Anime2, add Anime4
            var updateOps = new List<RecoveryOperation>
            {
                new RecoveryOperation
                {
                    OperationType = "Update",
                    Record = new AnimeRecord { title = "Anime1", numberOfEpisodes = 20 },
                    Timestamp = DateTime.Now.AddMinutes(-30)
                },
                new RecoveryOperation
                {
                    OperationType = "Delete",
                    Record = new AnimeRecord { title = "Anime2" },
                    Timestamp = DateTime.Now.AddMinutes(-15)
                },
                new RecoveryOperation
                {
                    OperationType = "Create",
                    Record = new AnimeRecord { title = "Anime4", numberOfEpisodes = 50 },
                    Timestamp = DateTime.Now
                }
            };

            recoveryManager.SaveRecoveryFile(updateOps);

            // Assert - verify merged results
            var loadedOps = recoveryManager.LoadRecoveryFile();
            Assert.IsNotNull(loadedOps);
            Assert.AreEqual(4, loadedOps.Count);

            var anime1 = loadedOps.FirstOrDefault(o => o.Record.title == "Anime1");
            var anime2 = loadedOps.FirstOrDefault(o => o.Record.title == "Anime2");
            var anime3 = loadedOps.FirstOrDefault(o => o.Record.title == "Anime3");
            var anime4 = loadedOps.FirstOrDefault(o => o.Record.title == "Anime4");

            Assert.AreEqual("Update", anime1.OperationType);
            Assert.AreEqual(20, anime1.Record.numberOfEpisodes);

            Assert.AreEqual("Delete", anime2.OperationType);
            Assert.AreEqual("Create", anime3.OperationType);
            Assert.AreEqual("Create", anime4.OperationType);
            Assert.AreEqual(50, anime4.Record.numberOfEpisodes);
        }

        #endregion

        #region Helper Methods

        [TestMethod]
        public void SaveAndLoadCycle_WithMultipleOperations_PreservesData()
        {
            // Arrange
            var operations = new List<RecoveryOperation>
            {
                new RecoveryOperation
                {
                    OperationType = "Create",
                    Record = new AnimeRecord 
                    { 
                        title = "Attack on Titan",
                        numberOfEpisodes = 75,
                        rating = 9,
                        description = "Humanity vs Giants",
                        year = 2013,
                        season = "Spring"
                    },
                    Timestamp = DateTime.Now.AddHours(-1)
                },
                new RecoveryOperation
                {
                    OperationType = "Update",
                    Record = new AnimeRecord 
                    { 
                        title = "Death Note",
                        numberOfEpisodes = 37,
                        rating = 8
                    },
                    Timestamp = DateTime.Now.AddMinutes(-30)
                },
                new RecoveryOperation
                {
                    OperationType = "Delete",
                    Record = new AnimeRecord { title = "Old Anime" },
                    Timestamp = DateTime.Now
                }
            };

            // Act
            recoveryManager.SaveRecoveryFile(operations);
            var loaded = recoveryManager.LoadRecoveryFile();

            // Assert
            Assert.IsNotNull(loaded);
            Assert.AreEqual(3, loaded.Count);
            Assert.AreEqual("Attack on Titan", loaded[0].Record.title);
            Assert.AreEqual("Death Note", loaded[1].Record.title);
            Assert.AreEqual("Old Anime", loaded[2].Record.title);
        }

        #endregion
    }
}
