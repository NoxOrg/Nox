﻿// Generated

#nullable enable
using System;
using System.Linq;

using TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

internal static class TestEntityOwnedRelationshipZeroOrOneExtensions
{
    public static TestEntityOwnedRelationshipZeroOrOneDto ToDto(this TestEntityOwnedRelationshipZeroOrOne entity)
    {
        var dto = new TestEntityOwnedRelationshipZeroOrOneDto();
        SetIfNotNull(entity?.Id, () => dto.Id = entity!.Id.Value);
        SetIfNotNull(entity?.TextTestField, () => dto.TextTestField =entity!.TextTestField!.Value);
        SetIfNotNull(entity?.SecondTestEntityOwnedRelationshipZeroOrOne, () => dto.SecondTestEntityOwnedRelationshipZeroOrOne = entity!.SecondTestEntityOwnedRelationshipZeroOrOne!.ToDto());

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