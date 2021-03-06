﻿using Cars.Data.Models;
using Cars.Data.Models.Configurations;
using Microsoft.EntityFrameworkCore;
using System;

namespace Cars.Data
{
    public class CarsDbContext : DbContext
    {
        public CarsDbContext()
        {

        }

        public CarsDbContext(DbContextOptions options)
            :base(options)
        {

        }


        public DbSet<Make> Makes { get; set; }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Engine> Engines { get; set; }

        public DbSet<LicensePlate> LicensePlates { get; set; }

        public DbSet<Dealership> Dealerships { get; set; }

        public DbSet<CarDealership> CarDealerships { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(@"Server=DESKTOP-R4OGD90\SQLEXPRESS;Database=Cars;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CarConfiguration()); 

            builder.ApplyConfiguration(new CarDealershipConfiguration());

            builder.ApplyConfiguration(new EngineConfiguration());
        }
    }
}
