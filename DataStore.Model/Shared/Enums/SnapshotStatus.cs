using System.ComponentModel;

namespace DataStore.Model.Shared.Enums
{
    public enum SnapshotStatus
    {
        [Description("Active")]
        Active = 1,

        [Description("Archived")]
        Archived = 2,

        [Description("Flagged For Deletion")]
        FlaggedForDeletion = 3
    }
}
