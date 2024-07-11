using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirLine_API.Intrfaces;
using api.Context;
using api.DTOs.User;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace AirLine_API.Repository
{
    public class UserRepository : IUserRepository
    {
         private readonly db_context database;
        public UserRepository(db_context data)
        {
            database = data;
        }

        public async Task<class_users> CreateAsync(class_users createUser)
        {
            await database.Users.AddAsync(createUser);
            await database.SaveChangesAsync();
            return createUser;
        }

        public async Task<class_users?> DeleteAsync(int id)
        {
           var Duser = await database.Users.FirstOrDefaultAsync(a => a.u_id == id);
            if(Duser == null)
            {
                return null;
            }
                database.Remove(Duser);
                await database.SaveChangesAsync();
                return Duser;
        }

        public async Task<List<class_users>> GetAllAsync()
        {
            return await database.Users.ToListAsync();
        }

        public async Task<class_users?> GetByIdAsync(int id)
        {
             var data = await database.Users.FindAsync(id);
            if (data == null)
            {
                return null;
            }
            return data;
        }

        public async Task<class_users?> UpdateAsync(int id, updateUserDTO User)
        {
           var users = await database.Users.FirstOrDefaultAsync(a => a.u_id == id);
            if(users == null)
            {
                return null;
            }else
            {
                users.u_name = User.u_name;
                users.u_mail = User.u_mail;
                users.u_pass = User.u_pass;
                users.r_id = User.r_id;

                await database.SaveChangesAsync();

                return users;
            }
        }
    }
}