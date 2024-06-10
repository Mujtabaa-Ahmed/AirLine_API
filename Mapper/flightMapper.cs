using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Flight;
using api.Models;

namespace api.Mapper
{
    public static class flightMapper
    {
        public static flightDTO ToflightDTO(this class_flight flight)
        {
            return new flightDTO
            {
                f_id = flight.f_id,
                f_name = flight.f_name
            };
        }
        public static class_flight ToCreateFlightDTO(this createFlightDTO fDTO)
        {
            return new class_flight
            {
                f_name = fDTO.f_name
            };
        }
    }
}