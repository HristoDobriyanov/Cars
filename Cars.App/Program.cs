﻿using Cars.Data;
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
                new Engine
                {
                    Capacity = 1.6,
                    Cylinders =4,
                    FuelType = FuelType.Petrol,
                    HorsePower = 95
                },
                new Engine
                {
                    Capacity = 3.0,
                    Cylinders =8,
                    FuelType = FuelType.Diesel,
                    HorsePower = 318
                },
                new Engine
                {
                    Capacity = 1.2,
                    Cylinders =3,
                    FuelType = FuelType.Gas,
                    HorsePower = 60
                }
            };


            var cars = new [] 
            {
                new Car
                {
                    Engine = engines[2],
                    Make = makes[6],
                    Doors = 4,
                    Model = "Кашон-P50",
                    ProductionYear = new DateTime(1958, 1, 1),
                    Transmission = Transmission.Manual
                },
                new Car
                {
                    Engine = engines[1],
                    Make = makes[5],
                    Doors = 4,
                    Model = "Москвич-423",
                    ProductionYear = new DateTime(1954, 1, 1),
                    Transmission = Transmission.Automatic
                },
                new Car
                {
                    Engine = engines[0],
                    Make = makes[0],
                    Doors = 4,
                    Model = "Escort",
                    ProductionYear = new DateTime(1955, 1, 1),
                    Transmission = Transmission.Automatic
                },

            };

        }
    }
}
