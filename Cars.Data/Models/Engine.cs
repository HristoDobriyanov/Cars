namespace Cars.Data.Models
{
    public class Engine
    {
        public int Id { get; set; }

        public string Make { get; set; }

        public double Capacity { get; set; }

        public FuelType FuelType { get; set; }

        public int Cylinders { get; set; }

        public int HorsePower { get; set; }

    }
}