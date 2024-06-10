using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Bookings;
using api.Models;

namespace api.Mapper
{
    public static class bookingMapper
    {
        public static bookingsDTO ToBookingDTO(this class_bookings book)
        {
            return new bookingsDTO 
            {
                b_id = book.b_id,
                b_quan = book.b_quan,
                b_ammount = book.b_amount,
                c_id = book.c_id,
                s_id = book.s_id
            };
        }
        public static class_bookings ToCreateBookingDTO(this createBookingDTO bDTO)
        {
            return new class_bookings
            {
                b_quan = bDTO.b_quan,
                b_amount = bDTO.b_amount,
                c_id = bDTO.c_id,
                s_id = bDTO.s_id
            };
        } 
    }
}