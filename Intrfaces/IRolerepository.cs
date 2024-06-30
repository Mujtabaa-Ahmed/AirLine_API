using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Role;
using api.Models;

namespace AirLine_API.Intrfaces
{
    public interface IRoleRepository
    {
        Task<List<class_roles>> GetAllAsync();
        Task<class_roles?> GetByIdAsync(int id);
        Task<class_roles> CreateAsync(class_roles createRole);
        Task<class_roles?> UpdateAsync(int id,updateRoleDTO Role);
        Task<class_roles?> DeleteAsync(int id);
    }
}