using Nox.Types;

namespace SampleWebApp.SeedData.Models
{
    public class AllNoxTypeModel
    {
        public string Id { get; set; } = string.Empty;
        public bool Boolean { get; set; } = false;
        public string CountryCode2 { get; set; } = string.Empty;
        public string CountryCode3 { get; set; } = string.Empty;
        public string TextField { get; set; } = string.Empty;
        public string VatNumber { get; set; } = string.Empty;
    }
}