using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Context;
using api.DTOs.Rout;
using api.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace api.Apicontroller
{
    [Route("api/rout")]
    [ApiController]
    public class Routcontroller : Controller
    {
       private readonly db_context database;
                
        public Routcontroller(db_context data)
        {
            database = data;
        }

        [HttpGet]
        public IActionResult getrout()
        {
            var data = database.rout.ToList().Select(c => c.ToroutDTO());

            return Ok(data);
        }
        [HttpGet("{id}")]
        public IActionResult getroutbyid([FromRoute] int id)
        {
            var data = database.rout.Find(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data.ToroutDTO());
        }
  
        [HttpPost]
        public IActionResult createrout([FromBody] createRoutDTO roDTO)
        {
            var rout = roDTO.ToCreateRoutDTO();
            database.rout.Add(rout);
            database.SaveChanges();
            return CreatedAtAction(nameof(getroutbyid) , new{id = rout.Rout_id},rout.ToroutDTO());
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult updateRoute([FromRoute] int id, [FromBody] updateRoutDTO rout)
        {
            var routs = database.rout.FirstOrDefault(a => a.Rout_id == id);
            if(routs == null)
            {
                return NotFound();
            }else
            {
                routs.rout_name = rout.rout_name;

                database.SaveChanges();
                return Ok(routs.ToroutDTO());
            }
        }
    }
}