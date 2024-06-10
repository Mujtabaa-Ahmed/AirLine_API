using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Schedule;
using api.Models;

namespace api.Mapper
{
    public static class scheduleMapper
    {
        public static scheduleDTO ToscheduleDTO(this class_schedule schedule)
        {
            return new scheduleDTO
            {
                s_id = schedule.s_id,
                s_departure = schedule.s_departure,
                s_arival = schedule.s_arival,
                f_id = schedule.f_id,
                rout_id = schedule.rout_id
            };
        }

        public static class_schedule ToCreateRequestScheduleDTO(this createScheduleRequestDTO sDTO)
        {
            return new class_schedule
            {
                s_departure = sDTO.s_departure,
                s_arival = sDTO.s_arival,
                rout_id = sDTO.rout_id,
                f_id = sDTO.f_id
            };
        }
    }
}