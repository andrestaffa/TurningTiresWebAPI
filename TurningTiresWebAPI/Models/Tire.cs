using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TurningTiresWebAPI.Models
{
    /// <summary>
    /// Represents one instance of a tire.
    /// </summary>
    public class Tire
    {
        /// <summary>
        /// Unique identifier for the tire (primary key). Created from MySQL.
        /// </summary>
        [Key]
        public long tire_id { get; set; }
        /// <summary>
        /// Unique identifier for the vehicle (reference key). Created from MySQL.
        /// </summary>
        public long vehicle_id { get; set; }
        /// <summary>
        /// The tire size of the registered vehicle.
        /// </summary>
        public int tire_size { get; set; }
        /// <summary>
        /// The type of tire of the registered vehicle.
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// The tread percentage of all four tires of the registered vehicle.
        /// </summary>
        public int tread_percentage { get; set; }
    }
}