using FluentAssertions;
using System.Text.Json;
using System.Text.Json.Serialization;
using Cryptocash.Application.Dto;

namespace Cryptocash.Tests;

public class CryptocashCountryDtoDataCreationTests
{
    private static readonly JsonSerializerOptions JsonOptions = CreateJsonSerializerOptions();

#nullable enable

    /// <summary>
    /// Test used to create one-off CountryDto JSON data from Reference Data - to use make sure source json files are available otherwise test just returns empty string - use returning rtnJson value from Convert_Country_ReferenceData_to_DtoDataAsync to create the CryptocashCountry.Json file manually
    /// </summary>
    [Fact(Skip = "Only used as one-off to create DataSeeder Country JSON file")]
    public async Task Create_CountryDto_data_from_CountryReferenceData()
    {
        var rootPath = "../../../../.nox";        

        var action = await Convert_Country_ReferenceData_to_DtoDataAsync(
            $"{rootPath}/Nox.Reference.Countries.json",
            $"{rootPath}/Nox.Reference.Holidays.json",
            $"{rootPath}/Nox.Reference.TimeZones.json",
            $"{rootPath}/Nox.Reference.Currencies.json"
            ); //source json file locations

        if (File.Exists($"{rootPath}/Nox.Reference.Countries.json"))
        {
            action.Should().NotBeNullOrWhiteSpace();
        }
        else
        {
            action.Should().BeNullOrWhiteSpace();
        }        
    }

    private static async Task<string> Convert_Country_ReferenceData_to_DtoDataAsync(string CountryDataFilePath, string HolidayDataFilePatch, string TimeZoneDataFilePath, string CurrencyDataFilePath)
    {
        if (File.Exists(CountryDataFilePath)
            && File.Exists(HolidayDataFilePatch)
            && File.Exists(TimeZoneDataFilePath)
            && File.Exists(CurrencyDataFilePath))
        {
            List<CountryReferenceData>? CountrySourceData = new();
            List<HolidayReferenceData>? HolidaySourceData = new();
            List<TimeZoneReferenceData>? TimeZoneSourceData = new();
            List<CurrencyReferenceData>? CurrencySourceData = new();

            List<CountryDto>? CreatedData = new();

            using (StreamReader r = new(CountryDataFilePath))
            {
                string json = r.ReadToEnd();
                CountrySourceData = System.Text.Json.JsonSerializer.Deserialize<List<CountryReferenceData>>(json);
            }

            using (StreamReader r = new(HolidayDataFilePatch))
            {
                string json = r.ReadToEnd();
                HolidaySourceData = System.Text.Json.JsonSerializer.Deserialize<List<HolidayReferenceData>>(json);
            }

            using (StreamReader r = new(TimeZoneDataFilePath))
            {
                string json = r.ReadToEnd();
                TimeZoneSourceData = System.Text.Json.JsonSerializer.Deserialize<List<TimeZoneReferenceData>>(json);
            }

            using (StreamReader r = new(CurrencyDataFilePath))
            {
                string json = r.ReadToEnd();
                CurrencySourceData = System.Text.Json.JsonSerializer.Deserialize<List<CurrencyReferenceData>>(json);
            }

            List<CurrencyReferenceData>? ValidatedCurrencySourceData = CreateValidatedCurrencyList(CurrencySourceData);

            if (CountrySourceData != null)
            {
                foreach (CountryReferenceData currentCountry in CountrySourceData)
                {
                    string? testedCountryID = testCountryId(currentCountry.Id);
                    string? testedCurrencyId = testCurrencyId(Convert_CurrencyJson_to_Dto(currentCountry?.Currency?.ToString()), ValidatedCurrencySourceData);

                    if (currentCountry != null
                        && !String.IsNullOrWhiteSpace(testedCountryID)
                        && currentCountry.Name != null                        
                        && !String.IsNullOrWhiteSpace(currentCountry.Name.Common)
                        && !String.IsNullOrWhiteSpace(currentCountry.Name.Official)
                        && !String.IsNullOrWhiteSpace(currentCountry.CountryIsoNumeric)
                        && !String.IsNullOrWhiteSpace(currentCountry.StartOfWeek)
                        && !String.IsNullOrWhiteSpace(testedCurrencyId)
                        && currentCountry.GeoCoordinates != null
                        )
                    {
                        CreatedData.Add(
                            new()
                            {
                                Id = testedCountryID,
                                Name = currentCountry.Name.Common,
                                OfficialName = Convert_String_to_Dto(currentCountry.Name.Official),
                                CountryIsoNumeric = Convert_IsoNumberReference_to_Dto(currentCountry.CountryIsoNumeric),
                                CountryIsoAlpha3 = currentCountry.CountryIsoAlpha3,
                                FlagEmoji = currentCountry.FlagEmoji,
                                GoogleMapsUrl = testUrl(currentCountry.Maps?.GoogleMaps),
                                OpenStreetMapsUrl = testUrl(currentCountry.Maps?.OpenStreetMaps),
                                StartOfWeek = Convert_DayString_to_Dto(FirstLetterToUpper(currentCountry.StartOfWeek)),
                                CurrencyId = testedCurrencyId,
                                Population = currentCountry.Population == null ? 0 : (int)currentCountry.Population,
                                GeoCoords = new LatLongDto(currentCountry.GeoCoordinates.Latitude, currentCountry.GeoCoordinates.Longitude),
                                FlagSvg = await testImageAsync(currentCountry.Flags?.FlagSvg == null ? null : currentCountry.Flags.FlagSvg, currentCountry.Id),
                                FlagPng = await testImageAsync(currentCountry.Flags?.FlagPng == null ? null : currentCountry.Flags.FlagPng, currentCountry.Id),
                                CoatOfArmsSvg = await testImageAsync(currentCountry.CoatOfArms?.CoatOfArmsSvg == null ? null : currentCountry.CoatOfArms.CoatOfArmsSvg, currentCountry.Id),
                                CoatOfArmsPng = await testImageAsync(currentCountry.CoatOfArms?.CoatOfArmsPng == null ? null : currentCountry.CoatOfArms.CoatOfArmsPng, currentCountry.Id),
                                CountryTimeZones = Convert_TimeZoneReference_to_Dto(TimeZoneSourceData, testedCountryID),
                                Holidays = Convert_HolidayReference_to_Dto(HolidaySourceData, testedCountryID)
                            }
                        );                                               
                    }                 
                }

                string rtnJson = System.Text.Json.JsonSerializer.Serialize(CreatedData, JsonOptions);

                return rtnJson;
            }
        }

        return string.Empty;
    }

    public class CountryReferenceData
    {
        [JsonPropertyName("cca2")]
        public System.String? Id { get; set; }

        [JsonPropertyName("name")]
        public CountryReferenceName? Name { get; set; }

        [JsonPropertyName("ccn3")]
        public System.String? CountryIsoNumeric { get; set; }

        [JsonPropertyName("cca3")]
        public System.String? CountryIsoAlpha3 { get; set; }

        [JsonPropertyName("flag")]
        public System.String? FlagEmoji { get; set; }

        [JsonPropertyName("maps")]
        public CountryReferenceMap? Maps { get; set; }

        [JsonPropertyName("startOfWeek")]
        public System.String? StartOfWeek { get; set; }

        [JsonPropertyName("currencies")]
        public dynamic? Currency { get; set; }

        [JsonPropertyName("population")]
        public int? Population { get; set; }

        [JsonPropertyName("geoCoordinates")]
        public CountryReferenceGeoLocation? GeoCoordinates { get; set; }

        [JsonPropertyName("flags")]
        public CountryReferenceFlag? Flags { get; set; }

        [JsonPropertyName("coatOfArms")]
        public CountryReferenceCoatOfArm? CoatOfArms { get; set; }
    }

    public class CountryReferenceName
    {
        [JsonPropertyName("common")]
        public System.String? Common { get; set; }

        [JsonPropertyName("official")]
        public System.String? Official { get; set; }
    }

    public class CountryReferenceMap
    {
        [JsonPropertyName("googleMaps")]
        public System.String? GoogleMaps { get; set; }

        [JsonPropertyName("openStreetMaps")]
        public System.String? OpenStreetMaps { get; set; }
    }

    public class CountryReferenceCurrency
    {
        public System.String? CurrencyId { get; set; }
    }

    public class CountryReferenceGeoLocation
    {
        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }
    }

    public class CountryReferenceFlag
    {
        [JsonPropertyName("svg")]
        public System.String? FlagSvg { get; set; }

        [JsonPropertyName("png")]
        public System.String? FlagPng { get; set; }
    }

    public class CountryReferenceCoatOfArm
    {
        [JsonPropertyName("svg")]
        public System.String? CoatOfArmsSvg { get; set; }

        [JsonPropertyName("png")]
        public System.String? CoatOfArmsPng { get; set; }
    }

    public class HolidayReferenceData
    {
        [JsonPropertyName("country")]
        public System.String? CountryId { get; set; }

        [JsonPropertyName("holidays")]
        public List<HolidayDayReferenceData>? Holidays { get; set; }

    }

    public class HolidayDayReferenceData
    {
        [JsonPropertyName("name")]
        public System.String? Name { get; set; }

        [JsonPropertyName("type")]
        public System.String? Type { get; set; }

        [JsonPropertyName("date")]
        public System.DateTime? Date { get; set; }

    }

    public class TimeZoneReferenceData
    {
        [JsonPropertyName("sdt_timeZoneAbbreviation")]
        public System.String? TimeZoneAbbreviation { get; set; }

        [JsonPropertyName("countriesWithTimeZone")]
        public List<System.String>? CountriesWithTimeZone { get; set; }

    }

    public class CurrencyReferenceData
    {
        [JsonPropertyName("isoCode")]
        public System.String? IsoCode { get; set; }

        [JsonPropertyName("isoNumber")]
        public System.String? IsoNumber { get; set; }

        [JsonPropertyName("symbol")]
        public System.String? Symbol { get; set; }
    }

    private static List<CountryTimeZoneDto> Convert_TimeZoneReference_to_Dto(List<TimeZoneReferenceData>? TimeZoneSourceData, string CurrentCountryId)
    {
        List<CountryTimeZoneDto> rtnTimeZoneList = new();

        if (TimeZoneSourceData != null)
        {   
            List<TimeZoneReferenceData>? foundTimeZones = TimeZoneSourceData.Where(
                TimeZone => TimeZone.CountriesWithTimeZone != null 
                && TimeZone.CountriesWithTimeZone.Contains(CurrentCountryId)).ToList();

            if (foundTimeZones != null)
            {
                foreach(TimeZoneReferenceData CurrentTimeZone in foundTimeZones.Distinct())
                {
                    if (CurrentTimeZone?.TimeZoneAbbreviation != null
                        && !String.IsNullOrWhiteSpace(testTimeZoneId(CurrentTimeZone.TimeZoneAbbreviation)))
                    {
                        if (!rtnTimeZoneList.Any(TimeZone => TimeZone.TimeZoneCode.Equals(CurrentTimeZone.TimeZoneAbbreviation)))
                        {
                            rtnTimeZoneList.Add(new()
                            {
                                TimeZoneCode = CurrentTimeZone.TimeZoneAbbreviation
                            });
                        }                        
                    }
                }
            }          
        }

        return rtnTimeZoneList;
    }

    private static List<HolidayDto> Convert_HolidayReference_to_Dto(List<HolidayReferenceData>? HolidaySourceData, string CurrentCountryId)
    {
        List<HolidayDto> rtnHolidaysList = new();

        if (HolidaySourceData != null)
        {
            List<HolidayReferenceData> foundHolidays = HolidaySourceData.Where(
                Holiday => !String.IsNullOrEmpty(Holiday.CountryId)
                && Holiday.Holidays != null
                && Holiday.CountryId.Equals(CurrentCountryId)).ToList();

            if (foundHolidays != null)
            {
                foreach (HolidayReferenceData CurrentHolidayList in foundHolidays)
                {
                    if (CurrentHolidayList?.CountryId != null
                        && !String.IsNullOrWhiteSpace(testCountryId(CurrentHolidayList.CountryId))
                        && CurrentHolidayList?.Holidays != null)
                    {
                        foreach (HolidayDayReferenceData CurrentHoliday in CurrentHolidayList.Holidays)
                        {
                            if (!String.IsNullOrWhiteSpace(CurrentHoliday.Name)
                                && !String.IsNullOrWhiteSpace(CurrentHoliday.Type)
                                && CurrentHoliday.Date != null)
                            {
                                string? tempName = Convert_String_to_Dto(CurrentHoliday.Name!);

                                rtnHolidaysList.Add(new() { 
                                    Date = (DateTime)CurrentHoliday.Date!, 
                                    Name = tempName ?? string.Empty, 
                                    Type = CurrentHoliday.Type
                                });
                            }
                        }                        
                    }
                }
            }            
        }

        return rtnHolidaysList;
    }

    private static ushort? Convert_IsoNumberReference_to_Dto(string CurrentIsoNumber)
    {
        return ushort.Parse(CurrentIsoNumber);
    }

    private static ushort Convert_DayString_to_Dto(string CurrentDay)
    {
        int tempDayOfWeek = (int)Enum.Parse(typeof(DayOfWeek), CurrentDay);

        return (ushort)tempDayOfWeek;
    }

    private static string? Convert_String_to_Dto(string? CurrentString)
    {
        if (!String.IsNullOrWhiteSpace(CurrentString))
        {
            if (CurrentString.Length > 63)
            {
                return CurrentString[..62];
            }
            else
            {
                return CurrentString;
            }
        }

        return null;
    }

    private static string? Convert_CurrencyJson_to_Dto(string? CurrentCurrencyObject)
    {
        if (!String.IsNullOrWhiteSpace(CurrentCurrencyObject)
            && CurrentCurrencyObject.Contains(':'))
        {
            return CurrentCurrencyObject.Split(":")[0]
                .Replace("{", String.Empty)
                .Replace("\"", "")
                .Trim();
        }

        return null;
    }

    private static string FirstLetterToUpper(string str)
    {
        if (str.Length > 1)
            return char.ToUpper(str[0]) + str.Substring(1);

        return str.ToUpper();
    }

    private static string? testCurrencyId(string? CurrentCurrencyId, List<CurrencyReferenceData>? currencyList)
    {
        if (!String.IsNullOrWhiteSpace(CurrentCurrencyId))
        {
            try
            {
                if (currencyList != null
                    && currencyList.Any(Currency => Currency!.IsoCode!.Equals(CurrentCurrencyId))
                    && Enum.IsDefined(typeof(Nox.Types.CurrencyCode), CurrentCurrencyId))
                {
                    return CurrentCurrencyId;
                }             
            }
            catch
            {
                //deliberately dont throw an error
                Console.WriteLine($"ERROR Non valid Enum: testCurrencyId: {CurrentCurrencyId}");
            }
        }

        return null;
    }

    private static string? testCountryId(string? CurrentCountryId)
    {
        if (!String.IsNullOrWhiteSpace(CurrentCountryId))
        {
            try
            {
                Nox.Types.CountryCode2 CurrentTest = Nox.Types.CountryCode2.From(CurrentCountryId);
                return CurrentTest.Value;
            }
            catch
            {
                //deliberately dont throw an error
                Console.WriteLine($"ERROR Non valid Enum: testCountryId: {CurrentCountryId}");
            }
        }

        return null;
    }

    private static string? testTimeZoneId(string? CurrentTimeZoneId)
    {
        if (!String.IsNullOrWhiteSpace(CurrentTimeZoneId))
        {
            try
            {
                Nox.Types.TimeZoneCode CurrentTest = Nox.Types.TimeZoneCode.From(CurrentTimeZoneId);
                return CurrentTest.Value;
            }
            catch
            {
                //deliberately dont throw an error
                Console.WriteLine($"ERROR Non valid Enum: testTimeZoneId: {CurrentTimeZoneId}");
            }
        }

        return null;
    }

    private static string? testUrl(string? CurrentUrl)
    {
        if (!String.IsNullOrWhiteSpace(CurrentUrl))
        {
            try
            {
                if (!CurrentUrl.StartsWith("https://"))
                    CurrentUrl = "https://" + CurrentUrl;

                Nox.Types.Url CurrentTest = Nox.Types.Url.From(CurrentUrl);
                return CurrentTest.Value.ToString();
            }
            catch
            {
                //deliberately dont throw an error
                Console.WriteLine($"ERROR Non valid Url: testUrl: {CurrentUrl}");
            }
        }

        return null;
    }

    private static async Task<ImageDto?> testImageAsync(string? CurrentUrl, string? CurrentName)
    {
        if (!String.IsNullOrWhiteSpace(testUrl(CurrentUrl))
            && !String.IsNullOrWhiteSpace(CurrentName))
        {
            try
            {
                long? getByteSize = await getByteSizeFromUrlAsync(CurrentUrl);

                if (getByteSize != null
                    && getByteSize > 0)
                {
                    Nox.Types.Image CurrentTest = Nox.Types.Image.From(CurrentUrl!, CurrentName, (int)getByteSize);
                    return new ImageDto(CurrentTest.Url, CurrentTest.PrettyName, CurrentTest.SizeInBytes);
                }                
            }
            catch
            {
                //deliberately dont throw an error
                Console.WriteLine($"ERROR Non valid Url: testImage: {CurrentUrl}");
            }
        }

        return null;
    }

    private static async Task<long?> getByteSizeFromUrlAsync(string? CurrentUrl)
    {
        if (!String.IsNullOrWhiteSpace(testUrl(CurrentUrl)))
        {
            HttpClient http = new HttpClient();

            var res = await http.GetAsync(CurrentUrl);

            byte[] bytes = await res.Content.ReadAsByteArrayAsync();

            return bytes.LongCount();
        }        

        return null;
     }

    private static List<CurrencyReferenceData> CreateValidatedCurrencyList(List<CurrencyReferenceData>? currencyList)
    {
        if (currencyList != null)
        {
            List<CurrencyReferenceData> rtnValidatedCurrencyList = new();

            foreach (CurrencyReferenceData currentCurrency in currencyList)
            {
                if (currentCurrency != null
                    && !String.IsNullOrWhiteSpace(currentCurrency.IsoCode)
                    && !String.IsNullOrWhiteSpace(currentCurrency.IsoNumber)
                    && !String.IsNullOrWhiteSpace(currentCurrency.Symbol)
                    && Enum.IsDefined(typeof(Nox.Types.CurrencyCode), currentCurrency.IsoCode)
                    && Enum.IsDefined(typeof(Nox.Types.CurrencyCode), (int)Convert_IsoNumberReference_to_Dto(currentCurrency.IsoNumber)!)
                    )
                {
                    rtnValidatedCurrencyList.Add(currentCurrency);
                }                
            }

            return rtnValidatedCurrencyList;
        }

        return new();
    }

    private static JsonSerializerOptions CreateJsonSerializerOptions()
    {
        var jsonOptions = new JsonSerializerOptions()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
        };

        jsonOptions.Converters.Add(new JsonStringEnumConverter());

        return jsonOptions;
    }
}