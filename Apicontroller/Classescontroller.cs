using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using api.Context;
using api.DTOs.Classes;
using api.Mapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> getclasses()
        {
            var data = await database.classes.ToListAsync();
            var clas = data.Select(c => c.ToClassesDTO());

            return Ok(clas);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getclassesbyid([FromRoute] int id)
        {
            var data = await database.classes.FindAsync(id);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data.ToClassesDTO());
        }

        [HttpPost]
        public async Task<IActionResult> createclass([FromBody] createClassesDTO classes)
        {
            var cls = classes.ToCreateClassDTO();
            await database.AddAsync(cls);
            await database.SaveChangesAsync();
            return CreatedAtAction(nameof(getclassesbyid) , new {id = cls.c_id}, cls.ToClassesDTO());
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> updateClass([FromRoute] int id,[FromBody] updateClassDTO updateClass)
        {
            var update = await database.classes.FirstOrDefaultAsync(a => a.c_id == id);
            if(update == null)
            {
                return NotFound();
            }else
            {
                update.c_name = updateClass.c_name;
                update.c_price = updateClass.c_price;

                await database.SaveChangesAsync();
                return Ok(update.ToClassesDTO());
            }
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteClass([FromRoute] int id)
        {
            var Dclass = await database.classes.FirstOrDefaultAsync(a => a.c_id == id);

            if(Dclass == null)
            {
                return NotFound();
            }else
            {
                database.Remove(Dclass);
                await database.SaveChangesAsync();
                return Content("Class is Deleted");
            }
        }
    }
}