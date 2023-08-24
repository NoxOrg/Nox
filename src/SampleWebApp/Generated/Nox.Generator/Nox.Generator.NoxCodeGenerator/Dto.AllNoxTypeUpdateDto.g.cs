// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SampleWebApp.Application.Dto; 

/// <summary>
/// Entity to test all nox types.
/// </summary>
public partial class AllNoxTypeUpdateDto
{
    //TODO Add owned Entities and update odata endpoints
    /// <summary>
    /// Area Nox Type (Required).
    /// </summary>
    [Required(ErrorMessage = "AreaField is required")]
    
    public System.Decimal AreaField { get; set; } = default!;
    /// <summary>
    /// BooleanField Nox Type (Required).
    /// </summary>
    [Required(ErrorMessage = "BooleanField is required")]
    
    public System.Boolean BooleanField { get; set; } = default!;
    /// <summary>
    /// CountryCode2 Nox Type (Required).
    /// </summary>
    [Required(ErrorMessage = "CountryCode2Field is required")]
    
    public System.String CountryCode2Field { get; set; } = default!;
    /// <summary>
    /// CountryCode3 Nox Type (Required).
    /// </summary>
    [Required(ErrorMessage = "CountryCode3Field is required")]
    
    public System.String CountryCode3Field { get; set; } = default!;
    /// <summary>
    /// CountryNumber Nox Type (Required).
    /// </summary>
    [Required(ErrorMessage = "CountryNumberField is required")]
    
    public System.UInt16 CountryNumberField { get; set; } = default!;
    /// <summary>
    /// CultureCode Nox Type (Required).
    /// </summary>
    [Required(ErrorMessage = "CultureCodeField is required")]
    
    public System.String CultureCodeField { get; set; } = default!;
    /// <summary>
    /// CurrencyCode3Field Nox Type (Required).
    /// </summary>
    [Required(ErrorMessage = "CurrencyCode3Field is required")]
    
    public System.String CurrencyCode3Field { get; set; } = default!;
    /// <summary>
    /// Currency Number Nox Type (Required).
    /// </summary>
    [Required(ErrorMessage = "CurrencyNumberField is required")]
    
    public System.Int16 CurrencyNumberField { get; set; } = default!;
    /// <summary>
    /// Date Nox Type (Required).
    /// </summary>
    [Required(ErrorMessage = "DateField is required")]
    
    public System.DateTime DateField { get; set; } = default!;
    /// <summary>
    /// Date Time Nox Type (Required).
    /// </summary>
    [Required(ErrorMessage = "DateTimeField is required")]
    
    public System.DateTimeOffset DateTimeField { get; set; } = default!;
    /// <summary>
    /// Date Time Duration Nox Type (Required).
    /// </summary>
    [Required(ErrorMessage = "DateTimeDurationField is required")]
    
    public System.Int64 DateTimeDurationField { get; set; } = default!;
    /// <summary>
    /// Date Time Schedule Nox Type (Required).
    /// </summary>
    [Required(ErrorMessage = "DateTimeScheduleField is required")]
    
    public System.String DateTimeScheduleField { get; set; } = default!;
    /// <summary>
    /// DayOfWeek Nox Type (Required).
    /// </summary>
    [Required(ErrorMessage = "DayOfWeekField is required")]
    
    public System.UInt16 DayOfWeekField { get; set; } = default!;
    /// <summary>
    /// Distance Nox Type (Required).
    /// </summary>
    [Required(ErrorMessage = "DistanceField is required")]
    
    public System.Decimal DistanceField { get; set; } = default!;
    /// <summary>
    /// Email Nox Type (Required).
    /// </summary>
    [Required(ErrorMessage = "EmailField is required")]
    
    public System.String EmailField { get; set; } = default!;
    /// <summary>
    /// Guid Nox Type (Required).
    /// </summary>
    [Required(ErrorMessage = "GuidField is required")]
    
    public System.Guid GuidField { get; set; } = default!;
    /// <summary>
    /// HtmlField Nox Type (Required).
    /// </summary>
    [Required(ErrorMessage = "HtmlField is required")]
    
    public System.String HtmlField { get; set; } = default!;
    /// <summary>
    /// Internet Domain Nox Type (Required).
    /// </summary>
    [Required(ErrorMessage = "InternetDomainField is required")]
    
    public System.String InternetDomainField { get; set; } = default!;
    /// <summary>
    /// IpAddress Nox Type (Required).
    /// </summary>
    [Required(ErrorMessage = "IpAddressField is required")]
    
    public System.String IpAddressField { get; set; } = default!;
    /// <summary>
    /// Json Nox Type (Required).
    /// </summary>
    [Required(ErrorMessage = "JsonField is required")]
    
    public System.String JsonField { get; set; } = default!;
    /// <summary>
    /// JwtToken Nox Type (Required).
    /// </summary>
    [Required(ErrorMessage = "JwtTokenField is required")]
    
    public System.String JwtTokenField { get; set; } = default!;
    /// <summary>
    /// Language Code Nox Type (Required).
    /// </summary>
    [Required(ErrorMessage = "LanguageCodeField is required")]
    
    public System.String LanguageCodeField { get; set; } = default!;
    /// <summary>
    /// Length Nox Type (Required).
    /// </summary>
    [Required(ErrorMessage = "LengthField is required")]
    
    public System.Decimal LengthField { get; set; } = default!;
    /// <summary>
    /// MacAddress Nox Type (Required).
    /// </summary>
    [Required(ErrorMessage = "MacAddressField is required")]
    
    public System.String MacAddressField { get; set; } = default!;
    /// <summary>
    /// Mark down Nox Type (Required).
    /// </summary>
    [Required(ErrorMessage = "MarkdownField is required")]
    
    public System.String MarkdownField { get; set; } = default!;
    /// <summary>
    /// Month Nox Type (Required).
    /// </summary>
    [Required(ErrorMessage = "MonthField is required")]
    
    public System.Byte MonthField { get; set; } = default!;
    /// <summary>
    /// NuidField Type (Required).
    /// </summary>
    [Required(ErrorMessage = "NuidField is required")]
    
    public System.UInt32 NuidField { get; set; } = default!;
    /// <summary>
    /// NumberField Nox Type (Required).
    /// </summary>
    [Required(ErrorMessage = "NumberField is required")]
    
    public System.Int32 NumberField { get; set; } = default!;
    /// <summary>
    /// Percentage Nox Type (Required).
    /// </summary>
    [Required(ErrorMessage = "PercentageField is required")]
    
    public System.Single PercentageField { get; set; } = default!;
    /// <summary>
    /// Phone Number Nox Type (Required).
    /// </summary>
    [Required(ErrorMessage = "PhoneNumberField is required")]
    
    public System.String PhoneNumberField { get; set; } = default!;
    /// <summary>
    /// Temperature Nox Type (Required).
    /// </summary>
    [Required(ErrorMessage = "TemperatureField is required")]
    
    public System.Decimal TemperatureField { get; set; } = default!;
    /// <summary>
    /// Text Nox Type (Required).
    /// </summary>
    [Required(ErrorMessage = "TextField is required")]
    
    public System.String TextField { get; set; } = default!;
    /// <summary>
    /// Time Nox Type (Required).
    /// </summary>
    [Required(ErrorMessage = "TimeField is required")]
    
    public System.TimeSpan TimeField { get; set; } = default!;
    /// <summary>
    /// TimeZoneCode Nox Type (Required).
    /// </summary>
    [Required(ErrorMessage = "TimeZoneCodeField is required")]
    
    public System.String TimeZoneCodeField { get; set; } = default!;
    /// <summary>
    /// Uri Nox Type (Required).
    /// </summary>
    [Required(ErrorMessage = "UriField is required")]
    
    public System.String UriField { get; set; } = default!;
    /// <summary>
    /// Url Nox Type (Required).
    /// </summary>
    [Required(ErrorMessage = "UrlField is required")]
    
    public System.String UrlField { get; set; } = default!;
    /// <summary>
    /// User Nox Type (Required).
    /// </summary>
    [Required(ErrorMessage = "UserField is required")]
    
    public System.String UserField { get; set; } = default!;
    /// <summary>
    /// Volume Nox Type (Required).
    /// </summary>
    [Required(ErrorMessage = "VolumeField is required")]
    
    public System.Decimal VolumeField { get; set; } = default!;
    /// <summary>
    /// Weight Nox Type (Required).
    /// </summary>
    [Required(ErrorMessage = "WeightField is required")]
    
    public System.Decimal WeightField { get; set; } = default!;
    /// <summary>
    /// Yaml Nox Type (Required).
    /// </summary>
    [Required(ErrorMessage = "YamlField is required")]
    
    public System.String YamlField { get; set; } = default!;
    /// <summary>
    /// YearField Nox Type (Required).
    /// </summary>
    [Required(ErrorMessage = "YearField is required")]
    
    public System.UInt16 YearField { get; set; } = default!;
    /// <summary>
    /// File Nox Type (Required).
    /// </summary>
    [Required(ErrorMessage = "FileField is required")]
    
    public FileDto FileField { get; set; } = default!;
    /// <summary>
    /// Image Nox Type (Required).
    /// </summary>
    [Required(ErrorMessage = "ImageField is required")]
    
    public ImageDto ImageField { get; set; } = default!;
    /// <summary>
    /// Money Nox Type (Required).
    /// </summary>
    [Required(ErrorMessage = "MoneyField is required")]
    
    public MoneyDto MoneyField { get; set; } = default!;
    /// <summary>
    /// StreetAddress Nox Type (Required).
    /// </summary>
    [Required(ErrorMessage = "StreetAddressField is required")]
    
    public StreetAddressDto StreetAddressField { get; set; } = default!;
    /// <summary>
    /// TranslatedText Nox Type (Required).
    /// </summary>
    [Required(ErrorMessage = "TranslatedTextField is required")]
    
    public TranslatedTextDto TranslatedTextField { get; set; } = default!;
    /// <summary>
    /// VatNumber Nox Type (Required).
    /// </summary>
    [Required(ErrorMessage = "VatNumberField is required")]
    
    public VatNumberDto VatNumberField { get; set; } = default!;
}