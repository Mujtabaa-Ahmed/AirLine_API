using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly db_context database;
        public Usercontroller(db_context data)
        {
            database = data;
        }
        [HttpGet]
        public async Task<IActionResult> getusers()
        {
            var data = await database.Users.ToListAsync();
            var user = data.Select(u => u.ToUserDTO());
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getusersbyid([FromRoute] int id)
        {
            var data = await database.Users.FindAsync(id);
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
            await database.Users.AddAsync(user);
            await database.SaveChangesAsync();
            return CreatedAtAction(nameof(getusersbyid) , new {id = user.u_id}, user.ToUserDTO());
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> updateUser([FromRoute] int id,[FromBody] updateUserDTO user)
        {
            var users = await database.Users.FirstOrDefaultAsync(a => a.u_id == id);
            if(users == null)
            {
                return NotFound();
            }else
            {
                users.u_name = user.u_name;
                users.u_mail = user.u_mail;
                users.u_pass = user.u_pass;
                users.r_id = user.r_id;

                await database.SaveChangesAsync();

                return Ok(users.ToUserDTO());
            }
        }
    }
}