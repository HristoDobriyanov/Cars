using Cars.Data;
using Cars.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Text;

namespace Cars.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            var context = new CarsDbContext();
            //ResetDatabase(context);

            var cars = context
                .Cars
                .Include(c => c.Engine)
                .Include(c => c.Make)
                .Include(c => c.LicensePlate)
                .Include(c => c.CarDealerships)
                .ThenInclude(cd => cd.Dealership)
                .OrderBy(c => c.ProductionYear)
                .ToArray();

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Make.Name} {car.Model}");
                Console.WriteLine($"--Fuel: {car.Engine.FuelType}");
                Console.WriteLine($"--Transmission: {car.Transmission}");
                var licensePlate = car.LicensePlate != null ? $"--{car.LicensePlate.Number}" : "No Plate";
                Console.WriteLine($"Plate number: {licensePlate}");
                Console.WriteLine("---------------------------");
            }


            Console.WriteLine();
           
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

            var cars = new[]
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
                    Make = makes[4],
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
            context.Cars.AddRange(cars);


            var dealerships = new[]
            {
                new Dealership
                {
                    Name = "SoftUni-Auto",
                },

                 new Dealership
                {
                    Name = "Fast and Furious Auto"
                },
            };
            context.Dealerships.AddRange(dealerships);

            var carDealerships = new[]
            {
                new CarDealership
                {
                    Car =  cars[0],
                    Dealership = dealerships[0]
                },
                new CarDealership
                {
                    Car =  cars[1],
                    Dealership = dealerships[1]
                },
                new CarDealership
                {
                    Car =  cars[0],
                    Dealership = dealerships[1]
                }
            };
            context.CarDealerships.AddRange(carDealerships);

            var licensePlates = new[]
            {
                new LicensePlate
                {
                    Number = "CB1234AB"
                },

                new LicensePlate
                {
                    Number = "CB4567AB"
                },

                new LicensePlate
                {
                    Number = "BP9999AA"
                },
            };
            context.LicensePlates.AddRange(licensePlates);

            context.SaveChanges();
        }
    }
}
