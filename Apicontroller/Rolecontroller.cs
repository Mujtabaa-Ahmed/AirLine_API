using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirLine_API.Intrfaces;
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
        private readonly IRoleRepository _roleRepo;
        public Rolecontroller(IRoleRepository repo)
        {
            _roleRepo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> allroles()
        {
            var data = await _roleRepo.GetAllAsync();
            var role = data.Select(r => r.ToroleDTO());
            return Ok(role);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getrolesbyid([FromRoute]int id)
        {
            var data = await _roleRepo.GetByIdAsync(id);
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
            await _roleRepo.CreateAsync(role);
            return CreatedAtAction(nameof(getrolesbyid) , new {id = role.r_id}, role.ToroleDTO());
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> updateRole([FromRoute] int id,[FromBody] updateRoleDTO role)
        {
            var roles = await _roleRepo.UpdateAsync(id,role);

            if(roles == null)
            {
                return NotFound();
            }
                return Ok(roles.ToroleDTO());
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> RoleDelete([FromRoute] int id)
        {
            var DRole = await _roleRepo.DeleteAsync(id);
            if(DRole == null)
            {
                return NotFound();
            }   
            return Content("Role is deleted");
        }
    }
}