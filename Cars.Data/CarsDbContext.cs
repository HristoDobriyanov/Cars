using Cars.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Cars.Data
{
    public class CarsDbContext : DbContext
    {
        public DbSet<Make> Makes { get; set; }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Engine> Engines { get; set; }

        public DbSet<LicensePlate> LicensePlates { get; set; }

        public DbSet<Dealership> Dealerships { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(@"Server=DESKTOP-R4OGD90\SQLEXPRESS;Database=Cars;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
