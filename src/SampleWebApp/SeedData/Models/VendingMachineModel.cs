using Nox.Types;

namespace SampleWebApp.SeedData.Models
{
    public class VendingMachineModel
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string Phone { get; set; } = string.Empty;
    }
}