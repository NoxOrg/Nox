namespace SampleWebApp.SeedData.Models
{
    public class CountryModel
    {
        public string AlphaCode2 { get; set; } = string.Empty;
        public string AlphaCode3 { get; set; } = string.Empty;
        public decimal AreaInSquareKilometres { get; set; }
        public string Capital { get; set; } = string.Empty;
        public string Demonym { get; set; } = string.Empty;
        public string DialingCodes { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string FormalName { get; set; } = string.Empty;
        public int NumericCode { get; set; }
        public decimal Population { get; set; }
        public string TopLevelDomains { get; set; } = string.Empty;
        public string GeoRegion { get; set; } = string.Empty;
        public string GeoSubRegion { get; set; } = string.Empty;
        public string GeoWorldRegion { get; set; } = string.Empty;
        public List<CountryLocalName> CountryLocalNames { get; set; } = new List<CountryLocalName>();
    }
}