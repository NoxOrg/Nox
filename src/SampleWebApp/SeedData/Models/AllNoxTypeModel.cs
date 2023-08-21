using Nox.Types;

namespace SampleWebApp.SeedData.Models
{
    public class AllNoxTypeModel
    {
        public string Id { get; set; } = string.Empty;
        public bool Boolean { get; set; } = false;
        public string CountryCode2 { get; set; } = string.Empty;
        public string CountryCode3 { get; set; } = string.Empty;
        public string CultureCode { get; set; } = string.Empty;
        public short CurrencyNumber { get; set; } = short.MinValue;
        public string LanguageCode { get; set; } = string.Empty;
        public decimal LengthValue { get; set; } = decimal.MinValue;
        public string LengthUnit { get; set; } = string.Empty;
        public string MacAddress { get; set; } = string.Empty;
        public string Markdown { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public decimal Temperature { get; set; } = decimal.MinValue;
        public string TemperatureUnit { get; set; } = string.Empty;
        public string TextField { get; set; } = string.Empty;
        public string VatNumber { get; set; } = string.Empty;
    }
}