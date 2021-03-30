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
    /// Retrieve and post various endpoints about appointments. This contains all data revolving around appointments in the database.
    /// </summary>
    public class AppointmentController : ApiController
    {
        private readonly Database.AppointmentDB db;

        /// <summary>
        /// AppointmentController Constructor. Instantiate appointment database.
        /// </summary>
        public AppointmentController()
        {
            db = new Database.AppointmentDB();
        }

        /// <summary>
        /// Get all appointments currently in the database.
        /// </summary>
        /// <returns>List of appointment objects.</returns>
        [HttpGet]
        [Route("api/appointments/all")]
        public List<Appointment> GetAllAppointments()
        {
            return db.GetAll();
        }

        /// <summary>
        /// Get a specific appointment provided a unique appointment id.
        /// </summary>
        /// <param name="id">The unique identifier for this appointment.</param>
        /// <returns>A single appointment object.</returns>
        [HttpGet]
        [Route("api/appointments/{id}")]
        public Appointment GetAppointmentById(long id)
        {
            return db.GetById(id);
        }

        /// <summary>
        /// Get appointment objects provided a unique client id.
        /// </summary>
        /// <param name="id">The unique identifier of the client that represents their appointments.</param>
        /// <returns>List of appointment objects that are registered to the specfic client id.</returns>
        [HttpGet]
        [Route("api/appointments/from_client/{id}")]
        public List<Appointment> GetAppointmentsByClientId(long id)
        {
            return db.GetAppointmentsByClientId(id);
        }

        /// <summary>
        /// Create an appointment to be stored in the database provided a unique client id.
        /// </summary>
        /// <param name="client_id">The unique identifier for the client creating an appointment.</param>
        /// <param name="date">The date when the appointment will take place.</param>
        /// <param name="location">The location where the appointment will take place.</param>
        /// <param name="type">The type of appointment.</param>
        /// <returns>The single appointment object that was created. Null otherwise.</returns>
        [HttpPost]
        [Route("api/appointments/add_appointment")]
        public Appointment AddAppointment(long client_id, string date, string location, string type)
        {
            Appointment appointment = new Appointment();
            appointment.client_id = client_id;
            appointment.date = date;
            appointment.location = location;
            appointment.type = type;
            db.Add(appointment);
            return appointment;
        }

        /// <summary>
        /// Delete appointment in the database provided the unique appointment id.
        /// </summary>
        /// <param name="id">The unique identifier for this appointment.</param>
        [HttpDelete]
        [Route("api/appointments/delete_appointment/{id}")]
        public void DeleteAppointmentById(long id)
        {
            db.Delete(id);
        }

        /// <summary>
        /// Delete appointment in the database provided the unique client id. This will delete all appointments pointed to this client id.
        /// </summary>
        /// <param name="id">The unique client id.</param>
        [HttpDelete]
        [Route("api/appointments/delete_appointment/from_client/{id}")]
        public void DeleteAppointmentByClientId(long id)
        {
            db.DeleteAppointmentByClientId(id);
        }


        // NEEDS IMPLEMENTAION
        /// <summary>
        /// Update appointment information.
        /// </summary>
        [HttpPut]
        [Route("api/appointments/update_appointment")]
        public void UpdateAppointment()
        {

        }

    }
}
