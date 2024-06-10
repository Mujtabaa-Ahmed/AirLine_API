using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Context;
using api.DTOs.Schedule;
using api.Mapper;
using api.Models;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult getschedule()
        {
            var data = database.schedule.ToList().Select(c => c.ToscheduleDTO());

            return Ok(data);
        }
        [HttpGet("{id}")]
        public IActionResult getschedulebyid([FromRoute] int id)
        {
            var data = database.schedule.Find(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data.ToscheduleDTO());
        }

        [HttpPost]
        public IActionResult createSchedule([FromBody] createScheduleRequestDTO schedule)
        {
            var schedules = schedule.ToCreateRequestScheduleDTO();
            database.schedule.Add(schedules);
            database.SaveChanges();
            return CreatedAtAction(nameof(getschedulebyid) , new {id = schedules.s_id}, schedules.ToscheduleDTO());
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult updateSchedules([FromRoute] int id, [FromBody] updateScheduleDTO schedule)
        {
            var schedules = database.schedule.FirstOrDefault(a => a.s_id == id);
            if(schedules == null)
            {
                return NotFound();
            }else
            {
                schedules.f_id = schedule.f_id;
                schedules.rout_id = schedule.rout_id;
                schedules.s_arival = schedule.s_arival;
                schedules.s_departure = schedule.s_departure;

                database.SaveChanges();
                return Ok(schedules.ToscheduleDTO());
            }
        }
    }
}