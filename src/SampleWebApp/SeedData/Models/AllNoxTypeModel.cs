using Nox.Types;

namespace SampleWebApp.SeedData.Models
{
    public class AllNoxTypeModel
    {
        public string Id { get; set; } = string.Empty;
        public bool Boolean { get; set; } = false;
        public string CountryCode2 { get; set; } = string.Empty;
        public string CountryCode3 { get; set; } = string.Empty;
        public string CurrencyCode3 { get; set; } = string.Empty;
        public string TextField { get; set; } = string.Empty;
        public string VatNumber { get; set; } = string.Empty;
        public short CountryNumber { get; set;} = short.MinValue;
        public short CurrencyNumber { get; set; } = short.MinValue;
        public string CultureCode { get; set; } = string.Empty;
        public double AreaValue { get; set; } = double.MinValue;
        public string AreaUnit { get; set; } = "SquareMeter";
        public double DistanceValue { get; set; } = double.MinValue;
        public string DistanceUnit { get; set; } = "Kilometer";
        public string Email { get; set; } = string.Empty;
        public EncryptedTextTypeOptions EncryptedTextTypeOptions { get; set; } = null!;
        public string FileName { get; set; } = string.Empty;
        public string FileUrl { get; set; } = string.Empty;
        public uint FileSize { get; set; } =0;
        public string HtmlText { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string ImageName { get; set; } = string.Empty;
        public uint ImageSize { get; set; } = 0;
        public string InternetDomain { get; set; } = string.Empty;
        public string IpAddress { get; set; } = string.Empty;
        public string Json { get; set; } = string.Empty;
        public string JwtToken { get; set; } = string.Empty;
        public string LanguageCode { get; set; } = string.Empty;
        public double Latitude { get; set; } = 0;
        public double Longitude { get; set; } = 0;
        public string TranslatedText { get; set; } = string.Empty;
        public string CurrencyCode { get; set; } = string.Empty;
        public decimal MoneyAmount { get; set; } = decimal.MinValue;
        public string MacAddress { get; set; } = string.Empty;
        public string Markdown { get; set; } = string.Empty;
        public byte Month { get; set; } = 1;
        public float Percentage { get; set; } = float.MinValue;
        public decimal Number { get; set; } = decimal.MinValue;
        public NumberTypeOptions NumberTypeOptions { get; set; } = null!;
        public string TimeZoneCode { get; set; } = string.Empty;
        public decimal Temperature { get; set; } = decimal.MinValue;
        public string TemperatureUnit { get; set; } = string.Empty;
        public decimal Volume { get; set; } = decimal.MinValue;
        public string VolumeUnit { get; set; } = string.Empty;
        public decimal Weight { get; set; } = decimal.MinValue;
        public string WeightUnit { get; set; } = string.Empty;
        public string Uri { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string Yaml { get; set; } = string.Empty;
        public ushort Year { get; set; } = ushort.MinValue;

        public StreetAddressItem StreetAddress { get; set; } = null!;
        public decimal Length { get; set; } = decimal.MinValue;
        public string LengthUnit { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string NuidText { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public string DayOfTheWeek { get; set; } = string.Empty;
        public long DurationTicks { get; set; } = 0;
        public int DateYear { get; set; } = 0;
        public int DateMonth { get; set; } = 1;
        public int DateDay { get; set; } = 1;
        public int TimeHour { get; set; } = 0;
        public int TimeMinute { get; set; } = 0;
        public int TimeSecond { get; set; } = 0;
        public int TimeMillisecond { get; set; } = 0;
        public string User { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Guid { get; set; } = System.Guid.Empty.ToString();
    }
}