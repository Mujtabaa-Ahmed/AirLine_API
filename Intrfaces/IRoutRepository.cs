using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Rout;
using api.Models;

namespace AirLine_API.Intrfaces
{
    public interface IRoutRepository
    {
        Task<List<class_rout>> GetAllAsync();
        Task<class_rout?> GetByIdAsync(int id);
        Task<class_rout> CreateAsync(class_flight createRoout);
        Task<class_rout?> UpdateAsync(int id,updateRoutDTO Rout);
        Task<class_rout?> DeleteAsync(int id);
    }
}