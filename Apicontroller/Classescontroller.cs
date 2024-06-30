using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using AirLine_API.Intrfaces;
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
        private readonly IClassRepository _classRepo;
        public Classescontroller(IClassRepository classRepo , db_context data)
        {
           _classRepo = classRepo;
           database = data;
        }

        [HttpGet]
        public async Task<IActionResult> getclasses()
        {
            var data = await _classRepo.GetAllAsync();
            var clas = data.Select(c => c.ToClassesDTO());

            return Ok(clas);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getclassesbyid([FromRoute] int id)
        {
            var data = await _classRepo.GetById(id);
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
            await _classRepo.CreateAsync(cls);
            return CreatedAtAction(nameof(getclassesbyid) , new {id = cls.c_id}, cls.ToClassesDTO());
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> updateClass([FromRoute] int id,[FromBody] updateClassDTO updateClass)
        {
            var update = await _classRepo.UpdateAsync(id,updateClass);
            if(update == null)
            {
                return NotFound();
            }
                 return Ok(update.ToClassesDTO());
            
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteClass([FromRoute] int id)
        {
            var Dclass = await _classRepo.DeleteAsync(id);

            if(Dclass == null)
            {
                return NotFound();
            }
                return Content("Class is Deleted");
            
        }
    }
}