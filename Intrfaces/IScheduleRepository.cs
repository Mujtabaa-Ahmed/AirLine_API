using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Schedule;
using api.Models;

namespace AirLine_API.Intrfaces
{
    public interface IScheduleRepository
    {
        Task<List<class_schedule>> GetAllAsync();
        Task<class_schedule?> GetByIdAsync(int id);
        Task<class_schedule> CreateAsync(class_schedule createSchedule);
        Task<class_schedule?> UpdateAsync(int id,updateScheduleDTO Schedule);
        Task<class_schedule?> DeleteAsync(int id);
    }
}