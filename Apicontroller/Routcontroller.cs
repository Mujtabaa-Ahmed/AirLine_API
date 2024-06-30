using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirLine_API.Intrfaces;
using api.Context;
using api.DTOs.Rout;
using api.Mapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Apicontroller
{
    [Route("api/rout")]
    [ApiController]
    public class Routcontroller : Controller
    {
        private readonly db_context database;
        private readonly IRoutRepository _routRepo;
        public Routcontroller(db_context data,IRoutRepository repo)
        {
            database = data;
            _routRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> getrout()
        {
            var data = await database.rout.ToListAsync();
            var rout = data.Select(c => c.ToroutDTO());

            return Ok(rout);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getroutbyid([FromRoute] int id)
        {
            var data = await database.rout.FindAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data.ToroutDTO());
        }
  
        [HttpPost]
        public async Task<IActionResult> createrout([FromBody] createRoutDTO roDTO)
        {
            var rout = roDTO.ToCreateRoutDTO();
            await database.rout.AddAsync(rout);
            await database.SaveChangesAsync();
            return CreatedAtAction(nameof(getroutbyid) , new{id = rout.Rout_id},rout.ToroutDTO());
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> updateRoute([FromRoute] int id, [FromBody] updateRoutDTO rout)
        {
            var routs = await database.rout.FirstOrDefaultAsync(a => a.Rout_id == id);
            if(routs == null)
            {
                return NotFound();
            }else
            {
                routs.rout_name = rout.rout_name;

                await database.SaveChangesAsync();
                return Ok(routs.ToroutDTO());
            }
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteRoute([FromRoute] int id)
        {
            var deleteR = await database.rout.FirstOrDefaultAsync(a => a.Rout_id == id);

            if(deleteR == null)
            {
                return NotFound();
            }else
            {
                database.Remove(deleteR);
                await database.SaveChangesAsync();
                return Content("Role is deleted");
            }
        }
    }
}