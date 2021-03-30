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
    /// Retrieve and post various endpoints about vehicles. This contains all data revolving around vehicles in the database.
    /// </summary>
    public class VehicleController : ApiController
    {
        private readonly Database.VehicleDB db;

        /// <summary>
        /// VehicleController Constructor. Instantiate vehicle database.
        /// </summary>
        public VehicleController()
        {
            db = new Database.VehicleDB();
        }

        /// <summary>
        /// Get all vehicles currently in the database.
        /// </summary>
        /// <returns>List of vehicle objects.</returns>
        [HttpGet]
        [Route("api/vehicles/all")]
        public List<Vehicle> GetAllVehicles()
        {
            return db.GetAll();
        }

        /// <summary>
        /// Get a specific vehicle provided a unique vehicle id.
        /// </summary>
        /// <param name="id">The unique identifier for this vehicle.</param>
        /// <returns>A single vehicle object.</returns>
        [HttpGet]
        [Route("api/vehicles/{id}")]
        public Vehicle GetVehicletById(long id)
        {
            return db.GetById(id);
        }

        /// <summary>
        /// Get vehicle objects provided a unique client id.
        /// </summary>
        /// <param name="id">The unique identifier of the client that represents their vehicle.</param>
        /// <returns>List of vehicle objects that are registered to the specfic client id.</returns>
        [HttpGet]
        [Route("api/vehicles/from_client/{id}")]
        public List<Vehicle> GetVehiclesByClientId(long id)
        {
            return db.GetVehiclesByClientId(id);
        }

        /// <summary>
        /// Create a vehicle to be stored in the database provided a unique client id.
        /// </summary>
        /// <param name="client_id">The unique identifier for the client registering a vehicle.</param>
        /// <param name="model">The make and model of the vehicle.</param>
        /// <param name="tire_size">The tire size of the vehicle.</param>
        /// <returns>The single vehicle object that was created. Null otherwise.</returns>
        [HttpPost]
        [Route("api/vehicles/add_vehicle")]
        public Vehicle AddVehicle(long client_id, string model, int tire_size)
        {
            Vehicle vehicle = new Vehicle();
            vehicle.client_id = client_id;
            vehicle.model = model;
            vehicle.tire_size = tire_size;
            db.Add(vehicle);
            return vehicle;
        }

        /// <summary>
        /// Delete vehicle in the database provided the unique vehicle id.
        /// </summary>
        /// <param name="id">The unique identifier for this vehicle.</param>
        [HttpDelete]
        [Route("api/vehicles/delete_vehicle/{id}")]
        public void DeleteVehicletById(long id)
        {
            db.Delete(id);
        }

        /// <summary>
        /// Delete vehicle in the database provided the unique client id. This will delete all vehicles pointed to this client id.
        /// </summary>
        /// <param name="id">The unique client id.</param>
        [HttpDelete]
        [Route("api/vehicles/delete_vehicle/from_client/{id}")]
        public void DeleteVehicletByClientId(long id)
        {
            db.DeleteVehicleByClientId(id);
        }


        // NEEDS IMPLEMENTAION
        /// <summary>
        /// Update vehicle information.
        /// </summary>
        [HttpPut]
        [Route("api/vehicles/update_vehicle")]
        public void UpdateVehicle()
        {

        }

    }
}
