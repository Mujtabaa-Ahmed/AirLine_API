using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Role;

namespace api.DTOs.UserDTO
{
    public class userDTO
    {
          
        public int u_id { get; set; }
        public string u_name {get;set;} = string.Empty;
        public string u_mail {get;set;} = string.Empty;
        public string u_pass {get;set;} = string.Empty;
        public int r_id {get;set;}
    }
}