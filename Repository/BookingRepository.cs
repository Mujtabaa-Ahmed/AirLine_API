using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirLine_API.Intrfaces;
using api.Context;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace AirLine_API.Repository
{
    public class BookingRepository : IBookingRepository
    {
        private readonly db_context database;
        public BookingRepository(db_context data)
        {
            database = data;
        }
        public Task<List<class_bookings>> GetAllAsync()
        {
            return database.booking.ToListAsync();
        }
    }
}