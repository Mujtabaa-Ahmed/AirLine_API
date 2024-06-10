using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using api.Context;
using api.DTOs.Bookings;
using api.Mapper;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Apicontroller
{
    [Route("api/booking")]
    [ApiController]
    public class Bookingcontroller : Controller
    {
        private readonly db_context database;
                
        public Bookingcontroller(db_context data)
        {
            database = data;
        }

        [HttpGet]
        public IActionResult getbookings()
        {
            var data = database.booking.ToList().Select(c => c.ToBookingDTO());

            return Ok(data);
        }
        [HttpGet("{id}")]
        public IActionResult getbookingbyid([FromRoute] int id)
        {
            var data = database.booking.Find(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data.ToBookingDTO());
        }

        [HttpPost]
        public IActionResult creteBooking([FromBody] createBookingDTO bDTOs)
        {
            var booking = bDTOs.ToCreateBookingDTO();
            database.booking.Add(booking);
            database.SaveChanges();
            return CreatedAtAction(nameof(getbookingbyid) , new {id = booking.b_id}, booking.ToBookingDTO());
        }
       [HttpPut]
       [Route("{id}")]
       public IActionResult updateBooking([FromRoute] int id,[FromBody] updateBookingDTO uBDTO)
       {
        var updateBooking = database.booking.FirstOrDefault(a => a.b_id == id);

        if(updateBooking == null)
        {
            return NotFound();
        }else
        {
            updateBooking.b_quan = uBDTO.b_quan;
            updateBooking.b_amount = uBDTO.b_amount;
            updateBooking.c_id = uBDTO.c_id;
            updateBooking.s_id = uBDTO.s_id;

            database.SaveChanges();
            return Ok(updateBooking.ToBookingDTO());
        }

       }
    }
}