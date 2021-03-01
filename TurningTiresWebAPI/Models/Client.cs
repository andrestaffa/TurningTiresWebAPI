using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TurningTiresWebAPI.Models
{
    public class Client
    {
        [Key]
        public long client_id { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string address { get; set; }
    }
}