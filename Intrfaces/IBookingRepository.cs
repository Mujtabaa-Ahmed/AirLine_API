using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Bookings;
using api.Models;

namespace AirLine_API.Intrfaces
{
    public interface IBookingRepository
    {
        Task<List<class_bookings>> GetAllAsync();
        Task<class_bookings?> GetByIdAsync(int id);
        Task<class_bookings> CreateAsync(class_bookings bookingModel);
        Task<class_bookings?> UpdateAsync(int id, updateBookingDTO bookingDTO);
        Task<class_bookings?> DeleteAsync(int id);
       
    }
}