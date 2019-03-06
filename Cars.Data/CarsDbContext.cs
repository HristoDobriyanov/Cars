using Cars.Data.Models;
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



        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(@"Server=DESKTOP-R4OGD90\SQLEXPRESS;Database=Cars;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Car>()
                .HasOne(c => c.LicensePlate)
                .WithOne(lp => lp.Car)
                .HasForeignKey<LicensePlate>(lp => lp.CarId);

            builder.Entity<Car>()
                .HasMany(c => c.CarDealerships)
                .WithOne(cd => cd.Car)
                .HasForeignKey(cd => cd.CarId);


            builder.Entity<CarDealership>()
                .HasKey(cd => new { cd.CarId, cd.DealershipId });



        }
    }
}
