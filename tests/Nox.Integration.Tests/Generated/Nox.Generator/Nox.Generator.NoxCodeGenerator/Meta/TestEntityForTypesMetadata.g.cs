// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using Nox.Solution;
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
            IsLocalized = false,
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
            IsLocalized = false,
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
            => Nox.Types.AutoNumber.FromDatabase(value);
        
    
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
        

        /// <summary>
        /// User Interface for property 'TextTestField'
        /// </summary>
        public static TypeUserInterface? TextTestFieldUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("TestEntityForTypes")
                .GetAttributeByName("TextTestField")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'NumberTestField'
        /// </summary>
        public static TypeUserInterface? NumberTestFieldUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("TestEntityForTypes")
                .GetAttributeByName("NumberTestField")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'MoneyTestField'
        /// </summary>
        public static TypeUserInterface? MoneyTestFieldUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("TestEntityForTypes")
                .GetAttributeByName("MoneyTestField")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'CountryCode2TestField'
        /// </summary>
        public static TypeUserInterface? CountryCode2TestFieldUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("TestEntityForTypes")
                .GetAttributeByName("CountryCode2TestField")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'StreetAddressTestField'
        /// </summary>
        public static TypeUserInterface? StreetAddressTestFieldUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("TestEntityForTypes")
                .GetAttributeByName("StreetAddressTestField")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'CurrencyCode3TestField'
        /// </summary>
        public static TypeUserInterface? CurrencyCode3TestFieldUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("TestEntityForTypes")
                .GetAttributeByName("CurrencyCode3TestField")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'DayOfWeekTestField'
        /// </summary>
        public static TypeUserInterface? DayOfWeekTestFieldUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("TestEntityForTypes")
                .GetAttributeByName("DayOfWeekTestField")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'JwtTokenTestField'
        /// </summary>
        public static TypeUserInterface? JwtTokenTestFieldUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("TestEntityForTypes")
                .GetAttributeByName("JwtTokenTestField")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'GeoCoordTestField'
        /// </summary>
        public static TypeUserInterface? GeoCoordTestFieldUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("TestEntityForTypes")
                .GetAttributeByName("GeoCoordTestField")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'AreaTestField'
        /// </summary>
        public static TypeUserInterface? AreaTestFieldUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("TestEntityForTypes")
                .GetAttributeByName("AreaTestField")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'TimeZoneCodeTestField'
        /// </summary>
        public static TypeUserInterface? TimeZoneCodeTestFieldUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("TestEntityForTypes")
                .GetAttributeByName("TimeZoneCodeTestField")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'BooleanTestField'
        /// </summary>
        public static TypeUserInterface? BooleanTestFieldUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("TestEntityForTypes")
                .GetAttributeByName("BooleanTestField")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'CountryCode3TestField'
        /// </summary>
        public static TypeUserInterface? CountryCode3TestFieldUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("TestEntityForTypes")
                .GetAttributeByName("CountryCode3TestField")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'CountryNumberTestField'
        /// </summary>
        public static TypeUserInterface? CountryNumberTestFieldUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("TestEntityForTypes")
                .GetAttributeByName("CountryNumberTestField")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'CurrencyNumberTestField'
        /// </summary>
        public static TypeUserInterface? CurrencyNumberTestFieldUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("TestEntityForTypes")
                .GetAttributeByName("CurrencyNumberTestField")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'DateTimeTestField'
        /// </summary>
        public static TypeUserInterface? DateTimeTestFieldUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("TestEntityForTypes")
                .GetAttributeByName("DateTimeTestField")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'DateTimeRangeTestField'
        /// </summary>
        public static TypeUserInterface? DateTimeRangeTestFieldUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("TestEntityForTypes")
                .GetAttributeByName("DateTimeRangeTestField")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'DistanceTestField'
        /// </summary>
        public static TypeUserInterface? DistanceTestFieldUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("TestEntityForTypes")
                .GetAttributeByName("DistanceTestField")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'EmailTestField'
        /// </summary>
        public static TypeUserInterface? EmailTestFieldUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("TestEntityForTypes")
                .GetAttributeByName("EmailTestField")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'EncryptedTextTestField'
        /// </summary>
        public static TypeUserInterface? EncryptedTextTestFieldUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("TestEntityForTypes")
                .GetAttributeByName("EncryptedTextTestField")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'GuidTestField'
        /// </summary>
        public static TypeUserInterface? GuidTestFieldUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("TestEntityForTypes")
                .GetAttributeByName("GuidTestField")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'HashedTextTestField'
        /// </summary>
        public static TypeUserInterface? HashedTextTestFieldUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("TestEntityForTypes")
                .GetAttributeByName("HashedTextTestField")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'InternetDomainTestField'
        /// </summary>
        public static TypeUserInterface? InternetDomainTestFieldUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("TestEntityForTypes")
                .GetAttributeByName("InternetDomainTestField")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'IpAddressV4TestField'
        /// </summary>
        public static TypeUserInterface? IpAddressV4TestFieldUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("TestEntityForTypes")
                .GetAttributeByName("IpAddressV4TestField")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'IpAddressV6TestField'
        /// </summary>
        public static TypeUserInterface? IpAddressV6TestFieldUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("TestEntityForTypes")
                .GetAttributeByName("IpAddressV6TestField")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'JsonTestField'
        /// </summary>
        public static TypeUserInterface? JsonTestFieldUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("TestEntityForTypes")
                .GetAttributeByName("JsonTestField")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'LengthTestField'
        /// </summary>
        public static TypeUserInterface? LengthTestFieldUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("TestEntityForTypes")
                .GetAttributeByName("LengthTestField")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'MacAddressTestField'
        /// </summary>
        public static TypeUserInterface? MacAddressTestFieldUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("TestEntityForTypes")
                .GetAttributeByName("MacAddressTestField")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'MonthTestField'
        /// </summary>
        public static TypeUserInterface? MonthTestFieldUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("TestEntityForTypes")
                .GetAttributeByName("MonthTestField")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'PasswordTestField'
        /// </summary>
        public static TypeUserInterface? PasswordTestFieldUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("TestEntityForTypes")
                .GetAttributeByName("PasswordTestField")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'PercentageTestField'
        /// </summary>
        public static TypeUserInterface? PercentageTestFieldUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("TestEntityForTypes")
                .GetAttributeByName("PercentageTestField")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'PhoneNumberTestField'
        /// </summary>
        public static TypeUserInterface? PhoneNumberTestFieldUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("TestEntityForTypes")
                .GetAttributeByName("PhoneNumberTestField")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'TemperatureTestField'
        /// </summary>
        public static TypeUserInterface? TemperatureTestFieldUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("TestEntityForTypes")
                .GetAttributeByName("TemperatureTestField")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'TranslatedTextTestField'
        /// </summary>
        public static TypeUserInterface? TranslatedTextTestFieldUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("TestEntityForTypes")
                .GetAttributeByName("TranslatedTextTestField")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'UriTestField'
        /// </summary>
        public static TypeUserInterface? UriTestFieldUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("TestEntityForTypes")
                .GetAttributeByName("UriTestField")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'VolumeTestField'
        /// </summary>
        public static TypeUserInterface? VolumeTestFieldUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("TestEntityForTypes")
                .GetAttributeByName("VolumeTestField")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'WeightTestField'
        /// </summary>
        public static TypeUserInterface? WeightTestFieldUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("TestEntityForTypes")
                .GetAttributeByName("WeightTestField")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'YearTestField'
        /// </summary>
        public static TypeUserInterface? YearTestFieldUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("TestEntityForTypes")
                .GetAttributeByName("YearTestField")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'CultureCodeTestField'
        /// </summary>
        public static TypeUserInterface? CultureCodeTestFieldUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("TestEntityForTypes")
                .GetAttributeByName("CultureCodeTestField")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'LanguageCodeTestField'
        /// </summary>
        public static TypeUserInterface? LanguageCodeTestFieldUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("TestEntityForTypes")
                .GetAttributeByName("LanguageCodeTestField")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'YamlTestField'
        /// </summary>
        public static TypeUserInterface? YamlTestFieldUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("TestEntityForTypes")
                .GetAttributeByName("YamlTestField")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'DateTimeDurationTestField'
        /// </summary>
        public static TypeUserInterface? DateTimeDurationTestFieldUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("TestEntityForTypes")
                .GetAttributeByName("DateTimeDurationTestField")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'TimeTestField'
        /// </summary>
        public static TypeUserInterface? TimeTestFieldUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("TestEntityForTypes")
                .GetAttributeByName("TimeTestField")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'VatNumberTestField'
        /// </summary>
        public static TypeUserInterface? VatNumberTestFieldUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("TestEntityForTypes")
                .GetAttributeByName("VatNumberTestField")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'DateTestField'
        /// </summary>
        public static TypeUserInterface? DateTestFieldUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("TestEntityForTypes")
                .GetAttributeByName("DateTestField")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'MarkdownTestField'
        /// </summary>
        public static TypeUserInterface? MarkdownTestFieldUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("TestEntityForTypes")
                .GetAttributeByName("MarkdownTestField")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'FileTestField'
        /// </summary>
        public static TypeUserInterface? FileTestFieldUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("TestEntityForTypes")
                .GetAttributeByName("FileTestField")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'ColorTestField'
        /// </summary>
        public static TypeUserInterface? ColorTestFieldUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("TestEntityForTypes")
                .GetAttributeByName("ColorTestField")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'UrlTestField'
        /// </summary>
        public static TypeUserInterface? UrlTestFieldUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("TestEntityForTypes")
                .GetAttributeByName("UrlTestField")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'DateTimeScheduleTestField'
        /// </summary>
        public static TypeUserInterface? DateTimeScheduleTestFieldUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("TestEntityForTypes")
                .GetAttributeByName("DateTimeScheduleTestField")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'UserTestField'
        /// </summary>
        public static TypeUserInterface? UserTestFieldUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("TestEntityForTypes")
                .GetAttributeByName("UserTestField")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'FormulaTestField'
        /// </summary>
        public static TypeUserInterface? FormulaTestFieldUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("TestEntityForTypes")
                .GetAttributeByName("FormulaTestField")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'AutoNumberTestField'
        /// </summary>
        public static TypeUserInterface? AutoNumberTestFieldUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("TestEntityForTypes")
                .GetAttributeByName("AutoNumberTestField")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'HtmlTestField'
        /// </summary>
        public static TypeUserInterface? HtmlTestFieldUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("TestEntityForTypes")
                .GetAttributeByName("HtmlTestField")?
                .UserInterface;

        /// <summary>
        /// User Interface for property 'ImageTestField'
        /// </summary>
        public static TypeUserInterface? ImageTestFieldUiOptions(NoxSolution solution) 
            => solution.Domain!
                .GetEntityByName("TestEntityForTypes")
                .GetAttributeByName("ImageTestField")?
                .UserInterface;
}