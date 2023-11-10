// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using DomainNamespace = TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

public partial class TestEntityForTypesCreateDto : TestEntityForTypesCreateDtoBase
{

}

/// <summary>
/// Entity created for testing database.
/// </summary>
public abstract class TestEntityForTypesCreateDtoBase : IEntityDto<DomainNamespace.TestEntityForTypes>
{
    /// <summary>
    /// 
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "Id is required")]
    public System.String Id { get; set; } = default!;
    /// <summary>
    ///  
    /// <remarks>Required</remarks>    
    /// </summary>
    [Required(ErrorMessage = "TextTestField is required")]
    
    public virtual System.String TextTestField { get; set; } = default!;
    /// <summary>
    ///  
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual System.Int32? EnumerationTestField { get; set; }
    /// <summary>
    ///  
    /// <remarks>Required</remarks>    
    /// </summary>
    [Required(ErrorMessage = "NumberTestField is required")]
    
    public virtual System.Int16 NumberTestField { get; set; } = default!;
    /// <summary>
    ///  
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual MoneyDto? MoneyTestField { get; set; }
    /// <summary>
    ///  
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual System.String? CountryCode2TestField { get; set; }
    /// <summary>
    ///  
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual StreetAddressDto? StreetAddressTestField { get; set; }
    /// <summary>
    ///  
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual System.String? CurrencyCode3TestField { get; set; }
    /// <summary>
    ///  
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual System.UInt16? DayOfWeekTestField { get; set; }
    /// <summary>
    ///  
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual System.String? JwtTokenTestField { get; set; }
    /// <summary>
    ///  
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual LatLongDto? GeoCoordTestField { get; set; }
    /// <summary>
    ///  
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual System.Decimal? AreaTestField { get; set; }
    /// <summary>
    ///  
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual System.String? TimeZoneCodeTestField { get; set; }
    /// <summary>
    ///  
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual System.Boolean? BooleanTestField { get; set; }
    /// <summary>
    ///  
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual System.String? CountryCode3TestField { get; set; }
    /// <summary>
    ///  
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual System.UInt16? CountryNumberTestField { get; set; }
    /// <summary>
    ///  
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual System.Int16? CurrencyNumberTestField { get; set; }
    /// <summary>
    ///  
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual System.DateTimeOffset? DateTimeTestField { get; set; }
    /// <summary>
    ///  
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual DateTimeRangeDto? DateTimeRangeTestField { get; set; }
    /// <summary>
    ///  
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual System.Decimal? DistanceTestField { get; set; }
    /// <summary>
    ///  
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual System.String? EmailTestField { get; set; }
    /// <summary>
    ///  
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual System.Byte[]? EncryptedTextTestField { get; set; }
    /// <summary>
    ///  
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual System.Guid? GuidTestField { get; set; }
    /// <summary>
    ///  
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual HashedTextDto? HashedTextTestField { get; set; }
    /// <summary>
    ///  
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual System.String? InternetDomainTestField { get; set; }
    /// <summary>
    ///  
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual System.String? IpAddressV4TestField { get; set; }
    /// <summary>
    ///  
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual System.String? IpAddressV6TestField { get; set; }
    /// <summary>
    ///  
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual System.String? JsonTestField { get; set; }
    /// <summary>
    ///  
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual System.Decimal? LengthTestField { get; set; }
    /// <summary>
    ///  
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual System.String? MacAddressTestField { get; set; }
    /// <summary>
    ///  
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual System.Byte? MonthTestField { get; set; }
    /// <summary>
    ///  
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual PasswordDto? PasswordTestField { get; set; }
    /// <summary>
    ///  
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual System.Single? PercentageTestField { get; set; }
    /// <summary>
    ///  
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual System.String? PhoneNumberTestField { get; set; }
    /// <summary>
    ///  
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual System.Decimal? TemperatureTestField { get; set; }
    /// <summary>
    ///  
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual TranslatedTextDto? TranslatedTextTestField { get; set; }
    /// <summary>
    ///  
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual System.String? UriTestField { get; set; }
    /// <summary>
    ///  
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual System.Decimal? VolumeTestField { get; set; }
    /// <summary>
    ///  
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual System.Decimal? WeightTestField { get; set; }
    /// <summary>
    ///  
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual System.UInt16? YearTestField { get; set; }
    /// <summary>
    ///  
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual System.String? CultureCodeTestField { get; set; }
    /// <summary>
    ///  
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual System.String? LanguageCodeTestField { get; set; }
    /// <summary>
    ///  
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual System.String? YamlTestField { get; set; }
    /// <summary>
    ///  
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual System.Int64? DateTimeDurationTestField { get; set; }
    /// <summary>
    ///  
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual System.DateTime? TimeTestField { get; set; }
    /// <summary>
    ///  
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual VatNumberDto? VatNumberTestField { get; set; }
    /// <summary>
    ///  
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual System.DateTime? DateTestField { get; set; }
    /// <summary>
    ///  
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual System.String? MarkdownTestField { get; set; }
    /// <summary>
    ///  
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual FileDto? FileTestField { get; set; }
    /// <summary>
    ///  
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual System.String? ColorTestField { get; set; }
    /// <summary>
    ///  
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual System.String? UrlTestField { get; set; }
    /// <summary>
    ///  
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual System.String? DateTimeScheduleTestField { get; set; }
    /// <summary>
    ///  
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual System.String? UserTestField { get; set; }
    /// <summary>
    ///  
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual System.String? FormulaTestField { get; set; }
    /// <summary>
    ///  
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual System.String? HtmlTestField { get; set; }
    /// <summary>
    ///  
    /// <remarks>Optional</remarks>    
    /// </summary>
    public virtual ImageDto? ImageTestField { get; set; }
}