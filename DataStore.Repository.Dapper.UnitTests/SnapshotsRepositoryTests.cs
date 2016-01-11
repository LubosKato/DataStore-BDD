using System;
using System.Data;
using Dapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using DataStore.Model.Shared.Enums;
using DataStore.Repository.Abstractions;
using DataStore.Repository.Dapper.DataAccess.Interfaces;
using Shared.Membership.Service;
using Shared.Membership.Service.Models;

namespace DataStore.Repository.Dapper.UnitTests
{
    [TestClass]
    public class SnapshotsRepositoryTests
    {
        private ISnapshotsRepository cut;
        private Mock<IDataBaseAccess> _dataBaseAccess;
        private Mock<IUserService> _userService;

        private static readonly Guid MyTeamId = new Guid("2E970F28-58ED-449F-BDFC-7735E67435BA");
        private static readonly Guid UserGuid = new Guid("E92EFE94-516A-4F4C-975D-A9C689D3CC27");

        [TestInitialize]
        public void Initialize()
        {
            _userService = new Mock<IUserService>();
            _dataBaseAccess = new Mock<IDataBaseAccess>();
            _userService.Setup(s => s.GetCurrentUser()).Returns(() => new User
            {
                Name = "int/katolu",
                Id = UserGuid,
                Team = new Team
                {
                    Id = MyTeamId,
                }
            });
        }

        [TestMethod]
        public void Should_Get_Ascend_Snapshots()
        {
            cut = new SnapshotsRepository(_userService.Object, _dataBaseAccess.Object);
            cut.GetSnapshots(SnapshotType.User);
            _dataBaseAccess.Verify(v => v.Execute(null, It.IsAny<string>(), It.IsAny<DynamicParameters>(), null, null, It.IsAny<CommandType>()), Times.Once);
        }
    }
}