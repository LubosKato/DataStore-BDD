using System;
using DataStore.Model.Shared.Enums;

namespace DataStore.Model.ValueObjects.Snapshots
{
    public class Snapshot
    {
        public static Snapshot CreateInstance(int snapshotId, DateTime createdDate, DateTime importDate, string name,
            string description, Guid? creatorGuid, string creatorName, DateTime? asAtDate, int version, int? parentId,
            SnapshotStatus status, Guid? teamId)
        {
            return new Snapshot
            {
                SnapshotId = snapshotId,
                CreatedDate = createdDate,
                ImportDate = importDate,
                Name = name,
                Description = description,
                CreatorGuid = creatorGuid,
                CreatorName = creatorName,
                AsAtDate = asAtDate,
                Version = version,
                ParentId = parentId,
                Status = status,
                TeamId = teamId
            };
        }

        #region Properties

        public int SnapshotId { get; set; }

        public int SnapshotTypeId { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ImportDate { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Guid? CreatorGuid { get; set; }

        public string CreatorName { get; set; }

        public DateTime? AsAtDate { get; set; }

        public int Version { get; set; }

        public int? ParentId { get; set; }

        public SnapshotType SnapshotType
        {
            get { return (SnapshotType)SnapshotTypeId; }
            set { SnapshotTypeId = (int)value; }
        }

        public SnapshotStatus Status { get; set; }

        public Guid? TeamId { get; set; }

        #endregion 
    }
}