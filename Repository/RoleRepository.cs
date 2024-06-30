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

        public Task<class_roles> CreateAsync(class_flight createRole)
        {
            throw new NotImplementedException();
        }

        public Task<class_roles?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<class_roles>> GetAllAsync()
        {
            return await database._Role.ToListAsync();
        }

        public Task<class_roles?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<class_roles?> UpdateAsync(int id, updateRoleDTO Role)
        {
            throw new NotImplementedException();
        }
    }
}