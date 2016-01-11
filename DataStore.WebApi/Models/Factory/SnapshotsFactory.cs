using System.Collections.Generic;
using System.Linq;
using DataStore.Model.Shared.Enums;
using DataStore.WebApi.Models.Dto;

namespace DataStore.WebApi.Models.Factory
{
    public class SnapshotsFactory
    {

        internal static List<Snapshot> CreateInstance(List<Model.ValueObjects.Snapshots.Snapshot> snapshots)
        {
            return snapshots.Select(snapshot => new Snapshot
            {
                SnapshotId = snapshot.SnapshotId,
                CreatedDate = snapshot.CreatedDate,
                ImportDate = snapshot.ImportDate,
                Name = snapshot.Name,
                Description = snapshot.Description,
                CreatorGuid = snapshot.CreatorGuid,
                CreatorName = snapshot.CreatorName,
                AsAtDate = snapshot.AsAtDate,
                Version = snapshot.Version,
                ParentId = snapshot.ParentId,
                Status = snapshot.Status,
                TeamId = snapshot.TeamId
            }).ToList();
        }

        internal static SnapshotType CreateInstance(string snapshotType)
        {
            return EnumUtil.ParseEnum<SnapshotType>(snapshotType);
        }
    }
}