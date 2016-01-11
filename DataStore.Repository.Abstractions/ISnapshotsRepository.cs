using System.Collections.Generic;
using DataStore.Model.Shared.Enums;
using DataStore.Model.ValueObjects.Snapshots;

namespace DataStore.Repository.Abstractions
{
    public interface ISnapshotsRepository
    {
        IEnumerable<Snapshot> GetSnapshots(SnapshotType snapshotType);
    }
}