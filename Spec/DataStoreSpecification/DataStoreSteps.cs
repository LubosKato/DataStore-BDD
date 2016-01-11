using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TechTalk.SpecFlow;
using DataStore.Model.AggregateRoots.Snapshots;
using DataStore.Model.Events;
using DataStore.Model.Events.Interface;
using DataStore.Model.Events.Messages.Snapshots;
using DataStore.Model.Shared.Enums;
using DataStore.Model.ValueObjects.Snapshots;

namespace DataStoreSpecification
{
    [Binding]
    public class DataStoreSteps
    {
        private Snapshots _snapshots;
        private List<Snapshot> _result;
        private Mock<IEventDispatcher> _eventDispatcher;

        [BeforeScenario]
        public void Init()
        {
            _eventDispatcher = new Mock<IEventDispatcher>();
            DomainEvent.Dispatcher = _eventDispatcher.Object;
        }

        [Given]
        public void Given_There_are_Ascend_Snapshots_in_system()
        {
            _snapshots = new Snapshots(SnapshotType.User);
        }
        
        [When]
        public void When_I_retrieve_all_Ascend_Snapshots_for_my_Team()
        {
            _result = _snapshots.Values.ToList();
        }
        
        [Then]
        public void Then_I_get_all_Ascend_Snapshots_for_my_Team()
        {
            _eventDispatcher.Verify(v => v.Dispatch(It.IsAny<SnapshotsGet>()), Times.Once);
        }

        [Given]
        public void Given_There_are_Custom_Snapshots_in_system()
        {
            _snapshots = new Snapshots(SnapshotType.Custom);
        }

        [When]
        public void When_I_retrieve_all_Custom_Snapshots_for_my_Team()
        {
            _result = _snapshots.Values.ToList();
        }

        [Then]
        public void Then_I_get_all_Custom_Snapshots_for_my_Team()
        {
            _eventDispatcher.Verify(v => v.Dispatch(It.IsAny<SnapshotsGet>()), Times.Once);
        }
    }
}
