using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Rout;
using api.Models;

namespace api.Mapper
{
    public static class routMapper
    {
        public static routDTO ToroutDTO(this class_rout rout)
        {
            return new routDTO
            {
                Rout_id = rout.Rout_id,
                rout_name = rout.rout_name
            };
        }

        public static class_rout ToCreateRoutDTO(this createRoutDTO roDTO)
        {
            return new class_rout
            {
                rout_name = roDTO.rout_name
            };
        }
    }
}