using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class class_classes
    {
        [Key]
        public int c_id { get; set; }
        public string c_name { get; set; } = string.Empty;
        public int c_price { get; set; }
    }
}