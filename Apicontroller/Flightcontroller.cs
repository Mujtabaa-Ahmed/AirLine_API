using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Context;
using api.DTOs.Flight;
using api.Mapper;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult getflight()
        {
            var data = database.flight.ToList().Select(c => c.ToflightDTO());

            return Ok(data);
        }
        [HttpGet("{id}")]
        public IActionResult getflightbyid([FromRoute] int id)
        {
            var data = database.flight.Find(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data.ToflightDTO());
        }

        [HttpPost]
        public IActionResult creteflight([FromBody] createFlightDTO fDTO)
        {
            var flights = fDTO.ToCreateFlightDTO();
            database.flight.Add(flights);
            database.SaveChanges();
            return CreatedAtAction(nameof(getflightbyid) , new {id = flights.f_id}, flights.ToflightDTO());
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult updateFlight([FromRoute] int id,[FromBody] updateFlightDTO flight)
        {
            var flights = database.flight.FirstOrDefault(a => a.f_id == id);

            if(flights == null)
            {
                return NotFound();
            }else
            {
                flights.f_name = flight.f_name;

                database.SaveChanges();
                return Ok(flights.ToflightDTO());
            }
        }
    }
}