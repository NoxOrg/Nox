// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

internal static class BankNoteExtensions
{
    public static BankNoteDto ToDto(this BankNote entity)
    {
        var dto = new BankNoteDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.CashNote, (dto) => dto.CashNote =entity!.CashNote!.Value);
        dto.SetIfNotNull(entity?.Value, (dto) => dto.Value =entity!.Value!.ToDto());

        return dto;
    }
}