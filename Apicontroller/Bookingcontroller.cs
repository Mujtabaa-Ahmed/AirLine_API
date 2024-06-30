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
        private readonly IBookingRepository _bookingRepo;
                
        public Bookingcontroller(IBookingRepository bookingRepo)
        {
            _bookingRepo = bookingRepo;
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
            var data = await _bookingRepo.GetByIdAsync(id);
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
            await _bookingRepo.CreateAsync(booking);
            return CreatedAtAction(nameof(getbookingbyid) , new {id = booking.b_id}, booking.ToBookingDTO());
        }
       [HttpPut]
       [Route("{id}")]
       public async Task<IActionResult> updateBooking([FromRoute] int id,[FromBody] updateBookingDTO uBDTO)
       {
        var updateBooking = await _bookingRepo.UpdateAsync(id,uBDTO);
        if(updateBooking == null)
        {
            return NotFound();
        }
            return Ok(updateBooking.ToBookingDTO());
       }
       [HttpDelete]
       [Route("{id}")]
       public async Task<IActionResult> bookingDelete([FromRoute] int id)
       {
        var deleted = await _bookingRepo.DeleteAsync(id);
        if(deleted == null)
        {
            return NotFound();
        }

        return Content("Booking record is deleted");
        
       }
    }
}