// Generated

#nullable enable

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using Nox.Application.Dto;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;


using DomainNamespace = TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

public record TestEntityForTypesKeyDto(System.String keyId);

/// <summary>
/// Update TestEntityForTypes
/// Entity created for testing database.
/// </summary>
public partial class TestEntityForTypesDto : TestEntityForTypesDtoBase
{

}

/// <summary>
/// Entity created for testing database.
/// </summary>
public abstract class TestEntityForTypesDtoBase : EntityDtoBase
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.TextTestField is not null)
            ExecuteActionAndCollectValidationExceptions("TextTestField", () => DomainNamespace.TestEntityForTypesMetadata.CreateTextTestField(this.TextTestField.NonNullValue<System.String>()), result);
        else
            result.Add("TextTestField", new [] { "TextTestField is Required." });
    
        if (this.EnumerationTestField is not null)
            ExecuteActionAndCollectValidationExceptions("EnumerationTestField", () => DomainNamespace.TestEntityForTypesMetadata.CreateEnumerationTestField(this.EnumerationTestField.NonNullValue<System.Int32>()), result);
        ExecuteActionAndCollectValidationExceptions("NumberTestField", () => DomainNamespace.TestEntityForTypesMetadata.CreateNumberTestField(this.NumberTestField), result);
    
        if (this.MoneyTestField is not null)
            ExecuteActionAndCollectValidationExceptions("MoneyTestField", () => DomainNamespace.TestEntityForTypesMetadata.CreateMoneyTestField(this.MoneyTestField.NonNullValue<MoneyDto>()), result);
        if (this.CountryCode2TestField is not null)
            ExecuteActionAndCollectValidationExceptions("CountryCode2TestField", () => DomainNamespace.TestEntityForTypesMetadata.CreateCountryCode2TestField(this.CountryCode2TestField.NonNullValue<System.String>()), result);
        if (this.StreetAddressTestField is not null)
            ExecuteActionAndCollectValidationExceptions("StreetAddressTestField", () => DomainNamespace.TestEntityForTypesMetadata.CreateStreetAddressTestField(this.StreetAddressTestField.NonNullValue<StreetAddressDto>()), result);
        if (this.CurrencyCode3TestField is not null)
            ExecuteActionAndCollectValidationExceptions("CurrencyCode3TestField", () => DomainNamespace.TestEntityForTypesMetadata.CreateCurrencyCode3TestField(this.CurrencyCode3TestField.NonNullValue<System.String>()), result);
        if (this.DayOfWeekTestField is not null)
            ExecuteActionAndCollectValidationExceptions("DayOfWeekTestField", () => DomainNamespace.TestEntityForTypesMetadata.CreateDayOfWeekTestField(this.DayOfWeekTestField.NonNullValue<System.UInt16>()), result);
        if (this.JwtTokenTestField is not null)
            ExecuteActionAndCollectValidationExceptions("JwtTokenTestField", () => DomainNamespace.TestEntityForTypesMetadata.CreateJwtTokenTestField(this.JwtTokenTestField.NonNullValue<System.String>()), result);
        if (this.GeoCoordTestField is not null)
            ExecuteActionAndCollectValidationExceptions("GeoCoordTestField", () => DomainNamespace.TestEntityForTypesMetadata.CreateGeoCoordTestField(this.GeoCoordTestField.NonNullValue<LatLongDto>()), result);
        if (this.AreaTestField is not null)
            ExecuteActionAndCollectValidationExceptions("AreaTestField", () => DomainNamespace.TestEntityForTypesMetadata.CreateAreaTestField(this.AreaTestField.NonNullValue<System.Decimal>()), result);
        if (this.TimeZoneCodeTestField is not null)
            ExecuteActionAndCollectValidationExceptions("TimeZoneCodeTestField", () => DomainNamespace.TestEntityForTypesMetadata.CreateTimeZoneCodeTestField(this.TimeZoneCodeTestField.NonNullValue<System.String>()), result);
        if (this.BooleanTestField is not null)
            ExecuteActionAndCollectValidationExceptions("BooleanTestField", () => DomainNamespace.TestEntityForTypesMetadata.CreateBooleanTestField(this.BooleanTestField.NonNullValue<System.Boolean>()), result);
        if (this.CountryCode3TestField is not null)
            ExecuteActionAndCollectValidationExceptions("CountryCode3TestField", () => DomainNamespace.TestEntityForTypesMetadata.CreateCountryCode3TestField(this.CountryCode3TestField.NonNullValue<System.String>()), result);
        if (this.CountryNumberTestField is not null)
            ExecuteActionAndCollectValidationExceptions("CountryNumberTestField", () => DomainNamespace.TestEntityForTypesMetadata.CreateCountryNumberTestField(this.CountryNumberTestField.NonNullValue<System.UInt16>()), result);
        if (this.CurrencyNumberTestField is not null)
            ExecuteActionAndCollectValidationExceptions("CurrencyNumberTestField", () => DomainNamespace.TestEntityForTypesMetadata.CreateCurrencyNumberTestField(this.CurrencyNumberTestField.NonNullValue<System.Int16>()), result);
        if (this.DateTimeTestField is not null)
            ExecuteActionAndCollectValidationExceptions("DateTimeTestField", () => DomainNamespace.TestEntityForTypesMetadata.CreateDateTimeTestField(this.DateTimeTestField.NonNullValue<System.DateTimeOffset>()), result);
        if (this.DateTimeRangeTestField is not null)
            ExecuteActionAndCollectValidationExceptions("DateTimeRangeTestField", () => DomainNamespace.TestEntityForTypesMetadata.CreateDateTimeRangeTestField(this.DateTimeRangeTestField.NonNullValue<DateTimeRangeDto>()), result);
        if (this.DistanceTestField is not null)
            ExecuteActionAndCollectValidationExceptions("DistanceTestField", () => DomainNamespace.TestEntityForTypesMetadata.CreateDistanceTestField(this.DistanceTestField.NonNullValue<System.Decimal>()), result);
        if (this.EmailTestField is not null)
            ExecuteActionAndCollectValidationExceptions("EmailTestField", () => DomainNamespace.TestEntityForTypesMetadata.CreateEmailTestField(this.EmailTestField.NonNullValue<System.String>()), result); 
        if (this.GuidTestField is not null)
            ExecuteActionAndCollectValidationExceptions("GuidTestField", () => DomainNamespace.TestEntityForTypesMetadata.CreateGuidTestField(this.GuidTestField.NonNullValue<System.Guid>()), result); 
        if (this.InternetDomainTestField is not null)
            ExecuteActionAndCollectValidationExceptions("InternetDomainTestField", () => DomainNamespace.TestEntityForTypesMetadata.CreateInternetDomainTestField(this.InternetDomainTestField.NonNullValue<System.String>()), result);
        if (this.IpAddressV4TestField is not null)
            ExecuteActionAndCollectValidationExceptions("IpAddressV4TestField", () => DomainNamespace.TestEntityForTypesMetadata.CreateIpAddressV4TestField(this.IpAddressV4TestField.NonNullValue<System.String>()), result);
        if (this.IpAddressV6TestField is not null)
            ExecuteActionAndCollectValidationExceptions("IpAddressV6TestField", () => DomainNamespace.TestEntityForTypesMetadata.CreateIpAddressV6TestField(this.IpAddressV6TestField.NonNullValue<System.String>()), result);
        if (this.JsonTestField is not null)
            ExecuteActionAndCollectValidationExceptions("JsonTestField", () => DomainNamespace.TestEntityForTypesMetadata.CreateJsonTestField(this.JsonTestField.NonNullValue<System.String>()), result);
        if (this.LengthTestField is not null)
            ExecuteActionAndCollectValidationExceptions("LengthTestField", () => DomainNamespace.TestEntityForTypesMetadata.CreateLengthTestField(this.LengthTestField.NonNullValue<System.Decimal>()), result);
        if (this.MacAddressTestField is not null)
            ExecuteActionAndCollectValidationExceptions("MacAddressTestField", () => DomainNamespace.TestEntityForTypesMetadata.CreateMacAddressTestField(this.MacAddressTestField.NonNullValue<System.String>()), result);
        if (this.MonthTestField is not null)
            ExecuteActionAndCollectValidationExceptions("MonthTestField", () => DomainNamespace.TestEntityForTypesMetadata.CreateMonthTestField(this.MonthTestField.NonNullValue<System.Byte>()), result); 
        if (this.PercentageTestField is not null)
            ExecuteActionAndCollectValidationExceptions("PercentageTestField", () => DomainNamespace.TestEntityForTypesMetadata.CreatePercentageTestField(this.PercentageTestField.NonNullValue<System.Single>()), result);
        if (this.PhoneNumberTestField is not null)
            ExecuteActionAndCollectValidationExceptions("PhoneNumberTestField", () => DomainNamespace.TestEntityForTypesMetadata.CreatePhoneNumberTestField(this.PhoneNumberTestField.NonNullValue<System.String>()), result);
        if (this.TemperatureTestField is not null)
            ExecuteActionAndCollectValidationExceptions("TemperatureTestField", () => DomainNamespace.TestEntityForTypesMetadata.CreateTemperatureTestField(this.TemperatureTestField.NonNullValue<System.Decimal>()), result);
        if (this.TranslatedTextTestField is not null)
            ExecuteActionAndCollectValidationExceptions("TranslatedTextTestField", () => DomainNamespace.TestEntityForTypesMetadata.CreateTranslatedTextTestField(this.TranslatedTextTestField.NonNullValue<TranslatedTextDto>()), result);
        if (this.UriTestField is not null)
            ExecuteActionAndCollectValidationExceptions("UriTestField", () => DomainNamespace.TestEntityForTypesMetadata.CreateUriTestField(this.UriTestField.NonNullValue<System.String>()), result);
        if (this.VolumeTestField is not null)
            ExecuteActionAndCollectValidationExceptions("VolumeTestField", () => DomainNamespace.TestEntityForTypesMetadata.CreateVolumeTestField(this.VolumeTestField.NonNullValue<System.Decimal>()), result);
        if (this.WeightTestField is not null)
            ExecuteActionAndCollectValidationExceptions("WeightTestField", () => DomainNamespace.TestEntityForTypesMetadata.CreateWeightTestField(this.WeightTestField.NonNullValue<System.Decimal>()), result);
        if (this.YearTestField is not null)
            ExecuteActionAndCollectValidationExceptions("YearTestField", () => DomainNamespace.TestEntityForTypesMetadata.CreateYearTestField(this.YearTestField.NonNullValue<System.UInt16>()), result);
        if (this.CultureCodeTestField is not null)
            ExecuteActionAndCollectValidationExceptions("CultureCodeTestField", () => DomainNamespace.TestEntityForTypesMetadata.CreateCultureCodeTestField(this.CultureCodeTestField.NonNullValue<System.String>()), result);
        if (this.LanguageCodeTestField is not null)
            ExecuteActionAndCollectValidationExceptions("LanguageCodeTestField", () => DomainNamespace.TestEntityForTypesMetadata.CreateLanguageCodeTestField(this.LanguageCodeTestField.NonNullValue<System.String>()), result);
        if (this.YamlTestField is not null)
            ExecuteActionAndCollectValidationExceptions("YamlTestField", () => DomainNamespace.TestEntityForTypesMetadata.CreateYamlTestField(this.YamlTestField.NonNullValue<System.String>()), result);
        if (this.DateTimeDurationTestField is not null)
            ExecuteActionAndCollectValidationExceptions("DateTimeDurationTestField", () => DomainNamespace.TestEntityForTypesMetadata.CreateDateTimeDurationTestField(this.DateTimeDurationTestField.NonNullValue<System.Int64>()), result);
        if (this.TimeTestField is not null)
            ExecuteActionAndCollectValidationExceptions("TimeTestField", () => DomainNamespace.TestEntityForTypesMetadata.CreateTimeTestField(this.TimeTestField.NonNullValue<System.DateTime>()), result);
        if (this.VatNumberTestField is not null)
            ExecuteActionAndCollectValidationExceptions("VatNumberTestField", () => DomainNamespace.TestEntityForTypesMetadata.CreateVatNumberTestField(this.VatNumberTestField.NonNullValue<VatNumberDto>()), result);
        if (this.DateTestField is not null)
            ExecuteActionAndCollectValidationExceptions("DateTestField", () => DomainNamespace.TestEntityForTypesMetadata.CreateDateTestField(this.DateTestField.NonNullValue<System.DateTime>()), result);
        if (this.MarkdownTestField is not null)
            ExecuteActionAndCollectValidationExceptions("MarkdownTestField", () => DomainNamespace.TestEntityForTypesMetadata.CreateMarkdownTestField(this.MarkdownTestField.NonNullValue<System.String>()), result);
        if (this.FileTestField is not null)
            ExecuteActionAndCollectValidationExceptions("FileTestField", () => DomainNamespace.TestEntityForTypesMetadata.CreateFileTestField(this.FileTestField.NonNullValue<FileDto>()), result);
        if (this.ColorTestField is not null)
            ExecuteActionAndCollectValidationExceptions("ColorTestField", () => DomainNamespace.TestEntityForTypesMetadata.CreateColorTestField(this.ColorTestField.NonNullValue<System.String>()), result);
        if (this.UrlTestField is not null)
            ExecuteActionAndCollectValidationExceptions("UrlTestField", () => DomainNamespace.TestEntityForTypesMetadata.CreateUrlTestField(this.UrlTestField.NonNullValue<System.String>()), result);
        if (this.DateTimeScheduleTestField is not null)
            ExecuteActionAndCollectValidationExceptions("DateTimeScheduleTestField", () => DomainNamespace.TestEntityForTypesMetadata.CreateDateTimeScheduleTestField(this.DateTimeScheduleTestField.NonNullValue<System.String>()), result);
        if (this.UserTestField is not null)
            ExecuteActionAndCollectValidationExceptions("UserTestField", () => DomainNamespace.TestEntityForTypesMetadata.CreateUserTestField(this.UserTestField.NonNullValue<System.String>()), result); 
        ExecuteActionAndCollectValidationExceptions("AutoNumberTestField", () => DomainNamespace.TestEntityForTypesMetadata.CreateAutoNumberTestField(this.AutoNumberTestField), result);
    
        if (this.HtmlTestField is not null)
            ExecuteActionAndCollectValidationExceptions("HtmlTestField", () => DomainNamespace.TestEntityForTypesMetadata.CreateHtmlTestField(this.HtmlTestField.NonNullValue<System.String>()), result);
        if (this.ImageTestField is not null)
            ExecuteActionAndCollectValidationExceptions("ImageTestField", () => DomainNamespace.TestEntityForTypesMetadata.CreateImageTestField(this.ImageTestField.NonNullValue<ImageDto>()), result);

        return result;
    }
    #endregion

    /// <summary>
    /// 
    /// </summary>    
    public System.String Id { get; set; } = default!;

    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.String TextTestField { get; set; } = default!;

    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.Int32? EnumerationTestField { get; set; }
    public string? EnumerationTestFieldName { get; set; } = default!;

    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.Int16 NumberTestField { get; set; } = default!;

    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Optional.</remarks>
    public MoneyDto? MoneyTestField { get; set; }

    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.String? CountryCode2TestField { get; set; }

    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Optional.</remarks>
    public StreetAddressDto? StreetAddressTestField { get; set; }

    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.String? CurrencyCode3TestField { get; set; }

    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.UInt16? DayOfWeekTestField { get; set; }

    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.String? JwtTokenTestField { get; set; }

    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Optional.</remarks>
    public LatLongDto? GeoCoordTestField { get; set; }

    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.Decimal? AreaTestField { get; set; }

    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.String? TimeZoneCodeTestField { get; set; }

    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.Boolean? BooleanTestField { get; set; }

    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.String? CountryCode3TestField { get; set; }

    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.UInt16? CountryNumberTestField { get; set; }

    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.Int16? CurrencyNumberTestField { get; set; }

    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.DateTimeOffset? DateTimeTestField { get; set; }

    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Optional.</remarks>
    public DateTimeRangeDto? DateTimeRangeTestField { get; set; }

    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.Decimal? DistanceTestField { get; set; }

    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.String? EmailTestField { get; set; }

    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.Guid? GuidTestField { get; set; }

    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.String? InternetDomainTestField { get; set; }

    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.String? IpAddressV4TestField { get; set; }

    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.String? IpAddressV6TestField { get; set; }

    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.String? JsonTestField { get; set; }

    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.Decimal? LengthTestField { get; set; }

    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.String? MacAddressTestField { get; set; }

    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.Byte? MonthTestField { get; set; }

    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.Single? PercentageTestField { get; set; }

    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.String? PhoneNumberTestField { get; set; }

    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.Decimal? TemperatureTestField { get; set; }

    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Optional.</remarks>
    public TranslatedTextDto? TranslatedTextTestField { get; set; }

    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.String? UriTestField { get; set; }

    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.Decimal? VolumeTestField { get; set; }

    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.Decimal? WeightTestField { get; set; }

    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.UInt16? YearTestField { get; set; }

    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.String? CultureCodeTestField { get; set; }

    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.String? LanguageCodeTestField { get; set; }

    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.String? YamlTestField { get; set; }

    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.Int64? DateTimeDurationTestField { get; set; }

    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.DateTime? TimeTestField { get; set; }

    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Optional.</remarks>
    public VatNumberDto? VatNumberTestField { get; set; }

    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.DateTime? DateTestField { get; set; }

    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.String? MarkdownTestField { get; set; }

    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Optional.</remarks>
    public FileDto? FileTestField { get; set; }

    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.String? ColorTestField { get; set; }

    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.String? UrlTestField { get; set; }

    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.String? DateTimeScheduleTestField { get; set; }

    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.String? UserTestField { get; set; }

    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Optional.</remarks>
    public int? FormulaTestField { get; set; }

    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.Int64 AutoNumberTestField { get; set; } = default!;

    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.String? HtmlTestField { get; set; }

    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Optional.</remarks>
    public ImageDto? ImageTestField { get; set; }
    [System.Text.Json.Serialization.JsonIgnore]
    public System.DateTime? DeletedAtUtc { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}