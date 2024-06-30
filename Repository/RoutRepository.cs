using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirLine_API.Intrfaces;
using api.Context;
using api.DTOs.Rout;
using api.Models;

namespace AirLine_API.Repository
{
    public class RoutRepository : IRoutRepository
    {
        private readonly db_context database;
        public RoutRepository(db_context data)
        {
            database = data;
        }

        public Task<class_rout> CreateAsync(class_rout createRout)
        {
            throw new NotImplementedException();
        }

        public Task<class_rout?> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<class_rout>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<class_rout?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<class_rout?> UpdateAsync(int id, updateRoutDTO Rout)
        {
            throw new NotImplementedException();
        }
    }
}