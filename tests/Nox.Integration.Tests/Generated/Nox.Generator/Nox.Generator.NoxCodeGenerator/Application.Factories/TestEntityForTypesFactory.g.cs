

// Generated
//TODO: if CultureCode is not needed, remove it from the factory
#nullable enable

using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using MediatR;

using Nox.Abstractions;
using Nox.Solution;
using Nox.Domain;
using Nox.Application.Factories;
using Nox.Types;
using Nox.Application;
using Nox.Extensions;
using Nox.Exceptions;

using TestWebApp.Application.Dto;
using TestWebApp.Domain;
using TestEntityForTypesEntity = TestWebApp.Domain.TestEntityForTypes;

namespace TestWebApp.Application.Factories;

internal partial class TestEntityForTypesFactory : TestEntityForTypesFactoryBase
{
    public TestEntityForTypesFactory
    (
    ) : base()
    {}
}

internal abstract class TestEntityForTypesFactoryBase : IEntityFactory<TestEntityForTypesEntity, TestEntityForTypesCreateDto, TestEntityForTypesUpdateDto>
{

    public TestEntityForTypesFactoryBase(
        )
    {
    }

    public virtual async Task<TestEntityForTypesEntity> CreateEntityAsync(TestEntityForTypesCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
<<<<<<< main
        return await ToEntityAsync(createDto);
=======
        try
        {
            var entity =  await ToEntityAsync(createDto, cultureCode);
            return entity;
        }
        catch (NoxTypeValidationException ex)
        {
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
        }        
>>>>>>> Factory classes refactor has been completed (without tests)
    }

    public virtual async Task UpdateEntityAsync(TestEntityForTypesEntity entity, TestEntityForTypesUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        await UpdateEntityInternalAsync(entity, updateDto, cultureCode);
    }

    public virtual async Task PartialUpdateEntityAsync(TestEntityForTypesEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
<<<<<<< main
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
=======
<<<<<<< main
        try
        {
             PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
        }
        catch (NoxTypeValidationException ex)
        {
            throw new Nox.Application.Factories.CreateUpdateEntityInvalidDataException(ex);
        }   
=======
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
        await Task.CompletedTask;
>>>>>>> Factory classes refactor has been completed (without tests)
>>>>>>> Factory classes refactor has been completed (without tests)
    }

    private async Task<TestWebApp.Domain.TestEntityForTypes> ToEntityAsync(TestEntityForTypesCreateDto createDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        var entity = new TestWebApp.Domain.TestEntityForTypes();
        exceptionCollector.Collect("Id",() => entity.Id = TestEntityForTypesMetadata.CreateId(createDto.Id.NonNullValue<System.String>()));
        exceptionCollector.Collect("TextTestField", () => entity.SetIfNotNull(createDto.TextTestField, (entity) => entity.TextTestField = 
            TestWebApp.Domain.TestEntityForTypesMetadata.CreateTextTestField(createDto.TextTestField.NonNullValue<System.String>())));
        exceptionCollector.Collect("EnumerationTestField", () => entity.SetIfNotNull(createDto.EnumerationTestField, (entity) => entity.EnumerationTestField = 
            TestWebApp.Domain.TestEntityForTypesMetadata.CreateEnumerationTestField(createDto.EnumerationTestField.NonNullValue<System.Int32>())));
        exceptionCollector.Collect("NumberTestField", () => entity.SetIfNotNull(createDto.NumberTestField, (entity) => entity.NumberTestField = 
            TestWebApp.Domain.TestEntityForTypesMetadata.CreateNumberTestField(createDto.NumberTestField.NonNullValue<System.Int16>())));
        exceptionCollector.Collect("MoneyTestField", () => entity.SetIfNotNull(createDto.MoneyTestField, (entity) => entity.MoneyTestField = 
            TestWebApp.Domain.TestEntityForTypesMetadata.CreateMoneyTestField(createDto.MoneyTestField.NonNullValue<MoneyDto>())));
        exceptionCollector.Collect("CountryCode2TestField", () => entity.SetIfNotNull(createDto.CountryCode2TestField, (entity) => entity.CountryCode2TestField = 
            TestWebApp.Domain.TestEntityForTypesMetadata.CreateCountryCode2TestField(createDto.CountryCode2TestField.NonNullValue<System.String>())));
        exceptionCollector.Collect("StreetAddressTestField", () => entity.SetIfNotNull(createDto.StreetAddressTestField, (entity) => entity.StreetAddressTestField = 
            TestWebApp.Domain.TestEntityForTypesMetadata.CreateStreetAddressTestField(createDto.StreetAddressTestField.NonNullValue<StreetAddressDto>())));
        exceptionCollector.Collect("CurrencyCode3TestField", () => entity.SetIfNotNull(createDto.CurrencyCode3TestField, (entity) => entity.CurrencyCode3TestField = 
            TestWebApp.Domain.TestEntityForTypesMetadata.CreateCurrencyCode3TestField(createDto.CurrencyCode3TestField.NonNullValue<System.String>())));
        exceptionCollector.Collect("DayOfWeekTestField", () => entity.SetIfNotNull(createDto.DayOfWeekTestField, (entity) => entity.DayOfWeekTestField = 
            TestWebApp.Domain.TestEntityForTypesMetadata.CreateDayOfWeekTestField(createDto.DayOfWeekTestField.NonNullValue<System.UInt16>())));
        exceptionCollector.Collect("JwtTokenTestField", () => entity.SetIfNotNull(createDto.JwtTokenTestField, (entity) => entity.JwtTokenTestField = 
            TestWebApp.Domain.TestEntityForTypesMetadata.CreateJwtTokenTestField(createDto.JwtTokenTestField.NonNullValue<System.String>())));
        exceptionCollector.Collect("GeoCoordTestField", () => entity.SetIfNotNull(createDto.GeoCoordTestField, (entity) => entity.GeoCoordTestField = 
            TestWebApp.Domain.TestEntityForTypesMetadata.CreateGeoCoordTestField(createDto.GeoCoordTestField.NonNullValue<LatLongDto>())));
        exceptionCollector.Collect("AreaTestField", () => entity.SetIfNotNull(createDto.AreaTestField, (entity) => entity.AreaTestField = 
            TestWebApp.Domain.TestEntityForTypesMetadata.CreateAreaTestField(createDto.AreaTestField.NonNullValue<System.Decimal>())));
        exceptionCollector.Collect("TimeZoneCodeTestField", () => entity.SetIfNotNull(createDto.TimeZoneCodeTestField, (entity) => entity.TimeZoneCodeTestField = 
            TestWebApp.Domain.TestEntityForTypesMetadata.CreateTimeZoneCodeTestField(createDto.TimeZoneCodeTestField.NonNullValue<System.String>())));
        exceptionCollector.Collect("BooleanTestField", () => entity.SetIfNotNull(createDto.BooleanTestField, (entity) => entity.BooleanTestField = 
            TestWebApp.Domain.TestEntityForTypesMetadata.CreateBooleanTestField(createDto.BooleanTestField.NonNullValue<System.Boolean>())));
        exceptionCollector.Collect("CountryCode3TestField", () => entity.SetIfNotNull(createDto.CountryCode3TestField, (entity) => entity.CountryCode3TestField = 
            TestWebApp.Domain.TestEntityForTypesMetadata.CreateCountryCode3TestField(createDto.CountryCode3TestField.NonNullValue<System.String>())));
        exceptionCollector.Collect("CountryNumberTestField", () => entity.SetIfNotNull(createDto.CountryNumberTestField, (entity) => entity.CountryNumberTestField = 
            TestWebApp.Domain.TestEntityForTypesMetadata.CreateCountryNumberTestField(createDto.CountryNumberTestField.NonNullValue<System.UInt16>())));
        exceptionCollector.Collect("CurrencyNumberTestField", () => entity.SetIfNotNull(createDto.CurrencyNumberTestField, (entity) => entity.CurrencyNumberTestField = 
            TestWebApp.Domain.TestEntityForTypesMetadata.CreateCurrencyNumberTestField(createDto.CurrencyNumberTestField.NonNullValue<System.Int16>())));
        exceptionCollector.Collect("DateTimeTestField", () => entity.SetIfNotNull(createDto.DateTimeTestField, (entity) => entity.DateTimeTestField = 
            TestWebApp.Domain.TestEntityForTypesMetadata.CreateDateTimeTestField(createDto.DateTimeTestField.NonNullValue<System.DateTimeOffset>())));
        exceptionCollector.Collect("DateTimeRangeTestField", () => entity.SetIfNotNull(createDto.DateTimeRangeTestField, (entity) => entity.DateTimeRangeTestField = 
            TestWebApp.Domain.TestEntityForTypesMetadata.CreateDateTimeRangeTestField(createDto.DateTimeRangeTestField.NonNullValue<DateTimeRangeDto>())));
        exceptionCollector.Collect("DistanceTestField", () => entity.SetIfNotNull(createDto.DistanceTestField, (entity) => entity.DistanceTestField = 
            TestWebApp.Domain.TestEntityForTypesMetadata.CreateDistanceTestField(createDto.DistanceTestField.NonNullValue<System.Decimal>())));
        exceptionCollector.Collect("EmailTestField", () => entity.SetIfNotNull(createDto.EmailTestField, (entity) => entity.EmailTestField = 
            TestWebApp.Domain.TestEntityForTypesMetadata.CreateEmailTestField(createDto.EmailTestField.NonNullValue<System.String>())));
        exceptionCollector.Collect("EncryptedTextTestField", () => entity.SetIfNotNull(createDto.EncryptedTextTestField, (entity) => entity.EncryptedTextTestField = 
            TestWebApp.Domain.TestEntityForTypesMetadata.CreateEncryptedTextTestField(createDto.EncryptedTextTestField.NonNullValue<System.Byte[]>())));
        exceptionCollector.Collect("GuidTestField", () => entity.SetIfNotNull(createDto.GuidTestField, (entity) => entity.GuidTestField = 
            TestWebApp.Domain.TestEntityForTypesMetadata.CreateGuidTestField(createDto.GuidTestField.NonNullValue<System.Guid>())));
        exceptionCollector.Collect("HashedTextTestField", () => entity.SetIfNotNull(createDto.HashedTextTestField, (entity) => entity.HashedTextTestField = 
            TestWebApp.Domain.TestEntityForTypesMetadata.CreateHashedTextTestField(createDto.HashedTextTestField.NonNullValue<HashedTextDto>())));
        exceptionCollector.Collect("InternetDomainTestField", () => entity.SetIfNotNull(createDto.InternetDomainTestField, (entity) => entity.InternetDomainTestField = 
            TestWebApp.Domain.TestEntityForTypesMetadata.CreateInternetDomainTestField(createDto.InternetDomainTestField.NonNullValue<System.String>())));
        exceptionCollector.Collect("IpAddressV4TestField", () => entity.SetIfNotNull(createDto.IpAddressV4TestField, (entity) => entity.IpAddressV4TestField = 
            TestWebApp.Domain.TestEntityForTypesMetadata.CreateIpAddressV4TestField(createDto.IpAddressV4TestField.NonNullValue<System.String>())));
        exceptionCollector.Collect("IpAddressV6TestField", () => entity.SetIfNotNull(createDto.IpAddressV6TestField, (entity) => entity.IpAddressV6TestField = 
            TestWebApp.Domain.TestEntityForTypesMetadata.CreateIpAddressV6TestField(createDto.IpAddressV6TestField.NonNullValue<System.String>())));
        exceptionCollector.Collect("JsonTestField", () => entity.SetIfNotNull(createDto.JsonTestField, (entity) => entity.JsonTestField = 
            TestWebApp.Domain.TestEntityForTypesMetadata.CreateJsonTestField(createDto.JsonTestField.NonNullValue<System.String>())));
        exceptionCollector.Collect("LengthTestField", () => entity.SetIfNotNull(createDto.LengthTestField, (entity) => entity.LengthTestField = 
            TestWebApp.Domain.TestEntityForTypesMetadata.CreateLengthTestField(createDto.LengthTestField.NonNullValue<System.Decimal>())));
        exceptionCollector.Collect("MacAddressTestField", () => entity.SetIfNotNull(createDto.MacAddressTestField, (entity) => entity.MacAddressTestField = 
            TestWebApp.Domain.TestEntityForTypesMetadata.CreateMacAddressTestField(createDto.MacAddressTestField.NonNullValue<System.String>())));
        exceptionCollector.Collect("MonthTestField", () => entity.SetIfNotNull(createDto.MonthTestField, (entity) => entity.MonthTestField = 
            TestWebApp.Domain.TestEntityForTypesMetadata.CreateMonthTestField(createDto.MonthTestField.NonNullValue<System.Byte>())));
        exceptionCollector.Collect("PasswordTestField", () => entity.SetIfNotNull(createDto.PasswordTestField, (entity) => entity.PasswordTestField = 
            TestWebApp.Domain.TestEntityForTypesMetadata.CreatePasswordTestField(createDto.PasswordTestField.NonNullValue<PasswordDto>())));
        exceptionCollector.Collect("PercentageTestField", () => entity.SetIfNotNull(createDto.PercentageTestField, (entity) => entity.PercentageTestField = 
            TestWebApp.Domain.TestEntityForTypesMetadata.CreatePercentageTestField(createDto.PercentageTestField.NonNullValue<System.Single>())));
        exceptionCollector.Collect("PhoneNumberTestField", () => entity.SetIfNotNull(createDto.PhoneNumberTestField, (entity) => entity.PhoneNumberTestField = 
            TestWebApp.Domain.TestEntityForTypesMetadata.CreatePhoneNumberTestField(createDto.PhoneNumberTestField.NonNullValue<System.String>())));
        exceptionCollector.Collect("TemperatureTestField", () => entity.SetIfNotNull(createDto.TemperatureTestField, (entity) => entity.TemperatureTestField = 
            TestWebApp.Domain.TestEntityForTypesMetadata.CreateTemperatureTestField(createDto.TemperatureTestField.NonNullValue<System.Decimal>())));
        exceptionCollector.Collect("TranslatedTextTestField", () => entity.SetIfNotNull(createDto.TranslatedTextTestField, (entity) => entity.TranslatedTextTestField = 
            TestWebApp.Domain.TestEntityForTypesMetadata.CreateTranslatedTextTestField(createDto.TranslatedTextTestField.NonNullValue<TranslatedTextDto>())));
        exceptionCollector.Collect("UriTestField", () => entity.SetIfNotNull(createDto.UriTestField, (entity) => entity.UriTestField = 
            TestWebApp.Domain.TestEntityForTypesMetadata.CreateUriTestField(createDto.UriTestField.NonNullValue<System.String>())));
        exceptionCollector.Collect("VolumeTestField", () => entity.SetIfNotNull(createDto.VolumeTestField, (entity) => entity.VolumeTestField = 
            TestWebApp.Domain.TestEntityForTypesMetadata.CreateVolumeTestField(createDto.VolumeTestField.NonNullValue<System.Decimal>())));
        exceptionCollector.Collect("WeightTestField", () => entity.SetIfNotNull(createDto.WeightTestField, (entity) => entity.WeightTestField = 
            TestWebApp.Domain.TestEntityForTypesMetadata.CreateWeightTestField(createDto.WeightTestField.NonNullValue<System.Decimal>())));
        exceptionCollector.Collect("YearTestField", () => entity.SetIfNotNull(createDto.YearTestField, (entity) => entity.YearTestField = 
            TestWebApp.Domain.TestEntityForTypesMetadata.CreateYearTestField(createDto.YearTestField.NonNullValue<System.UInt16>())));
        exceptionCollector.Collect("CultureCodeTestField", () => entity.SetIfNotNull(createDto.CultureCodeTestField, (entity) => entity.CultureCodeTestField = 
            TestWebApp.Domain.TestEntityForTypesMetadata.CreateCultureCodeTestField(createDto.CultureCodeTestField.NonNullValue<System.String>())));
        exceptionCollector.Collect("LanguageCodeTestField", () => entity.SetIfNotNull(createDto.LanguageCodeTestField, (entity) => entity.LanguageCodeTestField = 
            TestWebApp.Domain.TestEntityForTypesMetadata.CreateLanguageCodeTestField(createDto.LanguageCodeTestField.NonNullValue<System.String>())));
        exceptionCollector.Collect("YamlTestField", () => entity.SetIfNotNull(createDto.YamlTestField, (entity) => entity.YamlTestField = 
            TestWebApp.Domain.TestEntityForTypesMetadata.CreateYamlTestField(createDto.YamlTestField.NonNullValue<System.String>())));
        exceptionCollector.Collect("DateTimeDurationTestField", () => entity.SetIfNotNull(createDto.DateTimeDurationTestField, (entity) => entity.DateTimeDurationTestField = 
            TestWebApp.Domain.TestEntityForTypesMetadata.CreateDateTimeDurationTestField(createDto.DateTimeDurationTestField.NonNullValue<System.Int64>())));
        exceptionCollector.Collect("TimeTestField", () => entity.SetIfNotNull(createDto.TimeTestField, (entity) => entity.TimeTestField = 
            TestWebApp.Domain.TestEntityForTypesMetadata.CreateTimeTestField(createDto.TimeTestField.NonNullValue<System.DateTime>())));
        exceptionCollector.Collect("VatNumberTestField", () => entity.SetIfNotNull(createDto.VatNumberTestField, (entity) => entity.VatNumberTestField = 
            TestWebApp.Domain.TestEntityForTypesMetadata.CreateVatNumberTestField(createDto.VatNumberTestField.NonNullValue<VatNumberDto>())));
        exceptionCollector.Collect("DateTestField", () => entity.SetIfNotNull(createDto.DateTestField, (entity) => entity.DateTestField = 
            TestWebApp.Domain.TestEntityForTypesMetadata.CreateDateTestField(createDto.DateTestField.NonNullValue<System.DateTime>())));
        exceptionCollector.Collect("MarkdownTestField", () => entity.SetIfNotNull(createDto.MarkdownTestField, (entity) => entity.MarkdownTestField = 
            TestWebApp.Domain.TestEntityForTypesMetadata.CreateMarkdownTestField(createDto.MarkdownTestField.NonNullValue<System.String>())));
        exceptionCollector.Collect("FileTestField", () => entity.SetIfNotNull(createDto.FileTestField, (entity) => entity.FileTestField = 
            TestWebApp.Domain.TestEntityForTypesMetadata.CreateFileTestField(createDto.FileTestField.NonNullValue<FileDto>())));
        exceptionCollector.Collect("ColorTestField", () => entity.SetIfNotNull(createDto.ColorTestField, (entity) => entity.ColorTestField = 
            TestWebApp.Domain.TestEntityForTypesMetadata.CreateColorTestField(createDto.ColorTestField.NonNullValue<System.String>())));
        exceptionCollector.Collect("UrlTestField", () => entity.SetIfNotNull(createDto.UrlTestField, (entity) => entity.UrlTestField = 
            TestWebApp.Domain.TestEntityForTypesMetadata.CreateUrlTestField(createDto.UrlTestField.NonNullValue<System.String>())));
        exceptionCollector.Collect("DateTimeScheduleTestField", () => entity.SetIfNotNull(createDto.DateTimeScheduleTestField, (entity) => entity.DateTimeScheduleTestField = 
            TestWebApp.Domain.TestEntityForTypesMetadata.CreateDateTimeScheduleTestField(createDto.DateTimeScheduleTestField.NonNullValue<System.String>())));
        exceptionCollector.Collect("UserTestField", () => entity.SetIfNotNull(createDto.UserTestField, (entity) => entity.UserTestField = 
            TestWebApp.Domain.TestEntityForTypesMetadata.CreateUserTestField(createDto.UserTestField.NonNullValue<System.String>())));
        exceptionCollector.Collect("HtmlTestField", () => entity.SetIfNotNull(createDto.HtmlTestField, (entity) => entity.HtmlTestField = 
            TestWebApp.Domain.TestEntityForTypesMetadata.CreateHtmlTestField(createDto.HtmlTestField.NonNullValue<System.String>())));
        exceptionCollector.Collect("ImageTestField", () => entity.SetIfNotNull(createDto.ImageTestField, (entity) => entity.ImageTestField = 
            TestWebApp.Domain.TestEntityForTypesMetadata.CreateImageTestField(createDto.ImageTestField.NonNullValue<ImageDto>())));

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);        
        return await Task.FromResult(entity);
    }

    private async Task UpdateEntityInternalAsync(TestEntityForTypesEntity entity, TestEntityForTypesUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();
        exceptionCollector.Collect("TextTestField",() => entity.TextTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateTextTestField(updateDto.TextTestField.NonNullValue<System.String>()));
        if(updateDto.EnumerationTestField is null)
        {
             entity.EnumerationTestField = null;
        }
        else
        {
            exceptionCollector.Collect("EnumerationTestField",() =>entity.EnumerationTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateEnumerationTestField(updateDto.EnumerationTestField.ToValueFromNonNull<System.Int32>()));
        }
        exceptionCollector.Collect("NumberTestField",() => entity.NumberTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateNumberTestField(updateDto.NumberTestField.NonNullValue<System.Int16>()));
        if(updateDto.MoneyTestField is null)
        {
             entity.MoneyTestField = null;
        }
        else
        {
            exceptionCollector.Collect("MoneyTestField",() =>entity.MoneyTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateMoneyTestField(updateDto.MoneyTestField.ToValueFromNonNull<MoneyDto>()));
        }
        if(updateDto.CountryCode2TestField is null)
        {
             entity.CountryCode2TestField = null;
        }
        else
        {
            exceptionCollector.Collect("CountryCode2TestField",() =>entity.CountryCode2TestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateCountryCode2TestField(updateDto.CountryCode2TestField.ToValueFromNonNull<System.String>()));
        }
        if(updateDto.StreetAddressTestField is null)
        {
             entity.StreetAddressTestField = null;
        }
        else
        {
            exceptionCollector.Collect("StreetAddressTestField",() =>entity.StreetAddressTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateStreetAddressTestField(updateDto.StreetAddressTestField.ToValueFromNonNull<StreetAddressDto>()));
        }
        if(updateDto.CurrencyCode3TestField is null)
        {
             entity.CurrencyCode3TestField = null;
        }
        else
        {
            exceptionCollector.Collect("CurrencyCode3TestField",() =>entity.CurrencyCode3TestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateCurrencyCode3TestField(updateDto.CurrencyCode3TestField.ToValueFromNonNull<System.String>()));
        }
        if(updateDto.DayOfWeekTestField is null)
        {
             entity.DayOfWeekTestField = null;
        }
        else
        {
            exceptionCollector.Collect("DayOfWeekTestField",() =>entity.DayOfWeekTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateDayOfWeekTestField(updateDto.DayOfWeekTestField.ToValueFromNonNull<System.UInt16>()));
        }
        if(updateDto.JwtTokenTestField is null)
        {
             entity.JwtTokenTestField = null;
        }
        else
        {
            exceptionCollector.Collect("JwtTokenTestField",() =>entity.JwtTokenTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateJwtTokenTestField(updateDto.JwtTokenTestField.ToValueFromNonNull<System.String>()));
        }
        if(updateDto.GeoCoordTestField is null)
        {
             entity.GeoCoordTestField = null;
        }
        else
        {
            exceptionCollector.Collect("GeoCoordTestField",() =>entity.GeoCoordTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateGeoCoordTestField(updateDto.GeoCoordTestField.ToValueFromNonNull<LatLongDto>()));
        }
        if(updateDto.AreaTestField is null)
        {
             entity.AreaTestField = null;
        }
        else
        {
            exceptionCollector.Collect("AreaTestField",() =>entity.AreaTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateAreaTestField(updateDto.AreaTestField.ToValueFromNonNull<System.Decimal>()));
        }
        if(updateDto.TimeZoneCodeTestField is null)
        {
             entity.TimeZoneCodeTestField = null;
        }
        else
        {
            exceptionCollector.Collect("TimeZoneCodeTestField",() =>entity.TimeZoneCodeTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateTimeZoneCodeTestField(updateDto.TimeZoneCodeTestField.ToValueFromNonNull<System.String>()));
        }
        if(updateDto.BooleanTestField is null)
        {
             entity.BooleanTestField = null;
        }
        else
        {
            exceptionCollector.Collect("BooleanTestField",() =>entity.BooleanTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateBooleanTestField(updateDto.BooleanTestField.ToValueFromNonNull<System.Boolean>()));
        }
        if(updateDto.CountryCode3TestField is null)
        {
             entity.CountryCode3TestField = null;
        }
        else
        {
            exceptionCollector.Collect("CountryCode3TestField",() =>entity.CountryCode3TestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateCountryCode3TestField(updateDto.CountryCode3TestField.ToValueFromNonNull<System.String>()));
        }
        if(updateDto.CountryNumberTestField is null)
        {
             entity.CountryNumberTestField = null;
        }
        else
        {
            exceptionCollector.Collect("CountryNumberTestField",() =>entity.CountryNumberTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateCountryNumberTestField(updateDto.CountryNumberTestField.ToValueFromNonNull<System.UInt16>()));
        }
        if(updateDto.CurrencyNumberTestField is null)
        {
             entity.CurrencyNumberTestField = null;
        }
        else
        {
            exceptionCollector.Collect("CurrencyNumberTestField",() =>entity.CurrencyNumberTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateCurrencyNumberTestField(updateDto.CurrencyNumberTestField.ToValueFromNonNull<System.Int16>()));
        }
        if(updateDto.DateTimeTestField is null)
        {
             entity.DateTimeTestField = null;
        }
        else
        {
            exceptionCollector.Collect("DateTimeTestField",() =>entity.DateTimeTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateDateTimeTestField(updateDto.DateTimeTestField.ToValueFromNonNull<System.DateTimeOffset>()));
        }
        if(updateDto.DateTimeRangeTestField is null)
        {
             entity.DateTimeRangeTestField = null;
        }
        else
        {
            exceptionCollector.Collect("DateTimeRangeTestField",() =>entity.DateTimeRangeTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateDateTimeRangeTestField(updateDto.DateTimeRangeTestField.ToValueFromNonNull<DateTimeRangeDto>()));
        }
        if(updateDto.DistanceTestField is null)
        {
             entity.DistanceTestField = null;
        }
        else
        {
            exceptionCollector.Collect("DistanceTestField",() =>entity.DistanceTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateDistanceTestField(updateDto.DistanceTestField.ToValueFromNonNull<System.Decimal>()));
        }
        if(updateDto.EmailTestField is null)
        {
             entity.EmailTestField = null;
        }
        else
        {
            exceptionCollector.Collect("EmailTestField",() =>entity.EmailTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateEmailTestField(updateDto.EmailTestField.ToValueFromNonNull<System.String>()));
        }
        if(updateDto.GuidTestField is null)
        {
             entity.GuidTestField = null;
        }
        else
        {
            exceptionCollector.Collect("GuidTestField",() =>entity.GuidTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateGuidTestField(updateDto.GuidTestField.ToValueFromNonNull<System.Guid>()));
        }
        if(updateDto.InternetDomainTestField is null)
        {
             entity.InternetDomainTestField = null;
        }
        else
        {
            exceptionCollector.Collect("InternetDomainTestField",() =>entity.InternetDomainTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateInternetDomainTestField(updateDto.InternetDomainTestField.ToValueFromNonNull<System.String>()));
        }
        if(updateDto.IpAddressV4TestField is null)
        {
             entity.IpAddressV4TestField = null;
        }
        else
        {
            exceptionCollector.Collect("IpAddressV4TestField",() =>entity.IpAddressV4TestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateIpAddressV4TestField(updateDto.IpAddressV4TestField.ToValueFromNonNull<System.String>()));
        }
        if(updateDto.IpAddressV6TestField is null)
        {
             entity.IpAddressV6TestField = null;
        }
        else
        {
            exceptionCollector.Collect("IpAddressV6TestField",() =>entity.IpAddressV6TestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateIpAddressV6TestField(updateDto.IpAddressV6TestField.ToValueFromNonNull<System.String>()));
        }
        if(updateDto.JsonTestField is null)
        {
             entity.JsonTestField = null;
        }
        else
        {
            exceptionCollector.Collect("JsonTestField",() =>entity.JsonTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateJsonTestField(updateDto.JsonTestField.ToValueFromNonNull<System.String>()));
        }
        if(updateDto.LengthTestField is null)
        {
             entity.LengthTestField = null;
        }
        else
        {
            exceptionCollector.Collect("LengthTestField",() =>entity.LengthTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateLengthTestField(updateDto.LengthTestField.ToValueFromNonNull<System.Decimal>()));
        }
        if(updateDto.MacAddressTestField is null)
        {
             entity.MacAddressTestField = null;
        }
        else
        {
            exceptionCollector.Collect("MacAddressTestField",() =>entity.MacAddressTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateMacAddressTestField(updateDto.MacAddressTestField.ToValueFromNonNull<System.String>()));
        }
        if(updateDto.MonthTestField is null)
        {
             entity.MonthTestField = null;
        }
        else
        {
            exceptionCollector.Collect("MonthTestField",() =>entity.MonthTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateMonthTestField(updateDto.MonthTestField.ToValueFromNonNull<System.Byte>()));
        }
        if(updateDto.PercentageTestField is null)
        {
             entity.PercentageTestField = null;
        }
        else
        {
            exceptionCollector.Collect("PercentageTestField",() =>entity.PercentageTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreatePercentageTestField(updateDto.PercentageTestField.ToValueFromNonNull<System.Single>()));
        }
        if(updateDto.PhoneNumberTestField is null)
        {
             entity.PhoneNumberTestField = null;
        }
        else
        {
            exceptionCollector.Collect("PhoneNumberTestField",() =>entity.PhoneNumberTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreatePhoneNumberTestField(updateDto.PhoneNumberTestField.ToValueFromNonNull<System.String>()));
        }
        if(updateDto.TemperatureTestField is null)
        {
             entity.TemperatureTestField = null;
        }
        else
        {
            exceptionCollector.Collect("TemperatureTestField",() =>entity.TemperatureTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateTemperatureTestField(updateDto.TemperatureTestField.ToValueFromNonNull<System.Decimal>()));
        }
        if(updateDto.TranslatedTextTestField is null)
        {
             entity.TranslatedTextTestField = null;
        }
        else
        {
            exceptionCollector.Collect("TranslatedTextTestField",() =>entity.TranslatedTextTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateTranslatedTextTestField(updateDto.TranslatedTextTestField.ToValueFromNonNull<TranslatedTextDto>()));
        }
        if(updateDto.UriTestField is null)
        {
             entity.UriTestField = null;
        }
        else
        {
            exceptionCollector.Collect("UriTestField",() =>entity.UriTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateUriTestField(updateDto.UriTestField.ToValueFromNonNull<System.String>()));
        }
        if(updateDto.VolumeTestField is null)
        {
             entity.VolumeTestField = null;
        }
        else
        {
            exceptionCollector.Collect("VolumeTestField",() =>entity.VolumeTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateVolumeTestField(updateDto.VolumeTestField.ToValueFromNonNull<System.Decimal>()));
        }
        if(updateDto.WeightTestField is null)
        {
             entity.WeightTestField = null;
        }
        else
        {
            exceptionCollector.Collect("WeightTestField",() =>entity.WeightTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateWeightTestField(updateDto.WeightTestField.ToValueFromNonNull<System.Decimal>()));
        }
        if(updateDto.YearTestField is null)
        {
             entity.YearTestField = null;
        }
        else
        {
            exceptionCollector.Collect("YearTestField",() =>entity.YearTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateYearTestField(updateDto.YearTestField.ToValueFromNonNull<System.UInt16>()));
        }
        if(updateDto.CultureCodeTestField is null)
        {
             entity.CultureCodeTestField = null;
        }
        else
        {
            exceptionCollector.Collect("CultureCodeTestField",() =>entity.CultureCodeTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateCultureCodeTestField(updateDto.CultureCodeTestField.ToValueFromNonNull<System.String>()));
        }
        if(updateDto.LanguageCodeTestField is null)
        {
             entity.LanguageCodeTestField = null;
        }
        else
        {
            exceptionCollector.Collect("LanguageCodeTestField",() =>entity.LanguageCodeTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateLanguageCodeTestField(updateDto.LanguageCodeTestField.ToValueFromNonNull<System.String>()));
        }
        if(updateDto.YamlTestField is null)
        {
             entity.YamlTestField = null;
        }
        else
        {
            exceptionCollector.Collect("YamlTestField",() =>entity.YamlTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateYamlTestField(updateDto.YamlTestField.ToValueFromNonNull<System.String>()));
        }
        if(updateDto.DateTimeDurationTestField is null)
        {
             entity.DateTimeDurationTestField = null;
        }
        else
        {
            exceptionCollector.Collect("DateTimeDurationTestField",() =>entity.DateTimeDurationTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateDateTimeDurationTestField(updateDto.DateTimeDurationTestField.ToValueFromNonNull<System.Int64>()));
        }
        if(updateDto.TimeTestField is null)
        {
             entity.TimeTestField = null;
        }
        else
        {
            exceptionCollector.Collect("TimeTestField",() =>entity.TimeTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateTimeTestField(updateDto.TimeTestField.ToValueFromNonNull<System.DateTime>()));
        }
        if(updateDto.VatNumberTestField is null)
        {
             entity.VatNumberTestField = null;
        }
        else
        {
            exceptionCollector.Collect("VatNumberTestField",() =>entity.VatNumberTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateVatNumberTestField(updateDto.VatNumberTestField.ToValueFromNonNull<VatNumberDto>()));
        }
        if(updateDto.DateTestField is null)
        {
             entity.DateTestField = null;
        }
        else
        {
            exceptionCollector.Collect("DateTestField",() =>entity.DateTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateDateTestField(updateDto.DateTestField.ToValueFromNonNull<System.DateTime>()));
        }
        if(updateDto.MarkdownTestField is null)
        {
             entity.MarkdownTestField = null;
        }
        else
        {
            exceptionCollector.Collect("MarkdownTestField",() =>entity.MarkdownTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateMarkdownTestField(updateDto.MarkdownTestField.ToValueFromNonNull<System.String>()));
        }
        if(updateDto.FileTestField is null)
        {
             entity.FileTestField = null;
        }
        else
        {
            exceptionCollector.Collect("FileTestField",() =>entity.FileTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateFileTestField(updateDto.FileTestField.ToValueFromNonNull<FileDto>()));
        }
        if(updateDto.ColorTestField is null)
        {
             entity.ColorTestField = null;
        }
        else
        {
            exceptionCollector.Collect("ColorTestField",() =>entity.ColorTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateColorTestField(updateDto.ColorTestField.ToValueFromNonNull<System.String>()));
        }
        if(updateDto.UrlTestField is null)
        {
             entity.UrlTestField = null;
        }
        else
        {
            exceptionCollector.Collect("UrlTestField",() =>entity.UrlTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateUrlTestField(updateDto.UrlTestField.ToValueFromNonNull<System.String>()));
        }
        if(updateDto.DateTimeScheduleTestField is null)
        {
             entity.DateTimeScheduleTestField = null;
        }
        else
        {
            exceptionCollector.Collect("DateTimeScheduleTestField",() =>entity.DateTimeScheduleTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateDateTimeScheduleTestField(updateDto.DateTimeScheduleTestField.ToValueFromNonNull<System.String>()));
        }
        if(updateDto.UserTestField is null)
        {
             entity.UserTestField = null;
        }
        else
        {
            exceptionCollector.Collect("UserTestField",() =>entity.UserTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateUserTestField(updateDto.UserTestField.ToValueFromNonNull<System.String>()));
        }
        if(updateDto.HtmlTestField is null)
        {
             entity.HtmlTestField = null;
        }
        else
        {
            exceptionCollector.Collect("HtmlTestField",() =>entity.HtmlTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateHtmlTestField(updateDto.HtmlTestField.ToValueFromNonNull<System.String>()));
        }
        if(updateDto.ImageTestField is null)
        {
             entity.ImageTestField = null;
        }
        else
        {
            exceptionCollector.Collect("ImageTestField",() =>entity.ImageTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateImageTestField(updateDto.ImageTestField.ToValueFromNonNull<ImageDto>()));
        }

        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
        await Task.CompletedTask;
    }

    private void PartialUpdateEntityInternal(TestEntityForTypesEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        ExceptionCollector<NoxTypeValidationException> exceptionCollector = new();

        if (updatedProperties.TryGetValue("TextTestField", out var TextTestFieldUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(TextTestFieldUpdateValue, "Attribute 'TextTestField' can't be null.");
            {
                exceptionCollector.Collect("TextTestField",() =>entity.TextTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateTextTestField(TextTestFieldUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("EnumerationTestField", out var EnumerationTestFieldUpdateValue))
        {
            if (EnumerationTestFieldUpdateValue == null) { entity.EnumerationTestField = null; }
            else
            {
                exceptionCollector.Collect("EnumerationTestField",() =>entity.EnumerationTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateEnumerationTestField(EnumerationTestFieldUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("NumberTestField", out var NumberTestFieldUpdateValue))
        {
            ArgumentNullException.ThrowIfNull(NumberTestFieldUpdateValue, "Attribute 'NumberTestField' can't be null.");
            {
                exceptionCollector.Collect("NumberTestField",() =>entity.NumberTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateNumberTestField(NumberTestFieldUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("MoneyTestField", out var MoneyTestFieldUpdateValue))
        {
            if (MoneyTestFieldUpdateValue == null) { entity.MoneyTestField = null; }
            else
            {
                var entityToUpdate = entity.MoneyTestField is null ? new MoneyDto() : entity.MoneyTestField.ToDto();
                MoneyDto.UpdateFromDictionary(entityToUpdate, MoneyTestFieldUpdateValue);
                exceptionCollector.Collect("MoneyTestField",() =>entity.MoneyTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateMoneyTestField(entityToUpdate));
            }
        }

        if (updatedProperties.TryGetValue("CountryCode2TestField", out var CountryCode2TestFieldUpdateValue))
        {
            if (CountryCode2TestFieldUpdateValue == null) { entity.CountryCode2TestField = null; }
            else
            {
                exceptionCollector.Collect("CountryCode2TestField",() =>entity.CountryCode2TestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateCountryCode2TestField(CountryCode2TestFieldUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("StreetAddressTestField", out var StreetAddressTestFieldUpdateValue))
        {
            if (StreetAddressTestFieldUpdateValue == null) { entity.StreetAddressTestField = null; }
            else
            {
                var entityToUpdate = entity.StreetAddressTestField is null ? new StreetAddressDto() : entity.StreetAddressTestField.ToDto();
                StreetAddressDto.UpdateFromDictionary(entityToUpdate, StreetAddressTestFieldUpdateValue);
                exceptionCollector.Collect("StreetAddressTestField",() =>entity.StreetAddressTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateStreetAddressTestField(entityToUpdate));
            }
        }

        if (updatedProperties.TryGetValue("CurrencyCode3TestField", out var CurrencyCode3TestFieldUpdateValue))
        {
            if (CurrencyCode3TestFieldUpdateValue == null) { entity.CurrencyCode3TestField = null; }
            else
            {
                exceptionCollector.Collect("CurrencyCode3TestField",() =>entity.CurrencyCode3TestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateCurrencyCode3TestField(CurrencyCode3TestFieldUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("DayOfWeekTestField", out var DayOfWeekTestFieldUpdateValue))
        {
            if (DayOfWeekTestFieldUpdateValue == null) { entity.DayOfWeekTestField = null; }
            else
            {
                exceptionCollector.Collect("DayOfWeekTestField",() =>entity.DayOfWeekTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateDayOfWeekTestField(DayOfWeekTestFieldUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("JwtTokenTestField", out var JwtTokenTestFieldUpdateValue))
        {
            if (JwtTokenTestFieldUpdateValue == null) { entity.JwtTokenTestField = null; }
            else
            {
                exceptionCollector.Collect("JwtTokenTestField",() =>entity.JwtTokenTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateJwtTokenTestField(JwtTokenTestFieldUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("GeoCoordTestField", out var GeoCoordTestFieldUpdateValue))
        {
            if (GeoCoordTestFieldUpdateValue == null) { entity.GeoCoordTestField = null; }
            else
            {
                var entityToUpdate = entity.GeoCoordTestField is null ? new LatLongDto() : entity.GeoCoordTestField.ToDto();
                LatLongDto.UpdateFromDictionary(entityToUpdate, GeoCoordTestFieldUpdateValue);
                exceptionCollector.Collect("GeoCoordTestField",() =>entity.GeoCoordTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateGeoCoordTestField(entityToUpdate));
            }
        }

        if (updatedProperties.TryGetValue("AreaTestField", out var AreaTestFieldUpdateValue))
        {
            if (AreaTestFieldUpdateValue == null) { entity.AreaTestField = null; }
            else
            {
                exceptionCollector.Collect("AreaTestField",() =>entity.AreaTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateAreaTestField(AreaTestFieldUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("TimeZoneCodeTestField", out var TimeZoneCodeTestFieldUpdateValue))
        {
            if (TimeZoneCodeTestFieldUpdateValue == null) { entity.TimeZoneCodeTestField = null; }
            else
            {
                exceptionCollector.Collect("TimeZoneCodeTestField",() =>entity.TimeZoneCodeTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateTimeZoneCodeTestField(TimeZoneCodeTestFieldUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("BooleanTestField", out var BooleanTestFieldUpdateValue))
        {
            if (BooleanTestFieldUpdateValue == null) { entity.BooleanTestField = null; }
            else
            {
                exceptionCollector.Collect("BooleanTestField",() =>entity.BooleanTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateBooleanTestField(BooleanTestFieldUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("CountryCode3TestField", out var CountryCode3TestFieldUpdateValue))
        {
            if (CountryCode3TestFieldUpdateValue == null) { entity.CountryCode3TestField = null; }
            else
            {
                exceptionCollector.Collect("CountryCode3TestField",() =>entity.CountryCode3TestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateCountryCode3TestField(CountryCode3TestFieldUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("CountryNumberTestField", out var CountryNumberTestFieldUpdateValue))
        {
            if (CountryNumberTestFieldUpdateValue == null) { entity.CountryNumberTestField = null; }
            else
            {
                exceptionCollector.Collect("CountryNumberTestField",() =>entity.CountryNumberTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateCountryNumberTestField(CountryNumberTestFieldUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("CurrencyNumberTestField", out var CurrencyNumberTestFieldUpdateValue))
        {
            if (CurrencyNumberTestFieldUpdateValue == null) { entity.CurrencyNumberTestField = null; }
            else
            {
                exceptionCollector.Collect("CurrencyNumberTestField",() =>entity.CurrencyNumberTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateCurrencyNumberTestField(CurrencyNumberTestFieldUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("DateTimeTestField", out var DateTimeTestFieldUpdateValue))
        {
            if (DateTimeTestFieldUpdateValue == null) { entity.DateTimeTestField = null; }
            else
            {
                exceptionCollector.Collect("DateTimeTestField",() =>entity.DateTimeTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateDateTimeTestField(DateTimeTestFieldUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("DateTimeRangeTestField", out var DateTimeRangeTestFieldUpdateValue))
        {
            if (DateTimeRangeTestFieldUpdateValue == null) { entity.DateTimeRangeTestField = null; }
            else
            {
                var entityToUpdate = entity.DateTimeRangeTestField is null ? new DateTimeRangeDto() : entity.DateTimeRangeTestField.ToDto();
                DateTimeRangeDto.UpdateFromDictionary(entityToUpdate, DateTimeRangeTestFieldUpdateValue);
                exceptionCollector.Collect("DateTimeRangeTestField",() =>entity.DateTimeRangeTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateDateTimeRangeTestField(entityToUpdate));
            }
        }

        if (updatedProperties.TryGetValue("DistanceTestField", out var DistanceTestFieldUpdateValue))
        {
            if (DistanceTestFieldUpdateValue == null) { entity.DistanceTestField = null; }
            else
            {
                exceptionCollector.Collect("DistanceTestField",() =>entity.DistanceTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateDistanceTestField(DistanceTestFieldUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("EmailTestField", out var EmailTestFieldUpdateValue))
        {
            if (EmailTestFieldUpdateValue == null) { entity.EmailTestField = null; }
            else
            {
                exceptionCollector.Collect("EmailTestField",() =>entity.EmailTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateEmailTestField(EmailTestFieldUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("GuidTestField", out var GuidTestFieldUpdateValue))
        {
            if (GuidTestFieldUpdateValue == null) { entity.GuidTestField = null; }
            else
            {
                exceptionCollector.Collect("GuidTestField",() =>entity.GuidTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateGuidTestField(GuidTestFieldUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("InternetDomainTestField", out var InternetDomainTestFieldUpdateValue))
        {
            if (InternetDomainTestFieldUpdateValue == null) { entity.InternetDomainTestField = null; }
            else
            {
                exceptionCollector.Collect("InternetDomainTestField",() =>entity.InternetDomainTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateInternetDomainTestField(InternetDomainTestFieldUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("IpAddressV4TestField", out var IpAddressV4TestFieldUpdateValue))
        {
            if (IpAddressV4TestFieldUpdateValue == null) { entity.IpAddressV4TestField = null; }
            else
            {
                exceptionCollector.Collect("IpAddressV4TestField",() =>entity.IpAddressV4TestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateIpAddressV4TestField(IpAddressV4TestFieldUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("IpAddressV6TestField", out var IpAddressV6TestFieldUpdateValue))
        {
            if (IpAddressV6TestFieldUpdateValue == null) { entity.IpAddressV6TestField = null; }
            else
            {
                exceptionCollector.Collect("IpAddressV6TestField",() =>entity.IpAddressV6TestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateIpAddressV6TestField(IpAddressV6TestFieldUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("JsonTestField", out var JsonTestFieldUpdateValue))
        {
            if (JsonTestFieldUpdateValue == null) { entity.JsonTestField = null; }
            else
            {
                exceptionCollector.Collect("JsonTestField",() =>entity.JsonTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateJsonTestField(JsonTestFieldUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("LengthTestField", out var LengthTestFieldUpdateValue))
        {
            if (LengthTestFieldUpdateValue == null) { entity.LengthTestField = null; }
            else
            {
                exceptionCollector.Collect("LengthTestField",() =>entity.LengthTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateLengthTestField(LengthTestFieldUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("MacAddressTestField", out var MacAddressTestFieldUpdateValue))
        {
            if (MacAddressTestFieldUpdateValue == null) { entity.MacAddressTestField = null; }
            else
            {
                exceptionCollector.Collect("MacAddressTestField",() =>entity.MacAddressTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateMacAddressTestField(MacAddressTestFieldUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("MonthTestField", out var MonthTestFieldUpdateValue))
        {
            if (MonthTestFieldUpdateValue == null) { entity.MonthTestField = null; }
            else
            {
                exceptionCollector.Collect("MonthTestField",() =>entity.MonthTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateMonthTestField(MonthTestFieldUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("PercentageTestField", out var PercentageTestFieldUpdateValue))
        {
            if (PercentageTestFieldUpdateValue == null) { entity.PercentageTestField = null; }
            else
            {
                exceptionCollector.Collect("PercentageTestField",() =>entity.PercentageTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreatePercentageTestField(PercentageTestFieldUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("PhoneNumberTestField", out var PhoneNumberTestFieldUpdateValue))
        {
            if (PhoneNumberTestFieldUpdateValue == null) { entity.PhoneNumberTestField = null; }
            else
            {
                exceptionCollector.Collect("PhoneNumberTestField",() =>entity.PhoneNumberTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreatePhoneNumberTestField(PhoneNumberTestFieldUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("TemperatureTestField", out var TemperatureTestFieldUpdateValue))
        {
            if (TemperatureTestFieldUpdateValue == null) { entity.TemperatureTestField = null; }
            else
            {
                exceptionCollector.Collect("TemperatureTestField",() =>entity.TemperatureTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateTemperatureTestField(TemperatureTestFieldUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("TranslatedTextTestField", out var TranslatedTextTestFieldUpdateValue))
        {
            if (TranslatedTextTestFieldUpdateValue == null) { entity.TranslatedTextTestField = null; }
            else
            {
                var entityToUpdate = entity.TranslatedTextTestField is null ? new TranslatedTextDto() : entity.TranslatedTextTestField.ToDto();
                TranslatedTextDto.UpdateFromDictionary(entityToUpdate, TranslatedTextTestFieldUpdateValue);
                exceptionCollector.Collect("TranslatedTextTestField",() =>entity.TranslatedTextTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateTranslatedTextTestField(entityToUpdate));
            }
        }

        if (updatedProperties.TryGetValue("UriTestField", out var UriTestFieldUpdateValue))
        {
            if (UriTestFieldUpdateValue == null) { entity.UriTestField = null; }
            else
            {
                exceptionCollector.Collect("UriTestField",() =>entity.UriTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateUriTestField(UriTestFieldUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("VolumeTestField", out var VolumeTestFieldUpdateValue))
        {
            if (VolumeTestFieldUpdateValue == null) { entity.VolumeTestField = null; }
            else
            {
                exceptionCollector.Collect("VolumeTestField",() =>entity.VolumeTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateVolumeTestField(VolumeTestFieldUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("WeightTestField", out var WeightTestFieldUpdateValue))
        {
            if (WeightTestFieldUpdateValue == null) { entity.WeightTestField = null; }
            else
            {
                exceptionCollector.Collect("WeightTestField",() =>entity.WeightTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateWeightTestField(WeightTestFieldUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("YearTestField", out var YearTestFieldUpdateValue))
        {
            if (YearTestFieldUpdateValue == null) { entity.YearTestField = null; }
            else
            {
                exceptionCollector.Collect("YearTestField",() =>entity.YearTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateYearTestField(YearTestFieldUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("CultureCodeTestField", out var CultureCodeTestFieldUpdateValue))
        {
            if (CultureCodeTestFieldUpdateValue == null) { entity.CultureCodeTestField = null; }
            else
            {
                exceptionCollector.Collect("CultureCodeTestField",() =>entity.CultureCodeTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateCultureCodeTestField(CultureCodeTestFieldUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("LanguageCodeTestField", out var LanguageCodeTestFieldUpdateValue))
        {
            if (LanguageCodeTestFieldUpdateValue == null) { entity.LanguageCodeTestField = null; }
            else
            {
                exceptionCollector.Collect("LanguageCodeTestField",() =>entity.LanguageCodeTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateLanguageCodeTestField(LanguageCodeTestFieldUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("YamlTestField", out var YamlTestFieldUpdateValue))
        {
            if (YamlTestFieldUpdateValue == null) { entity.YamlTestField = null; }
            else
            {
                exceptionCollector.Collect("YamlTestField",() =>entity.YamlTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateYamlTestField(YamlTestFieldUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("DateTimeDurationTestField", out var DateTimeDurationTestFieldUpdateValue))
        {
            if (DateTimeDurationTestFieldUpdateValue == null) { entity.DateTimeDurationTestField = null; }
            else
            {
                exceptionCollector.Collect("DateTimeDurationTestField",() =>entity.DateTimeDurationTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateDateTimeDurationTestField(DateTimeDurationTestFieldUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("TimeTestField", out var TimeTestFieldUpdateValue))
        {
            if (TimeTestFieldUpdateValue == null) { entity.TimeTestField = null; }
            else
            {
                exceptionCollector.Collect("TimeTestField",() =>entity.TimeTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateTimeTestField(TimeTestFieldUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("VatNumberTestField", out var VatNumberTestFieldUpdateValue))
        {
            if (VatNumberTestFieldUpdateValue == null) { entity.VatNumberTestField = null; }
            else
            {
                var entityToUpdate = entity.VatNumberTestField is null ? new VatNumberDto() : entity.VatNumberTestField.ToDto();
                VatNumberDto.UpdateFromDictionary(entityToUpdate, VatNumberTestFieldUpdateValue);
                exceptionCollector.Collect("VatNumberTestField",() =>entity.VatNumberTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateVatNumberTestField(entityToUpdate));
            }
        }

        if (updatedProperties.TryGetValue("DateTestField", out var DateTestFieldUpdateValue))
        {
            if (DateTestFieldUpdateValue == null) { entity.DateTestField = null; }
            else
            {
                exceptionCollector.Collect("DateTestField",() =>entity.DateTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateDateTestField(DateTestFieldUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("MarkdownTestField", out var MarkdownTestFieldUpdateValue))
        {
            if (MarkdownTestFieldUpdateValue == null) { entity.MarkdownTestField = null; }
            else
            {
                exceptionCollector.Collect("MarkdownTestField",() =>entity.MarkdownTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateMarkdownTestField(MarkdownTestFieldUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("FileTestField", out var FileTestFieldUpdateValue))
        {
            if (FileTestFieldUpdateValue == null) { entity.FileTestField = null; }
            else
            {
                var entityToUpdate = entity.FileTestField is null ? new FileDto() : entity.FileTestField.ToDto();
                FileDto.UpdateFromDictionary(entityToUpdate, FileTestFieldUpdateValue);
                exceptionCollector.Collect("FileTestField",() =>entity.FileTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateFileTestField(entityToUpdate));
            }
        }

        if (updatedProperties.TryGetValue("ColorTestField", out var ColorTestFieldUpdateValue))
        {
            if (ColorTestFieldUpdateValue == null) { entity.ColorTestField = null; }
            else
            {
                exceptionCollector.Collect("ColorTestField",() =>entity.ColorTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateColorTestField(ColorTestFieldUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("UrlTestField", out var UrlTestFieldUpdateValue))
        {
            if (UrlTestFieldUpdateValue == null) { entity.UrlTestField = null; }
            else
            {
                exceptionCollector.Collect("UrlTestField",() =>entity.UrlTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateUrlTestField(UrlTestFieldUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("DateTimeScheduleTestField", out var DateTimeScheduleTestFieldUpdateValue))
        {
            if (DateTimeScheduleTestFieldUpdateValue == null) { entity.DateTimeScheduleTestField = null; }
            else
            {
                exceptionCollector.Collect("DateTimeScheduleTestField",() =>entity.DateTimeScheduleTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateDateTimeScheduleTestField(DateTimeScheduleTestFieldUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("UserTestField", out var UserTestFieldUpdateValue))
        {
            if (UserTestFieldUpdateValue == null) { entity.UserTestField = null; }
            else
            {
                exceptionCollector.Collect("UserTestField",() =>entity.UserTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateUserTestField(UserTestFieldUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("HtmlTestField", out var HtmlTestFieldUpdateValue))
        {
            if (HtmlTestFieldUpdateValue == null) { entity.HtmlTestField = null; }
            else
            {
                exceptionCollector.Collect("HtmlTestField",() =>entity.HtmlTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateHtmlTestField(HtmlTestFieldUpdateValue));
            }
        }

        if (updatedProperties.TryGetValue("ImageTestField", out var ImageTestFieldUpdateValue))
        {
            if (ImageTestFieldUpdateValue == null) { entity.ImageTestField = null; }
            else
            {
                var entityToUpdate = entity.ImageTestField is null ? new ImageDto() : entity.ImageTestField.ToDto();
                ImageDto.UpdateFromDictionary(entityToUpdate, ImageTestFieldUpdateValue);
                exceptionCollector.Collect("ImageTestField",() =>entity.ImageTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateImageTestField(entityToUpdate));
            }
        }
        CreateUpdateEntityInvalidDataException.ThrowIfAnyNoxTypeValidationException(exceptionCollector.ValidationErrors);
    }
}