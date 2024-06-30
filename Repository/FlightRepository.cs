using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirLine_API.Intrfaces;
using api.Context;
using api.DTOs.Flight;
using api.Models;

namespace AirLine_API.Repository
{
    public class FlightRepository : IFlightRepository
    {
        private readonly db_context database;
        public FlightRepository (db_context data)
        {
            database = data;
        }
        public Task<class_flight> CreateAsync(class_flight createGlight)
        {
            throw new NotImplementedException();
        }

        public Task<class_flight?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<class_flight>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<class_flight?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<class_flight?> UpdateAsync(int id, updateFlightDTO flight)
        {
            throw new NotImplementedException();
        }
    }
}