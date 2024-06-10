using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.Bookings
{
    public class updateBookingDTO
    {
        public int b_quan {get;set;}
        public int b_amount {get;set;}
        public int c_id {get;set;}
        public int s_id {get;set;}
    }
}