using System.Collections.Generic;

namespace DataStore.WebApi.Models.Dto
{
    public class Snapshots
    {
        public Snapshots()
        {
            SnapshotValues = new List<Snapshot>();
        }

        public List<Snapshot> SnapshotValues { get; set; } 
    }
}