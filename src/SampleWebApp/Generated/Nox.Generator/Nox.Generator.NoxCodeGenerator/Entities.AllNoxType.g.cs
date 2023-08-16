// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using System;
using System.Collections.Generic;

namespace SampleWebApp.Domain;

/// <summary>
/// Entity to test all nox types.
/// </summary>
public partial class AllNoxType : AuditableEntityBase
{
    /// <summary>
    /// DatabaseNumber Nox Type (Required).
    /// </summary>
    public DatabaseNumber Id { get; set; } = null!;
    /// <summary>
    /// Second Text Id (Required).
    /// </summary>
    public Text TextId { get; set; } = null!;

    /// <summary>
    /// NuidField Type (Optional).
    /// </summary>
    public Nox.Types.Nuid? NuidField { get; set; } = null!;

    /// <summary>
    /// BooleanField Nox Type (Optional).
    /// </summary>
    public Nox.Types.Boolean? BooleanField { get; set; } = null!;

    /// <summary>
    /// CountryCode2 Nox Type (Required).
    /// </summary>
    public Nox.Types.CountryCode2 CountryCode2Field { get; set; } = null!;

    /// <summary>
    /// CountryCode3 Nox Type (Optional).
    /// </summary>
    public Nox.Types.CountryCode3? CountryCode3Field { get; set; } = null!;

    /// <summary>
    /// CountryNumber Nox Type (Optional).
    /// </summary>
    public Nox.Types.CountryNumber? CountryNumberField { get; set; } = null!;

    /// <summary>
    /// CultureCode Nox Type (Optional).
    /// </summary>
    public Nox.Types.CultureCode? CultureCodeField { get; set; } = null!;

    /// <summary>
    /// CurrencyCode3Field Nox Type (Optional).
    /// </summary>
    public Nox.Types.CurrencyCode3? CurrencyCode3Field { get; set; } = null!;

    /// <summary>
    /// DatetimeField Nox Type (Optional).
    /// </summary>
    public Nox.Types.DateTime? DateTimeField { get; set; } = null!;

    /// <summary>
    /// Formula Nox Type (Optional).
    /// </summary>
    public string? FormulaField => CountryCode2Field.ToString();

    /// <summary>
    /// HtmlField Nox Type (Optional).
    /// </summary>
    public Nox.Types.Html? HtmlField { get; set; } = null!;

    /// <summary>
    /// MarkdownField Nox Type (Optional).
    /// </summary>
    public Nox.Types.Markdown? MarkdownField { get; set; } = null!;

    /// <summary>
    /// Yaml Nox Type (Optional).
    /// </summary>
    public Nox.Types.Yaml? YamlField { get; set; } = null!;

    /// <summary>
    /// Weight Nox Type (Optional).
    /// </summary>
    public Nox.Types.Weight? WeightField { get; set; } = null!;

    /// <summary>
    /// Volume Nox Type (Optional).
    /// </summary>
    public Nox.Types.Volume? VolumeField { get; set; } = null!;

    /// <summary>
    /// Url Nox Type (Optional).
    /// </summary>
    public Nox.Types.Url? UrlField { get; set; } = null!;

    /// <summary>
    /// Uri Nox Type (Optional).
    /// </summary>
    public Nox.Types.Uri? UriField { get; set; } = null!;

    /// <summary>
    /// TimeZoneCode Nox Type (Optional).
    /// </summary>
    public Nox.Types.TimeZoneCode? TimeZoneCodeField { get; set; } = null!;

    /// <summary>
    /// Temperature Nox Type (Optional).
    /// </summary>
    public Nox.Types.Temperature? TemperatureField { get; set; } = null!;

    /// <summary>
    /// Percentage Nox Type (Optional).
    /// </summary>
    public Nox.Types.Percentage? PercentageField { get; set; } = null!;

    /// <summary>
    /// Time Nox Type (Optional).
    /// </summary>
    public Nox.Types.Time? TimeField { get; set; } = null!;

    /// <summary>
    /// NumberField Nox Type (Optional).
    /// </summary>
    public Nox.Types.Number? NumberField { get; set; } = null!;

    /// <summary>
    /// Text Nox Type (Required).
    /// </summary>
    public Nox.Types.Text TextField { get; set; } = null!;

    /// <summary>
    /// StreetAddress Nox Type (Optional).
    /// </summary>
    public Nox.Types.StreetAddress? StreetAddressField { get; set; } = null!;

    /// <summary>
    /// File Nox Type (Optional).
    /// </summary>
    public Nox.Types.File? FileField { get; set; } = null!;

    /// <summary>
    /// TranslatedText Nox Type (Optional).
    /// </summary>
    public Nox.Types.TranslatedText? TranslatedTextField { get; set; } = null!;

    /// <summary>
    /// VatNumber Nox Type (Optional).
    /// </summary>
    public Nox.Types.VatNumber? VatNumberField { get; set; } = null!;

    /// <summary>
    /// Password Nox Type (Optional).
    /// </summary>
    public Nox.Types.Password? PasswordField { get; set; } = null!;

    /// <summary>
    /// Money Nox Type (Optional).
    /// </summary>
    public Nox.Types.Money? MoneyField { get; set; } = null!;

    /// <summary>
    /// HashedTex Nox Type (Optional).
    /// </summary>
    public Nox.Types.HashedText? HashedTexField { get; set; } = null!;

    /// <summary>
    /// LatLongField Nox Type (Optional).
    /// </summary>
    public Nox.Types.LatLong? LatLongField { get; set; } = null!;

    /// <summary>
    /// EncryptedText Nox Type (Optional).
    /// </summary>
    public Nox.Types.EncryptedText? EncryptedTextField { get; set; } = null!;
}