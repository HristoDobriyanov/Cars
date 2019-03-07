using Cars.Data;
using Cars.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Cars.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new CarsDbContext();

            ResetDatabase(context);

            Console.WriteLine("Enter");
            Console.ReadLine();



        }

        private static void ResetDatabase(CarsDbContext context)
        {
            context.Database.EnsureCreated();

            context.Database.Migrate();

            Seed(context);
        }

        private static void Seed(CarsDbContext context)
        {
            var makes = new[]
            {
               new Make { Name = "Ford"},
               new Make { Name = "Mercedes"},
               new Make { Name = "Audi"},
               new Make { Name = "BMW"},
               new Make { Name = "АЗЛК"},
               new Make { Name = "Lada"},
               new Make { Name = "Трабант"}
            };

            var engines = new[]
            {
                new Engine{ Capacity = 1.6, Cylinders=4, FuelType = FuelType.Petrol, HorsePower = 95},
            };


            var cars = new [] 
            {
                new Car{ Make = makes[0] },
            };

        }
    }
}
