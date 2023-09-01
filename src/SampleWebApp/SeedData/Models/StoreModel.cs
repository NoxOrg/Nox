namespace SampleWebApp.SeedData.Models
{
    public class StoreModel
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public decimal PhysicalMoney { get; set; }
        public string? StoreOwnerId { get; set; }
    }
}