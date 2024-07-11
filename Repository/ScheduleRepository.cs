using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirLine_API.Intrfaces;
using api.Context;
using api.DTOs.Schedule;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace AirLine_API.Repository
{
    public class ScheduleRepository : IScheduleRepository
    {
         private readonly db_context database;
        public ScheduleRepository(db_context data)
        {
            database = data;
        }

        public async Task<class_schedule> CreateAsync(class_schedule createSchedule)
        {
            await database.schedule.AddAsync(createSchedule);
            await database.SaveChangesAsync();
            return createSchedule;
        }

        public async Task<class_schedule?> DeleteAsync(int id)
        {
            var deleteS = await database.schedule.FirstOrDefaultAsync(a => a.s_id == id);
             if(deleteS == null)
             {
                return null;
             }else
             {
                database.Remove(deleteS);
                await database.SaveChangesAsync();
                return deleteS;
             }
        }

        public async Task<List<class_schedule>> GetAllAsync()
        {
            return await database.schedule.ToListAsync();
        }

        public async Task<class_schedule?> GetByIdAsync(int id)
        {
             var data = await database.schedule.FindAsync(id);
            if (data == null)
            {
                return null;
            }
            return data;
        }

        public async Task<class_schedule?> UpdateAsync(int id, updateScheduleDTO Schedule)
        {
             var schedules = await database.schedule.FirstOrDefaultAsync(a => a.s_id == id);
            if(schedules == null)
            {
                return null;
            }else
            {
                schedules.f_id = Schedule.f_id;
                schedules.rout_id = Schedule.rout_id;
                schedules.s_arival = Schedule.s_arival;
                schedules.s_departure = Schedule.s_departure;

                await database.SaveChangesAsync();
                return schedules;
            }
        }
    }
}