// Generated

#nullable enable
using System;
using System.Linq;

using TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

internal static class TestEntityForUniqueConstraintsExtensions
{
    public static TestEntityForUniqueConstraintsDto ToDto(this TestEntityForUniqueConstraints entity)
    {
        var dto = new TestEntityForUniqueConstraintsDto();
        SetIfNotNull(entity?.Id, () => dto.Id = entity!.Id.Value);
        SetIfNotNull(entity?.TextField, () => dto.TextField =entity!.TextField!.Value);
        SetIfNotNull(entity?.NumberField, () => dto.NumberField =entity!.NumberField!.Value);
        SetIfNotNull(entity?.UniqueNumberField, () => dto.UniqueNumberField =entity!.UniqueNumberField!.Value);
        SetIfNotNull(entity?.UniqueCountryCode, () => dto.UniqueCountryCode =entity!.UniqueCountryCode!.Value);
        SetIfNotNull(entity?.UniqueCurrencyCode, () => dto.UniqueCurrencyCode =entity!.UniqueCurrencyCode!.Value);

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