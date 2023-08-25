// Generated

#nullable enable
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using Nox.Types;
using Nox.Domain;
//using SampleWebApp.Application.DataTransferObjects;
using SampleWebApp.Domain;

namespace SampleWebApp.Application.Dto;

public record AllNoxTypeKeyDto(System.Int64 keyId, System.String keyTextId);

/// <summary>
/// Entity to test all nox types.
/// </summary>
public partial class AllNoxTypeDto
{

    /// <summary>
    /// DatabaseNumber Nox Type (Required).
    /// </summary>
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// Second Text Id (Required).
    /// </summary>
    public System.String TextId { get; set; } = default!;

    /// <summary>
    /// Area Nox Type (Required).
    /// </summary>
    public System.Decimal AreaField { get; set; } = default!;

    /// <summary>
    /// BooleanField Nox Type (Required).
    /// </summary>
    public System.Boolean BooleanField { get; set; } = default!;

    /// <summary>
    /// CountryCode2 Nox Type (Required).
    /// </summary>
    public System.String CountryCode2Field { get; set; } = default!;

    /// <summary>
    /// CountryCode3 Nox Type (Required).
    /// </summary>
    public System.String CountryCode3Field { get; set; } = default!;

    /// <summary>
    /// CountryNumber Nox Type (Required).
    /// </summary>
    public System.UInt16 CountryNumberField { get; set; } = default!;

    /// <summary>
    /// CultureCode Nox Type (Required).
    /// </summary>
    public System.String CultureCodeField { get; set; } = default!;

    /// <summary>
    /// CurrencyCode3Field Nox Type (Required).
    /// </summary>
    public System.String CurrencyCode3Field { get; set; } = default!;

    /// <summary>
    /// Currency Number Nox Type (Required).
    /// </summary>
    public System.Int16 CurrencyNumberField { get; set; } = default!;

    /// <summary>
    /// Date Nox Type (Required).
    /// </summary>
    public System.DateTime DateField { get; set; } = default!;

    /// <summary>
    /// Date Time Nox Type (Required).
    /// </summary>
    public System.DateTimeOffset DateTimeField { get; set; } = default!;

    /// <summary>
    /// Date Time Duration Nox Type (Required).
    /// </summary>
    public System.Int64 DateTimeDurationField { get; set; } = default!;

    /// <summary>
    /// Date Time Schedule Nox Type (Required).
    /// </summary>
    public System.String DateTimeScheduleField { get; set; } = default!;

    /// <summary>
    /// DayOfWeek Nox Type (Required).
    /// </summary>
    public System.UInt16 DayOfWeekField { get; set; } = default!;

    /// <summary>
    /// Distance Nox Type (Required).
    /// </summary>
    public System.Decimal DistanceField { get; set; } = default!;

    /// <summary>
    /// Email Nox Type (Required).
    /// </summary>
    public System.String EmailField { get; set; } = default!;

    /// <summary>
    /// Formula Nox Type (Required).
    /// </summary>
    public System.String FormulaField { get; set; } = default!;

    /// <summary>
    /// Guid Nox Type (Required).
    /// </summary>
    public System.Guid GuidField { get; set; } = default!;

    /// <summary>
    /// HtmlField Nox Type (Required).
    /// </summary>
    public System.String HtmlField { get; set; } = default!;

    /// <summary>
    /// Internet Domain Nox Type (Required).
    /// </summary>
    public System.String InternetDomainField { get; set; } = default!;

    /// <summary>
    /// IpAddress Nox Type (Required).
    /// </summary>
    public System.String IpAddressField { get; set; } = default!;

    /// <summary>
    /// Json Nox Type (Required).
    /// </summary>
    public System.String JsonField { get; set; } = default!;

    /// <summary>
    /// JwtToken Nox Type (Required).
    /// </summary>
    public System.String JwtTokenField { get; set; } = default!;

    /// <summary>
    /// Language Code Nox Type (Required).
    /// </summary>
    public System.String LanguageCodeField { get; set; } = default!;

    /// <summary>
    /// Length Nox Type (Required).
    /// </summary>
    public System.Decimal LengthField { get; set; } = default!;

    /// <summary>
    /// MacAddress Nox Type (Required).
    /// </summary>
    public System.String MacAddressField { get; set; } = default!;

    /// <summary>
    /// Mark down Nox Type (Required).
    /// </summary>
    public System.String MarkdownField { get; set; } = default!;

    /// <summary>
    /// Month Nox Type (Required).
    /// </summary>
    public System.Byte MonthField { get; set; } = default!;

    /// <summary>
    /// NuidField Type (Required).
    /// </summary>
    public System.UInt32 NuidField { get; set; } = default!;

    /// <summary>
    /// NumberField Nox Type (Required).
    /// </summary>
    public System.Int32 NumberField { get; set; } = default!;

    /// <summary>
    /// Percentage Nox Type (Required).
    /// </summary>
    public System.Single PercentageField { get; set; } = default!;

    /// <summary>
    /// Phone Number Nox Type (Required).
    /// </summary>
    public System.String PhoneNumberField { get; set; } = default!;

    /// <summary>
    /// Temperature Nox Type (Required).
    /// </summary>
    public System.Decimal TemperatureField { get; set; } = default!;

    /// <summary>
    /// Text Nox Type (Required).
    /// </summary>
    public System.String TextField { get; set; } = default!;

    /// <summary>
    /// Time Nox Type (Required).
    /// </summary>
    public System.TimeSpan TimeField { get; set; } = default!;

    /// <summary>
    /// TimeZoneCode Nox Type (Required).
    /// </summary>
    public System.String TimeZoneCodeField { get; set; } = default!;

    /// <summary>
    /// Uri Nox Type (Required).
    /// </summary>
    public System.String UriField { get; set; } = default!;

    /// <summary>
    /// Url Nox Type (Required).
    /// </summary>
    public System.String UrlField { get; set; } = default!;

    /// <summary>
    /// User Nox Type (Required).
    /// </summary>
    public System.String UserField { get; set; } = default!;

    /// <summary>
    /// Volume Nox Type (Required).
    /// </summary>
    public System.Decimal VolumeField { get; set; } = default!;

    /// <summary>
    /// Weight Nox Type (Required).
    /// </summary>
    public System.Decimal WeightField { get; set; } = default!;

    /// <summary>
    /// Yaml Nox Type (Required).
    /// </summary>
    public System.String YamlField { get; set; } = default!;

    /// <summary>
    /// YearField Nox Type (Required).
    /// </summary>
    public System.UInt16 YearField { get; set; } = default!;

    /// <summary>
    /// File Nox Type (Required).
    /// </summary>
    public FileDto FileField { get; set; } = default!;

    /// <summary>
    /// Image Nox Type (Required).
    /// </summary>
    public ImageDto ImageField { get; set; } = default!;

    /// <summary>
    /// Money Nox Type (Required).
    /// </summary>
    public MoneyDto MoneyField { get; set; } = default!;

    /// <summary>
    /// StreetAddress Nox Type (Required).
    /// </summary>
    public StreetAddressDto StreetAddressField { get; set; } = default!;

    /// <summary>
    /// TranslatedText Nox Type (Required).
    /// </summary>
    public TranslatedTextDto TranslatedTextField { get; set; } = default!;

    /// <summary>
    /// VatNumber Nox Type (Required).
    /// </summary>
    public VatNumberDto VatNumberField { get; set; } = default!;

    public System.DateTime? DeletedAtUtc { get; set; }
}