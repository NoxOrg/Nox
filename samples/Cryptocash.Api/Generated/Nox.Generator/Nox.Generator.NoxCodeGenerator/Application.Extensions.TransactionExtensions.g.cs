// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

internal static class TransactionExtensions
{
    public static TransactionDto ToDto(this Transaction entity)
    {
        var dto = new TransactionDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.TransactionType, (dto) => dto.TransactionType =entity!.TransactionType!.Value);
        dto.SetIfNotNull(entity?.ProcessedOnDateTime, (dto) => dto.ProcessedOnDateTime =entity!.ProcessedOnDateTime!.Value);
        dto.SetIfNotNull(entity?.Amount, (dto) => dto.Amount =entity!.Amount!.ToDto());
        dto.SetIfNotNull(entity?.Reference, (dto) => dto.Reference =entity!.Reference!.Value);
        dto.SetIfNotNull(entity?.TransactionForCustomerId, (dto) => dto.TransactionForCustomerId = entity!.TransactionForCustomerId!.Value);
        dto.SetIfNotNull(entity?.TransactionForBookingId, (dto) => dto.TransactionForBookingId = entity!.TransactionForBookingId!.Value);

        return dto;
    }
}