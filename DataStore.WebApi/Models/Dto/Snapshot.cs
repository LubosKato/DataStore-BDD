using System;
using DataStore.Model.Events.Messages.Snapshots;
using DataStore.Model.Shared.Enums;

namespace DataStore.WebApi.Models.Dto
{
    public class Snapshot
    {
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
    }
}