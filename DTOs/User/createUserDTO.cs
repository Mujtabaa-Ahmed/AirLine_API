using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.User
{
    public class createUserDTO
    {
         public string u_name {get;set;} = string.Empty;
        public string u_mail {get;set;} = string.Empty;
        public string u_pass {get;set;} = string.Empty;
        public int r_id {get;set;} 
    }
}