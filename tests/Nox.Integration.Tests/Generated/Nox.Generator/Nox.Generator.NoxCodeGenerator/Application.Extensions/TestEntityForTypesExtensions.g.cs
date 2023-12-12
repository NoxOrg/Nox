// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace TestWebApp.Application.Dto;

internal static class TestEntityForTypesExtensions
{
    public static TestEntityForTypesDto ToDto(this TestWebApp.Domain.TestEntityForTypes entity)
    {
        var dto = new TestEntityForTypesDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.TextTestField, (dto) => dto.TextTestField =entity!.TextTestField!.Value);
        dto.SetIfNotNull(entity?.EnumerationTestField, (dto) => dto.EnumerationTestField =entity!.EnumerationTestField!.Value);
        dto.SetIfNotNull(entity?.NumberTestField, (dto) => dto.NumberTestField =entity!.NumberTestField!.Value);
        dto.SetIfNotNull(entity?.MoneyTestField, (dto) => dto.MoneyTestField =entity!.MoneyTestField!.ToDto());
        dto.SetIfNotNull(entity?.CountryCode2TestField, (dto) => dto.CountryCode2TestField =entity!.CountryCode2TestField!.Value);
        dto.SetIfNotNull(entity?.StreetAddressTestField, (dto) => dto.StreetAddressTestField =entity!.StreetAddressTestField!.ToDto());
        dto.SetIfNotNull(entity?.CurrencyCode3TestField, (dto) => dto.CurrencyCode3TestField =entity!.CurrencyCode3TestField!.Value);
        dto.SetIfNotNull(entity?.DayOfWeekTestField, (dto) => dto.DayOfWeekTestField =entity!.DayOfWeekTestField!.Value);
        dto.SetIfNotNull(entity?.JwtTokenTestField, (dto) => dto.JwtTokenTestField =entity!.JwtTokenTestField!.Value);
        dto.SetIfNotNull(entity?.GeoCoordTestField, (dto) => dto.GeoCoordTestField =entity!.GeoCoordTestField!.ToDto());
        dto.SetIfNotNull(entity?.AreaTestField, (dto) => dto.AreaTestField =entity!.AreaTestField!.Value);
        dto.SetIfNotNull(entity?.TimeZoneCodeTestField, (dto) => dto.TimeZoneCodeTestField =entity!.TimeZoneCodeTestField!.Value);
        dto.SetIfNotNull(entity?.BooleanTestField, (dto) => dto.BooleanTestField =entity!.BooleanTestField!.Value);
        dto.SetIfNotNull(entity?.CountryCode3TestField, (dto) => dto.CountryCode3TestField =entity!.CountryCode3TestField!.Value);
        dto.SetIfNotNull(entity?.CountryNumberTestField, (dto) => dto.CountryNumberTestField =entity!.CountryNumberTestField!.Value);
        dto.SetIfNotNull(entity?.CurrencyNumberTestField, (dto) => dto.CurrencyNumberTestField =entity!.CurrencyNumberTestField!.Value);
        dto.SetIfNotNull(entity?.DateTimeTestField, (dto) => dto.DateTimeTestField =entity!.DateTimeTestField!.Value);
        dto.SetIfNotNull(entity?.DateTimeRangeTestField, (dto) => dto.DateTimeRangeTestField =entity!.DateTimeRangeTestField!.ToDto());
        dto.SetIfNotNull(entity?.DistanceTestField, (dto) => dto.DistanceTestField =entity!.DistanceTestField!.Value);
        dto.SetIfNotNull(entity?.EmailTestField, (dto) => dto.EmailTestField =entity!.EmailTestField!.Value);
        dto.SetIfNotNull(entity?.GuidTestField, (dto) => dto.GuidTestField =entity!.GuidTestField!.Value);
        dto.SetIfNotNull(entity?.InternetDomainTestField, (dto) => dto.InternetDomainTestField =entity!.InternetDomainTestField!.Value);
        dto.SetIfNotNull(entity?.IpAddressV4TestField, (dto) => dto.IpAddressV4TestField =entity!.IpAddressV4TestField!.Value);
        dto.SetIfNotNull(entity?.IpAddressV6TestField, (dto) => dto.IpAddressV6TestField =entity!.IpAddressV6TestField!.Value);
        dto.SetIfNotNull(entity?.JsonTestField, (dto) => dto.JsonTestField =entity!.JsonTestField!.Value);
        dto.SetIfNotNull(entity?.LengthTestField, (dto) => dto.LengthTestField =entity!.LengthTestField!.Value);
        dto.SetIfNotNull(entity?.MacAddressTestField, (dto) => dto.MacAddressTestField =entity!.MacAddressTestField!.Value);
        dto.SetIfNotNull(entity?.MonthTestField, (dto) => dto.MonthTestField =entity!.MonthTestField!.Value);
        dto.SetIfNotNull(entity?.PercentageTestField, (dto) => dto.PercentageTestField =entity!.PercentageTestField!.Value);
        dto.SetIfNotNull(entity?.PhoneNumberTestField, (dto) => dto.PhoneNumberTestField =entity!.PhoneNumberTestField!.Value);
        dto.SetIfNotNull(entity?.TemperatureTestField, (dto) => dto.TemperatureTestField =entity!.TemperatureTestField!.Value);
        dto.SetIfNotNull(entity?.TranslatedTextTestField, (dto) => dto.TranslatedTextTestField =entity!.TranslatedTextTestField!.ToDto());
        dto.SetIfNotNull(entity?.UriTestField, (dto) => dto.UriTestField =entity!.UriTestField!.Value.ToString());
        dto.SetIfNotNull(entity?.VolumeTestField, (dto) => dto.VolumeTestField =entity!.VolumeTestField!.Value);
        dto.SetIfNotNull(entity?.WeightTestField, (dto) => dto.WeightTestField =entity!.WeightTestField!.Value);
        dto.SetIfNotNull(entity?.YearTestField, (dto) => dto.YearTestField =entity!.YearTestField!.Value);
        dto.SetIfNotNull(entity?.CultureCodeTestField, (dto) => dto.CultureCodeTestField =entity!.CultureCodeTestField!.Value);
        dto.SetIfNotNull(entity?.LanguageCodeTestField, (dto) => dto.LanguageCodeTestField =entity!.LanguageCodeTestField!.Value);
        dto.SetIfNotNull(entity?.YamlTestField, (dto) => dto.YamlTestField =entity!.YamlTestField!.Value);
        dto.SetIfNotNull(entity?.DateTimeDurationTestField, (dto) => dto.DateTimeDurationTestField =entity!.DateTimeDurationTestField!.Value);
        dto.SetIfNotNull(entity?.TimeTestField, (dto) => dto.TimeTestField =System.DateTime.Parse(entity!.TimeTestField!.Value.ToLongTimeString()));
        dto.SetIfNotNull(entity?.VatNumberTestField, (dto) => dto.VatNumberTestField =entity!.VatNumberTestField!.ToDto());
        dto.SetIfNotNull(entity?.DateTestField, (dto) => dto.DateTestField =entity!.DateTestField!.Value.ToDateTime(new System.TimeOnly(0, 0, 0)));
        dto.SetIfNotNull(entity?.MarkdownTestField, (dto) => dto.MarkdownTestField =entity!.MarkdownTestField!.Value);
        dto.SetIfNotNull(entity?.FileTestField, (dto) => dto.FileTestField =entity!.FileTestField!.ToDto());
        dto.SetIfNotNull(entity?.ColorTestField, (dto) => dto.ColorTestField =entity!.ColorTestField!.Value);
        dto.SetIfNotNull(entity?.UrlTestField, (dto) => dto.UrlTestField =entity!.UrlTestField!.Value.ToString());
        dto.SetIfNotNull(entity?.DateTimeScheduleTestField, (dto) => dto.DateTimeScheduleTestField =entity!.DateTimeScheduleTestField!.Value);
        dto.SetIfNotNull(entity?.UserTestField, (dto) => dto.UserTestField =entity!.UserTestField!.Value);
        dto.SetIfNotNull(entity?.FormulaTestField, (dto) => dto.FormulaTestField =entity!.FormulaTestField);
        dto.SetIfNotNull(entity?.AutoNumberTestField, (dto) => dto.AutoNumberTestField =entity!.AutoNumberTestField!.Value);
        dto.SetIfNotNull(entity?.HtmlTestField, (dto) => dto.HtmlTestField =entity!.HtmlTestField!.Value);
        dto.SetIfNotNull(entity?.ImageTestField, (dto) => dto.ImageTestField =entity!.ImageTestField!.ToDto());

        return dto;
    }
}