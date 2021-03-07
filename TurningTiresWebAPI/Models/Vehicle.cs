using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TurningTiresWebAPI.Models
{
    public class Vehicle
    {
        [Key]
        public long vehicle_id { get; set; }
        public long client_id { get; set; }
        public string model { get; set; }
        public int tire_size { get; set; }
    }
}