using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    
    
       private readonly db_context database;
                
        public Schedulecontroller(db_context data)
        {
            database = data;
        }

        [HttpGet]
        public async Task<IActionResult> getschedule()
        {
            var data = await database.schedule.ToListAsync();
            var schedules = data.Select(c => c.ToscheduleDTO());

            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getschedulebyid([FromRoute] int id)
        {
            var data = await database.schedule.FindAsync(id);
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
            await database.schedule.AddAsync(schedules);
            await database.SaveChangesAsync();
            return CreatedAtAction(nameof(getschedulebyid) , new {id = schedules.s_id}, schedules.ToscheduleDTO());
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> updateSchedules([FromRoute] int id, [FromBody] updateScheduleDTO schedule)
        {
            var schedules = await database.schedule.FirstOrDefaultAsync(a => a.s_id == id);
            if(schedules == null)
            {
                return NotFound();
            }else
            {
                schedules.f_id = schedule.f_id;
                schedules.rout_id = schedule.rout_id;
                schedules.s_arival = schedule.s_arival;
                schedules.s_departure = schedule.s_departure;

                await database.SaveChangesAsync();
                return Ok(schedules.ToscheduleDTO());
            }
        }
        public async Task<IActionResult> DeleteShedules([FromRoute] int id)
        {
            var deleteS = await database.schedule.FirstOrDefaultAsync(a => a.s_id == id);
             if(deleteS == null)
             {
                return NotFound();
             }else
             {
                database.Remove(deleteS);
                await database.SaveChangesAsync();
                return Content("deleted");
             }
        }
    }
}