using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Context;
using api.DTOs.Role;
using api.Mapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;

namespace api.Apicontroller
{
    [Route("api/role")]
    [ApiController]
    public class Rolecontroller : Controller
    {
        private readonly db_context database;

        public Rolecontroller(db_context data)
        {
            database = data;
        }

        [HttpGet]
        public async Task<IActionResult> allroles()
        {
            var data = await database._Role.ToListAsync();
            var role = data.Select(r => r.ToroleDTO());
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getrolesbyid([FromRoute]int id)
        {
            var data = await database._Role.FindAsync(id);
            if(data == null)
            {
                return NotFound();
            }
            return Ok(data.ToroleDTO());
        }
        
        [HttpPost]
        public async Task<IActionResult> createRole([FromBody] createRoleDTO rolee)
        {
            var role = rolee.ToCreateRoleDTO();
            await database._Role.AddAsync(role);
            await database.SaveChangesAsync();
            return CreatedAtAction(nameof(getrolesbyid) , new {id = role.r_id}, role.ToroleDTO());
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> updateRole([FromRoute] int id,[FromBody] updateRoleDTO role)
        {
            var roles = await database._Role.FirstOrDefaultAsync(a => a.r_id == id);

            if(roles == null)
            {
                return NotFound();
            }else
            {
                roles.r_name = role.r_name;

                 await database.SaveChangesAsync();
                return Ok(roles.ToroleDTO());
            }
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> RoleDelete([FromRoute] int id)
        {
            var DRole = await database._Role.FirstOrDefaultAsync(a => a.r_id == id);
            if(DRole == null)
            {
                return NotFound();
            }else
            {
                database.Remove(DRole);
                await database.SaveChangesAsync();
                return Content("Role is deleted");
            }
        }
    }
    
 
}