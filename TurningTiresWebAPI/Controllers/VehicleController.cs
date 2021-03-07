using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TurningTiresWebAPI.Models;

namespace TurningTiresWebAPI.Controllers
{
    public class VehicleController : ApiController
    {
        private readonly Database.VehicleDB db;

        public VehicleController()
        {
            db = new Database.VehicleDB();
        }

        [HttpGet]
        [Route("api/vehicles/all")]
        public List<Vehicle> GetVehicles()
        {
            return db.GetAll();
        }

        [HttpGet]
        [Route("api/vehicles/{id}")]
        public Vehicle GetVehicletById(long id)
        {
            return db.GetById(id);
        }

        [HttpGet]
        [Route("api/vehicles/from_client/{id}")]
        public List<Vehicle> GetVehiclesByClientId(long id)
        {
            return db.GetVehiclesByClientId(id);
        }

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

        [HttpDelete]
        [Route("api/vehicles/delete_vehicle/{id}")]
        public void DeleteVehicletById(long id)
        {
            db.Delete(id);
        }

        [HttpDelete]
        [Route("api/vehicles/delete_vehicle/from_client/{id}")]
        public void DeleteVehicletByClientId(long id)
        {
            db.DeleteVehicleByClientId(id);
        }

      
        // NEEDS IMPLEMENTAION
        [HttpPut]
        [Route("api/vehicles/update_vehicle")]
        public void UpdateVehicle()
        {

        }

    }
}
