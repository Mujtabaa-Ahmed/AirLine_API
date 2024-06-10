using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Context;
using api.DTOs.Role;
using api.Mapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;

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
        public IActionResult allroles()
        {
            var data = database._Role.ToList().Select(r => r.ToroleDTO());
            return Ok(data);
        }
        [HttpGet("{id}")]
        public IActionResult getrolesbyid([FromRoute]int id)
        {
            var data = database._Role.Find(id);
            if(data == null)
            {
                return NotFound();
            }
            return Ok(data.ToroleDTO());
        }
        
        [HttpPost]
        public IActionResult createRole([FromBody] createRoleDTO rolee)
        {
            var role = rolee.ToCreateRoleDTO();
            database._Role.Add(role);
            database.SaveChanges();
            return CreatedAtAction(nameof(getrolesbyid) , new {id = role.r_id}, role.ToroleDTO());
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult updateRole([FromRoute] int id,[FromBody] updateRoleDTO role)
        {
            var roles = database._Role.FirstOrDefault(a => a.r_id == id);

            if(roles == null)
            {
                return NotFound();
            }else
            {
                roles.r_name = role.r_name;

                database.SaveChanges();
                return Ok(roles.ToroleDTO());
            }
        }
    }
    
 
}