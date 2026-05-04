using System;

namespace AnimeOrganizerDataObjects
{
    /// <summary>
    /// Represents a pending database operation for recovery purposes.
    /// </summary>
    [Serializable]
    public class RecoveryOperation
    {
        /// <summary>
        /// The type of operation: "Create", "Update", or "Delete"
        /// </summary>
        public string OperationType { get; set; }

        /// <summary>
        /// The anime record involved in the operation
        /// </summary>
        public AnimeRecord Record { get; set; }

        /// <summary>
        /// The timestamp when this operation was captured
        /// </summary>
        public DateTime Timestamp { get; set; }
    }
}
