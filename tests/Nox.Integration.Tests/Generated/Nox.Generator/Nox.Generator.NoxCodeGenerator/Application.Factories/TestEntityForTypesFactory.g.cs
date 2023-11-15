// Generated

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

internal abstract class TestEntityForTypesFactoryBase : IEntityFactory<TestEntityForTypesEntity, TestEntityForTypesCreateDto, TestEntityForTypesUpdateDto>
{
    private static readonly Nox.Types.CultureCode _defaultCultureCode = Nox.Types.CultureCode.From("en-US");

    public TestEntityForTypesFactoryBase
    (
        )
    {
    }

    public virtual TestEntityForTypesEntity CreateEntity(TestEntityForTypesCreateDto createDto)
    {
        return ToEntity(createDto);
    }

    public virtual void UpdateEntity(TestEntityForTypesEntity entity, TestEntityForTypesUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        UpdateEntityInternal(entity, updateDto, cultureCode);
    }

    public virtual void PartialUpdateEntity(TestEntityForTypesEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
    {
        PartialUpdateEntityInternal(entity, updatedProperties, cultureCode);
    }

    private TestWebApp.Domain.TestEntityForTypes ToEntity(TestEntityForTypesCreateDto createDto)
    {
        var entity = new TestWebApp.Domain.TestEntityForTypes();
        entity.Id = TestEntityForTypesMetadata.CreateId(createDto.Id);
        entity.TextTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateTextTestField(createDto.TextTestField);
        entity.SetIfNotNull(createDto.EnumerationTestField, (entity) => entity.EnumerationTestField =TestWebApp.Domain.TestEntityForTypesMetadata.CreateEnumerationTestField(createDto.EnumerationTestField.NonNullValue<System.Int32>()));
        entity.NumberTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateNumberTestField(createDto.NumberTestField);
        entity.SetIfNotNull(createDto.MoneyTestField, (entity) => entity.MoneyTestField =TestWebApp.Domain.TestEntityForTypesMetadata.CreateMoneyTestField(createDto.MoneyTestField.NonNullValue<MoneyDto>()));
        entity.SetIfNotNull(createDto.CountryCode2TestField, (entity) => entity.CountryCode2TestField =TestWebApp.Domain.TestEntityForTypesMetadata.CreateCountryCode2TestField(createDto.CountryCode2TestField.NonNullValue<System.String>()));
        entity.SetIfNotNull(createDto.StreetAddressTestField, (entity) => entity.StreetAddressTestField =TestWebApp.Domain.TestEntityForTypesMetadata.CreateStreetAddressTestField(createDto.StreetAddressTestField.NonNullValue<StreetAddressDto>()));
        entity.SetIfNotNull(createDto.CurrencyCode3TestField, (entity) => entity.CurrencyCode3TestField =TestWebApp.Domain.TestEntityForTypesMetadata.CreateCurrencyCode3TestField(createDto.CurrencyCode3TestField.NonNullValue<System.String>()));
        entity.SetIfNotNull(createDto.DayOfWeekTestField, (entity) => entity.DayOfWeekTestField =TestWebApp.Domain.TestEntityForTypesMetadata.CreateDayOfWeekTestField(createDto.DayOfWeekTestField.NonNullValue<System.UInt16>()));
        entity.SetIfNotNull(createDto.JwtTokenTestField, (entity) => entity.JwtTokenTestField =TestWebApp.Domain.TestEntityForTypesMetadata.CreateJwtTokenTestField(createDto.JwtTokenTestField.NonNullValue<System.String>()));
        entity.SetIfNotNull(createDto.GeoCoordTestField, (entity) => entity.GeoCoordTestField =TestWebApp.Domain.TestEntityForTypesMetadata.CreateGeoCoordTestField(createDto.GeoCoordTestField.NonNullValue<LatLongDto>()));
        entity.SetIfNotNull(createDto.AreaTestField, (entity) => entity.AreaTestField =TestWebApp.Domain.TestEntityForTypesMetadata.CreateAreaTestField(createDto.AreaTestField.NonNullValue<System.Decimal>()));
        entity.SetIfNotNull(createDto.TimeZoneCodeTestField, (entity) => entity.TimeZoneCodeTestField =TestWebApp.Domain.TestEntityForTypesMetadata.CreateTimeZoneCodeTestField(createDto.TimeZoneCodeTestField.NonNullValue<System.String>()));
        entity.SetIfNotNull(createDto.BooleanTestField, (entity) => entity.BooleanTestField =TestWebApp.Domain.TestEntityForTypesMetadata.CreateBooleanTestField(createDto.BooleanTestField.NonNullValue<System.Boolean>()));
        entity.SetIfNotNull(createDto.CountryCode3TestField, (entity) => entity.CountryCode3TestField =TestWebApp.Domain.TestEntityForTypesMetadata.CreateCountryCode3TestField(createDto.CountryCode3TestField.NonNullValue<System.String>()));
        entity.SetIfNotNull(createDto.CountryNumberTestField, (entity) => entity.CountryNumberTestField =TestWebApp.Domain.TestEntityForTypesMetadata.CreateCountryNumberTestField(createDto.CountryNumberTestField.NonNullValue<System.UInt16>()));
        entity.SetIfNotNull(createDto.CurrencyNumberTestField, (entity) => entity.CurrencyNumberTestField =TestWebApp.Domain.TestEntityForTypesMetadata.CreateCurrencyNumberTestField(createDto.CurrencyNumberTestField.NonNullValue<System.Int16>()));
        entity.SetIfNotNull(createDto.DateTimeTestField, (entity) => entity.DateTimeTestField =TestWebApp.Domain.TestEntityForTypesMetadata.CreateDateTimeTestField(createDto.DateTimeTestField.NonNullValue<System.DateTimeOffset>()));
        entity.SetIfNotNull(createDto.DateTimeRangeTestField, (entity) => entity.DateTimeRangeTestField =TestWebApp.Domain.TestEntityForTypesMetadata.CreateDateTimeRangeTestField(createDto.DateTimeRangeTestField.NonNullValue<DateTimeRangeDto>()));
        entity.SetIfNotNull(createDto.DistanceTestField, (entity) => entity.DistanceTestField =TestWebApp.Domain.TestEntityForTypesMetadata.CreateDistanceTestField(createDto.DistanceTestField.NonNullValue<System.Decimal>()));
        entity.SetIfNotNull(createDto.EmailTestField, (entity) => entity.EmailTestField =TestWebApp.Domain.TestEntityForTypesMetadata.CreateEmailTestField(createDto.EmailTestField.NonNullValue<System.String>()));
        entity.SetIfNotNull(createDto.GuidTestField, (entity) => entity.GuidTestField =TestWebApp.Domain.TestEntityForTypesMetadata.CreateGuidTestField(createDto.GuidTestField.NonNullValue<System.Guid>()));
        entity.SetIfNotNull(createDto.InternetDomainTestField, (entity) => entity.InternetDomainTestField =TestWebApp.Domain.TestEntityForTypesMetadata.CreateInternetDomainTestField(createDto.InternetDomainTestField.NonNullValue<System.String>()));
        entity.SetIfNotNull(createDto.IpAddressV4TestField, (entity) => entity.IpAddressV4TestField =TestWebApp.Domain.TestEntityForTypesMetadata.CreateIpAddressV4TestField(createDto.IpAddressV4TestField.NonNullValue<System.String>()));
        entity.SetIfNotNull(createDto.IpAddressV6TestField, (entity) => entity.IpAddressV6TestField =TestWebApp.Domain.TestEntityForTypesMetadata.CreateIpAddressV6TestField(createDto.IpAddressV6TestField.NonNullValue<System.String>()));
        entity.SetIfNotNull(createDto.JsonTestField, (entity) => entity.JsonTestField =TestWebApp.Domain.TestEntityForTypesMetadata.CreateJsonTestField(createDto.JsonTestField.NonNullValue<System.String>()));
        entity.SetIfNotNull(createDto.LengthTestField, (entity) => entity.LengthTestField =TestWebApp.Domain.TestEntityForTypesMetadata.CreateLengthTestField(createDto.LengthTestField.NonNullValue<System.Decimal>()));
        entity.SetIfNotNull(createDto.MacAddressTestField, (entity) => entity.MacAddressTestField =TestWebApp.Domain.TestEntityForTypesMetadata.CreateMacAddressTestField(createDto.MacAddressTestField.NonNullValue<System.String>()));
        entity.SetIfNotNull(createDto.MonthTestField, (entity) => entity.MonthTestField =TestWebApp.Domain.TestEntityForTypesMetadata.CreateMonthTestField(createDto.MonthTestField.NonNullValue<System.Byte>()));
        entity.SetIfNotNull(createDto.PercentageTestField, (entity) => entity.PercentageTestField =TestWebApp.Domain.TestEntityForTypesMetadata.CreatePercentageTestField(createDto.PercentageTestField.NonNullValue<System.Single>()));
        entity.SetIfNotNull(createDto.PhoneNumberTestField, (entity) => entity.PhoneNumberTestField =TestWebApp.Domain.TestEntityForTypesMetadata.CreatePhoneNumberTestField(createDto.PhoneNumberTestField.NonNullValue<System.String>()));
        entity.SetIfNotNull(createDto.TemperatureTestField, (entity) => entity.TemperatureTestField =TestWebApp.Domain.TestEntityForTypesMetadata.CreateTemperatureTestField(createDto.TemperatureTestField.NonNullValue<System.Decimal>()));
        entity.SetIfNotNull(createDto.TranslatedTextTestField, (entity) => entity.TranslatedTextTestField =TestWebApp.Domain.TestEntityForTypesMetadata.CreateTranslatedTextTestField(createDto.TranslatedTextTestField.NonNullValue<TranslatedTextDto>()));
        entity.SetIfNotNull(createDto.UriTestField, (entity) => entity.UriTestField =TestWebApp.Domain.TestEntityForTypesMetadata.CreateUriTestField(createDto.UriTestField.NonNullValue<System.String>()));
        entity.SetIfNotNull(createDto.VolumeTestField, (entity) => entity.VolumeTestField =TestWebApp.Domain.TestEntityForTypesMetadata.CreateVolumeTestField(createDto.VolumeTestField.NonNullValue<System.Decimal>()));
        entity.SetIfNotNull(createDto.WeightTestField, (entity) => entity.WeightTestField =TestWebApp.Domain.TestEntityForTypesMetadata.CreateWeightTestField(createDto.WeightTestField.NonNullValue<System.Decimal>()));
        entity.SetIfNotNull(createDto.YearTestField, (entity) => entity.YearTestField =TestWebApp.Domain.TestEntityForTypesMetadata.CreateYearTestField(createDto.YearTestField.NonNullValue<System.UInt16>()));
        entity.SetIfNotNull(createDto.CultureCodeTestField, (entity) => entity.CultureCodeTestField =TestWebApp.Domain.TestEntityForTypesMetadata.CreateCultureCodeTestField(createDto.CultureCodeTestField.NonNullValue<System.String>()));
        entity.SetIfNotNull(createDto.LanguageCodeTestField, (entity) => entity.LanguageCodeTestField =TestWebApp.Domain.TestEntityForTypesMetadata.CreateLanguageCodeTestField(createDto.LanguageCodeTestField.NonNullValue<System.String>()));
        entity.SetIfNotNull(createDto.YamlTestField, (entity) => entity.YamlTestField =TestWebApp.Domain.TestEntityForTypesMetadata.CreateYamlTestField(createDto.YamlTestField.NonNullValue<System.String>()));
        entity.SetIfNotNull(createDto.DateTimeDurationTestField, (entity) => entity.DateTimeDurationTestField =TestWebApp.Domain.TestEntityForTypesMetadata.CreateDateTimeDurationTestField(createDto.DateTimeDurationTestField.NonNullValue<System.Int64>()));
        entity.SetIfNotNull(createDto.TimeTestField, (entity) => entity.TimeTestField =TestWebApp.Domain.TestEntityForTypesMetadata.CreateTimeTestField(createDto.TimeTestField.NonNullValue<System.DateTime>()));
        entity.SetIfNotNull(createDto.VatNumberTestField, (entity) => entity.VatNumberTestField =TestWebApp.Domain.TestEntityForTypesMetadata.CreateVatNumberTestField(createDto.VatNumberTestField.NonNullValue<VatNumberDto>()));
        entity.SetIfNotNull(createDto.DateTestField, (entity) => entity.DateTestField =TestWebApp.Domain.TestEntityForTypesMetadata.CreateDateTestField(createDto.DateTestField.NonNullValue<System.DateTime>()));
        entity.SetIfNotNull(createDto.MarkdownTestField, (entity) => entity.MarkdownTestField =TestWebApp.Domain.TestEntityForTypesMetadata.CreateMarkdownTestField(createDto.MarkdownTestField.NonNullValue<System.String>()));
        entity.SetIfNotNull(createDto.FileTestField, (entity) => entity.FileTestField =TestWebApp.Domain.TestEntityForTypesMetadata.CreateFileTestField(createDto.FileTestField.NonNullValue<FileDto>()));
        entity.SetIfNotNull(createDto.ColorTestField, (entity) => entity.ColorTestField =TestWebApp.Domain.TestEntityForTypesMetadata.CreateColorTestField(createDto.ColorTestField.NonNullValue<System.String>()));
        entity.SetIfNotNull(createDto.UrlTestField, (entity) => entity.UrlTestField =TestWebApp.Domain.TestEntityForTypesMetadata.CreateUrlTestField(createDto.UrlTestField.NonNullValue<System.String>()));
        entity.SetIfNotNull(createDto.DateTimeScheduleTestField, (entity) => entity.DateTimeScheduleTestField =TestWebApp.Domain.TestEntityForTypesMetadata.CreateDateTimeScheduleTestField(createDto.DateTimeScheduleTestField.NonNullValue<System.String>()));
        entity.SetIfNotNull(createDto.UserTestField, (entity) => entity.UserTestField =TestWebApp.Domain.TestEntityForTypesMetadata.CreateUserTestField(createDto.UserTestField.NonNullValue<System.String>()));
        entity.SetIfNotNull(createDto.HtmlTestField, (entity) => entity.HtmlTestField =TestWebApp.Domain.TestEntityForTypesMetadata.CreateHtmlTestField(createDto.HtmlTestField.NonNullValue<System.String>()));
        entity.SetIfNotNull(createDto.ImageTestField, (entity) => entity.ImageTestField =TestWebApp.Domain.TestEntityForTypesMetadata.CreateImageTestField(createDto.ImageTestField.NonNullValue<ImageDto>()));
        return entity;
    }

    private void UpdateEntityInternal(TestEntityForTypesEntity entity, TestEntityForTypesUpdateDto updateDto, Nox.Types.CultureCode cultureCode)
    {
        entity.TextTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateTextTestField(updateDto.TextTestField.NonNullValue<System.String>());
        entity.SetIfNotNull(updateDto.EnumerationTestField, (entity) => entity.EnumerationTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateEnumerationTestField(updateDto.EnumerationTestField.ToValueFromNonNull<System.Int32>()));
        entity.NumberTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateNumberTestField(updateDto.NumberTestField.NonNullValue<System.Int16>());
        entity.SetIfNotNull(updateDto.MoneyTestField, (entity) => entity.MoneyTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateMoneyTestField(updateDto.MoneyTestField.ToValueFromNonNull<MoneyDto>()));
        entity.SetIfNotNull(updateDto.CountryCode2TestField, (entity) => entity.CountryCode2TestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateCountryCode2TestField(updateDto.CountryCode2TestField.ToValueFromNonNull<System.String>()));
        entity.SetIfNotNull(updateDto.StreetAddressTestField, (entity) => entity.StreetAddressTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateStreetAddressTestField(updateDto.StreetAddressTestField.ToValueFromNonNull<StreetAddressDto>()));
        entity.SetIfNotNull(updateDto.CurrencyCode3TestField, (entity) => entity.CurrencyCode3TestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateCurrencyCode3TestField(updateDto.CurrencyCode3TestField.ToValueFromNonNull<System.String>()));
        entity.SetIfNotNull(updateDto.DayOfWeekTestField, (entity) => entity.DayOfWeekTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateDayOfWeekTestField(updateDto.DayOfWeekTestField.ToValueFromNonNull<System.UInt16>()));
        entity.SetIfNotNull(updateDto.JwtTokenTestField, (entity) => entity.JwtTokenTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateJwtTokenTestField(updateDto.JwtTokenTestField.ToValueFromNonNull<System.String>()));
        entity.SetIfNotNull(updateDto.GeoCoordTestField, (entity) => entity.GeoCoordTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateGeoCoordTestField(updateDto.GeoCoordTestField.ToValueFromNonNull<LatLongDto>()));
        entity.SetIfNotNull(updateDto.AreaTestField, (entity) => entity.AreaTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateAreaTestField(updateDto.AreaTestField.ToValueFromNonNull<System.Decimal>()));
        entity.SetIfNotNull(updateDto.TimeZoneCodeTestField, (entity) => entity.TimeZoneCodeTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateTimeZoneCodeTestField(updateDto.TimeZoneCodeTestField.ToValueFromNonNull<System.String>()));
        entity.SetIfNotNull(updateDto.BooleanTestField, (entity) => entity.BooleanTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateBooleanTestField(updateDto.BooleanTestField.ToValueFromNonNull<System.Boolean>()));
        entity.SetIfNotNull(updateDto.CountryCode3TestField, (entity) => entity.CountryCode3TestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateCountryCode3TestField(updateDto.CountryCode3TestField.ToValueFromNonNull<System.String>()));
        entity.SetIfNotNull(updateDto.CountryNumberTestField, (entity) => entity.CountryNumberTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateCountryNumberTestField(updateDto.CountryNumberTestField.ToValueFromNonNull<System.UInt16>()));
        entity.SetIfNotNull(updateDto.CurrencyNumberTestField, (entity) => entity.CurrencyNumberTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateCurrencyNumberTestField(updateDto.CurrencyNumberTestField.ToValueFromNonNull<System.Int16>()));
        entity.SetIfNotNull(updateDto.DateTimeTestField, (entity) => entity.DateTimeTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateDateTimeTestField(updateDto.DateTimeTestField.ToValueFromNonNull<System.DateTimeOffset>()));
        entity.SetIfNotNull(updateDto.DateTimeRangeTestField, (entity) => entity.DateTimeRangeTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateDateTimeRangeTestField(updateDto.DateTimeRangeTestField.ToValueFromNonNull<DateTimeRangeDto>()));
        entity.SetIfNotNull(updateDto.DistanceTestField, (entity) => entity.DistanceTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateDistanceTestField(updateDto.DistanceTestField.ToValueFromNonNull<System.Decimal>()));
        entity.SetIfNotNull(updateDto.EmailTestField, (entity) => entity.EmailTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateEmailTestField(updateDto.EmailTestField.ToValueFromNonNull<System.String>()));
        entity.SetIfNotNull(updateDto.GuidTestField, (entity) => entity.GuidTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateGuidTestField(updateDto.GuidTestField.ToValueFromNonNull<System.Guid>()));
        entity.SetIfNotNull(updateDto.InternetDomainTestField, (entity) => entity.InternetDomainTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateInternetDomainTestField(updateDto.InternetDomainTestField.ToValueFromNonNull<System.String>()));
        entity.SetIfNotNull(updateDto.IpAddressV4TestField, (entity) => entity.IpAddressV4TestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateIpAddressV4TestField(updateDto.IpAddressV4TestField.ToValueFromNonNull<System.String>()));
        entity.SetIfNotNull(updateDto.IpAddressV6TestField, (entity) => entity.IpAddressV6TestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateIpAddressV6TestField(updateDto.IpAddressV6TestField.ToValueFromNonNull<System.String>()));
        entity.SetIfNotNull(updateDto.JsonTestField, (entity) => entity.JsonTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateJsonTestField(updateDto.JsonTestField.ToValueFromNonNull<System.String>()));
        entity.SetIfNotNull(updateDto.LengthTestField, (entity) => entity.LengthTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateLengthTestField(updateDto.LengthTestField.ToValueFromNonNull<System.Decimal>()));
        entity.SetIfNotNull(updateDto.MacAddressTestField, (entity) => entity.MacAddressTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateMacAddressTestField(updateDto.MacAddressTestField.ToValueFromNonNull<System.String>()));
        entity.SetIfNotNull(updateDto.MonthTestField, (entity) => entity.MonthTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateMonthTestField(updateDto.MonthTestField.ToValueFromNonNull<System.Byte>()));
        entity.SetIfNotNull(updateDto.PercentageTestField, (entity) => entity.PercentageTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreatePercentageTestField(updateDto.PercentageTestField.ToValueFromNonNull<System.Single>()));
        entity.SetIfNotNull(updateDto.PhoneNumberTestField, (entity) => entity.PhoneNumberTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreatePhoneNumberTestField(updateDto.PhoneNumberTestField.ToValueFromNonNull<System.String>()));
        entity.SetIfNotNull(updateDto.TemperatureTestField, (entity) => entity.TemperatureTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateTemperatureTestField(updateDto.TemperatureTestField.ToValueFromNonNull<System.Decimal>()));
        entity.SetIfNotNull(updateDto.TranslatedTextTestField, (entity) => entity.TranslatedTextTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateTranslatedTextTestField(updateDto.TranslatedTextTestField.ToValueFromNonNull<TranslatedTextDto>()));
        entity.SetIfNotNull(updateDto.UriTestField, (entity) => entity.UriTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateUriTestField(updateDto.UriTestField.ToValueFromNonNull<System.String>()));
        entity.SetIfNotNull(updateDto.VolumeTestField, (entity) => entity.VolumeTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateVolumeTestField(updateDto.VolumeTestField.ToValueFromNonNull<System.Decimal>()));
        entity.SetIfNotNull(updateDto.WeightTestField, (entity) => entity.WeightTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateWeightTestField(updateDto.WeightTestField.ToValueFromNonNull<System.Decimal>()));
        entity.SetIfNotNull(updateDto.YearTestField, (entity) => entity.YearTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateYearTestField(updateDto.YearTestField.ToValueFromNonNull<System.UInt16>()));
        entity.SetIfNotNull(updateDto.CultureCodeTestField, (entity) => entity.CultureCodeTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateCultureCodeTestField(updateDto.CultureCodeTestField.ToValueFromNonNull<System.String>()));
        entity.SetIfNotNull(updateDto.LanguageCodeTestField, (entity) => entity.LanguageCodeTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateLanguageCodeTestField(updateDto.LanguageCodeTestField.ToValueFromNonNull<System.String>()));
        entity.SetIfNotNull(updateDto.YamlTestField, (entity) => entity.YamlTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateYamlTestField(updateDto.YamlTestField.ToValueFromNonNull<System.String>()));
        entity.SetIfNotNull(updateDto.DateTimeDurationTestField, (entity) => entity.DateTimeDurationTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateDateTimeDurationTestField(updateDto.DateTimeDurationTestField.ToValueFromNonNull<System.Int64>()));
        entity.SetIfNotNull(updateDto.TimeTestField, (entity) => entity.TimeTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateTimeTestField(updateDto.TimeTestField.ToValueFromNonNull<System.DateTime>()));
        entity.SetIfNotNull(updateDto.VatNumberTestField, (entity) => entity.VatNumberTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateVatNumberTestField(updateDto.VatNumberTestField.ToValueFromNonNull<VatNumberDto>()));
        entity.SetIfNotNull(updateDto.DateTestField, (entity) => entity.DateTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateDateTestField(updateDto.DateTestField.ToValueFromNonNull<System.DateTime>()));
        entity.SetIfNotNull(updateDto.MarkdownTestField, (entity) => entity.MarkdownTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateMarkdownTestField(updateDto.MarkdownTestField.ToValueFromNonNull<System.String>()));
        entity.SetIfNotNull(updateDto.FileTestField, (entity) => entity.FileTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateFileTestField(updateDto.FileTestField.ToValueFromNonNull<FileDto>()));
        entity.SetIfNotNull(updateDto.ColorTestField, (entity) => entity.ColorTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateColorTestField(updateDto.ColorTestField.ToValueFromNonNull<System.String>()));
        entity.SetIfNotNull(updateDto.UrlTestField, (entity) => entity.UrlTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateUrlTestField(updateDto.UrlTestField.ToValueFromNonNull<System.String>()));
        entity.SetIfNotNull(updateDto.DateTimeScheduleTestField, (entity) => entity.DateTimeScheduleTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateDateTimeScheduleTestField(updateDto.DateTimeScheduleTestField.ToValueFromNonNull<System.String>()));
        entity.SetIfNotNull(updateDto.UserTestField, (entity) => entity.UserTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateUserTestField(updateDto.UserTestField.ToValueFromNonNull<System.String>()));
        entity.SetIfNotNull(updateDto.HtmlTestField, (entity) => entity.HtmlTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateHtmlTestField(updateDto.HtmlTestField.ToValueFromNonNull<System.String>()));
        entity.SetIfNotNull(updateDto.ImageTestField, (entity) => entity.ImageTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateImageTestField(updateDto.ImageTestField.ToValueFromNonNull<ImageDto>()));
    }

    private void PartialUpdateEntityInternal(TestEntityForTypesEntity entity, Dictionary<string, dynamic> updatedProperties, Nox.Types.CultureCode cultureCode)
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

        if (updatedProperties.TryGetValue("EnumerationTestField", out var EnumerationTestFieldUpdateValue))
        {
            if (EnumerationTestFieldUpdateValue == null) { entity.EnumerationTestField = null; }
            else
            {
                entity.EnumerationTestField = TestWebApp.Domain.TestEntityForTypesMetadata.CreateEnumerationTestField(EnumerationTestFieldUpdateValue);
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

    private static bool IsDefaultCultureCode(Nox.Types.CultureCode cultureCode)
        => cultureCode == _defaultCultureCode;
}

internal partial class TestEntityForTypesFactory : TestEntityForTypesFactoryBase
{
}