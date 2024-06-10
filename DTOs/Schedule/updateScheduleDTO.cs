using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Schedule
{
    public class updateScheduleDTO
    {
         public int f_id {get;set;}
        public int rout_id {get;set;}
        public DateTime s_departure {get;set;} 
        public DateTime s_arival {get;set;} 
    }
}