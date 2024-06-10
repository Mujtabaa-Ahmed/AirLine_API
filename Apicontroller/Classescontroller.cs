using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Context;
using api.DTOs.Classes;
using api.Mapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Identity.Client;

namespace api.Apicontroller
{
    [Route("api/classes")]
    [ApiController]
    public class Classescontroller : Controller
    {
        private readonly db_context database;
                
        public Classescontroller(db_context data)
        {
            database = data;
        }

        [HttpGet]
        public IActionResult getclasses()
        {
            var data = database.classes.ToList().Select(c => c.ToClassesDTO());

            return Ok(data);
        }
        [HttpGet("{id}")]
        public IActionResult getclassesbyid([FromRoute] int id)
        {
            var data = database.classes.Find(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data.ToClassesDTO());
        }

        [HttpPost]
        public IActionResult createclass([FromBody] createClassesDTO classes)
        {
            var cls = classes.ToCreateClassDTO();
            database.Add(cls);
            database.SaveChanges();
            return CreatedAtAction(nameof(getclassesbyid) , new {id = cls.c_id}, cls.ToClassesDTO());
        }
        [HttpPut]
        [Route("{id}")]
        public IActionResult updateClass([FromRoute] int id,[FromBody] updateClassDTO updateClass)
        {
            var update = database.classes.FirstOrDefault(a => a.c_id == id);
            if(update == null)
            {
                return NotFound();
            }else
            {
                update.c_name = updateClass.c_name;
                update.c_price = updateClass.c_price;

                database.SaveChanges();
                return Ok(update.ToClassesDTO());
            }
        }
    }
}