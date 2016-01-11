using System.Collections.Generic;
using DataStore.Model.Events;
using DataStore.Model.Events.Messages.Snapshots;
using DataStore.Model.Shared.Enums;
using DataStore.Model.ValueObjects.Snapshots;

namespace DataStore.Model.AggregateRoots.Snapshots
{
    public interface ISnapshots
    {
        IEnumerable<Snapshot> Values { get; }
    }

    public class Snapshots : ISnapshots
    {
        private IEnumerable<Snapshot> _snapshots;
        private readonly SnapshotType _snapshotType;

        public Snapshots(SnapshotType snapshotType)
        {
            _snapshotType = snapshotType;
        }

        public IEnumerable<Snapshot> Values
        {
            get
            {
                if (_snapshots == null)
                {
                    var message = new SnapshotsGet(_snapshotType);
                    DomainEvent.Raise(message);
                    _snapshots = message.Snapshots;
                }
                return _snapshots;
            }
        }
    }
}