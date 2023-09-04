// Generated

#nullable enable
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;
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
    public System.DateTime TimeField { get; set; } = default!;

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
    /// LatLongField Nox Type (Required).
    /// </summary>
    public LatLongDto LatLongField { get; set; } = default!;

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

    public AllNoxType ToEntity()
    {
        var entity = new AllNoxType();
        entity.Id = AllNoxType.CreateId(Id);
        entity.TextId = AllNoxType.CreateTextId(TextId);
        entity.AreaField = AllNoxType.CreateAreaField(AreaField);
        entity.BooleanField = AllNoxType.CreateBooleanField(BooleanField);
        entity.CountryCode2Field = AllNoxType.CreateCountryCode2Field(CountryCode2Field);
        entity.CountryCode3Field = AllNoxType.CreateCountryCode3Field(CountryCode3Field);
        entity.CountryNumberField = AllNoxType.CreateCountryNumberField(CountryNumberField);
        entity.CultureCodeField = AllNoxType.CreateCultureCodeField(CultureCodeField);
        entity.CurrencyCode3Field = AllNoxType.CreateCurrencyCode3Field(CurrencyCode3Field);
        entity.CurrencyNumberField = AllNoxType.CreateCurrencyNumberField(CurrencyNumberField);
        entity.DateField = AllNoxType.CreateDateField(DateField);
        entity.DateTimeField = AllNoxType.CreateDateTimeField(DateTimeField);
        entity.DateTimeDurationField = AllNoxType.CreateDateTimeDurationField(DateTimeDurationField);
        entity.DateTimeScheduleField = AllNoxType.CreateDateTimeScheduleField(DateTimeScheduleField);
        entity.DayOfWeekField = AllNoxType.CreateDayOfWeekField(DayOfWeekField);
        entity.DistanceField = AllNoxType.CreateDistanceField(DistanceField);
        entity.EmailField = AllNoxType.CreateEmailField(EmailField);
        entity.GuidField = AllNoxType.CreateGuidField(GuidField);
        entity.HtmlField = AllNoxType.CreateHtmlField(HtmlField);
        entity.InternetDomainField = AllNoxType.CreateInternetDomainField(InternetDomainField);
        entity.IpAddressField = AllNoxType.CreateIpAddressField(IpAddressField);
        entity.JsonField = AllNoxType.CreateJsonField(JsonField);
        entity.JwtTokenField = AllNoxType.CreateJwtTokenField(JwtTokenField);
        entity.LanguageCodeField = AllNoxType.CreateLanguageCodeField(LanguageCodeField);
        entity.LengthField = AllNoxType.CreateLengthField(LengthField);
        entity.MacAddressField = AllNoxType.CreateMacAddressField(MacAddressField);
        entity.MarkdownField = AllNoxType.CreateMarkdownField(MarkdownField);
        entity.MonthField = AllNoxType.CreateMonthField(MonthField);
        entity.NuidField = AllNoxType.CreateNuidField(NuidField);
        entity.NumberField = AllNoxType.CreateNumberField(NumberField);
        entity.PercentageField = AllNoxType.CreatePercentageField(PercentageField);
        entity.PhoneNumberField = AllNoxType.CreatePhoneNumberField(PhoneNumberField);
        entity.TemperatureField = AllNoxType.CreateTemperatureField(TemperatureField);
        entity.TextField = AllNoxType.CreateTextField(TextField);
        entity.TimeField = AllNoxType.CreateTimeField(TimeField);
        entity.TimeZoneCodeField = AllNoxType.CreateTimeZoneCodeField(TimeZoneCodeField);
        entity.UriField = AllNoxType.CreateUriField(UriField);
        entity.UrlField = AllNoxType.CreateUrlField(UrlField);
        entity.UserField = AllNoxType.CreateUserField(UserField);
        entity.VolumeField = AllNoxType.CreateVolumeField(VolumeField);
        entity.WeightField = AllNoxType.CreateWeightField(WeightField);
        entity.YamlField = AllNoxType.CreateYamlField(YamlField);
        entity.YearField = AllNoxType.CreateYearField(YearField);
        entity.FileField = AllNoxType.CreateFileField(FileField);
        entity.ImageField = AllNoxType.CreateImageField(ImageField);
        entity.LatLongField = AllNoxType.CreateLatLongField(LatLongField);
        entity.MoneyField = AllNoxType.CreateMoneyField(MoneyField);
        entity.StreetAddressField = AllNoxType.CreateStreetAddressField(StreetAddressField);
        entity.TranslatedTextField = AllNoxType.CreateTranslatedTextField(TranslatedTextField);
        entity.VatNumberField = AllNoxType.CreateVatNumberField(VatNumberField);
        return entity;
    }

}