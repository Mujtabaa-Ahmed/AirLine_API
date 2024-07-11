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
        private readonly IRoutRepository _routRepo;
        public Routcontroller(IRoutRepository repo)
        {
            _routRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> getrout()
        {
            var data = await _routRepo.GetAllAsync();
            var rout = data.Select(c => c.ToroutDTO());

            return Ok(rout);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getroutbyid([FromRoute] int id)
        {
            var data = await _routRepo.GetByIdAsync(id);
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
            await _routRepo.CreateAsync(rout);
            return CreatedAtAction(nameof(getroutbyid) , new{id = rout.Rout_id},rout.ToroutDTO());
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> updateRoute([FromRoute] int id, [FromBody] updateRoutDTO rout)
        {
            var routs = await _routRepo.UpdateAsync(id,rout);
            if(routs == null)
            {
                return NotFound();
            }
                return Ok(routs.ToroutDTO());
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteRoute([FromRoute] int id)
        {
            var deleteR = await _routRepo.DeleteAsync(id);

            if(deleteR == null)
            {
                return NotFound();
            }
                return Content("Role is deleted");
        }
    }
}