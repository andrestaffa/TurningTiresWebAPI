using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace TurningTiresWebAPI.Models
{

    interface IDatabase<T>
    {
        List<T> GetAll();
        T GetById(long id);
        T Add(T type);
        void Delete(long id);
        T Update(T type);
    }

    public class Database
    {

        public class ClientDB : IDatabase<Client>
        {
            private string connectionString = @"server=127.0.0.1;port=5000;uid=root;pwd=Scarfaceiscool1!;database=turningtiresdb";

            public List<Client> GetAll()
            {
                using (IDbConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = @"select * from client";
                    List<Client> clients = connection.Query<Client>(sql).ToList();
                    return clients;
                }
            }

            public Client GetById(long id)
            {
                using (IDbConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = @"select * from client where client_id=" + id;
                    Client client = connection.Query<Client>(sql).FirstOrDefault();
                    return client;
                }
            }

            public Client Add(Client client)
            {
                using (IDbConnection connection = new MySqlConnection(connectionString))
                {
                    client.client_id = (long)Math.Abs(Guid.NewGuid().GetHashCode());
                    string sql = @"insert into client values(@client_id, @email, @first_name, @last_name, @address)";
                    connection.Execute(sql, client);
                    return client;
                }
            }

            public void Delete(long id)
            {
                using (IDbConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = @"delete from client where client_id=" + id;
                    connection.Execute(sql);
                }
            }

            public Client Update(Client client)
            {
                throw new NotImplementedException();
            }
        }

        public class AppointmentDB : IDatabase<Appointment>
        {
            private string connectionString = @"server=127.0.0.1;port=5000;uid=root;pwd=Scarfaceiscool1!;database=turningtiresdb";

            public List<Appointment> GetAll()
            {
                using (IDbConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = @"select * from appointment";
                    List<Appointment> appointments = connection.Query<Appointment>(sql).ToList();
                    return appointments;
                }
            }

            public Appointment GetById(long id)
            {
                using (IDbConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = @"select * from appointment where appointment_id=" + id;
                    Appointment appointment = connection.Query<Appointment>(sql).FirstOrDefault();
                    return appointment;
                }
            }

            public List<Appointment> GetAppointmentsByClientId(long id)
            {
                using (IDbConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = @"select * from appointment where client_id=" + id;
                    List<Appointment> appointment = connection.Query<Appointment>(sql).ToList();
                    return appointment;
                }
            }

            public Appointment Add(Appointment appointment)
            {
                using (IDbConnection connection = new MySqlConnection(connectionString))
                {
                    appointment.appointment_id = (long)Math.Abs(Guid.NewGuid().GetHashCode());
                    string sql = @"insert into appointment values(@appointment_id, @client_id, @date, @location, @type)";
                    connection.Execute(sql, appointment);
                    return appointment;
                }
            }

            public void Delete(long id)
            {
                using (IDbConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = @"delete from appointment where appointment_id=" + id;
                    connection.Execute(sql);
                }
            }

            public void DeleteAppointmentByClientId(long id)
            {
                using (IDbConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = @"delete from appointment where client_id=" + id;
                    connection.Execute(sql);
                }
            }

            public Appointment Update(Appointment appointment)
            {
                throw new NotImplementedException();
            }
        }

        public class VehicleDB : IDatabase<Vehicle>
        {

            private string connectionString = @"server=127.0.0.1;port=5000;uid=root;pwd=Scarfaceiscool1!;database=turningtiresdb";

            public List<Vehicle> GetAll()
            {
                using (IDbConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = @"select * from vehicle";
                    List<Vehicle> vehicles = connection.Query<Vehicle>(sql).ToList();
                    return vehicles;
                }
            }

            public Vehicle GetById(long id)
            {
                using (IDbConnection connection = new MySqlConnection(connectionString))
                {
                    string sql =  @"select * from vehicle where vehicle_id=" + id;
                    Vehicle vehicle = connection.Query<Vehicle>(sql).FirstOrDefault();
                    return vehicle;
                }
            }

            public List<Vehicle> GetVehiclesByClientId(long id)
            {
                using (IDbConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = @"select * from vehicle where client_id=" + id;
                    List<Vehicle> vehicles = connection.Query<Vehicle>(sql).ToList();
                    return vehicles;
                }
            }

            public Vehicle Add(Vehicle vehicle)
            {
                using (IDbConnection connection = new MySqlConnection(connectionString))
                {
                    vehicle.vehicle_id = (long)Math.Abs(Guid.NewGuid().GetHashCode());
                    string sql = @"insert into vehicle values(@vehicle_id, @client_id, @model, @tire_size)";
                    connection.Execute(sql, vehicle);
                    return vehicle;
                }
            }

            public void Delete(long id)
            {
                using (IDbConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = @"delete from vehicle where vehicle_id=" + id;
                    connection.Execute(sql);
                }
            }

            public void DeleteVehicleByClientId(long id)
            {
                using (IDbConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = @"delete from vehicle where client_id=" + id;
                    connection.Execute(sql);
                }
            }

            public Vehicle Update(Vehicle vehicle)
            {
                throw new NotImplementedException();
            }
        }

        public class TireDB : IDatabase<Tire>
        {
            private string connectionString = @"server=127.0.0.1;port=5000;uid=root;pwd=Scarfaceiscool1!;database=turningtiresdb";

            public List<Tire> GetAll()
            {
                using (IDbConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = @"select * from tire";
                    List<Tire> tires = connection.Query<Tire>(sql).ToList();
                    return tires;
                }
            }

            public Tire GetById(long id)
            {
                using (IDbConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = @"select * from tire where tire_id=" + id;
                    Tire tire = connection.Query<Tire>(sql).FirstOrDefault();
                    return tire;
                }
            }

            public List<Tire> GetTireByVehicleId(long id)
            {
                using (IDbConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = @"select * from tire where vehicle_id=" + id;
                    List<Tire> tires = connection.Query<Tire>(sql).ToList();
                    return tires;
                }
            }

            public Tire Add(Tire tire)
            {
                using (IDbConnection connection = new MySqlConnection(connectionString))
                {
                    tire.tire_id = (long)Math.Abs(Guid.NewGuid().GetHashCode());
                    string sql = @"insert into tire values(@tire_id, @vehicle_id, @tire_size, @type, @tread_percentage)";
                    connection.Execute(sql, tire);
                    return tire;
                }
            }

            public void Delete(long id)
            {
                using (IDbConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = @"delete from tire where tire_id=" + id;
                    connection.Execute(sql);
                }
            }

            public void DeleteTireByVehicleId(long id)
            {
                using (IDbConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = @"delete from tire where vehicle_id=" + id;
                    connection.Execute(sql);
                }
            }

            public Tire Update(Tire tire)
            {
                throw new NotImplementedException();
            }
        }


    }
}