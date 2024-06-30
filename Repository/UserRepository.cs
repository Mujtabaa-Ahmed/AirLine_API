using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirLine_API.Intrfaces;
using api.Context;
using api.DTOs.User;
using api.Models;

namespace AirLine_API.Repository
{
    public class UserRepository : IUserRepository
    {
         private readonly db_context database;
        public UserRepository(db_context data)
        {
            database = data;
        }

        public Task<class_users> CreateAsync(class_flight createUser)
        {
            throw new NotImplementedException();
        }

        public Task<class_users?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<class_users>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<class_users?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<class_users?> UpdateAsync(int id, updateUserDTO User)
        {
            throw new NotImplementedException();
        }
    }
}