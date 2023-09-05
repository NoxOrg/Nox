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