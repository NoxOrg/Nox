// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using SampleWebApp.Domain;

namespace SampleWebApp.Application.Dto;

/// <summary>
/// Entity to test all nox types.
/// </summary>
public partial class AllNoxTypeCreateDto 
{
    /// <summary>
    /// Second Text Id (Required).
    /// </summary>
    [Required(ErrorMessage = "TextId is required")]
    public System.String TextId { get; set; } = default!;    
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
    /// Formula Nox Type (Required).
    /// </summary>
    [Required(ErrorMessage = "FormulaField is required")]
    
    public System.String FormulaField { get; set; } = default!;    
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
    
    public System.DateTime TimeField { get; set; } = default!;    
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
    /// Encrypted Text Nox Type (Required).
    /// </summary>
    [Required(ErrorMessage = "EncryptedTextField is required")]
    
    public System.Byte[] EncryptedTextField { get; set; } = default!;    
    /// <summary>
    /// File Nox Type (Required).
    /// </summary>
    [Required(ErrorMessage = "FileField is required")]
    
    public FileDto FileField { get; set; } = default!;    
    /// <summary>
    /// HashedTex Nox Type (Required).
    /// </summary>
    [Required(ErrorMessage = "HashedTexField is required")]
    
    public HashedTextDto HashedTexField { get; set; } = default!;    
    /// <summary>
    /// Image Nox Type (Required).
    /// </summary>
    [Required(ErrorMessage = "ImageField is required")]
    
    public ImageDto ImageField { get; set; } = default!;    
    /// <summary>
    /// LatLongField Nox Type (Required).
    /// </summary>
    [Required(ErrorMessage = "LatLongField is required")]
    
    public LatLongDto LatLongField { get; set; } = default!;    
    /// <summary>
    /// Money Nox Type (Required).
    /// </summary>
    [Required(ErrorMessage = "MoneyField is required")]
    
    public MoneyDto MoneyField { get; set; } = default!;    
    /// <summary>
    /// Password Nox Type (Required).
    /// </summary>
    [Required(ErrorMessage = "PasswordField is required")]
    
    public PasswordDto PasswordField { get; set; } = default!;    
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

    public SampleWebApp.Domain.AllNoxType ToEntity()
    {
        var entity = new SampleWebApp.Domain.AllNoxType();
        entity.TextId = AllNoxType.CreateTextId(TextId);
        entity.AreaField = SampleWebApp.Domain.AllNoxType.CreateAreaField(AreaField);
        entity.BooleanField = SampleWebApp.Domain.AllNoxType.CreateBooleanField(BooleanField);
        entity.CountryCode2Field = SampleWebApp.Domain.AllNoxType.CreateCountryCode2Field(CountryCode2Field);
        entity.CountryCode3Field = SampleWebApp.Domain.AllNoxType.CreateCountryCode3Field(CountryCode3Field);
        entity.CountryNumberField = SampleWebApp.Domain.AllNoxType.CreateCountryNumberField(CountryNumberField);
        entity.CultureCodeField = SampleWebApp.Domain.AllNoxType.CreateCultureCodeField(CultureCodeField);
        entity.CurrencyCode3Field = SampleWebApp.Domain.AllNoxType.CreateCurrencyCode3Field(CurrencyCode3Field);
        entity.CurrencyNumberField = SampleWebApp.Domain.AllNoxType.CreateCurrencyNumberField(CurrencyNumberField);
        entity.DateField = SampleWebApp.Domain.AllNoxType.CreateDateField(DateField);
        entity.DateTimeField = SampleWebApp.Domain.AllNoxType.CreateDateTimeField(DateTimeField);
        entity.DateTimeDurationField = SampleWebApp.Domain.AllNoxType.CreateDateTimeDurationField(DateTimeDurationField);
        entity.DateTimeScheduleField = SampleWebApp.Domain.AllNoxType.CreateDateTimeScheduleField(DateTimeScheduleField);
        entity.DayOfWeekField = SampleWebApp.Domain.AllNoxType.CreateDayOfWeekField(DayOfWeekField);
        entity.DistanceField = SampleWebApp.Domain.AllNoxType.CreateDistanceField(DistanceField);
        entity.EmailField = SampleWebApp.Domain.AllNoxType.CreateEmailField(EmailField);
        entity.GuidField = SampleWebApp.Domain.AllNoxType.CreateGuidField(GuidField);
        entity.HtmlField = SampleWebApp.Domain.AllNoxType.CreateHtmlField(HtmlField);
        entity.InternetDomainField = SampleWebApp.Domain.AllNoxType.CreateInternetDomainField(InternetDomainField);
        entity.IpAddressField = SampleWebApp.Domain.AllNoxType.CreateIpAddressField(IpAddressField);
        entity.JsonField = SampleWebApp.Domain.AllNoxType.CreateJsonField(JsonField);
        entity.JwtTokenField = SampleWebApp.Domain.AllNoxType.CreateJwtTokenField(JwtTokenField);
        entity.LanguageCodeField = SampleWebApp.Domain.AllNoxType.CreateLanguageCodeField(LanguageCodeField);
        entity.LengthField = SampleWebApp.Domain.AllNoxType.CreateLengthField(LengthField);
        entity.MacAddressField = SampleWebApp.Domain.AllNoxType.CreateMacAddressField(MacAddressField);
        entity.MarkdownField = SampleWebApp.Domain.AllNoxType.CreateMarkdownField(MarkdownField);
        entity.MonthField = SampleWebApp.Domain.AllNoxType.CreateMonthField(MonthField);
        entity.NuidField = SampleWebApp.Domain.AllNoxType.CreateNuidField(NuidField);
        entity.NumberField = SampleWebApp.Domain.AllNoxType.CreateNumberField(NumberField);
        entity.PercentageField = SampleWebApp.Domain.AllNoxType.CreatePercentageField(PercentageField);
        entity.PhoneNumberField = SampleWebApp.Domain.AllNoxType.CreatePhoneNumberField(PhoneNumberField);
        entity.TemperatureField = SampleWebApp.Domain.AllNoxType.CreateTemperatureField(TemperatureField);
        entity.TextField = SampleWebApp.Domain.AllNoxType.CreateTextField(TextField);
        entity.TimeField = SampleWebApp.Domain.AllNoxType.CreateTimeField(TimeField);
        entity.TimeZoneCodeField = SampleWebApp.Domain.AllNoxType.CreateTimeZoneCodeField(TimeZoneCodeField);
        entity.UriField = SampleWebApp.Domain.AllNoxType.CreateUriField(UriField);
        entity.UrlField = SampleWebApp.Domain.AllNoxType.CreateUrlField(UrlField);
        entity.UserField = SampleWebApp.Domain.AllNoxType.CreateUserField(UserField);
        entity.VolumeField = SampleWebApp.Domain.AllNoxType.CreateVolumeField(VolumeField);
        entity.WeightField = SampleWebApp.Domain.AllNoxType.CreateWeightField(WeightField);
        entity.YamlField = SampleWebApp.Domain.AllNoxType.CreateYamlField(YamlField);
        entity.YearField = SampleWebApp.Domain.AllNoxType.CreateYearField(YearField);
        entity.FileField = SampleWebApp.Domain.AllNoxType.CreateFileField(FileField);
        entity.ImageField = SampleWebApp.Domain.AllNoxType.CreateImageField(ImageField);
        entity.LatLongField = SampleWebApp.Domain.AllNoxType.CreateLatLongField(LatLongField);
        entity.MoneyField = SampleWebApp.Domain.AllNoxType.CreateMoneyField(MoneyField);
        entity.StreetAddressField = SampleWebApp.Domain.AllNoxType.CreateStreetAddressField(StreetAddressField);
        entity.TranslatedTextField = SampleWebApp.Domain.AllNoxType.CreateTranslatedTextField(TranslatedTextField);
        entity.VatNumberField = SampleWebApp.Domain.AllNoxType.CreateVatNumberField(VatNumberField);
        return entity;
    }
}