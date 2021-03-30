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
            private string connectionString = @"server=sql3.freemysqlhosting.net;port=3306;uid=sql3402161;pwd=wszULCLN5G;database=sql3402161";

            public List<Client> GetAll()
            {
                using (IDbConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = @"call GetAllClients()";
                    List<Client> clients = connection.Query<Client>(sql).ToList();
                    return clients;
                }
            }

            public Client GetById(long id)
            {
                using (IDbConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = @"call GetClientById(" + id + ")";
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
                    string sql = @"call DeleteClientById(" + id + ")";
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
            private string connectionString = @"server=sql3.freemysqlhosting.net;port=3306;uid=sql3402161;pwd=wszULCLN5G;database=sql3402161";

            public List<Appointment> GetAll()
            {
                using (IDbConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = @"call GetAllAppointments()";
                    List<Appointment> appointments = connection.Query<Appointment>(sql).ToList();
                    return appointments;
                }
            }

            public Appointment GetById(long id)
            {
                using (IDbConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = @"call GetAppointmentById(" + id + ")";
                    Appointment appointment = connection.Query<Appointment>(sql).FirstOrDefault();
                    return appointment;
                }
            }

            public List<Appointment> GetAppointmentsByClientId(long id)
            {
                using (IDbConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = @"call GetAppointmentByClientId(" + id + ")";
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
                    string sql = @"call DeleteAppointmentById(" + id + ")";
                    connection.Execute(sql);
                }
            }

            public void DeleteAppointmentByClientId(long id)
            {
                using (IDbConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = @"call DeleteAppointmentByClientId(" + id + ")";
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

            private string connectionString = @"server=sql3.freemysqlhosting.net;port=3306;uid=sql3402161;pwd=wszULCLN5G;database=sql3402161";

            public List<Vehicle> GetAll()
            {
                using (IDbConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = @"call GetAllVehicles()";
                    List<Vehicle> vehicles = connection.Query<Vehicle>(sql).ToList();
                    return vehicles;
                }
            }

            public Vehicle GetById(long id)
            {
                using (IDbConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = @"call GetVehicleById(" + id + ")";
                    Vehicle vehicle = connection.Query<Vehicle>(sql).FirstOrDefault();
                    return vehicle;
                }
            }

            public List<Vehicle> GetVehiclesByClientId(long id)
            {
                using (IDbConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = @"call GetVehicleByClientId(" + id + ")";
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
                    string sql = @"call DeleteVehicleById(" + id + ")";
                    connection.Execute(sql);
                }
            }

            public void DeleteVehicleByClientId(long id)
            {
                using (IDbConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = @"call DeleteVehicleByClientId(" + id + ")";
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
            private string connectionString = @"server=sql3.freemysqlhosting.net;port=3306;uid=sql3402161;pwd=wszULCLN5G;database=sql3402161";

            public List<Tire> GetAll()
            {
                using (IDbConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = @"call GetAllTires()";
                    List<Tire> tires = connection.Query<Tire>(sql).ToList();
                    return tires;
                }
            }

            public Tire GetById(long id)
            {
                using (IDbConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = @"call GetTireById(" + id + ")";
                    Tire tire = connection.Query<Tire>(sql).FirstOrDefault();
                    return tire;
                }
            }

            public List<Tire> GetTireByVehicleId(long id)
            {
                using (IDbConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = @"call GetTireByVehicleId(" + id + ")";
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
                    string sql = @"call DeleteTireById(" + id + ")";
                    connection.Execute(sql);
                }
            }

            public void DeleteTireByVehicleId(long id)
            {
                using (IDbConnection connection = new MySqlConnection(connectionString))
                {
                    string sql = @"call DeleteTireByVehicleId(" + id + ")";
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