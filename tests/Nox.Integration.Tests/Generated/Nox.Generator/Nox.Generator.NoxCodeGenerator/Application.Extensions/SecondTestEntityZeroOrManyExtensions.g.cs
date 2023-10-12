// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

using TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

internal static class SecondTestEntityZeroOrManyExtensions
{
    public static SecondTestEntityZeroOrManyDto ToDto(this SecondTestEntityZeroOrMany entity)
    {
        var dto = new SecondTestEntityZeroOrManyDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.TextTestField2, (dto) => dto.TextTestField2 =entity!.TextTestField2!.Value);
        dto.SetIfNotNull(entity?.TestEntityZeroOrManyRelationship, (dto) => dto.TestEntityZeroOrManyRelationship = entity!.TestEntityZeroOrManyRelationship.Select(e => e.ToDto()).ToList());

        return dto;
    }
}