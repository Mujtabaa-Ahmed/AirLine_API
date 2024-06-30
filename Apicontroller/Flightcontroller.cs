using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirLine_API.Intrfaces;
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
        private readonly IFlightRepository _FlightRepo;
        public Flightcontroller (IFlightRepository flight)
        {
            _FlightRepo = flight;
        }   

        [HttpGet]
        public async Task<IActionResult> getflight()
        {
            var data = await _FlightRepo.GetAllAsync();
            var flight = data.Select(c => c.ToflightDTO());

            return Ok(flight);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getflightbyid([FromRoute] int id)
        {
            var data = await _FlightRepo.GetByIdAsync(id);
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
            await _FlightRepo.CreateAsync(flights);
            return CreatedAtAction(nameof(getflightbyid) , new {id = flights.f_id}, flights.ToflightDTO());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> updateFlight([FromRoute] int id,[FromBody] updateFlightDTO flight)
        {
            var flights = await _FlightRepo.UpdateAsync(id,flight);

            if(flights == null)
            {
                return NotFound();
            }
                return Ok(flights.ToflightDTO());
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> filghtDelete([FromRoute] int id)
        {
            var DFlight = await _FlightRepo.DeleteAsync(id);
            if(DFlight == null)
            {
                return NotFound();
            }
                return Content("Flight is Deleted");
            
        }
    }
}