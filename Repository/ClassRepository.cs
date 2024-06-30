using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using AirLine_API.Intrfaces;
using api.Context;
using api.DTOs.Classes;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace AirLine_API.Repository
{
    
    public class ClassRepository : IClassRepository
    {
        private readonly db_context database;
        public ClassRepository (db_context data)
        {
            database = data;
        }

        public async Task<class_classes> CreateAsync(class_classes classes)
        {
            await database.classes.AddAsync(classes);
            await database.SaveChangesAsync();
            return classes;
        }

        public async Task<class_classes?> DeleteAsync(int id)
        {
            var removingClass = await database.classes.FirstOrDefaultAsync(a => a.c_id == id);
            if(removingClass == null)
            {
                return null;
            }

            database.Remove(removingClass);
            await database.SaveChangesAsync();
            return removingClass;
        }

        public async Task<List<class_classes>> GetAllAsync()
        {
            return await database.classes.ToListAsync();
        }

        public async Task<class_classes?> GetById(int id)
        {
            return await database.classes.FindAsync(id);
        }

        public async Task<class_classes?> UpdateAsync(int id, updateClassDTO classes)
        {
                var UpdatClass = await database.classes.FirstOrDefaultAsync(a => a.c_id == id);

                if(UpdatClass == null)
                {
                    return null;
                }

                UpdatClass.c_name = classes.c_name;
                UpdatClass.c_price = classes.c_price;

                await database.SaveChangesAsync();
                return UpdatClass;
                
        }
    }
}