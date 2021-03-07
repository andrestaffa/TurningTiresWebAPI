using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TurningTiresWebAPI.Models;

namespace TurningTiresWebAPI.Controllers
{
    public class ClientController : ApiController
    {
        private readonly Database.ClientDB db;

        public ClientController()
        {
            db = new Database.ClientDB();
        }

        [HttpGet]
        [Route("api/clients/all")]
        public List<Client> GetAllClients()
        {
            return db.GetAll();
        }

        [HttpGet]
        [Route("api/clients/{id}")]
        public Client GetClientByID(long id)
        {
            return db.GetById(id);
        }

        [HttpPost]
        [Route("api/clients/sign_up")]
        public Client AddClient(string email, string first_name, string last_name, string address)
        {
            Client client = new Client();
            client.email = email;
            client.first_name = first_name;
            client.last_name = last_name;
            client.address = address;
            db.Add(client);
            return client;
        }

        [HttpDelete]
        [Route("api/clients/delete/{id}")]
        public void DeleteClient(long id)
        {
            db.Delete(id);
        }

        // NEEDS IMPLEMENTAION
        [HttpPut]
        [Route("api/clients/update_client")]
        public void UpdateAppointment()
        {

        }
    }
}
