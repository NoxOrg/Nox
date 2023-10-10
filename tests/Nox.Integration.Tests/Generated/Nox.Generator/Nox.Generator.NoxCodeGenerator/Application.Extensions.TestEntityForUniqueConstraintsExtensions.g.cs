// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

using TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

internal static class TestEntityForUniqueConstraintsExtensions
{
    public static TestEntityForUniqueConstraintsDto ToDto(this TestEntityForUniqueConstraints entity)
    {
        var dto = new TestEntityForUniqueConstraintsDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.TextField, (dto) => dto.TextField =entity!.TextField!.Value);
        dto.SetIfNotNull(entity?.NumberField, (dto) => dto.NumberField =entity!.NumberField!.Value);
        dto.SetIfNotNull(entity?.UniqueNumberField, (dto) => dto.UniqueNumberField =entity!.UniqueNumberField!.Value);
        dto.SetIfNotNull(entity?.UniqueCountryCode, (dto) => dto.UniqueCountryCode =entity!.UniqueCountryCode!.Value);
        dto.SetIfNotNull(entity?.UniqueCurrencyCode, (dto) => dto.UniqueCurrencyCode =entity!.UniqueCurrencyCode!.Value);

        return dto;
    }
}