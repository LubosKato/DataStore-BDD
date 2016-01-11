using DataStore.Model.Events.Interface;
using DataStore.Model.Events.Messages.Snapshots;
using DataStore.Repository.Abstractions;

namespace DataStore.Handlers.Snapshots
{
    public class SnapshotsGetHandlerPersistance : IDomainHandler<SnapshotsGet>
    {
        private readonly ISnapshotsRepository _snapshotsRepository;

        public SnapshotsGetHandlerPersistance(ISnapshotsRepository snapshotsRepository)
        {
            _snapshotsRepository = snapshotsRepository;
        }

        public void Handle(SnapshotsGet args)
        {
            args.Snapshots = _snapshotsRepository.GetSnapshots(args.SnapshotType);
        }
    }
}