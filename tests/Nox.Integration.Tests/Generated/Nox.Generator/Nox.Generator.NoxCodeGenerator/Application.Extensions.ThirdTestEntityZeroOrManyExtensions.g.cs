﻿// Generated

#nullable enable
using System;
using System.Linq;

using TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

internal static class ThirdTestEntityZeroOrManyExtensions
{
    public static ThirdTestEntityZeroOrManyDto ToDto(this ThirdTestEntityZeroOrMany entity)
    {
        var dto = new ThirdTestEntityZeroOrManyDto();
        SetIfNotNull(entity?.Id, () => dto.Id = entity!.Id.Value);
        SetIfNotNull(entity?.TextTestField2, () => dto.TextTestField2 =entity!.TextTestField2!.Value);
        SetIfNotNull(entity?.ThirdTestEntityOneOrManyRelationship, () => dto.ThirdTestEntityOneOrManyRelationship = entity!.ThirdTestEntityOneOrManyRelationship.Select(e => e.ToDto()).ToList());

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