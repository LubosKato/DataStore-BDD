using System.Collections.Generic;
using DataStore.Model.Events.Interface;
using DataStore.Model.Shared.Enums;
using DataStore.Model.ValueObjects.Snapshots;

namespace DataStore.Model.Events.Messages.Snapshots
{
    public class SnapshotsGet : IDomainEvent
    {
        public SnapshotsGet(SnapshotType snapshotType)
        {
            SnapshotType = snapshotType;
        }

        public IEnumerable<Snapshot> Snapshots { get; set; }

        public SnapshotType SnapshotType { get; set; }
    }
}