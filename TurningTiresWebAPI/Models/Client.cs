using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TurningTiresWebAPI.Models
{
    /// <summary>
    /// Represents one instance of a client.
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Unique identifier for the client (primary key). Created from MySQL.
        /// </summary>
        [Key]
        public long client_id { get; set; }
        /// <summary>
        /// The email address of the client.
        /// </summary>
        public string email { get; set; }
        /// <summary>
        /// The first name of the client.
        /// </summary>
        public string first_name { get; set; }
        /// <summary>
        /// The last name of the client.
        /// </summary>
        public string last_name { get; set; }
        /// <summary>
        /// The current residing address of the client.
        /// </summary>
        public string address { get; set; }
    }
}