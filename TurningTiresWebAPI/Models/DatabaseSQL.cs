using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace TurningTiresWebAPI.Models
{
    public class Database
    {

        private string connectionString = @"server=127.0.0.1;port=5000;uid=root;pwd=Scarfaceiscool1!;database=turningtiresdb";

        // =========== Client Operations ===============

        // GET COMMANDS

        public List<Client> GetAllClients()
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = @"select * from client";
                List<Client> clients = connection.Query<Client>(sql).ToList();
                return clients;
            }
        }

        public Client GetClientById(long id)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = @"select * from client where client_id=" + id;
                Client client = connection.Query<Client>(sql).FirstOrDefault();
                return client;
            }
        }


        // POSTING, UPDATING and DELETING COMMANDS

        public void AddClient(Client client)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                client.client_id = (long)Math.Abs(Guid.NewGuid().GetHashCode());
                string sql = @"insert into client values(@client_id, @email, @first_name, @last_name, @address)";
                connection.Execute(sql, client);
            }
        }

        public void DeleteClient(long id)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                string sql = @"delete from client where client_id=" + id;
                connection.Execute(sql);
            }
        }

    }
}