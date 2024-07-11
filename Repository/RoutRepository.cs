using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirLine_API.Intrfaces;
using api.Context;
using api.DTOs.Rout;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace AirLine_API.Repository
{
    public class RoutRepository : IRoutRepository
    {
        private readonly db_context database;
        public RoutRepository(db_context data)
        {
            database = data;
        }

        public async Task<class_rout> CreateAsync(class_rout createRout)
        {
            await database.rout.AddAsync(createRout);
            await database.SaveChangesAsync();
            return createRout;
        }

        public async Task<class_rout?> DeleteAsync(int id)
        {
            var deleteR = await database.rout.FirstOrDefaultAsync(a => a.Rout_id == id);

            if(deleteR == null)
            {
                return null;
            }else
            {
                database.Remove(deleteR);
                await database.SaveChangesAsync();
                return deleteR;
            }
        }

        public async Task<List<class_rout>> GetAllAsync()
        {
            return await database.rout.ToListAsync();
        }

        public async Task<class_rout?> GetByIdAsync(int id)
        {
            var rout = await database.rout.FirstOrDefaultAsync(a => a.Rout_id == id);
            if(rout == null)
            {
                return null;
            }

            return rout;
        }

        public async Task<class_rout?> UpdateAsync(int id, updateRoutDTO Rout)
        {
           var routs = await database.rout.FirstOrDefaultAsync(a => a.Rout_id == id);
            if(routs == null)
            {
                return null;
            }
                routs.rout_name = Rout.rout_name;
                await database.SaveChangesAsync();
                return routs;
        }
    }
}