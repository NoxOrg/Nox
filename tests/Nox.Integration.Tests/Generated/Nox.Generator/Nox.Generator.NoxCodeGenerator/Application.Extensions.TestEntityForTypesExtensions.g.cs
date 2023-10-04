// Generated

#nullable enable
using System;
using System.Linq;

using TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

internal static class TestEntityForTypesExtensions
{
    public static TestEntityForTypesDto ToDto(this TestEntityForTypes entity)
    {
        var dto = new TestEntityForTypesDto();
        SetIfNotNull(entity?.Id, () => dto.Id = entity!.Id.Value);
        SetIfNotNull(entity?.TextTestField, () => dto.TextTestField =entity!.TextTestField!.Value);
        SetIfNotNull(entity?.NumberTestField, () => dto.NumberTestField =entity!.NumberTestField!.Value);
        SetIfNotNull(entity?.MoneyTestField, () => dto.MoneyTestField =entity!.MoneyTestField!.ToDto());
        SetIfNotNull(entity?.CountryCode2TestField, () => dto.CountryCode2TestField =entity!.CountryCode2TestField!.Value);
        SetIfNotNull(entity?.StreetAddressTestField, () => dto.StreetAddressTestField =entity!.StreetAddressTestField!.ToDto());
        SetIfNotNull(entity?.CurrencyCode3TestField, () => dto.CurrencyCode3TestField =entity!.CurrencyCode3TestField!.Value);
        SetIfNotNull(entity?.DayOfWeekTestField, () => dto.DayOfWeekTestField =entity!.DayOfWeekTestField!.Value);
        SetIfNotNull(entity?.JwtTokenTestField, () => dto.JwtTokenTestField =entity!.JwtTokenTestField!.Value);
        SetIfNotNull(entity?.GeoCoordTestField, () => dto.GeoCoordTestField =entity!.GeoCoordTestField!.ToDto());
        SetIfNotNull(entity?.AreaTestField, () => dto.AreaTestField =entity!.AreaTestField!.Value);
        SetIfNotNull(entity?.TimeZoneCodeTestField, () => dto.TimeZoneCodeTestField =entity!.TimeZoneCodeTestField!.Value);
        SetIfNotNull(entity?.BooleanTestField, () => dto.BooleanTestField =entity!.BooleanTestField!.Value);
        SetIfNotNull(entity?.CountryCode3TestField, () => dto.CountryCode3TestField =entity!.CountryCode3TestField!.Value);
        SetIfNotNull(entity?.CountryNumberTestField, () => dto.CountryNumberTestField =entity!.CountryNumberTestField!.Value);
        SetIfNotNull(entity?.CurrencyNumberTestField, () => dto.CurrencyNumberTestField =entity!.CurrencyNumberTestField!.Value);
        SetIfNotNull(entity?.DateTimeTestField, () => dto.DateTimeTestField =entity!.DateTimeTestField!.Value);
        SetIfNotNull(entity?.DateTimeRangeTestField, () => dto.DateTimeRangeTestField =entity!.DateTimeRangeTestField!.ToDto());
        SetIfNotNull(entity?.DistanceTestField, () => dto.DistanceTestField =entity!.DistanceTestField!.Value);
        SetIfNotNull(entity?.EmailTestField, () => dto.EmailTestField =entity!.EmailTestField!.Value);
        SetIfNotNull(entity?.GuidTestField, () => dto.GuidTestField =entity!.GuidTestField!.Value);
        SetIfNotNull(entity?.InternetDomainTestField, () => dto.InternetDomainTestField =entity!.InternetDomainTestField!.Value);
        SetIfNotNull(entity?.IpAddressV4TestField, () => dto.IpAddressV4TestField =entity!.IpAddressV4TestField!.Value);
        SetIfNotNull(entity?.IpAddressV6TestField, () => dto.IpAddressV6TestField =entity!.IpAddressV6TestField!.Value);
        SetIfNotNull(entity?.JsonTestField, () => dto.JsonTestField =entity!.JsonTestField!.Value);
        SetIfNotNull(entity?.LengthTestField, () => dto.LengthTestField =entity!.LengthTestField!.Value);
        SetIfNotNull(entity?.MacAddressTestField, () => dto.MacAddressTestField =entity!.MacAddressTestField!.Value);
        SetIfNotNull(entity?.MonthTestField, () => dto.MonthTestField =entity!.MonthTestField!.Value);
        SetIfNotNull(entity?.PercentageTestField, () => dto.PercentageTestField =entity!.PercentageTestField!.Value);
        SetIfNotNull(entity?.PhoneNumberTestField, () => dto.PhoneNumberTestField =entity!.PhoneNumberTestField!.Value);
        SetIfNotNull(entity?.TemperatureTestField, () => dto.TemperatureTestField =entity!.TemperatureTestField!.Value);
        SetIfNotNull(entity?.TranslatedTextTestField, () => dto.TranslatedTextTestField =entity!.TranslatedTextTestField!.ToDto());
        SetIfNotNull(entity?.UriTestField, () => dto.UriTestField =entity!.UriTestField!.Value.ToString());
        SetIfNotNull(entity?.VolumeTestField, () => dto.VolumeTestField =entity!.VolumeTestField!.Value);
        SetIfNotNull(entity?.WeightTestField, () => dto.WeightTestField =entity!.WeightTestField!.Value);
        SetIfNotNull(entity?.YearTestField, () => dto.YearTestField =entity!.YearTestField!.Value);
        SetIfNotNull(entity?.CultureCodeTestField, () => dto.CultureCodeTestField =entity!.CultureCodeTestField!.Value);
        SetIfNotNull(entity?.LanguageCodeTestField, () => dto.LanguageCodeTestField =entity!.LanguageCodeTestField!.Value);
        SetIfNotNull(entity?.YamlTestField, () => dto.YamlTestField =entity!.YamlTestField!.Value);
        SetIfNotNull(entity?.DateTimeDurationTestField, () => dto.DateTimeDurationTestField =entity!.DateTimeDurationTestField!.Value);
        SetIfNotNull(entity?.TimeTestField, () => dto.TimeTestField =System.DateTime.Parse(entity!.TimeTestField!.Value.ToLongTimeString()));
        SetIfNotNull(entity?.VatNumberTestField, () => dto.VatNumberTestField =entity!.VatNumberTestField!.ToDto());
        SetIfNotNull(entity?.DateTestField, () => dto.DateTestField =entity!.DateTestField!.Value.ToDateTime(new System.TimeOnly(0, 0, 0)));
        SetIfNotNull(entity?.MarkdownTestField, () => dto.MarkdownTestField =entity!.MarkdownTestField!.Value);
        SetIfNotNull(entity?.FileTestField, () => dto.FileTestField =entity!.FileTestField!.ToDto());
        SetIfNotNull(entity?.ColorTestField, () => dto.ColorTestField =entity!.ColorTestField!.Value);
        SetIfNotNull(entity?.UrlTestField, () => dto.UrlTestField =entity!.UrlTestField!.Value.ToString());
        SetIfNotNull(entity?.DateTimeScheduleTestField, () => dto.DateTimeScheduleTestField =entity!.DateTimeScheduleTestField!.Value);
        SetIfNotNull(entity?.UserTestField, () => dto.UserTestField =entity!.UserTestField!.Value);
        SetIfNotNull(entity?.FormulaTestField, () => dto.FormulaTestField =entity!.FormulaTestField!.ToString());
        SetIfNotNull(entity?.AutoNumberTestField, () => dto.AutoNumberTestField =entity!.AutoNumberTestField!.Value);
        SetIfNotNull(entity?.HtmlTestField, () => dto.HtmlTestField =entity!.HtmlTestField!.Value);
        SetIfNotNull(entity?.ImageTestField, () => dto.ImageTestField =entity!.ImageTestField!.ToDto());

        return dto;
    }

    private static void SetIfNotNull(object? value, Action setPropertyAction)
    {
        if (value is not null)
        {
            setPropertyAction();
        }
    }
}