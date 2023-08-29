// Generated

#nullable enable
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;
using SampleWebApp.Application.DataTransferObjects;
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
    /// NuidField Type (Optional).
    /// </summary>
    public System.UInt32? NuidField { get; set; }

    /// <summary>
    /// BooleanField Nox Type (Optional).
    /// </summary>
    public System.Boolean? BooleanField { get; set; }

    /// <summary>
    /// CountryCode2 Nox Type (Required).
    /// </summary>
    public System.String CountryCode2Field { get; set; } = default!;

    /// <summary>
    /// CountryCode3 Nox Type (Optional).
    /// </summary>
    public System.String? CountryCode3Field { get; set; }

    /// <summary>
    /// CountryNumber Nox Type (Optional).
    /// </summary>
    public System.UInt16? CountryNumberField { get; set; }

    /// <summary>
    /// CultureCode Nox Type (Optional).
    /// </summary>
    public System.String? CultureCodeField { get; set; }

    /// <summary>
    /// CurrencyCode3Field Nox Type (Optional).
    /// </summary>
    public System.String? CurrencyCode3Field { get; set; }

    /// <summary>
    /// DatetimeField Nox Type (Optional).
    /// </summary>
    public System.DateTimeOffset? DateTimeField { get; set; }

    /// <summary>
    /// Formula Nox Type (Optional).
    /// </summary>
    [NotMapped]public System.String? FormulaField { get; set; }

    /// <summary>
    /// HtmlField Nox Type (Optional).
    /// </summary>
    public System.String? HtmlField { get; set; }

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
    /// Phone Number Nox Type (Required).
    /// </summary>
    public System.String PhoneNumberField { get; set; } = default!;

    /// <summary>
    /// Temperature Nox Type (Required).
    /// </summary>
    public System.Decimal TemperatureField { get; set; } = default!;

    /// <summary>
    /// Yaml Nox Type (Optional).
    /// </summary>
    public System.String? YamlField { get; set; }

    /// <summary>
    /// YearField Nox Type (Optional).
    /// </summary>
    public System.UInt16? YearField { get; set; }

    /// <summary>
    /// Weight Nox Type (Optional).
    /// </summary>
    public System.Double? WeightField { get; set; }

    /// <summary>
    /// Volume Nox Type (Optional).
    /// </summary>
    public System.Double? VolumeField { get; set; }

    /// <summary>
    /// Url Nox Type (Optional).
    /// </summary>
    public System.String? UrlField { get; set; }

    /// <summary>
    /// Uri Nox Type (Optional).
    /// </summary>
    public System.String? UriField { get; set; }

    /// <summary>
    /// TimeZoneCode Nox Type (Optional).
    /// </summary>
    public System.String? TimeZoneCodeField { get; set; }

    /// <summary>
    /// Percentage Nox Type (Optional).
    /// </summary>
    public System.Single? PercentageField { get; set; }

    /// <summary>
    /// Time Nox Type (Optional).
    /// </summary>
    public System.DateTime? TimeField { get; set; }

    /// <summary>
    /// NumberField Nox Type (Optional).
    /// </summary>
    public System.Int32? NumberField { get; set; }

    /// <summary>
    /// Text Nox Type (Required).
    /// </summary>
    public System.String TextField { get; set; } = default!;

    /// <summary>
    /// StreetAddress Nox Type (Optional).
    /// </summary>
    public StreetAddressDto? StreetAddressField { get; set; }

    /// <summary>
    /// File Nox Type (Optional).
    /// </summary>
    public FileDto? FileField { get; set; }

    /// <summary>
    /// TranslatedText Nox Type (Optional).
    /// </summary>
    public TranslatedTextDto? TranslatedTextField { get; set; }

    /// <summary>
    /// VatNumber Nox Type (Optional).
    /// </summary>
    public VatNumberDto? VatNumberField { get; set; }

    /// <summary>
    /// Money Nox Type (Optional).
    /// </summary>
    public MoneyDto? MoneyField { get; set; }

    /// <summary>
    /// LatLongField Nox Type (Optional).
    /// </summary>
    public LatLongDto? LatLongField { get; set; }

    public bool? Deleted { get; set; }

    public AllNoxType ToEntity()
    {
        var entity = new AllNoxType();
        entity.Id = AllNoxType.CreateId(Id);
        entity.TextId = AllNoxType.CreateTextId(TextId);
        if (NuidField is not null)entity.NuidField = AllNoxType.CreateNuidField(NuidField.NonNullValue<System.UInt32>());
        if (BooleanField is not null)entity.BooleanField = AllNoxType.CreateBooleanField(BooleanField.NonNullValue<System.Boolean>());
        entity.CountryCode2Field = AllNoxType.CreateCountryCode2Field(CountryCode2Field);
        if (CountryCode3Field is not null)entity.CountryCode3Field = AllNoxType.CreateCountryCode3Field(CountryCode3Field.NonNullValue<System.String>());
        if (CountryNumberField is not null)entity.CountryNumberField = AllNoxType.CreateCountryNumberField(CountryNumberField.NonNullValue<System.UInt16>());
        if (CultureCodeField is not null)entity.CultureCodeField = AllNoxType.CreateCultureCodeField(CultureCodeField.NonNullValue<System.String>());
        if (CurrencyCode3Field is not null)entity.CurrencyCode3Field = AllNoxType.CreateCurrencyCode3Field(CurrencyCode3Field.NonNullValue<System.String>());
        if (DateTimeField is not null)entity.DateTimeField = AllNoxType.CreateDateTimeField(DateTimeField.NonNullValue<System.DateTimeOffset>());
        if (HtmlField is not null)entity.HtmlField = AllNoxType.CreateHtmlField(HtmlField.NonNullValue<System.String>());
        entity.LanguageCodeField = AllNoxType.CreateLanguageCodeField(LanguageCodeField);
        entity.LengthField = AllNoxType.CreateLengthField(LengthField);
        entity.MacAddressField = AllNoxType.CreateMacAddressField(MacAddressField);
        entity.MarkdownField = AllNoxType.CreateMarkdownField(MarkdownField);
        entity.PhoneNumberField = AllNoxType.CreatePhoneNumberField(PhoneNumberField);
        entity.TemperatureField = AllNoxType.CreateTemperatureField(TemperatureField);
        if (YamlField is not null)entity.YamlField = AllNoxType.CreateYamlField(YamlField.NonNullValue<System.String>());
        if (YearField is not null)entity.YearField = AllNoxType.CreateYearField(YearField.NonNullValue<System.UInt16>());
        if (WeightField is not null)entity.WeightField = AllNoxType.CreateWeightField(WeightField.NonNullValue<System.Double>());
        if (VolumeField is not null)entity.VolumeField = AllNoxType.CreateVolumeField(VolumeField.NonNullValue<System.Double>());
        if (UrlField is not null)entity.UrlField = AllNoxType.CreateUrlField(UrlField.NonNullValue<System.String>());
        if (UriField is not null)entity.UriField = AllNoxType.CreateUriField(UriField.NonNullValue<System.String>());
        if (TimeZoneCodeField is not null)entity.TimeZoneCodeField = AllNoxType.CreateTimeZoneCodeField(TimeZoneCodeField.NonNullValue<System.String>());
        if (PercentageField is not null)entity.PercentageField = AllNoxType.CreatePercentageField(PercentageField.NonNullValue<System.Single>());
        if (TimeField is not null)entity.TimeField = AllNoxType.CreateTimeField(TimeField.NonNullValue<System.DateTime>());
        if (NumberField is not null)entity.NumberField = AllNoxType.CreateNumberField(NumberField.NonNullValue<System.Int32>());
        entity.TextField = AllNoxType.CreateTextField(TextField);
        if (StreetAddressField is not null)entity.StreetAddressField = AllNoxType.CreateStreetAddressField(StreetAddressField.NonNullValue<StreetAddressDto>());
        if (FileField is not null)entity.FileField = AllNoxType.CreateFileField(FileField.NonNullValue<FileDto>());
        if (TranslatedTextField is not null)entity.TranslatedTextField = AllNoxType.CreateTranslatedTextField(TranslatedTextField.NonNullValue<TranslatedTextDto>());
        if (VatNumberField is not null)entity.VatNumberField = AllNoxType.CreateVatNumberField(VatNumberField.NonNullValue<VatNumberDto>());
        if (MoneyField is not null)entity.MoneyField = AllNoxType.CreateMoneyField(MoneyField.NonNullValue<MoneyDto>());
        if (LatLongField is not null)entity.LatLongField = AllNoxType.CreateLatLongField(LatLongField.NonNullValue<LatLongDto>());
        return entity;
    }
}