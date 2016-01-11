using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataStore.Model.Shared.Enums;
using DataStore.Model.ValueObjects.Snapshots;

namespace DataStore.Model.UnitTests.Snapshots
{
    [TestClass]
    public class SnapshotsTests
    {
        [TestMethod]
        public void Can_Create_A_Snapshot()
        {
            Assert.IsNotNull(Snapshot.CreateInstance(49, DateTime.Now, DateTime.Now, "User", "User", null, "int/katolu",
                DateTime.Now, 1, null, SnapshotStatus.Active, new Guid("2E970F28-58ED-449F-BDFC-7735E67435BA")));
        }

        [TestMethod]
        public void A_Snapshot_Values_Should_Expose_Its_Value()
        {
            const int value = 1;
            var cut = Snapshot.CreateInstance(value, DateTime.Now, DateTime.Now, "User", "User", null, "int/katolu",
                DateTime.Now, 1, null, SnapshotStatus.Active, new Guid("2E970F28-58ED-449F-BDFC-7735E67435BA"));
            Assert.AreEqual(value, cut.SnapshotId);
            Assert.AreEqual("User", cut.Name);
        }
    }
}