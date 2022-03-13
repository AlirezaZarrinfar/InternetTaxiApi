using InternetTaxiAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetTaxiAPI.Domain.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        { }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

    }
}
