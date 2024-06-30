using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirLine_API.Intrfaces;
using api.Context;
using api.DTOs.Bookings;
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

        public async Task<class_bookings> CreateAsync(class_bookings bookingModel)
        {
            await database.booking.AddAsync(bookingModel);
            await database.SaveChangesAsync();
            return bookingModel;
        }

        public async Task<class_bookings?> DeleteAsync(int id)
        {
            var delete = await database.booking.FirstOrDefaultAsync(a => a.b_id == id);
            if(delete == null)
            {
                return null;
            }

            database.Remove(delete);
            await database.SaveChangesAsync();
            return delete;
        }

        public async Task<List<class_bookings>> GetAllAsync()
        {
            return await database.booking.ToListAsync();
        }

        public async Task<class_bookings?> GetByIdAsync(int id)
        {
            return await database.booking.FindAsync(id);
        }

        public async Task<class_bookings?> UpdateAsync(int id, updateBookingDTO bookingDTO)
        {
            var updateBooking = await database.booking.FirstOrDefaultAsync(a => a.b_id == id);

            if(updateBooking == null)
            {
                return null;
            }

            updateBooking.b_quan = bookingDTO.b_quan;
            updateBooking.b_amount = bookingDTO.b_amount;
            updateBooking.c_id = bookingDTO.c_id;
            updateBooking.s_id = bookingDTO.s_id;

            await database.SaveChangesAsync();
            return updateBooking;

        }
        
    }
}