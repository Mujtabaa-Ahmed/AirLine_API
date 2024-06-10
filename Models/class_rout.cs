using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class class_rout
    {
        [Key]
        public int Rout_id { get; set; }
        public string rout_name { get; set; } = string.Empty;
    }
}