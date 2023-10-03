// Generated

#nullable enable
using System;
using System.Linq;

using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

internal static class BankNoteExtensions
{
    public static BankNoteDto ToDto(this BankNote entity)
    {
        var dto = new BankNoteDto();
        SetIfNotNull(entity?.Id, () => dto.Id = entity!.Id.Value);
        SetIfNotNull(entity?.CashNote, () => dto.CashNote = entity!.CashNote!.Value);
        SetIfNotNull(entity?.Value, () => dto.Value = entity!.Value!.ToDto());

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