using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cars.Data.Models.Configurations
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder
                .HasOne(c => c.LicensePlate)
                .WithOne(lp => lp.Car)
                .HasForeignKey<LicensePlate>(lp => lp.CarId);

            builder
                .HasMany(c => c.CarDealerships)
                .WithOne(cd => cd.Car)
                .HasForeignKey(cd => cd.CarId);
        }
    }
}
