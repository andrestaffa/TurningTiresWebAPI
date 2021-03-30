using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TurningTiresWebAPI.Models
{
    /// <summary>
    /// Represents one instance of a vehicle.
    /// </summary>
    public class Vehicle
    {
        /// <summary>
        /// Unique identifier for the vehicle (primary key). Created from MySQL.
        /// </summary>
        [Key]
        public long vehicle_id { get; set; }
        /// <summary>
        /// Unique identifier for the client (reference key). Created from MySQL.
        /// </summary>
        public long client_id { get; set; }
        /// <summary>
        /// The make and model of the vehicle.
        /// </summary>
        public string model { get; set; }
        /// <summary>
        /// The tire size of the vehicle.
        /// </summary>
        public int tire_size { get; set; }
    }
}