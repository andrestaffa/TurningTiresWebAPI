using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TurningTiresWebAPI.Models;

namespace TurningTiresWebAPI.Controllers
{
    public class TireController : ApiController
    {
        private readonly Database.TireDB db;

        public TireController()
        {
            db = new Database.TireDB();
        }

        [HttpGet]
        [Route("api/tires/all")]
        public List<Tire> GetTires()
        {
            return db.GetAll();
        }

        [HttpGet]
        [Route("api/tires/{id}")]
        public Tire GetTiretById(long id)
        {
            return db.GetById(id);
        }

        [HttpGet]
        [Route("api/tires/from_vehicle/{id}")]
        public List<Tire> GetTiresByVehicletId(long id)
        {
            return db.GetTireByVehicleId(id);
        }

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

        [HttpDelete]
        [Route("api/tires/delete_tire/{id}")]
        public void DeleteTiretById(long id)
        {
            db.Delete(id);
        }

        [HttpDelete]
        [Route("api/tires/delete_tire/from_vehicle/{id}")]
        public void DeleteVehicletByClientId(long id)
        {
            db.DeleteTireByVehicleId(id);
        }

        // NEEDS IMPLEMENTAION
        [HttpPut]
        [Route("api/tires/update_tire")]
        public void UpdateTire()
        {

        }

    }
}
