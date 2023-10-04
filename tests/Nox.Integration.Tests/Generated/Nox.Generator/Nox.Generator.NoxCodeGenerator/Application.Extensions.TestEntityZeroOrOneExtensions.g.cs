// Generated

#nullable enable
using System;
using System.Linq;

using TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

internal static class TestEntityZeroOrOneExtensions
{
    public static TestEntityZeroOrOneDto ToDto(this TestEntityZeroOrOne entity)
    {
        var dto = new TestEntityZeroOrOneDto();
        SetIfNotNull(entity?.Id, () => dto.Id = entity!.Id.Value);
        SetIfNotNull(entity?.TextTestField, () => dto.TextTestField =entity!.TextTestField!.Value);
        SetIfNotNull(entity?.SecondTestEntityZeroOrOneRelationshipId, () => dto.SecondTestEntityZeroOrOneRelationshipId = entity!.SecondTestEntityZeroOrOneRelationshipId!.Value);
        SetIfNotNull(entity?.SecondTestEntityZeroOrOneRelationship, () => dto.SecondTestEntityZeroOrOneRelationship = entity!.SecondTestEntityZeroOrOneRelationship!.ToDto());

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