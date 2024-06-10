using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Context;
using api.DTOs.User;
using api.Mapper;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult getusers()
        {
            var data = database.Users.ToList().Select(u => u.ToUserDTO());
            return Ok(data);
        }
        [HttpGet("{id}")]
        public IActionResult getusersbyid([FromRoute] int id)
        {
            var data = database.Users.Find(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data.ToUserDTO());
        }

        [HttpPost]
        public IActionResult createuser([FromBody] createUserDTO uDTO)
        {
            var user = uDTO.ToCreateUserDTO();
            database.Users.Add(user);
            database.SaveChanges();
            return CreatedAtAction(nameof(getusersbyid) , new {id = user.u_id}, user.ToUserDTO());
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult updateUser([FromRoute] int id,[FromBody] updateUserDTO user)
        {
            var users = database.Users.FirstOrDefault(a => a.u_id == id);
            if(users == null)
            {
                return NotFound();
            }else
            {
                users.u_name = user.u_name;
                users.u_mail = user.u_mail;
                users.u_pass = user.u_pass;
                users.r_id = user.r_id;

                database.SaveChanges();

                return Ok(users.ToUserDTO());
            }
        }
    }
}