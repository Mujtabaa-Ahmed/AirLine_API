using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirLine_API.Intrfaces;
using api.Context;
using api.DTOs.Schedule;
using api.Models;

namespace AirLine_API.Repository
{
    public class ScheduleRepository : IScheduleRepository
    {
         private readonly db_context database;
        public ScheduleRepository(db_context data)
        {
            database = data;
        }

        public Task<class_rout> CreateAsync(class_flight createSchedule)
        {
            throw new NotImplementedException();
        }

        public Task<class_schedule?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<class_schedule>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<class_schedule?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<class_schedule?> UpdateAsync(int id, updateScheduleDTO Schedule)
        {
            throw new NotImplementedException();
        }
    }
}