using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirLine_API.Intrfaces;
using api.Context;
using api.DTOs.Schedule;
using api.Mapper;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;

namespace api.Apicontroller
{
    [Route("api/schedule")]
    [ApiController]
    public class Schedulecontroller : Controller
    {
    
    
        private readonly IScheduleRepository _sheduleRepo;        
        public Schedulecontroller(IScheduleRepository repo)
        {
            _sheduleRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> getschedule()
        {
            var data = await _sheduleRepo.GetAllAsync();
            var schedules = data.Select(c => c.ToscheduleDTO());

            return Ok(schedules);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getschedulebyid([FromRoute] int id)
        {
            var data = await _sheduleRepo.GetByIdAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data.ToscheduleDTO());
        }

        [HttpPost]
        public async Task<IActionResult> createSchedule([FromBody] createScheduleRequestDTO schedule)
        {
            var schedules = schedule.ToCreateRequestScheduleDTO();
            await _sheduleRepo.CreateAsync(schedules);
            return CreatedAtAction(nameof(getschedulebyid) , new {id = schedules.s_id}, schedules.ToscheduleDTO());
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> updateSchedules([FromRoute] int id, [FromBody] updateScheduleDTO schedule)
        {
            var schedules = await _sheduleRepo.UpdateAsync(id,schedule);
            if(schedules == null)
            {
                return NotFound();
            }
                return Ok(schedules.ToscheduleDTO());
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteShedules([FromRoute] int id)
        {
            var deleteS = await _sheduleRepo.DeleteAsync(id);
             if(deleteS == null)
             {
                return NotFound();
             }
                return Content("deleted");
        }
    }
}