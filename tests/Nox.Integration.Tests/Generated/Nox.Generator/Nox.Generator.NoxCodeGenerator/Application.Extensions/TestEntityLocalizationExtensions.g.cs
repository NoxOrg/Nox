// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace TestWebApp.Application.Dto;

internal static class TestEntityLocalizationExtensions
{
    public static TestEntityLocalizationDto ToDto(this TestWebApp.Domain.TestEntityLocalization entity)
    {
        var dto = new TestEntityLocalizationDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.TextFieldToLocalize, (dto) => dto.TextFieldToLocalize =entity!.TextFieldToLocalize!.Value);
        dto.SetIfNotNull(entity?.NumberField, (dto) => dto.NumberField =entity!.NumberField!.Value);

        return dto;
    }
}