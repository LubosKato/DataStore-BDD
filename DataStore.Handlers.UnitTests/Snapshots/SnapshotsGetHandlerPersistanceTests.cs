using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using DataStore.Handlers.Snapshots;
using DataStore.Model.Events.Messages.Snapshots;
using DataStore.Model.Shared.Enums;
using DataStore.Model.ValueObjects.Snapshots;
using DataStore.Repository.Abstractions;

namespace DataStore.Handlers.UnitTests.Snapshots
{
    [TestClass]
    public class SnapshotsGetHandlerPersistanceTests
    {
        [TestMethod]
        public void Snapshot_Persistance_Should_Call_Snapshot_At_Least_Once()
        {
            var repo = new Mock<ISnapshotsRepository>();
            var snapshots = new List<Snapshot>();
            snapshots.Add(new Snapshot());
            repo.Setup(x => x.GetSnapshots(SnapshotType.User)).Returns(snapshots);
            var cut = new SnapshotsGetHandlerPersistance(repo.Object);
            cut.Handle(new SnapshotsGet(SnapshotType.User));
            repo.Verify(v => v.GetSnapshots(SnapshotType.User), Times.Once);
        }
    }
}