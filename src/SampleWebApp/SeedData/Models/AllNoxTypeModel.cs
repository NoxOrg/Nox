using Nox.Types;

namespace SampleWebApp.SeedData.Models
{
    public class AllNoxTypeModel
    {
        public string Id { get; set; } = string.Empty;
        public bool Boolean { get; set; } = false;
        public string Color { get; set; } = string.Empty;
        public string CountryCode2 { get; set; } = string.Empty;
        public string CountryCode3 { get; set; } = string.Empty;
        public string CultureCode { get; set; } = string.Empty;
        public short CurrencyNumber { get; set; } = short.MinValue;
        public string CurrencyCode3 { get; set; } = string.Empty;
        public string LanguageCode { get; set; } = string.Empty;
        public decimal LengthValue { get; set; } = decimal.MinValue;
        public string LengthUnit { get; set; } = string.Empty;
        public string MacAddress { get; set; } = string.Empty;
        public string Markdown { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public decimal Temperature { get; set; } = decimal.MinValue;
        public string TemperatureUnit { get; set; } = string.Empty;
        public string HtmlText { get; set; } = string.Empty;
        public string InternetDomain { get; set; } = string.Empty;
        public string IpAddress { get; set; } = string.Empty;
        public string Json { get; set; } = string.Empty;
        public string JwtToken { get; set; } = string.Empty;
        public byte Month { get; set; } = 1;
        public string NuidText { get; set; } = string.Empty;
        public string TextField { get; set; } = string.Empty;
        public string VatNumber { get; set; } = string.Empty;
        public long DurationTicks { get; set; } = 0;
        public int DateYear { get; set; } = 0;
        public int DateMonth { get; set; } = 1;
        public int DateDay { get; set; } = 1;
        public int TimeHour { get; set; } = 0;
        public int TimeMinute { get; set; } = 0;
        public int TimeSecond { get; set; } = 0;
        public int TimeMillisecond { get; set; } = 0;
        public string DateTimeSchedule { get; set; } = string.Empty;
    }
}