using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class class_users
    {
        [Key]
        public int u_id { get; set; }
        public string u_name {get;set;} = string.Empty;
        public string u_mail {get;set;} = string.Empty;
        public string u_pass {get;set;} = string.Empty;
        public int r_id {get;set;} 

    }
}