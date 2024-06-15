using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Context;
using api.DTOs.Flight;
using api.Mapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace api.Apicontroller
{
    [Route("api/flight")]
    [ApiController]
    public class Flightcontroller : Controller
    {
        private readonly db_context database;
        public Flightcontroller (db_context data)
        {
            database = data;
        }   

        [HttpGet]
        public async Task<IActionResult> getflight()
        {
            var data = await database.flight.ToListAsync();
            var flight = data.Select(c => c.ToflightDTO());

            return Ok(flight);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getflightbyid([FromRoute] int id)
        {
            var data = await database.flight.FindAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data.ToflightDTO());
        }

        [HttpPost]
        public async Task<IActionResult> creteflight([FromBody] createFlightDTO fDTO)
        {
            var flights = fDTO.ToCreateFlightDTO();
            await database.flight.AddAsync(flights);
            await database.SaveChangesAsync();
            return CreatedAtAction(nameof(getflightbyid) , new {id = flights.f_id}, flights.ToflightDTO());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> updateFlight([FromRoute] int id,[FromBody] updateFlightDTO flight)
        {
            var flights = await database.flight.FirstOrDefaultAsync(a => a.f_id == id);

            if(flights == null)
            {
                return NotFound();
            }else
            {
                flights.f_name = flight.f_name;

                await database.SaveChangesAsync();
                return Ok(flights.ToflightDTO());
            }
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> filghtDelete([FromRoute] int id)
        {
            var DFlight = await database.flight.FirstOrDefaultAsync(a => a.f_id == id);
            if(DFlight == null)
            {
                return NotFound();
            }else
            {
                database.Remove(DFlight);
                await database.SaveChangesAsync();
                return Content("Flight is Deleted");
            }
        }
    }
}