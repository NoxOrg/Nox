// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using System;
using System.Collections.Generic;

namespace SampleWebApp.Domain;

/// <summary>
/// Static methods for the AllNoxType class.
/// </summary>
public partial class AllNoxType
{
    /// <summary>
    /// Type options and factory for property 'Id'
    /// </summary>
    public static Nox.Types.DatabaseNumber CreateId(System.Int64 value)
        => Nox.Types.DatabaseNumber.From(value);
    

    /// <summary>
    /// Type options and factory for property 'TextId'
    /// </summary>
    public static Nox.Types.Text CreateTextId(System.String value)
        => Nox.Types.Text.From(value);
    

    /// <summary>
    /// Type options and factory for property 'NuidField'
    /// </summary>
    public static Nox.Types.NuidTypeOptions NuidFieldTypeOptions {get; private set;} = new ()
    {
        Separator = ".",
        PropertyNames = new System.String[]
        {
            "TextField",
        },
    };
    
    public static Nuid CreateNuidField(System.UInt32 value)
        => Nox.Types.Nuid.From(value, NuidFieldTypeOptions);
    

    /// <summary>
    /// Type options and factory for property 'BooleanField'
    /// </summary>
    public static Nox.Types.Boolean CreateBooleanField(System.Boolean value)
        => Nox.Types.Boolean.From(value);
    

    /// <summary>
    /// Type options and factory for property 'CountryCode2Field'
    /// </summary>
    public static Nox.Types.CountryCode2 CreateCountryCode2Field(System.String value)
        => Nox.Types.CountryCode2.From(value);
    

    /// <summary>
    /// Type options and factory for property 'CountryCode3Field'
    /// </summary>
    public static Nox.Types.CountryCode3 CreateCountryCode3Field(System.String value)
        => Nox.Types.CountryCode3.From(value);
    

    /// <summary>
    /// Type options and factory for property 'CountryNumberField'
    /// </summary>
    public static Nox.Types.CountryNumber CreateCountryNumberField(System.UInt16 value)
        => Nox.Types.CountryNumber.From(value);
    

    /// <summary>
    /// Type options and factory for property 'CultureCodeField'
    /// </summary>
    public static Nox.Types.CultureCode CreateCultureCodeField(System.String value)
        => Nox.Types.CultureCode.From(value);
    

    /// <summary>
    /// Type options and factory for property 'CurrencyCode3Field'
    /// </summary>
    public static Nox.Types.CurrencyCode3 CreateCurrencyCode3Field(System.String value)
        => Nox.Types.CurrencyCode3.From(value);
    

    /// <summary>
    /// Type options and factory for property 'DateTimeField'
    /// </summary>
    public static Nox.Types.DateTime CreateDateTimeField(System.DateTimeOffset value)
        => Nox.Types.DateTime.From(value);
    

    /// <summary>
    /// Type options and factory for property 'FormulaField'
    /// </summary>
    public static Nox.Types.FormulaTypeOptions FormulaFieldTypeOptions {get; private set;} = new ()
    {
        Expression = "CountryCode2Field.ToString()",
        Returns = Nox.Types.FormulaReturnType.String,
    };
    
    public static Formula CreateFormulaField(System.String value)
        => Nox.Types.Formula.From(value, FormulaFieldTypeOptions);
    

    /// <summary>
    /// Type options and factory for property 'HtmlField'
    /// </summary>
    public static Nox.Types.Html CreateHtmlField(System.String value)
        => Nox.Types.Html.From(value);
    

    /// <summary>
    /// Type options and factory for property 'LanguageCodeField'
    /// </summary>
    public static Nox.Types.LanguageCode CreateLanguageCodeField(System.String value)
        => Nox.Types.LanguageCode.From(value);
    

    /// <summary>
    /// Type options and factory for property 'LengthField'
    /// </summary>
    public static Nox.Types.Length CreateLengthField(System.Decimal value)
        => Nox.Types.Length.From(value);
    

    /// <summary>
    /// Type options and factory for property 'MacAddressField'
    /// </summary>
    public static Nox.Types.MacAddress CreateMacAddressField(System.String value)
        => Nox.Types.MacAddress.From(value);
    

    /// <summary>
    /// Type options and factory for property 'MarkdownField'
    /// </summary>
    public static Nox.Types.Markdown CreateMarkdownField(System.String value)
        => Nox.Types.Markdown.From(value);
    

    /// <summary>
    /// Type options and factory for property 'PhoneNumberField'
    /// </summary>
    public static Nox.Types.PhoneNumber CreatePhoneNumberField(System.String value)
        => Nox.Types.PhoneNumber.From(value);
    

    /// <summary>
    /// Type options and factory for property 'TemperatureField'
    /// </summary>
    public static Nox.Types.TemperatureTypeOptions TemperatureFieldTypeOptions {get; private set;} = new ()
    {
        PersistAs = Nox.Types.TemperatureTypeUnit.Celsius,
        Units = Nox.Types.TemperatureTypeUnit.Fahrenheit,
    };
    
    public static Temperature CreateTemperatureField(System.Decimal value)
        => Nox.Types.Temperature.From(value, TemperatureFieldTypeOptions);
    

    /// <summary>
    /// Type options and factory for property 'YamlField'
    /// </summary>
    public static Nox.Types.Yaml CreateYamlField(System.String value)
        => Nox.Types.Yaml.From(value);
    

    /// <summary>
    /// Type options and factory for property 'YearField'
    /// </summary>
    public static Nox.Types.Year CreateYearField(System.UInt16 value)
        => Nox.Types.Year.From(value);
    

    /// <summary>
    /// Type options and factory for property 'WeightField'
    /// </summary>
    public static Nox.Types.WeightTypeOptions WeightFieldTypeOptions {get; private set;} = new ()
    {
        MinValue = 10,
        MaxValue = 300,
        Units = Nox.Types.WeightTypeUnit.Kilogram,
        PersistAs = Nox.Types.WeightTypeUnit.Kilogram,
    };
    
    public static Weight CreateWeightField(System.Double value)
        => Nox.Types.Weight.From(value, WeightFieldTypeOptions);
    

    /// <summary>
    /// Type options and factory for property 'VolumeField'
    /// </summary>
    public static Nox.Types.VolumeTypeOptions VolumeFieldTypeOptions {get; private set;} = new ()
    {
        MinValue = 100,
        MaxValue = 500,
        Unit = Nox.Types.VolumeTypeUnit.CubicMeter,
        PersistAs = Nox.Types.VolumeTypeUnit.CubicMeter,
    };
    
    public static Volume CreateVolumeField(System.Double value)
        => Nox.Types.Volume.From(value, VolumeFieldTypeOptions);
    

    /// <summary>
    /// Type options and factory for property 'UrlField'
    /// </summary>
    public static Nox.Types.Url CreateUrlField(System.String value)
        => Nox.Types.Url.From(value);
    

    /// <summary>
    /// Type options and factory for property 'UriField'
    /// </summary>
    public static Nox.Types.Uri CreateUriField(System.String value)
        => Nox.Types.Uri.From(value);
    

    /// <summary>
    /// Type options and factory for property 'TimeZoneCodeField'
    /// </summary>
    public static Nox.Types.TimeZoneCode CreateTimeZoneCodeField(System.String value)
        => Nox.Types.TimeZoneCode.From(value);
    

    /// <summary>
    /// Type options and factory for property 'PercentageField'
    /// </summary>
    public static Nox.Types.Percentage CreatePercentageField(System.Single value)
        => Nox.Types.Percentage.From(value);
    

    /// <summary>
    /// Type options and factory for property 'TimeField'
    /// </summary>
    public static Nox.Types.Time CreateTimeField(System.DateTime value)
        => Nox.Types.Time.From(value);
    

    /// <summary>
    /// Type options and factory for property 'NumberField'
    /// </summary>
    public static Nox.Types.Number CreateNumberField(System.Int32 value)
        => Nox.Types.Number.From(value);
    

    /// <summary>
    /// Type options and factory for property 'TextField'
    /// </summary>
    public static Nox.Types.TextTypeOptions TextFieldTypeOptions {get; private set;} = new ()
    {
        MinLength = 4,
        MaxLength = 63,
        IsUnicode = true,
        IsLocalized = true,
        Casing = Nox.Types.TextTypeCasing.Normal,
    };
    
    public static Text CreateTextField(System.String value)
        => Nox.Types.Text.From(value, TextFieldTypeOptions);
    

    /// <summary>
    /// Type options and factory for property 'StreetAddressField'
    /// </summary>
    public static Nox.Types.StreetAddress CreateStreetAddressField(IStreetAddress value)
        => Nox.Types.StreetAddress.From(value);
    

    /// <summary>
    /// Type options and factory for property 'FileField'
    /// </summary>
    public static Nox.Types.File CreateFileField(IFile value)
        => Nox.Types.File.From(value);
    

    /// <summary>
    /// Type options and factory for property 'TranslatedTextField'
    /// </summary>
    public static Nox.Types.TranslatedText CreateTranslatedTextField(ITranslatedText value)
        => Nox.Types.TranslatedText.From(value);
    

    /// <summary>
    /// Type options and factory for property 'VatNumberField'
    /// </summary>
    public static Nox.Types.VatNumberTypeOptions VatNumberFieldTypeOptions {get; private set;} = new ()
    {
        CountryCode = Nox.Types.CountryCode.FR,
    };
    
    public static VatNumber CreateVatNumberField(IVatNumber value)
        => Nox.Types.VatNumber.From(value, VatNumberFieldTypeOptions);
    

    /// <summary>
    /// Type options and factory for property 'PasswordField'
    /// </summary>
    public static Nox.Types.Password CreatePasswordField(IPassword value)
        => Nox.Types.Password.From(value);
    

    /// <summary>
    /// Type options and factory for property 'MoneyField'
    /// </summary>
    public static Nox.Types.Money CreateMoneyField(IMoney value)
        => Nox.Types.Money.From(value);
    

    /// <summary>
    /// Type options and factory for property 'HashedTexField'
    /// </summary>
    public static Nox.Types.HashedText CreateHashedTexField(IHashedText value)
        => Nox.Types.HashedText.From(value);
    

    /// <summary>
    /// Type options and factory for property 'LatLongField'
    /// </summary>
    public static Nox.Types.LatLong CreateLatLongField(ILatLong value)
        => Nox.Types.LatLong.From(value);
    

    /// <summary>
    /// Type options and factory for property 'EncryptedTextField'
    /// </summary>
    public static Nox.Types.EncryptedText CreateEncryptedTextField(System.Byte[] value)
        => Nox.Types.EncryptedText.From(value);
    

}