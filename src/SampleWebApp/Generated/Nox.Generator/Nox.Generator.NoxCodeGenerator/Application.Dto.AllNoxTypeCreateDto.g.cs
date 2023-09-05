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
public partial class AllNoxTypeCreateDto : AllNoxTypeUpdateDto
{
    /// <summary>
    /// Second Text Id (Required).
    /// </summary>
    [Required(ErrorMessage = "TextId is required")]
    public System.String TextId { get; set; } = default!;

    public AllNoxType ToEntity()
    {
        var entity = new AllNoxType();
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