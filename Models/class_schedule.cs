using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class class_schedule
    {
        [Key]
        public int s_id {get;set;}
        public int f_id {get;set;}
        public int rout_id {get;set;}
        public DateTime s_departure {get;set;} 
        public DateTime s_arival {get;set;} 
    }
}