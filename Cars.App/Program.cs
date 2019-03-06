using Cars.Data;
using System;

namespace Cars.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new CarsDbContext();

            context.Database.EnsureCreated();

            Console.WriteLine();

        }
    }
}
