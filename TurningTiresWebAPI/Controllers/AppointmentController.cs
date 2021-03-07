using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TurningTiresWebAPI.Models;

namespace TurningTiresWebAPI.Controllers
{
    public class AppointmentController : ApiController
    {

        private readonly Database.AppointmentDB db;

        public AppointmentController()
        {
            db = new Database.AppointmentDB();
        }

        [HttpGet]
        [Route("api/appointments/all")]
        public List<Appointment> GetAppointments()
        {
            return db.GetAll();
        }

        [HttpGet]
        [Route("api/appointments/{id}")]
        public Appointment GetAppointmentById(long id)
        {
            return db.GetById(id);
        }

        [HttpGet]
        [Route("api/appointments/from_client/{id}")]
        public List<Appointment> GetAppointmentsByClientId(long id)
        {
            return db.GetAppointmentsByClientId(id);
        }

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

        [HttpDelete]
        [Route("api/appointments/delete_appointment/{id}")]
        public void DeleteAppointmentById(long id)
        {
            db.Delete(id);
        }

        [HttpDelete]
        [Route("api/appointments/delete_appointment/from_client/{id}")]
        public void DeleteAppointmentByClientId(long id)
        {
            db.DeleteAppointmentByClientId(id);
        }


        // NEEDS IMPLEMENTAION
        [HttpPut]
        [Route("api/appointments/update_appointment")]
        public void UpdateAppointment()
        {

        }

    }
}
