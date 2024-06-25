using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace AirLine_API.Intrfaces
{
    public interface IBookingRepository
    {
        Task<List<class_bookings>> GetAllAsync();
    }
}