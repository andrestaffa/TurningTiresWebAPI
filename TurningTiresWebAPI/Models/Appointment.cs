using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TurningTiresWebAPI.Models
{
    public class Appointment
    {
        [Key]
        public long appointment_id { get; set; }
        [Key]
        public long client_id { get; set; }
        public string date { get; set; }
        public string location { get; set; }
        public string type { get; set; }
    }
}