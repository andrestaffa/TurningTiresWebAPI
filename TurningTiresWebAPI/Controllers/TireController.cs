using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TurningTiresWebAPI.Models;

namespace TurningTiresWebAPI.Controllers
{
    /// <summary>
    /// Retrieve and post various endpoints about tires. This contains all data revolving around tires in the database.
    /// </summary>
    public class TireController : ApiController
    {
        private readonly Database.TireDB db;

        /// <summary>
        /// TireController Constructor. Instantiate tire database.
        /// </summary>
        public TireController()
        {
            db = new Database.TireDB();
        }

        /// <summary>
        /// Get all tires currently in the database.
        /// </summary>
        /// <returns>List of tire objects.</returns>
        [HttpGet]
        [Route("api/tires/all")]
        public List<Tire> GetAllTires()
        {
            return db.GetAll();
        }

        /// <summary>
        /// Get a specific tire provided a unique tire id.
        /// </summary>
        /// <param name="id">The unique identifier for this tire.</param>
        /// <returns>A single tire object.</returns>
        [HttpGet]
        [Route("api/tires/{id}")]
        public Tire GetTireById(long id)
        {
            return db.GetById(id);
        }

        /// <summary>
        /// Get tire objects provided a unique vehicle id.
        /// </summary>
        /// <param name="id">The unique identifier of the vehicle that represents the tire.</param>
        /// <returns>List of tire objects that are registered to the specfic vehicle id.</returns>
        [HttpGet]
        [Route("api/tires/from_vehicle/{id}")]
        public List<Tire> GetTiresByVehicleId(long id)
        {
            return db.GetTireByVehicleId(id);
        }

        /// <summary>
        /// Create a tire to be stored in the database provided a unique vehicle id.
        /// </summary>
        /// <param name="vehicle_id">The unique identifier for the vehicle registered to this tire.</param>
        /// <param name="tire_size">The tire size of the registered vehicle.</param>
        /// <param name="type">The type of tire of the registered vehicle.</param>
        /// <param name="tread_percentage">The tread percentage of all four tires of the registered vehicle.</param>
        /// <returns>The single tire object that was created. Null otherwise.</returns>
        [HttpPost]
        [Route("api/tires/add_tire")]
        public Tire AddTire(long vehicle_id, int tire_size, string type, int tread_percentage)
        {
            Tire tire = new Tire();
            tire.vehicle_id = vehicle_id;
            tire.tire_size = tire_size;
            tire.type = type;
            tire.tread_percentage = tread_percentage;
            db.Add(tire);
            return tire;
        }

        /// <summary>
        /// Delete tire in the database provided the unique tire id.
        /// </summary>
        /// <param name="id">The unique identifier for this tire</param>
        [HttpDelete]
        [Route("api/tires/delete_tire/{id}")]
        public void DeleteTireById(long id)
        {
            db.Delete(id);
        }

        /// <summary>
        /// Delete tire in the database provided the unique vehicle id. This will delete all tires pointed to this vehicle id.
        /// </summary>
        /// <param name="id">The unique vehicle id.</param>
        [HttpDelete]
        [Route("api/tires/delete_tire/from_vehicle/{id}")]
        public void DeleteTireByVehicleId(long id)
        {
            db.DeleteTireByVehicleId(id);
        }

        // NEEDS IMPLEMENTAION
        /// <summary>
        /// Update tire information.
        /// </summary>
        [HttpPut]
        [Route("api/tires/update_tire")]
        public void UpdateTire()
        {

        }

    }
}
