using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirLine_API.Intrfaces;
using api.Context;
using api.DTOs.Role;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace AirLine_API.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly db_context database;
        public RoleRepository (db_context data)
        {
            database = data;
        }

        public async Task<class_roles> CreateAsync(class_roles createRole)
        {
            await database._Role.AddAsync(createRole);
            await database.SaveChangesAsync();
            return createRole;
        }

        public async Task<class_roles?> DeleteAsync(int id)
        {
            var Drole = await database._Role.FirstOrDefaultAsync(a => a.r_id == id);
            if(Drole == null)
            {
                return null;
            }
            database.Remove(Drole);
            await database.SaveChangesAsync();
            return Drole;
        }

        public async Task<List<class_roles>> GetAllAsync()
        {
            return await database._Role.ToListAsync();
        }

        public async Task<class_roles?> GetByIdAsync(int id)
        {
            var role = await database._Role.FirstOrDefaultAsync(a => a.r_id == id);
            if(role == null)
            {
                return null;
            }
            return role;
        }

        public async Task<class_roles?> UpdateAsync(int id, updateRoleDTO Role)
        {
            var Urole = await database._Role.FirstOrDefaultAsync(a => a.r_id == id);
            if(Urole == null)
            {
                return null;
            }
            Urole.r_name = Role.r_name;
            await database.SaveChangesAsync();
            return Urole;
        }
    }
}