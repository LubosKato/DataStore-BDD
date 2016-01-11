namespace DataStore.Model.Shared.Enums
{
    /// <summary>
    /// Determines the type of snapshot
    /// </summary>
    public enum SnapshotType
    {
        /// <summary>
        /// A system (clean) snapshot
        /// </summary>
        System = 1,

        /// <summary>
        /// A user (non-edited) snapshot
        /// </summary>
        User = 2,

        /// <summary>
        /// A user edited (custom) snapshot
        /// </summary>
        Custom = 3,

        /// <summary>
        /// MLDB snapshot 
        /// </summary>
        MLDB = 4,
    }
}
