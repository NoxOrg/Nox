// Generated

#nullable enable

using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

using MediatR;

using Nox.Abstractions;
using Nox.Solution;
using Nox.Domain;
using Nox.Factories;
using Nox.Types;
using Nox.Application;
using Nox.Extensions;
using Nox.Exceptions;

using TestWebApp.Application.Dto;
using TestWebApp.Domain;
using TestEntityForTypesEntity = TestWebApp.Domain.TestEntityForTypes;

namespace TestWebApp.Application.Factories;

internal abstract class TestEntityForTypesFactoryBase : IEntityFactory<TestEntityForTypesEntity, TestEntityForTypesCreateDto, TestEntityForTypesUpdateDto>
{

    public TestEntityForTypesFactoryBase
    (
        )
    {
    }

    public virtual TestEntityForTypesEntity CreateEntity(TestEntityForTypesCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(TestEntityForTypesEntity entity, TestEntityForTypesUpdateDto updateDto)
    {
        UpdateEntityInternal(entity, updateDto);
    }

    public virtual void PartialUpdateEntity(TestEntityForTypesEntity entity, Dictionary<string, dynamic> updatedProperties)
    {
        PartialUpdateEntityInternal(entity, updatedProperties);
    }

    private TestWebApp.Domain.TestEntityForTypes ToEntity(TestEntityForTypesCreateDto createDto)
    {
        var entity = new TestWebApp.Domain.TestEntityForTypes();
        entity.Id = TestEntityForTypesMetadata.CreateId(createDto.Id);
        entity.TextTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateTextTestField(createDto.TextTestField);
        entity.NumberTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateNumberTestField(createDto.NumberTestField);
        if (createDto.MoneyTestField is not null)entity.MoneyTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateMoneyTestField(createDto.MoneyTestField.NonNullValue<MoneyDto>());
        if (createDto.CountryCode2TestField is not null)entity.CountryCode2TestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateCountryCode2TestField(createDto.CountryCode2TestField.NonNullValue<System.String>());
        if (createDto.StreetAddressTestField is not null)entity.StreetAddressTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateStreetAddressTestField(createDto.StreetAddressTestField.NonNullValue<StreetAddressDto>());
        if (createDto.CurrencyCode3TestField is not null)entity.CurrencyCode3TestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateCurrencyCode3TestField(createDto.CurrencyCode3TestField.NonNullValue<System.String>());
        if (createDto.DayOfWeekTestField is not null)entity.DayOfWeekTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateDayOfWeekTestField(createDto.DayOfWeekTestField.NonNullValue<System.UInt16>());
        if (createDto.JwtTokenTestField is not null)entity.JwtTokenTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateJwtTokenTestField(createDto.JwtTokenTestField.NonNullValue<System.String>());
        if (createDto.GeoCoordTestField is not null)entity.GeoCoordTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateGeoCoordTestField(createDto.GeoCoordTestField.NonNullValue<LatLongDto>());
        if (createDto.AreaTestField is not null)entity.AreaTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateAreaTestField(createDto.AreaTestField.NonNullValue<System.Decimal>());
        if (createDto.TimeZoneCodeTestField is not null)entity.TimeZoneCodeTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateTimeZoneCodeTestField(createDto.TimeZoneCodeTestField.NonNullValue<System.String>());
        if (createDto.BooleanTestField is not null)entity.BooleanTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateBooleanTestField(createDto.BooleanTestField.NonNullValue<System.Boolean>());
        if (createDto.CountryCode3TestField is not null)entity.CountryCode3TestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateCountryCode3TestField(createDto.CountryCode3TestField.NonNullValue<System.String>());
        if (createDto.CountryNumberTestField is not null)entity.CountryNumberTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateCountryNumberTestField(createDto.CountryNumberTestField.NonNullValue<System.UInt16>());
        if (createDto.CurrencyNumberTestField is not null)entity.CurrencyNumberTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateCurrencyNumberTestField(createDto.CurrencyNumberTestField.NonNullValue<System.Int16>());
        if (createDto.DateTimeTestField is not null)entity.DateTimeTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateDateTimeTestField(createDto.DateTimeTestField.NonNullValue<System.DateTimeOffset>());
        if (createDto.DateTimeRangeTestField is not null)entity.DateTimeRangeTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateDateTimeRangeTestField(createDto.DateTimeRangeTestField.NonNullValue<DateTimeRangeDto>());
        if (createDto.DistanceTestField is not null)entity.DistanceTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateDistanceTestField(createDto.DistanceTestField.NonNullValue<System.Decimal>());
        if (createDto.EmailTestField is not null)entity.EmailTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateEmailTestField(createDto.EmailTestField.NonNullValue<System.String>());
        if (createDto.GuidTestField is not null)entity.GuidTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateGuidTestField(createDto.GuidTestField.NonNullValue<System.Guid>());
        if (createDto.InternetDomainTestField is not null)entity.InternetDomainTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateInternetDomainTestField(createDto.InternetDomainTestField.NonNullValue<System.String>());
        if (createDto.IpAddressV4TestField is not null)entity.IpAddressV4TestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateIpAddressV4TestField(createDto.IpAddressV4TestField.NonNullValue<System.String>());
        if (createDto.IpAddressV6TestField is not null)entity.IpAddressV6TestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateIpAddressV6TestField(createDto.IpAddressV6TestField.NonNullValue<System.String>());
        if (createDto.JsonTestField is not null)entity.JsonTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateJsonTestField(createDto.JsonTestField.NonNullValue<System.String>());
        if (createDto.LengthTestField is not null)entity.LengthTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateLengthTestField(createDto.LengthTestField.NonNullValue<System.Decimal>());
        if (createDto.MacAddressTestField is not null)entity.MacAddressTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateMacAddressTestField(createDto.MacAddressTestField.NonNullValue<System.String>());
        if (createDto.MonthTestField is not null)entity.MonthTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateMonthTestField(createDto.MonthTestField.NonNullValue<System.Byte>());
        if (createDto.PercentageTestField is not null)entity.PercentageTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreatePercentageTestField(createDto.PercentageTestField.NonNullValue<System.Single>());
        if (createDto.PhoneNumberTestField is not null)entity.PhoneNumberTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreatePhoneNumberTestField(createDto.PhoneNumberTestField.NonNullValue<System.String>());
        if (createDto.TemperatureTestField is not null)entity.TemperatureTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateTemperatureTestField(createDto.TemperatureTestField.NonNullValue<System.Decimal>());
        if (createDto.TranslatedTextTestField is not null)entity.TranslatedTextTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateTranslatedTextTestField(createDto.TranslatedTextTestField.NonNullValue<TranslatedTextDto>());
        if (createDto.UriTestField is not null)entity.UriTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateUriTestField(createDto.UriTestField.NonNullValue<System.String>());
        if (createDto.VolumeTestField is not null)entity.VolumeTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateVolumeTestField(createDto.VolumeTestField.NonNullValue<System.Decimal>());
        if (createDto.WeightTestField is not null)entity.WeightTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateWeightTestField(createDto.WeightTestField.NonNullValue<System.Decimal>());
        if (createDto.YearTestField is not null)entity.YearTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateYearTestField(createDto.YearTestField.NonNullValue<System.UInt16>());
        if (createDto.CultureCodeTestField is not null)entity.CultureCodeTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateCultureCodeTestField(createDto.CultureCodeTestField.NonNullValue<System.String>());
        if (createDto.LanguageCodeTestField is not null)entity.LanguageCodeTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateLanguageCodeTestField(createDto.LanguageCodeTestField.NonNullValue<System.String>());
        if (createDto.YamlTestField is not null)entity.YamlTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateYamlTestField(createDto.YamlTestField.NonNullValue<System.String>());
        if (createDto.DateTimeDurationTestField is not null)entity.DateTimeDurationTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateDateTimeDurationTestField(createDto.DateTimeDurationTestField.NonNullValue<System.Int64>());
        if (createDto.TimeTestField is not null)entity.TimeTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateTimeTestField(createDto.TimeTestField.NonNullValue<System.DateTime>());
        if (createDto.VatNumberTestField is not null)entity.VatNumberTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateVatNumberTestField(createDto.VatNumberTestField.NonNullValue<VatNumberDto>());
        if (createDto.DateTestField is not null)entity.DateTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateDateTestField(createDto.DateTestField.NonNullValue<System.DateTime>());
        if (createDto.MarkdownTestField is not null)entity.MarkdownTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateMarkdownTestField(createDto.MarkdownTestField.NonNullValue<System.String>());
        if (createDto.FileTestField is not null)entity.FileTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateFileTestField(createDto.FileTestField.NonNullValue<FileDto>());
        if (createDto.ColorTestField is not null)entity.ColorTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateColorTestField(createDto.ColorTestField.NonNullValue<System.String>());
        if (createDto.UrlTestField is not null)entity.UrlTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateUrlTestField(createDto.UrlTestField.NonNullValue<System.String>());
        if (createDto.DateTimeScheduleTestField is not null)entity.DateTimeScheduleTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateDateTimeScheduleTestField(createDto.DateTimeScheduleTestField.NonNullValue<System.String>());
        if (createDto.UserTestField is not null)entity.UserTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateUserTestField(createDto.UserTestField.NonNullValue<System.String>());
        entity.AutoNumberTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateAutoNumberTestField(createDto.AutoNumberTestField);
        if (createDto.HtmlTestField is not null)entity.HtmlTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateHtmlTestField(createDto.HtmlTestField.NonNullValue<System.String>());
        if (createDto.ImageTestField is not null)entity.ImageTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateImageTestField(createDto.ImageTestField.NonNullValue<ImageDto>());
        return entity;
    }

    private void UpdateEntityInternal(TestEntityForTypesEntity entity, TestEntityForTypesUpdateDto updateDto)
    {
        entity.TextTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateTextTestField(updateDto.TextTestField.NonNullValue<System.String>());
        entity.NumberTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateNumberTestField(updateDto.NumberTestField.NonNullValue<System.Int16>());
        if (updateDto.MoneyTestField == null) { entity.MoneyTestField = null; } else {
            entity.MoneyTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateMoneyTestField(updateDto.MoneyTestField.ToValueFromNonNull<MoneyDto>());
        }
        if (updateDto.CountryCode2TestField == null) { entity.CountryCode2TestField = null; } else {
            entity.CountryCode2TestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateCountryCode2TestField(updateDto.CountryCode2TestField.ToValueFromNonNull<System.String>());
        }
        if (updateDto.StreetAddressTestField == null) { entity.StreetAddressTestField = null; } else {
            entity.StreetAddressTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateStreetAddressTestField(updateDto.StreetAddressTestField.ToValueFromNonNull<StreetAddressDto>());
        }
        if (updateDto.CurrencyCode3TestField == null) { entity.CurrencyCode3TestField = null; } else {
            entity.CurrencyCode3TestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateCurrencyCode3TestField(updateDto.CurrencyCode3TestField.ToValueFromNonNull<System.String>());
        }
        if (updateDto.DayOfWeekTestField == null) { entity.DayOfWeekTestField = null; } else {
            entity.DayOfWeekTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateDayOfWeekTestField(updateDto.DayOfWeekTestField.ToValueFromNonNull<System.UInt16>());
        }
        if (updateDto.JwtTokenTestField == null) { entity.JwtTokenTestField = null; } else {
            entity.JwtTokenTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateJwtTokenTestField(updateDto.JwtTokenTestField.ToValueFromNonNull<System.String>());
        }
        if (updateDto.GeoCoordTestField == null) { entity.GeoCoordTestField = null; } else {
            entity.GeoCoordTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateGeoCoordTestField(updateDto.GeoCoordTestField.ToValueFromNonNull<LatLongDto>());
        }
        if (updateDto.AreaTestField == null) { entity.AreaTestField = null; } else {
            entity.AreaTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateAreaTestField(updateDto.AreaTestField.ToValueFromNonNull<System.Decimal>());
        }
        if (updateDto.TimeZoneCodeTestField == null) { entity.TimeZoneCodeTestField = null; } else {
            entity.TimeZoneCodeTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateTimeZoneCodeTestField(updateDto.TimeZoneCodeTestField.ToValueFromNonNull<System.String>());
        }
        if (updateDto.BooleanTestField == null) { entity.BooleanTestField = null; } else {
            entity.BooleanTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateBooleanTestField(updateDto.BooleanTestField.ToValueFromNonNull<System.Boolean>());
        }
        if (updateDto.CountryCode3TestField == null) { entity.CountryCode3TestField = null; } else {
            entity.CountryCode3TestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateCountryCode3TestField(updateDto.CountryCode3TestField.ToValueFromNonNull<System.String>());
        }
        if (updateDto.CountryNumberTestField == null) { entity.CountryNumberTestField = null; } else {
            entity.CountryNumberTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateCountryNumberTestField(updateDto.CountryNumberTestField.ToValueFromNonNull<System.UInt16>());
        }
        if (updateDto.CurrencyNumberTestField == null) { entity.CurrencyNumberTestField = null; } else {
            entity.CurrencyNumberTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateCurrencyNumberTestField(updateDto.CurrencyNumberTestField.ToValueFromNonNull<System.Int16>());
        }
        if (updateDto.DateTimeTestField == null) { entity.DateTimeTestField = null; } else {
            entity.DateTimeTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateDateTimeTestField(updateDto.DateTimeTestField.ToValueFromNonNull<System.DateTimeOffset>());
        }
        if (updateDto.DateTimeRangeTestField == null) { entity.DateTimeRangeTestField = null; } else {
            entity.DateTimeRangeTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateDateTimeRangeTestField(updateDto.DateTimeRangeTestField.ToValueFromNonNull<DateTimeRangeDto>());
        }
        if (updateDto.DistanceTestField == null) { entity.DistanceTestField = null; } else {
            entity.DistanceTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateDistanceTestField(updateDto.DistanceTestField.ToValueFromNonNull<System.Decimal>());
        }
        if (updateDto.EmailTestField == null) { entity.EmailTestField = null; } else {
            entity.EmailTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateEmailTestField(updateDto.EmailTestField.ToValueFromNonNull<System.String>());
        }
        if (updateDto.GuidTestField == null) { entity.GuidTestField = null; } else {
            entity.GuidTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateGuidTestField(updateDto.GuidTestField.ToValueFromNonNull<System.Guid>());
        }
        if (updateDto.InternetDomainTestField == null) { entity.InternetDomainTestField = null; } else {
            entity.InternetDomainTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateInternetDomainTestField(updateDto.InternetDomainTestField.ToValueFromNonNull<System.String>());
        }
        if (updateDto.IpAddressV4TestField == null) { entity.IpAddressV4TestField = null; } else {
            entity.IpAddressV4TestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateIpAddressV4TestField(updateDto.IpAddressV4TestField.ToValueFromNonNull<System.String>());
        }
        if (updateDto.IpAddressV6TestField == null) { entity.IpAddressV6TestField = null; } else {
            entity.IpAddressV6TestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateIpAddressV6TestField(updateDto.IpAddressV6TestField.ToValueFromNonNull<System.String>());
        }
        if (updateDto.JsonTestField == null) { entity.JsonTestField = null; } else {
            entity.JsonTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateJsonTestField(updateDto.JsonTestField.ToValueFromNonNull<System.String>());
        }
        if (updateDto.LengthTestField == null) { entity.LengthTestField = null; } else {
            entity.LengthTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateLengthTestField(updateDto.LengthTestField.ToValueFromNonNull<System.Decimal>());
        }
        if (updateDto.MacAddressTestField == null) { entity.MacAddressTestField = null; } else {
            entity.MacAddressTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateMacAddressTestField(updateDto.MacAddressTestField.ToValueFromNonNull<System.String>());
        }
        if (updateDto.MonthTestField == null) { entity.MonthTestField = null; } else {
            entity.MonthTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateMonthTestField(updateDto.MonthTestField.ToValueFromNonNull<System.Byte>());
        }
        if (updateDto.PercentageTestField == null) { entity.PercentageTestField = null; } else {
            entity.PercentageTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreatePercentageTestField(updateDto.PercentageTestField.ToValueFromNonNull<System.Single>());
        }
        if (updateDto.PhoneNumberTestField == null) { entity.PhoneNumberTestField = null; } else {
            entity.PhoneNumberTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreatePhoneNumberTestField(updateDto.PhoneNumberTestField.ToValueFromNonNull<System.String>());
        }
        if (updateDto.TemperatureTestField == null) { entity.TemperatureTestField = null; } else {
            entity.TemperatureTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateTemperatureTestField(updateDto.TemperatureTestField.ToValueFromNonNull<System.Decimal>());
        }
        if (updateDto.TranslatedTextTestField == null) { entity.TranslatedTextTestField = null; } else {
            entity.TranslatedTextTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateTranslatedTextTestField(updateDto.TranslatedTextTestField.ToValueFromNonNull<TranslatedTextDto>());
        }
        if (updateDto.UriTestField == null) { entity.UriTestField = null; } else {
            entity.UriTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateUriTestField(updateDto.UriTestField.ToValueFromNonNull<System.String>());
        }
        if (updateDto.VolumeTestField == null) { entity.VolumeTestField = null; } else {
            entity.VolumeTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateVolumeTestField(updateDto.VolumeTestField.ToValueFromNonNull<System.Decimal>());
        }
        if (updateDto.WeightTestField == null) { entity.WeightTestField = null; } else {
            entity.WeightTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateWeightTestField(updateDto.WeightTestField.ToValueFromNonNull<System.Decimal>());
        }
        if (updateDto.YearTestField == null) { entity.YearTestField = null; } else {
            entity.YearTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateYearTestField(updateDto.YearTestField.ToValueFromNonNull<System.UInt16>());
        }
        if (updateDto.CultureCodeTestField == null) { entity.CultureCodeTestField = null; } else {
            entity.CultureCodeTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateCultureCodeTestField(updateDto.CultureCodeTestField.ToValueFromNonNull<System.String>());
        }
        if (updateDto.LanguageCodeTestField == null) { entity.LanguageCodeTestField = null; } else {
            entity.LanguageCodeTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateLanguageCodeTestField(updateDto.LanguageCodeTestField.ToValueFromNonNull<System.String>());
        }
        if (updateDto.YamlTestField == null) { entity.YamlTestField = null; } else {
            entity.YamlTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateYamlTestField(updateDto.YamlTestField.ToValueFromNonNull<System.String>());
        }
        if (updateDto.DateTimeDurationTestField == null) { entity.DateTimeDurationTestField = null; } else {
            entity.DateTimeDurationTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateDateTimeDurationTestField(updateDto.DateTimeDurationTestField.ToValueFromNonNull<System.Int64>());
        }
        if (updateDto.TimeTestField == null) { entity.TimeTestField = null; } else {
            entity.TimeTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateTimeTestField(updateDto.TimeTestField.ToValueFromNonNull<System.DateTime>());
        }
        if (updateDto.VatNumberTestField == null) { entity.VatNumberTestField = null; } else {
            entity.VatNumberTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateVatNumberTestField(updateDto.VatNumberTestField.ToValueFromNonNull<VatNumberDto>());
        }
        if (updateDto.DateTestField == null) { entity.DateTestField = null; } else {
            entity.DateTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateDateTestField(updateDto.DateTestField.ToValueFromNonNull<System.DateTime>());
        }
        if (updateDto.MarkdownTestField == null) { entity.MarkdownTestField = null; } else {
            entity.MarkdownTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateMarkdownTestField(updateDto.MarkdownTestField.ToValueFromNonNull<System.String>());
        }
        if (updateDto.FileTestField == null) { entity.FileTestField = null; } else {
            entity.FileTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateFileTestField(updateDto.FileTestField.ToValueFromNonNull<FileDto>());
        }
        if (updateDto.ColorTestField == null) { entity.ColorTestField = null; } else {
            entity.ColorTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateColorTestField(updateDto.ColorTestField.ToValueFromNonNull<System.String>());
        }
        if (updateDto.UrlTestField == null) { entity.UrlTestField = null; } else {
            entity.UrlTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateUrlTestField(updateDto.UrlTestField.ToValueFromNonNull<System.String>());
        }
        if (updateDto.DateTimeScheduleTestField == null) { entity.DateTimeScheduleTestField = null; } else {
            entity.DateTimeScheduleTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateDateTimeScheduleTestField(updateDto.DateTimeScheduleTestField.ToValueFromNonNull<System.String>());
        }
        if (updateDto.UserTestField == null) { entity.UserTestField = null; } else {
            entity.UserTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateUserTestField(updateDto.UserTestField.ToValueFromNonNull<System.String>());
        }
        entity.AutoNumberTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateAutoNumberTestField(updateDto.AutoNumberTestField.NonNullValue<System.Int64>());
        if (updateDto.HtmlTestField == null) { entity.HtmlTestField = null; } else {
            entity.HtmlTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateHtmlTestField(updateDto.HtmlTestField.ToValueFromNonNull<System.String>());
        }
        if (updateDto.ImageTestField == null) { entity.ImageTestField = null; } else {
            entity.ImageTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateImageTestField(updateDto.ImageTestField.ToValueFromNonNull<ImageDto>());
        }
    }

    private void PartialUpdateEntityInternal(TestEntityForTypesEntity entity, Dictionary<string, dynamic> updatedProperties)
    {

        if (updatedProperties.TryGetValue("TextTestField", out var TextTestFieldUpdateValue))
        {
            if (TextTestFieldUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'TextTestField' can't be null");
            }
            {
                entity.TextTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateTextTestField(TextTestFieldUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("NumberTestField", out var NumberTestFieldUpdateValue))
        {
            if (NumberTestFieldUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'NumberTestField' can't be null");
            }
            {
                entity.NumberTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateNumberTestField(NumberTestFieldUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("MoneyTestField", out var MoneyTestFieldUpdateValue))
        {
            if (MoneyTestFieldUpdateValue == null) { entity.MoneyTestField = null; }
            else
            {
                entity.MoneyTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateMoneyTestField(MoneyTestFieldUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("CountryCode2TestField", out var CountryCode2TestFieldUpdateValue))
        {
            if (CountryCode2TestFieldUpdateValue == null) { entity.CountryCode2TestField = null; }
            else
            {
                entity.CountryCode2TestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateCountryCode2TestField(CountryCode2TestFieldUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("StreetAddressTestField", out var StreetAddressTestFieldUpdateValue))
        {
            if (StreetAddressTestFieldUpdateValue == null) { entity.StreetAddressTestField = null; }
            else
            {
                entity.StreetAddressTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateStreetAddressTestField(StreetAddressTestFieldUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("CurrencyCode3TestField", out var CurrencyCode3TestFieldUpdateValue))
        {
            if (CurrencyCode3TestFieldUpdateValue == null) { entity.CurrencyCode3TestField = null; }
            else
            {
                entity.CurrencyCode3TestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateCurrencyCode3TestField(CurrencyCode3TestFieldUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("DayOfWeekTestField", out var DayOfWeekTestFieldUpdateValue))
        {
            if (DayOfWeekTestFieldUpdateValue == null) { entity.DayOfWeekTestField = null; }
            else
            {
                entity.DayOfWeekTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateDayOfWeekTestField(DayOfWeekTestFieldUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("JwtTokenTestField", out var JwtTokenTestFieldUpdateValue))
        {
            if (JwtTokenTestFieldUpdateValue == null) { entity.JwtTokenTestField = null; }
            else
            {
                entity.JwtTokenTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateJwtTokenTestField(JwtTokenTestFieldUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("GeoCoordTestField", out var GeoCoordTestFieldUpdateValue))
        {
            if (GeoCoordTestFieldUpdateValue == null) { entity.GeoCoordTestField = null; }
            else
            {
                entity.GeoCoordTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateGeoCoordTestField(GeoCoordTestFieldUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("AreaTestField", out var AreaTestFieldUpdateValue))
        {
            if (AreaTestFieldUpdateValue == null) { entity.AreaTestField = null; }
            else
            {
                entity.AreaTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateAreaTestField(AreaTestFieldUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("TimeZoneCodeTestField", out var TimeZoneCodeTestFieldUpdateValue))
        {
            if (TimeZoneCodeTestFieldUpdateValue == null) { entity.TimeZoneCodeTestField = null; }
            else
            {
                entity.TimeZoneCodeTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateTimeZoneCodeTestField(TimeZoneCodeTestFieldUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("BooleanTestField", out var BooleanTestFieldUpdateValue))
        {
            if (BooleanTestFieldUpdateValue == null) { entity.BooleanTestField = null; }
            else
            {
                entity.BooleanTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateBooleanTestField(BooleanTestFieldUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("CountryCode3TestField", out var CountryCode3TestFieldUpdateValue))
        {
            if (CountryCode3TestFieldUpdateValue == null) { entity.CountryCode3TestField = null; }
            else
            {
                entity.CountryCode3TestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateCountryCode3TestField(CountryCode3TestFieldUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("CountryNumberTestField", out var CountryNumberTestFieldUpdateValue))
        {
            if (CountryNumberTestFieldUpdateValue == null) { entity.CountryNumberTestField = null; }
            else
            {
                entity.CountryNumberTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateCountryNumberTestField(CountryNumberTestFieldUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("CurrencyNumberTestField", out var CurrencyNumberTestFieldUpdateValue))
        {
            if (CurrencyNumberTestFieldUpdateValue == null) { entity.CurrencyNumberTestField = null; }
            else
            {
                entity.CurrencyNumberTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateCurrencyNumberTestField(CurrencyNumberTestFieldUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("DateTimeTestField", out var DateTimeTestFieldUpdateValue))
        {
            if (DateTimeTestFieldUpdateValue == null) { entity.DateTimeTestField = null; }
            else
            {
                entity.DateTimeTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateDateTimeTestField(DateTimeTestFieldUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("DateTimeRangeTestField", out var DateTimeRangeTestFieldUpdateValue))
        {
            if (DateTimeRangeTestFieldUpdateValue == null) { entity.DateTimeRangeTestField = null; }
            else
            {
                entity.DateTimeRangeTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateDateTimeRangeTestField(DateTimeRangeTestFieldUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("DistanceTestField", out var DistanceTestFieldUpdateValue))
        {
            if (DistanceTestFieldUpdateValue == null) { entity.DistanceTestField = null; }
            else
            {
                entity.DistanceTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateDistanceTestField(DistanceTestFieldUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("EmailTestField", out var EmailTestFieldUpdateValue))
        {
            if (EmailTestFieldUpdateValue == null) { entity.EmailTestField = null; }
            else
            {
                entity.EmailTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateEmailTestField(EmailTestFieldUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("GuidTestField", out var GuidTestFieldUpdateValue))
        {
            if (GuidTestFieldUpdateValue == null) { entity.GuidTestField = null; }
            else
            {
                entity.GuidTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateGuidTestField(GuidTestFieldUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("InternetDomainTestField", out var InternetDomainTestFieldUpdateValue))
        {
            if (InternetDomainTestFieldUpdateValue == null) { entity.InternetDomainTestField = null; }
            else
            {
                entity.InternetDomainTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateInternetDomainTestField(InternetDomainTestFieldUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("IpAddressV4TestField", out var IpAddressV4TestFieldUpdateValue))
        {
            if (IpAddressV4TestFieldUpdateValue == null) { entity.IpAddressV4TestField = null; }
            else
            {
                entity.IpAddressV4TestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateIpAddressV4TestField(IpAddressV4TestFieldUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("IpAddressV6TestField", out var IpAddressV6TestFieldUpdateValue))
        {
            if (IpAddressV6TestFieldUpdateValue == null) { entity.IpAddressV6TestField = null; }
            else
            {
                entity.IpAddressV6TestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateIpAddressV6TestField(IpAddressV6TestFieldUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("JsonTestField", out var JsonTestFieldUpdateValue))
        {
            if (JsonTestFieldUpdateValue == null) { entity.JsonTestField = null; }
            else
            {
                entity.JsonTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateJsonTestField(JsonTestFieldUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("LengthTestField", out var LengthTestFieldUpdateValue))
        {
            if (LengthTestFieldUpdateValue == null) { entity.LengthTestField = null; }
            else
            {
                entity.LengthTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateLengthTestField(LengthTestFieldUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("MacAddressTestField", out var MacAddressTestFieldUpdateValue))
        {
            if (MacAddressTestFieldUpdateValue == null) { entity.MacAddressTestField = null; }
            else
            {
                entity.MacAddressTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateMacAddressTestField(MacAddressTestFieldUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("MonthTestField", out var MonthTestFieldUpdateValue))
        {
            if (MonthTestFieldUpdateValue == null) { entity.MonthTestField = null; }
            else
            {
                entity.MonthTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateMonthTestField(MonthTestFieldUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("PercentageTestField", out var PercentageTestFieldUpdateValue))
        {
            if (PercentageTestFieldUpdateValue == null) { entity.PercentageTestField = null; }
            else
            {
                entity.PercentageTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreatePercentageTestField(PercentageTestFieldUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("PhoneNumberTestField", out var PhoneNumberTestFieldUpdateValue))
        {
            if (PhoneNumberTestFieldUpdateValue == null) { entity.PhoneNumberTestField = null; }
            else
            {
                entity.PhoneNumberTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreatePhoneNumberTestField(PhoneNumberTestFieldUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("TemperatureTestField", out var TemperatureTestFieldUpdateValue))
        {
            if (TemperatureTestFieldUpdateValue == null) { entity.TemperatureTestField = null; }
            else
            {
                entity.TemperatureTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateTemperatureTestField(TemperatureTestFieldUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("TranslatedTextTestField", out var TranslatedTextTestFieldUpdateValue))
        {
            if (TranslatedTextTestFieldUpdateValue == null) { entity.TranslatedTextTestField = null; }
            else
            {
                entity.TranslatedTextTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateTranslatedTextTestField(TranslatedTextTestFieldUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("UriTestField", out var UriTestFieldUpdateValue))
        {
            if (UriTestFieldUpdateValue == null) { entity.UriTestField = null; }
            else
            {
                entity.UriTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateUriTestField(UriTestFieldUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("VolumeTestField", out var VolumeTestFieldUpdateValue))
        {
            if (VolumeTestFieldUpdateValue == null) { entity.VolumeTestField = null; }
            else
            {
                entity.VolumeTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateVolumeTestField(VolumeTestFieldUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("WeightTestField", out var WeightTestFieldUpdateValue))
        {
            if (WeightTestFieldUpdateValue == null) { entity.WeightTestField = null; }
            else
            {
                entity.WeightTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateWeightTestField(WeightTestFieldUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("YearTestField", out var YearTestFieldUpdateValue))
        {
            if (YearTestFieldUpdateValue == null) { entity.YearTestField = null; }
            else
            {
                entity.YearTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateYearTestField(YearTestFieldUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("CultureCodeTestField", out var CultureCodeTestFieldUpdateValue))
        {
            if (CultureCodeTestFieldUpdateValue == null) { entity.CultureCodeTestField = null; }
            else
            {
                entity.CultureCodeTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateCultureCodeTestField(CultureCodeTestFieldUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("LanguageCodeTestField", out var LanguageCodeTestFieldUpdateValue))
        {
            if (LanguageCodeTestFieldUpdateValue == null) { entity.LanguageCodeTestField = null; }
            else
            {
                entity.LanguageCodeTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateLanguageCodeTestField(LanguageCodeTestFieldUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("YamlTestField", out var YamlTestFieldUpdateValue))
        {
            if (YamlTestFieldUpdateValue == null) { entity.YamlTestField = null; }
            else
            {
                entity.YamlTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateYamlTestField(YamlTestFieldUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("DateTimeDurationTestField", out var DateTimeDurationTestFieldUpdateValue))
        {
            if (DateTimeDurationTestFieldUpdateValue == null) { entity.DateTimeDurationTestField = null; }
            else
            {
                entity.DateTimeDurationTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateDateTimeDurationTestField(DateTimeDurationTestFieldUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("TimeTestField", out var TimeTestFieldUpdateValue))
        {
            if (TimeTestFieldUpdateValue == null) { entity.TimeTestField = null; }
            else
            {
                entity.TimeTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateTimeTestField(TimeTestFieldUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("VatNumberTestField", out var VatNumberTestFieldUpdateValue))
        {
            if (VatNumberTestFieldUpdateValue == null) { entity.VatNumberTestField = null; }
            else
            {
                entity.VatNumberTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateVatNumberTestField(VatNumberTestFieldUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("DateTestField", out var DateTestFieldUpdateValue))
        {
            if (DateTestFieldUpdateValue == null) { entity.DateTestField = null; }
            else
            {
                entity.DateTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateDateTestField(DateTestFieldUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("MarkdownTestField", out var MarkdownTestFieldUpdateValue))
        {
            if (MarkdownTestFieldUpdateValue == null) { entity.MarkdownTestField = null; }
            else
            {
                entity.MarkdownTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateMarkdownTestField(MarkdownTestFieldUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("FileTestField", out var FileTestFieldUpdateValue))
        {
            if (FileTestFieldUpdateValue == null) { entity.FileTestField = null; }
            else
            {
                entity.FileTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateFileTestField(FileTestFieldUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("ColorTestField", out var ColorTestFieldUpdateValue))
        {
            if (ColorTestFieldUpdateValue == null) { entity.ColorTestField = null; }
            else
            {
                entity.ColorTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateColorTestField(ColorTestFieldUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("UrlTestField", out var UrlTestFieldUpdateValue))
        {
            if (UrlTestFieldUpdateValue == null) { entity.UrlTestField = null; }
            else
            {
                entity.UrlTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateUrlTestField(UrlTestFieldUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("DateTimeScheduleTestField", out var DateTimeScheduleTestFieldUpdateValue))
        {
            if (DateTimeScheduleTestFieldUpdateValue == null) { entity.DateTimeScheduleTestField = null; }
            else
            {
                entity.DateTimeScheduleTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateDateTimeScheduleTestField(DateTimeScheduleTestFieldUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("UserTestField", out var UserTestFieldUpdateValue))
        {
            if (UserTestFieldUpdateValue == null) { entity.UserTestField = null; }
            else
            {
                entity.UserTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateUserTestField(UserTestFieldUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("AutoNumberTestField", out var AutoNumberTestFieldUpdateValue))
        {
            if (AutoNumberTestFieldUpdateValue == null)
            {
                throw new ArgumentException("Attribute 'AutoNumberTestField' can't be null");
            }
            {
                entity.AutoNumberTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateAutoNumberTestField(AutoNumberTestFieldUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("HtmlTestField", out var HtmlTestFieldUpdateValue))
        {
            if (HtmlTestFieldUpdateValue == null) { entity.HtmlTestField = null; }
            else
            {
                entity.HtmlTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateHtmlTestField(HtmlTestFieldUpdateValue);
            }
        }

        if (updatedProperties.TryGetValue("ImageTestField", out var ImageTestFieldUpdateValue))
        {
            if (ImageTestFieldUpdateValue == null) { entity.ImageTestField = null; }
            else
            {
                entity.ImageTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateImageTestField(ImageTestFieldUpdateValue);
            }
        }
    }
}

internal partial class TestEntityForTypesFactory : TestEntityForTypesFactoryBase
{
}