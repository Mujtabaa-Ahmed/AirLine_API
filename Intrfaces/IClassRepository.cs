using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.DTOs.Classes;
using api.Models;

namespace AirLine_API.Intrfaces
{
    public interface IClassRepository
    {
        Task<List<class_classes>> GetAllAsync();
        Task<class_classes?> GetById(int id);
        Task<class_classes> CreateAsync(class_classes classes);
        Task <class_classes?> UpdateAsync(int id,updateClassDTO classes);
        Task<class_classes?> DeleteAsync(int id);
    }
}