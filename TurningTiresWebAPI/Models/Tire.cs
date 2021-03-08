using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TurningTiresWebAPI.Models
{
    public class Tire
    {
        [Key]
        public long tire_id { get; set; }
        public long vehicle_id { get; set; }
        public int tire_size { get; set; }
        public string type { get; set; }
        public int tread_percentage { get; set; }
    }
}