using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Threading.Tasks;
using AirLine_API.Intrfaces;
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
        private readonly IBookingRepository _bookingRepo;
                
        public Bookingcontroller(db_context data, IBookingRepository bookingRepo)
        {
            _bookingRepo = bookingRepo;
            database = data;
        }

        [HttpGet]
        public async Task<IActionResult> getbookings()
        {
            var data = await _bookingRepo.GetAllAsync();
            var booking = data.Select(c => c.ToBookingDTO());

            return Ok(booking);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getbookingbyid([FromRoute] int id)
        {
            var data = await database.booking.FindAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data.ToBookingDTO());
        }

        [HttpPost]
        public async Task<IActionResult> creteBooking([FromBody] createBookingDTO bDTOs)
        {
            var booking = bDTOs.ToCreateBookingDTO();
            await database.booking.AddAsync(booking);
            await database.SaveChangesAsync();
            return CreatedAtAction(nameof(getbookingbyid) , new {id = booking.b_id}, booking.ToBookingDTO());
        }
       [HttpPut]
       [Route("{id}")]
       public async Task<IActionResult> updateBooking([FromRoute] int id,[FromBody] updateBookingDTO uBDTO)
       {
        var updateBooking = await database.booking.FirstOrDefaultAsync(a => a.b_id == id);

        if(updateBooking == null)
        {
            return NotFound();
        }else
        {
            updateBooking.b_quan = uBDTO.b_quan;
            updateBooking.b_amount = uBDTO.b_amount;
            updateBooking.c_id = uBDTO.c_id;
            updateBooking.s_id = uBDTO.s_id;

            await database.SaveChangesAsync();
            return Ok(updateBooking.ToBookingDTO());
        }
       }
       [HttpDelete]
       [Route("{id}")]
       public async Task<IActionResult> bookingDelete([FromRoute] int id)
       {
        var deleted = await database.booking.FirstOrDefaultAsync(a => a.b_id == id);
        if(deleted == null)
        {
            return NotFound();
        }else
        {
            database.Remove(deleted);
            await database.SaveChangesAsync();
            return Content("Booking record is deleted");
        }
       }
    }
}