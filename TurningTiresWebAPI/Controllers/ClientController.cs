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
    /// Retrieve and post various endpoints about client information. This contains all data revolving around clients in the database. 
    /// </summary>
    public class ClientController : ApiController
    {
        private readonly Database.ClientDB db;

        /// <summary>
        /// ClientController Constructor. Instantiate client database.
        /// </summary>
        public ClientController()
        {
            db = new Database.ClientDB();
        }

        /// <summary>
        /// Get all clients currently in the database.
        /// </summary>
        /// <returns>List of client objects.</returns>
        [HttpGet]
        [Route("api/clients/all")]
        public List<Client> GetAllClients()
        {
            return db.GetAll();
        }

        /// <summary>
        /// Get a specific client provided their unique client id.
        /// </summary>
        /// <param name="id">The unique identifier for this client.</param>
        /// <returns>A single client object.</returns>
        [HttpGet]
        [Route("api/clients/{id}")]
        public Client GetClientByID(long id)
        {
            return db.GetById(id);
        }

        /// <summary>
        /// Create a client to be stored in the database.
        /// </summary>
        /// <param name="email">The email address of the client.</param>
        /// <param name="password">The encrypted password of the client.</param>
        /// <param name="first_name">The first name of the client.</param>
        /// <param name="last_name">The last name of the client.</param>
        /// <param name="address">The current residing address of the client.</param>
        /// <returns>The single client object that was created. Null otherwise.</returns>
        [HttpPost]
        [Route("api/clients/sign_up")]
        public Client AddClient(string email, string password, string first_name, string last_name, string address)
        {
            Client client = new Client();
            client.email = email;
            client.password = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
            client.first_name = first_name;
            client.last_name = last_name;
            client.address = address;
            db.Add(client);
            return client;
        }

        /// <summary>
        /// Delete client in the database provided their unique client id.
        /// </summary>
        /// <param name="id">The unique identifier for this client.</param>
        [HttpDelete]
        [Route("api/clients/delete/{id}")]
        public void DeleteClient(long id)
        {
            db.Delete(id);
        }

        /// <summary>
        /// Update an existing client provided the unique identifier of the client.
        /// </summary>
        /// <param name="client_id">The unique identifier for this client.</param>
        /// <param name="email">The email address of the client.</param>
        /// <param name="first_name">The first name of the client.</param>
        /// <param name="last_name">The last name of the client.</param>
        /// <param name="address">The current residing address of the client.</param>
        /// <returns>The updated client. Null otherwise.</returns>

        [HttpPut]
        [Route("api/clients/update_client")]
        public Client Update(long client_id, string email, string first_name, string last_name, string address)
        {
            Client client = new Client();
            client.client_id = client_id;
            client.email = email;
            client.first_name = first_name;
            client.last_name = last_name;
            client.address = address;
            db.Update(client);
            return client;
        }

    }
}
