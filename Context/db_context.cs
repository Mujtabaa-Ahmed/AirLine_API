using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace api.Context
{
    public class db_context : DbContext
    {
        public db_context(DbContextOptions<db_context>  options) : base (options)
        {
            
        }
        
        public DbSet<class_roles> _Role { get; set;}
        public DbSet<class_users> Users { get; set;}
        public DbSet<class_classes> classes { get; set;}
        public DbSet<class_bookings> booking { get; set;}
        public DbSet<class_flight> flight { get; set;}
        public DbSet<class_schedule> schedule { get; set;}
        public DbSet<class_rout> rout { get; set;}

    }

}