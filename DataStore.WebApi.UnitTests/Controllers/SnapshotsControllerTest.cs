using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using DataStore.Model.Events;
using DataStore.Model.Events.Interface;
using DataStore.WebApi.Controllers;

namespace DataStore.WebApi.UnitTests.Controllers
{
    [TestClass]
    public class SnapshotsControllerTest
    {
        [TestInitialize]
        public void Initialize()
        {
            DomainEvent.Dispatcher = new Mock<IEventDispatcher>().Object;
        }

        [TestMethod]
        public void The_Snapshots_Controller_Should_Return_Snapshots()
        {
            var cut = new SnapshotsController();
            var data = cut.Get("User");
            Assert.IsInstanceOfType(data, typeof(System.Web.Http.Results.NotFoundResult));
        }
    }
}
