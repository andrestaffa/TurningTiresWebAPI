using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TurningTiresWebAPI.Models
{
    /// <summary>
    /// Represents one instance of an appointment.
    /// </summary>
    public class Appointment
    {
        /// <summary>
        /// Unique identifier for the appointment (primary key). Created from MySQL.
        /// </summary>
        [Key]
        public long appointment_id { get; set; }
        /// <summary>
        /// Unique identifier for the client (reference key). Created from MySQL.
        /// </summary>
        public long client_id { get; set; }
        /// <summary>
        /// The date when the appointment will take place.
        /// </summary>
        public string date { get; set; }
        /// <summary>
        /// The location where the appointment will take place.
        /// </summary>
        public string location { get; set; }
        /// <summary>
        /// The type of appointment.
        /// </summary>
        public string type { get; set; }
    }
}