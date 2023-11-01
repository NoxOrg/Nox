// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

using DomainNamespace = TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

/// <summary>
/// Entity created for testing database.
/// </summary>
public partial class TestEntityForTypesUpdateDto : IEntityDto<DomainNamespace.TestEntityForTypes>
{
    /// <summary>
    ///  (Required).
    /// </summary>
    [Required(ErrorMessage = "TextTestField is required")]
    
    public System.String TextTestField { get; set; } = default!;
    /// <summary>
    ///  (Required).
    /// </summary>
    [Required(ErrorMessage = "NumberTestField is required")]
    
    public System.Int16 NumberTestField { get; set; } = default!;
    /// <summary>
    ///  (Optional).
    /// </summary>
    public MoneyDto? MoneyTestField { get; set; }
    /// <summary>
    ///  (Optional).
    /// </summary>
    public System.String? CountryCode2TestField { get; set; }
    /// <summary>
    ///  (Optional).
    /// </summary>
    public StreetAddressDto? StreetAddressTestField { get; set; }
    /// <summary>
    ///  (Optional).
    /// </summary>
    public System.String? CurrencyCode3TestField { get; set; }
    /// <summary>
    ///  (Optional).
    /// </summary>
    public System.UInt16? DayOfWeekTestField { get; set; }
    /// <summary>
    ///  (Optional).
    /// </summary>
    public System.String? JwtTokenTestField { get; set; }
    /// <summary>
    ///  (Optional).
    /// </summary>
    public LatLongDto? GeoCoordTestField { get; set; }
    /// <summary>
    ///  (Optional).
    /// </summary>
    public System.Decimal? AreaTestField { get; set; }
    /// <summary>
    ///  (Optional).
    /// </summary>
    public System.String? TimeZoneCodeTestField { get; set; }
    /// <summary>
    ///  (Optional).
    /// </summary>
    public System.Boolean? BooleanTestField { get; set; }
    /// <summary>
    ///  (Optional).
    /// </summary>
    public System.String? CountryCode3TestField { get; set; }
    /// <summary>
    ///  (Optional).
    /// </summary>
    public System.UInt16? CountryNumberTestField { get; set; }
    /// <summary>
    ///  (Optional).
    /// </summary>
    public System.Int16? CurrencyNumberTestField { get; set; }
    /// <summary>
    ///  (Optional).
    /// </summary>
    public System.DateTimeOffset? DateTimeTestField { get; set; }
    /// <summary>
    ///  (Optional).
    /// </summary>
    public DateTimeRangeDto? DateTimeRangeTestField { get; set; }
    /// <summary>
    ///  (Optional).
    /// </summary>
    public System.Decimal? DistanceTestField { get; set; }
    /// <summary>
    ///  (Optional).
    /// </summary>
    public System.String? EmailTestField { get; set; }
    /// <summary>
    ///  (Optional).
    /// </summary>
    public System.Guid? GuidTestField { get; set; }
    /// <summary>
    ///  (Optional).
    /// </summary>
    public System.String? InternetDomainTestField { get; set; }
    /// <summary>
    ///  (Optional).
    /// </summary>
    public System.String? IpAddressV4TestField { get; set; }
    /// <summary>
    ///  (Optional).
    /// </summary>
    public System.String? IpAddressV6TestField { get; set; }
    /// <summary>
    ///  (Optional).
    /// </summary>
    public System.String? JsonTestField { get; set; }
    /// <summary>
    ///  (Optional).
    /// </summary>
    public System.Decimal? LengthTestField { get; set; }
    /// <summary>
    ///  (Optional).
    /// </summary>
    public System.String? MacAddressTestField { get; set; }
    /// <summary>
    ///  (Optional).
    /// </summary>
    public System.Byte? MonthTestField { get; set; }
    /// <summary>
    ///  (Optional).
    /// </summary>
    public System.Single? PercentageTestField { get; set; }
    /// <summary>
    ///  (Optional).
    /// </summary>
    public System.String? PhoneNumberTestField { get; set; }
    /// <summary>
    ///  (Optional).
    /// </summary>
    public System.Decimal? TemperatureTestField { get; set; }
    /// <summary>
    ///  (Optional).
    /// </summary>
    public TranslatedTextDto? TranslatedTextTestField { get; set; }
    /// <summary>
    ///  (Optional).
    /// </summary>
    public System.String? UriTestField { get; set; }
    /// <summary>
    ///  (Optional).
    /// </summary>
    public System.Decimal? VolumeTestField { get; set; }
    /// <summary>
    ///  (Optional).
    /// </summary>
    public System.Decimal? WeightTestField { get; set; }
    /// <summary>
    ///  (Optional).
    /// </summary>
    public System.UInt16? YearTestField { get; set; }
    /// <summary>
    ///  (Optional).
    /// </summary>
    public System.String? CultureCodeTestField { get; set; }
    /// <summary>
    ///  (Optional).
    /// </summary>
    public System.String? LanguageCodeTestField { get; set; }
    /// <summary>
    ///  (Optional).
    /// </summary>
    public System.String? YamlTestField { get; set; }
    /// <summary>
    ///  (Optional).
    /// </summary>
    public System.Int64? DateTimeDurationTestField { get; set; }
    /// <summary>
    ///  (Optional).
    /// </summary>
    public System.DateTime? TimeTestField { get; set; }
    /// <summary>
    ///  (Optional).
    /// </summary>
    public VatNumberDto? VatNumberTestField { get; set; }
    /// <summary>
    ///  (Optional).
    /// </summary>
    public System.DateTime? DateTestField { get; set; }
    /// <summary>
    ///  (Optional).
    /// </summary>
    public System.String? MarkdownTestField { get; set; }
    /// <summary>
    ///  (Optional).
    /// </summary>
    public FileDto? FileTestField { get; set; }
    /// <summary>
    ///  (Optional).
    /// </summary>
    public System.String? ColorTestField { get; set; }
    /// <summary>
    ///  (Optional).
    /// </summary>
    public System.String? UrlTestField { get; set; }
    /// <summary>
    ///  (Optional).
    /// </summary>
    public System.String? DateTimeScheduleTestField { get; set; }
    /// <summary>
    ///  (Optional).
    /// </summary>
    public System.String? UserTestField { get; set; }
    /// <summary>
    ///  (Required).
    /// </summary>
    [Required(ErrorMessage = "AutoNumberTestField is required")]
    
    public System.Int64 AutoNumberTestField { get; set; } = default!;
    /// <summary>
    ///  (Optional).
    /// </summary>
    public System.String? HtmlTestField { get; set; }
    /// <summary>
    ///  (Optional).
    /// </summary>
    public ImageDto? ImageTestField { get; set; }
}