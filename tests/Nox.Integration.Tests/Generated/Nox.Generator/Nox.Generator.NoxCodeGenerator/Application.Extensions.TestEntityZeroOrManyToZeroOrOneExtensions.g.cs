// Generated

#nullable enable
using System;
using System.Linq;

using TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

internal static class TestEntityZeroOrManyToZeroOrOneExtensions
{
    public static TestEntityZeroOrManyToZeroOrOneDto ToDto(this TestEntityZeroOrManyToZeroOrOne entity)
    {
        var dto = new TestEntityZeroOrManyToZeroOrOneDto();
        SetIfNotNull(entity?.Id, () => dto.Id = entity!.Id.Value);
        SetIfNotNull(entity?.TextTestField2, () => dto.TextTestField2 =entity!.TextTestField2!.Value);
        SetIfNotNull(entity?.TestEntityZeroOrOneToZeroOrMany, () => dto.TestEntityZeroOrOneToZeroOrMany = entity!.TestEntityZeroOrOneToZeroOrMany.Select(e => e.ToDto()).ToList());

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