using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;

namespace AnimeOrganizerDataObjects
{
    /// <summary>
    /// Manages database recovery operations for crash resilience.
    /// Handles saving, loading, and merging of pending database operations.
    /// </summary>
    public class DatabaseRecoveryManager
    {
        private readonly string recoveryFilePath;

        public DatabaseRecoveryManager() : this(null)
        {
        }

        public DatabaseRecoveryManager(string customRecoveryFilePath)
        {
            if (string.IsNullOrEmpty(customRecoveryFilePath))
            {
                recoveryFilePath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "AnimeOrganizer",
                    "recovery.bin"
                );
            }
            else
            {
                recoveryFilePath = customRecoveryFilePath;
            }
        }

        /// <summary>
        /// Captures pending operations from the Entity Framework change tracker.
        /// </summary>
        public List<RecoveryOperation> CapturePendingOperations(DbChangeTracker changeTracker)
        {
            var operations = new List<RecoveryOperation>();

            foreach (var entry in changeTracker.Entries<AnimeRecord>())
            {
                string operationType = GetOperationTypeName(entry.State);
                if (string.IsNullOrEmpty(operationType))
                    continue;

                operations.Add(new RecoveryOperation
                {
                    OperationType = operationType,
                    Record = entry.Entity,
                    Timestamp = DateTime.Now
                });
            }

            return operations;
        }

        /// <summary>
        /// Saves pending operations to the recovery file, merging with existing operations if present.
        /// </summary>
        public void SaveRecoveryFile(List<RecoveryOperation> operations)
        {
            if (operations == null || operations.Count == 0)
                return;

            try
            {
                // Ensure directory exists
                string directory = Path.GetDirectoryName(recoveryFilePath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                // Merge with existing recovery file if it exists
                var mergedOperations = operations;
                if (File.Exists(recoveryFilePath))
                {
                    try
                    {
                        var existingOperations = LoadRecoveryFile();
                        if (existingOperations != null && existingOperations.Count > 0)
                        {
                            mergedOperations = MergeRecoveryOperations(existingOperations, operations);
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine($"Failed to read existing recovery file for merge: {ex.Message}");
                        // If merge fails, just use the new operations
                        mergedOperations = operations;
                    }
                }

                // Serialize merged operations to file
                using (FileStream fs = new FileStream(recoveryFilePath, FileMode.Create))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, mergedOperations);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Failed to save recovery file: {ex.Message}");
            }
        }

        /// <summary>
        /// Loads recovery operations from the recovery file.
        /// </summary>
        public List<RecoveryOperation> LoadRecoveryFile()
        {
            if (!File.Exists(recoveryFilePath))
                return null;

            try
            {
                using (FileStream fs = new FileStream(recoveryFilePath, FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    return (List<RecoveryOperation>)formatter.Deserialize(fs);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Failed to load recovery file: {ex.Message}");
                return null;
            }
        }

        /// <summary>
        /// Clears the recovery file after successful save.
        /// </summary>
        public void ClearRecoveryFile()
        {
            try
            {
                if (File.Exists(recoveryFilePath))
                {
                    File.Delete(recoveryFilePath);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Failed to clear recovery file: {ex.Message}");
            }
        }

        /// <summary>
        /// Merges existing recovery operations with new ones, keeping the latest based on timestamp.
        /// </summary>
        private List<RecoveryOperation> MergeRecoveryOperations(
            List<RecoveryOperation> existingOperations,
            List<RecoveryOperation> newOperations)
        {
            var mergedDict = new Dictionary<string, RecoveryOperation>();

            // Add existing operations indexed by title
            foreach (var op in existingOperations)
            {
                if (op.Record != null && !string.IsNullOrEmpty(op.Record.title))
                {
                    mergedDict[op.Record.title] = op;
                }
            }

            // Process new operations, keeping the latest based on timestamp
            foreach (var newOp in newOperations)
            {
                if (newOp.Record == null || string.IsNullOrEmpty(newOp.Record.title))
                    continue;

                string title = newOp.Record.title;

                if (mergedDict.ContainsKey(title))
                {
                    var existingOp = mergedDict[title];

                    // Keep the operation with the latest timestamp
                    if (newOp.Timestamp > existingOp.Timestamp)
                    {
                        mergedDict[title] = newOp;
                    }
                    // If timestamps are equal, prioritize Delete > Update > Create
                    else if (newOp.Timestamp == existingOp.Timestamp)
                    {
                        int newOpPriority = GetOperationPriority(newOp.OperationType);
                        int existingOpPriority = GetOperationPriority(existingOp.OperationType);

                        if (newOpPriority > existingOpPriority)
                        {
                            mergedDict[title] = newOp;
                        }
                    }
                }
                else
                {
                    mergedDict[title] = newOp;
                }
            }

            return new List<RecoveryOperation>(mergedDict.Values);
        }

        /// <summary>
        /// Gets the priority of an operation type for merge conflict resolution.
        /// Higher priority = should be kept when timestamps are equal.
        /// </summary>
        private int GetOperationPriority(string operationType)
        {
            switch (operationType)
            {
                case "Delete":
                    return 3;
                case "Update":
                    return 2;
                case "Create":
                    return 1;
                default:
                    return 0;
            }
        }

        /// <summary>
        /// Converts Entity Framework EntityState to operation type name.
        /// </summary>
        private string GetOperationTypeName(EntityState state)
        {
            switch (state)
            {
                case EntityState.Added:
                    return "Create";
                case EntityState.Modified:
                    return "Update";
                case EntityState.Deleted:
                    return "Delete";
                default:
                    return null;
            }
        }
    }
}
