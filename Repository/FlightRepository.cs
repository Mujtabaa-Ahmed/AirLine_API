using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirLine_API.Intrfaces;
using api.Context;
using api.DTOs.Flight;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace AirLine_API.Repository
{
    public class FlightRepository : IFlightRepository
    {
        private readonly db_context database;
        public FlightRepository (db_context data)
        {
            database = data;
        }
        public async Task<class_flight> CreateAsync(class_flight createFlight)
        {
            await database.flight.AddAsync(createFlight);
            await database.SaveChangesAsync();
            return createFlight;
        }

        public async Task<class_flight?> DeleteAsync(int id)
        {
            var Dflight = await database.flight.FirstOrDefaultAsync(a => a.f_id == id);
            if(Dflight == null)
            {
                return null;
            }

            database.Remove(Dflight);
            await database.SaveChangesAsync();
            return Dflight;
        }

        public async Task<List<class_flight>> GetAllAsync()
        {
            return await database.flight.ToListAsync();
        }

        public async Task<class_flight?> GetByIdAsync(int id)
        {
            var flight = await database.flight.FirstOrDefaultAsync(a => a.f_id == id);
            if(flight == null)
            {
                return null;
            }
            return flight;
        }

        public async Task<class_flight?> UpdateAsync(int id, updateFlightDTO flight)
        {
            var updateFlight = await database.flight.FirstOrDefaultAsync(a => a.f_id == id);
            if(updateFlight == null)
            {
                return null;
            }

            updateFlight.f_name = flight.f_name;
            await database.SaveChangesAsync();
            return updateFlight;
        }
    }
}