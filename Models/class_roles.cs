using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class class_roles
    {
        [Key]
        public int r_id { get; set; }
        public string r_name { get; set; } = string.Empty;
    }
}