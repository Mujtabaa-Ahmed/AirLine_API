using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class class_flight
    {
        [Key]
        public int f_id {get;set;}
        public string f_name {get;set;} = string.Empty;
    }
}