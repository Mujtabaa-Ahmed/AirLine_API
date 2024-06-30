using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Flight;
using api.Models;

namespace AirLine_API.Intrfaces
{
    public interface IFlightRepository
    {
        Task<List<class_flight>> GetAllAsync();
        Task<class_flight?> GetByIdAsync(int id);
        Task<class_flight> CreateAsync(class_flight createGlight);
        Task<class_flight?> UpdateAsync(int id,updateFlightDTO flight);
        Task<class_flight?> DeleteAsync(int id);
    }
}