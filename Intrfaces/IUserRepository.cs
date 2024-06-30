using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.User;
using api.Models;

namespace AirLine_API.Intrfaces
{
    public interface IUserRepository
    {
        Task<List<class_users>> GetAllAsync();
        Task<class_users?> GetByIdAsync(int id);
        Task<class_users> CreateAsync(class_users createUser);
        Task<class_users?> UpdateAsync(int id,updateUserDTO User);
        Task<class_users?> DeleteAsync(int id);
    }
}