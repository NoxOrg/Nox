// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace TestWebApp.Application.Dto;

internal static class TestEntityForAutoNumberUsagesExtensions
{
    public static TestEntityForAutoNumberUsagesDto ToDto(this TestWebApp.Domain.TestEntityForAutoNumberUsages entity)
    {
        var dto = new TestEntityForAutoNumberUsagesDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.AutoNumberField, (dto) => dto.AutoNumberField =entity!.AutoNumberField!.Value);
        dto.SetIfNotNull(entity?.TextField, (dto) => dto.TextField =entity!.TextField!.Value);

        return dto;
    }
}