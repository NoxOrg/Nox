// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using System;
using System.Collections.Generic;

namespace TestWebApp.Domain;

/// <summary>
/// Static methods for the TestEntityForTypes class.
/// </summary>
public partial class TestEntityForTypesMetadata
{
    
        /// <summary>
        /// Type options for property 'Id'
        /// </summary>
        public static Nox.Types.TextTypeOptions IdTypeOptions {get; private set;} = new ()
        {
            MinLength = 2,
            MaxLength = 2,
            IsUnicode = false,
            IsLocalized = true,
            Casing = Nox.Types.TextTypeCasing.Normal,
        };
    
    
        /// <summary>
        /// Factory for property 'Id'
        /// </summary>
        public static Nox.Types.Text CreateId(System.String value)
            => Nox.Types.Text.From(value, IdTypeOptions);
        
    
        /// <summary>
        /// Type options for property 'TextTestField'
        /// </summary>
        public static Nox.Types.TextTypeOptions TextTestFieldTypeOptions {get; private set;} = new ()
        {
            MinLength = 4,
            MaxLength = 63,
            IsUnicode = true,
            IsLocalized = true,
            Casing = Nox.Types.TextTypeCasing.Normal,
        };
    
    
        /// <summary>
        /// Factory for property 'TextTestField'
        /// </summary>
        public static Nox.Types.Text CreateTextTestField(System.String value)
            => Nox.Types.Text.From(value, TextTestFieldTypeOptions);
        
    
        /// <summary>
        /// Type options for property 'NumberTestField'
        /// </summary>
        public static Nox.Types.NumberTypeOptions NumberTestFieldTypeOptions {get; private set;} = new ()
        {
            MinValue = 4m,
            MaxValue = 894m,
            DecimalDigits = 0,
        };
    
    
        /// <summary>
        /// Factory for property 'NumberTestField'
        /// </summary>
        public static Nox.Types.Number CreateNumberTestField(System.Int16 value)
            => Nox.Types.Number.From(value, NumberTestFieldTypeOptions);
        
    
        /// <summary>
        /// Factory for property 'MoneyTestField'
        /// </summary>
        public static Nox.Types.Money CreateMoneyTestField(IMoney value)
            => Nox.Types.Money.From(value);
        
    
        /// <summary>
        /// Factory for property 'CountryCode2TestField'
        /// </summary>
        public static Nox.Types.CountryCode2 CreateCountryCode2TestField(System.String value)
            => Nox.Types.CountryCode2.From(value);
        
    
        /// <summary>
        /// Factory for property 'StreetAddressTestField'
        /// </summary>
        public static Nox.Types.StreetAddress CreateStreetAddressTestField(IStreetAddress value)
            => Nox.Types.StreetAddress.From(value);
        
    
        /// <summary>
        /// Factory for property 'CurrencyCode3TestField'
        /// </summary>
        public static Nox.Types.CurrencyCode3 CreateCurrencyCode3TestField(System.String value)
            => Nox.Types.CurrencyCode3.From(value);
        
    
        /// <summary>
        /// Factory for property 'DayOfWeekTestField'
        /// </summary>
        public static Nox.Types.DayOfWeek CreateDayOfWeekTestField(System.UInt16 value)
            => Nox.Types.DayOfWeek.From(value);
        
    
        /// <summary>
        /// Factory for property 'JwtTokenTestField'
        /// </summary>
        public static Nox.Types.JwtToken CreateJwtTokenTestField(System.String value)
            => Nox.Types.JwtToken.From(value);
        
    
        /// <summary>
        /// Factory for property 'GeoCoordTestField'
        /// </summary>
        public static Nox.Types.LatLong CreateGeoCoordTestField(ILatLong value)
            => Nox.Types.LatLong.From(value);
        
    
        /// <summary>
        /// Factory for property 'AreaTestField'
        /// </summary>
        public static Nox.Types.Area CreateAreaTestField(System.Decimal value)
            => Nox.Types.Area.From(value);
        
    
        /// <summary>
        /// Factory for property 'TimeZoneCodeTestField'
        /// </summary>
        public static Nox.Types.TimeZoneCode CreateTimeZoneCodeTestField(System.String value)
            => Nox.Types.TimeZoneCode.From(value);
        
    
        /// <summary>
        /// Factory for property 'BooleanTestField'
        /// </summary>
        public static Nox.Types.Boolean CreateBooleanTestField(System.Boolean value)
            => Nox.Types.Boolean.From(value);
        
    
        /// <summary>
        /// Factory for property 'CountryCode3TestField'
        /// </summary>
        public static Nox.Types.CountryCode3 CreateCountryCode3TestField(System.String value)
            => Nox.Types.CountryCode3.From(value);
        
    
        /// <summary>
        /// Factory for property 'CountryNumberTestField'
        /// </summary>
        public static Nox.Types.CountryNumber CreateCountryNumberTestField(System.UInt16 value)
            => Nox.Types.CountryNumber.From(value);
        
    
        /// <summary>
        /// Factory for property 'CurrencyNumberTestField'
        /// </summary>
        public static Nox.Types.CurrencyNumber CreateCurrencyNumberTestField(System.Int16 value)
            => Nox.Types.CurrencyNumber.From(value);
        
    
        /// <summary>
        /// Factory for property 'DateTimeTestField'
        /// </summary>
        public static Nox.Types.DateTime CreateDateTimeTestField(System.DateTimeOffset value)
            => Nox.Types.DateTime.From(value);
        
    
        /// <summary>
        /// Factory for property 'DateTimeRangeTestField'
        /// </summary>
        public static Nox.Types.DateTimeRange CreateDateTimeRangeTestField(IDateTimeRange value)
            => Nox.Types.DateTimeRange.From(value);
        
    
        /// <summary>
        /// Factory for property 'DistanceTestField'
        /// </summary>
        public static Nox.Types.Distance CreateDistanceTestField(System.Decimal value)
            => Nox.Types.Distance.From(value);
        
    
        /// <summary>
        /// Factory for property 'EmailTestField'
        /// </summary>
        public static Nox.Types.Email CreateEmailTestField(System.String value)
            => Nox.Types.Email.From(value);
        
    
        /// <summary>
        /// Factory for property 'EncryptedTextTestField'
        /// </summary>
        public static Nox.Types.EncryptedText CreateEncryptedTextTestField(System.Byte[] value)
            => Nox.Types.EncryptedText.From(value);
        
    
        /// <summary>
        /// Factory for property 'GuidTestField'
        /// </summary>
        public static Nox.Types.Guid CreateGuidTestField(System.Guid value)
            => Nox.Types.Guid.From(value);
        
    
        /// <summary>
        /// Factory for property 'HashedTextTestField'
        /// </summary>
        public static Nox.Types.HashedText CreateHashedTextTestField(IHashedText value)
            => Nox.Types.HashedText.From(value);
        
    
        /// <summary>
        /// Factory for property 'InternetDomainTestField'
        /// </summary>
        public static Nox.Types.InternetDomain CreateInternetDomainTestField(System.String value)
            => Nox.Types.InternetDomain.From(value);
        
    
        /// <summary>
        /// Factory for property 'IpAddressV4TestField'
        /// </summary>
        public static Nox.Types.IpAddress CreateIpAddressV4TestField(System.String value)
            => Nox.Types.IpAddress.From(value);
        
    
        /// <summary>
        /// Factory for property 'IpAddressV6TestField'
        /// </summary>
        public static Nox.Types.IpAddress CreateIpAddressV6TestField(System.String value)
            => Nox.Types.IpAddress.From(value);
        
    
        /// <summary>
        /// Factory for property 'JsonTestField'
        /// </summary>
        public static Nox.Types.Json CreateJsonTestField(System.String value)
            => Nox.Types.Json.From(value);
        
    
        /// <summary>
        /// Factory for property 'LengthTestField'
        /// </summary>
        public static Nox.Types.Length CreateLengthTestField(System.Decimal value)
            => Nox.Types.Length.From(value);
        
    
        /// <summary>
        /// Factory for property 'MacAddressTestField'
        /// </summary>
        public static Nox.Types.MacAddress CreateMacAddressTestField(System.String value)
            => Nox.Types.MacAddress.From(value);
        
    
        /// <summary>
        /// Factory for property 'MonthTestField'
        /// </summary>
        public static Nox.Types.Month CreateMonthTestField(System.Byte value)
            => Nox.Types.Month.From(value);
        
    
        /// <summary>
        /// Factory for property 'PasswordTestField'
        /// </summary>
        public static Nox.Types.Password CreatePasswordTestField(IPassword value)
            => Nox.Types.Password.From(value);
        
    
        /// <summary>
        /// Factory for property 'PercentageTestField'
        /// </summary>
        public static Nox.Types.Percentage CreatePercentageTestField(System.Single value)
            => Nox.Types.Percentage.From(value);
        
    
        /// <summary>
        /// Factory for property 'PhoneNumberTestField'
        /// </summary>
        public static Nox.Types.PhoneNumber CreatePhoneNumberTestField(System.String value)
            => Nox.Types.PhoneNumber.From(value);
        
    
        /// <summary>
        /// Factory for property 'TemperatureTestField'
        /// </summary>
        public static Nox.Types.Temperature CreateTemperatureTestField(System.Decimal value)
            => Nox.Types.Temperature.From(value);
        
    
        /// <summary>
        /// Factory for property 'TranslatedTextTestField'
        /// </summary>
        public static Nox.Types.TranslatedText CreateTranslatedTextTestField(ITranslatedText value)
            => Nox.Types.TranslatedText.From(value);
        
    
        /// <summary>
        /// Factory for property 'UriTestField'
        /// </summary>
        public static Nox.Types.Uri CreateUriTestField(System.String value)
            => Nox.Types.Uri.From(value);
        
    
        /// <summary>
        /// Factory for property 'VolumeTestField'
        /// </summary>
        public static Nox.Types.Volume CreateVolumeTestField(System.Decimal value)
            => Nox.Types.Volume.From(value);
        
    
        /// <summary>
        /// Factory for property 'WeightTestField'
        /// </summary>
        public static Nox.Types.Weight CreateWeightTestField(System.Decimal value)
            => Nox.Types.Weight.From(value);
        
    
        /// <summary>
        /// Factory for property 'YearTestField'
        /// </summary>
        public static Nox.Types.Year CreateYearTestField(System.UInt16 value)
            => Nox.Types.Year.From(value);
        
    
        /// <summary>
        /// Factory for property 'CultureCodeTestField'
        /// </summary>
        public static Nox.Types.CultureCode CreateCultureCodeTestField(System.String value)
            => Nox.Types.CultureCode.From(value);
        
    
        /// <summary>
        /// Factory for property 'LanguageCodeTestField'
        /// </summary>
        public static Nox.Types.LanguageCode CreateLanguageCodeTestField(System.String value)
            => Nox.Types.LanguageCode.From(value);
        
    
        /// <summary>
        /// Factory for property 'YamlTestField'
        /// </summary>
        public static Nox.Types.Yaml CreateYamlTestField(System.String value)
            => Nox.Types.Yaml.From(value);
        
    
        /// <summary>
        /// Factory for property 'DateTimeDurationTestField'
        /// </summary>
        public static Nox.Types.DateTimeDuration CreateDateTimeDurationTestField(System.Int64 value)
            => Nox.Types.DateTimeDuration.From(value);
        
    
        /// <summary>
        /// Factory for property 'TimeTestField'
        /// </summary>
        public static Nox.Types.Time CreateTimeTestField(System.DateTime value)
            => Nox.Types.Time.From(value);
        
    
        /// <summary>
        /// Factory for property 'VatNumberTestField'
        /// </summary>
        public static Nox.Types.VatNumber CreateVatNumberTestField(IVatNumber value)
            => Nox.Types.VatNumber.From(value);
        
    
        /// <summary>
        /// Factory for property 'DateTestField'
        /// </summary>
        public static Nox.Types.Date CreateDateTestField(System.DateTime value)
            => Nox.Types.Date.From(value);
        
    
        /// <summary>
        /// Factory for property 'MarkdownTestField'
        /// </summary>
        public static Nox.Types.Markdown CreateMarkdownTestField(System.String value)
            => Nox.Types.Markdown.From(value);
        
    
        /// <summary>
        /// Factory for property 'FileTestField'
        /// </summary>
        public static Nox.Types.File CreateFileTestField(IFile value)
            => Nox.Types.File.From(value);
        
    
        /// <summary>
        /// Factory for property 'ColorTestField'
        /// </summary>
        public static Nox.Types.Color CreateColorTestField(System.String value)
            => Nox.Types.Color.From(value);
        
    
        /// <summary>
        /// Factory for property 'UrlTestField'
        /// </summary>
        public static Nox.Types.Url CreateUrlTestField(System.String value)
            => Nox.Types.Url.From(value);
        
    
        /// <summary>
        /// Factory for property 'DateTimeScheduleTestField'
        /// </summary>
        public static Nox.Types.DateTimeSchedule CreateDateTimeScheduleTestField(System.String value)
            => Nox.Types.DateTimeSchedule.From(value);
        
    
        /// <summary>
        /// Factory for property 'UserTestField'
        /// </summary>
        public static Nox.Types.User CreateUserTestField(System.String value)
            => Nox.Types.User.From(value);
        
    
        /// <summary>
        /// Type options for property 'FormulaTestField'
        /// </summary>
        public static Nox.Types.FormulaTypeOptions FormulaTestFieldTypeOptions {get; private set;} = new ()
        {
            Expression = "2 + 2",
            Returns = Nox.Types.FormulaReturnType.@int,
        };
    
    
        /// <summary>
        /// Factory for property 'FormulaTestField'
        /// </summary>
        public static Nox.Types.Formula CreateFormulaTestField(System.String value)
            => Nox.Types.Formula.From(value, FormulaTestFieldTypeOptions);
        
    
        /// <summary>
        /// Factory for property 'AutoNumberTestField'
        /// </summary>
        public static Nox.Types.AutoNumber CreateAutoNumberTestField(System.Int64 value)
            => Nox.Types.AutoNumber.From(value);
        
    
        /// <summary>
        /// Factory for property 'HtmlTestField'
        /// </summary>
        public static Nox.Types.Html CreateHtmlTestField(System.String value)
            => Nox.Types.Html.From(value);
        
    
        /// <summary>
        /// Factory for property 'ImageTestField'
        /// </summary>
        public static Nox.Types.Image CreateImageTestField(IImage value)
            => Nox.Types.Image.From(value);
        
}