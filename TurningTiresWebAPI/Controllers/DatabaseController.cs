using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TurningTiresWebAPI.Models;

namespace TurningTiresWebAPI.Controllers
{
    public class DatabaseController : ApiController
    {
        private readonly Database db;

        public DatabaseController()
        {
            db = new Database();
        }

        [HttpGet]
        [Route("api/clients/all")]
        public List<Client> GetAllClients()
        {
            return db.GetAllClients();
        }

        [HttpGet]
        [Route("api/clients/{id}")]
        public Client GetClientByID(long id)
        {
            return db.GetClientById(id);
        }

        [HttpPost]
        [Route("api/clients/sign_up")]
        public void AddClient(string email, string first_name, string last_name, string address)
        {
            Client client = new Client();
            client.email = email;
            client.first_name = first_name;
            client.last_name = last_name;
            client.address = address;
            db.AddClient(client);
        }

        [HttpDelete]
        [Route("api/clients/delete/{id}")]
        public void DeleteClient(long id)
        {
            db.DeleteClient(id);
        }

    }
}
