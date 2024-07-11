using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AirLine_API.Intrfaces;
using api.Context;
using api.DTOs.User;
using api.Mapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Apicontroller
{
    [Route("api/user")]
    [ApiController]
    public class Usercontroller : Controller
    {
        private readonly IUserRepository _userRepo;
        public Usercontroller(db_context data, IUserRepository repo)
        {
            _userRepo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> getusers()
        {
            var data = await _userRepo.GetAllAsync();
            var user = data.Select(u => u.ToUserDTO());
            return Ok(user);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getusersbyid([FromRoute] int id)
        {
            var data = await _userRepo.GetByIdAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data.ToUserDTO());
        }

        [HttpPost]
        public async Task<IActionResult> createuser([FromBody] createUserDTO uDTO)
        {
            var user = uDTO.ToCreateUserDTO();
            await _userRepo.CreateAsync(user);
            return CreatedAtAction(nameof(getusersbyid) , new {id = user.u_id}, user.ToUserDTO());
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> updateUser([FromRoute] int id,[FromBody] updateUserDTO user)
        {
            var users = await _userRepo.UpdateAsync(id,user);
            if(users == null)
            {
                return NotFound();
            }
                return Ok(users.ToUserDTO());
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            var Duser = await _userRepo.DeleteAsync(id);
            if(Duser == null)
            {
                return NotFound();
            }else
            {
                return Content("User is deleted");
            }
        }
    }
}