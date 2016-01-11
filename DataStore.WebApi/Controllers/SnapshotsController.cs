using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using DataStore.WebApi.Models.Dto;
using DataStore.WebApi.Models.Factory;

namespace DataStore.WebApi.Controllers
{
    /// <summary>
    /// gets or sets Snapshots
    /// </summary>
    [RoutePrefix("api/snapshots")]
    public class SnapshotsController : ApiController
    {
        /// <summary>
        /// Gets the list of specified snapshot type.
        /// </summary>
        /// <param name="snapshotType">Type of the snapshot.</param>
        /// <returns></returns>
        [ResponseType(typeof(IEnumerable<Snapshots>))]
        [HttpGet]
        [Route("{snapshottype}")]
        public IHttpActionResult Get(string snapshotType)
        {
            var snapshots = new Model.AggregateRoots.Snapshots.Snapshots(SnapshotsFactory.CreateInstance(snapshotType));
            var data = snapshots.Values;
            if (data == null)
            {
                return NotFound();
            }

            return Ok(SnapshotsFactory.CreateInstance(data.ToList()));
        }
    }
}
