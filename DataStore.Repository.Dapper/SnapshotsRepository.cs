using System.Collections.Generic;
using System.Data;
using Dapper;
using DataStore.Model.Shared.Enums;
using DataStore.Model.ValueObjects.Snapshots;
using DataStore.Repository.Abstractions;
using DataStore.Repository.Dapper.DataAccess.Interfaces;
using Shared.Membership.Service;

namespace DataStore.Repository.Dapper
{
    public class SnapshotsRepository : ISnapshotsRepository
    {
        private readonly IUserService _userService;
        private readonly IDataBaseAccess _dataAccess;

        public SnapshotsRepository(IUserService userService, IDataBaseAccess dataAccess)
        {
            _userService = userService;
            _dataAccess = dataAccess;
        }

        public IEnumerable<Snapshot> GetSnapshots(SnapshotType snapshotType)
        {
            IEnumerable<Snapshot> result;
            using (var sqlConnection = _dataAccess.GetOpenConnectionArt())
            {
                var teamId = _userService.GetCurrentUser().Team.Id;
                var userName = _userService.GetCurrentUser().Name;

                result =
                    sqlConnection.Query<Snapshot>("usp_Snapshot_Sel", new
                    {
                        TeamId = teamId,
                        SnapshotType = (int)snapshotType,
                        CreatorName = userName
                    }, commandType: CommandType.StoredProcedure);
            }

            return result;

        }
    }
}