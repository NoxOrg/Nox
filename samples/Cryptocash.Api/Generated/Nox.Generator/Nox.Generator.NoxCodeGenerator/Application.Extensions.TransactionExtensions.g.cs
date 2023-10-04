// Generated

#nullable enable
using System;
using System.Linq;

using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

internal static class TransactionExtensions
{
    public static TransactionDto ToDto(this Transaction entity)
    {
        var dto = new TransactionDto();
        SetIfNotNull(entity?.Id, () => dto.Id = entity!.Id.Value);
        SetIfNotNull(entity?.TransactionType, () => dto.TransactionType =entity!.TransactionType!.Value);
        SetIfNotNull(entity?.ProcessedOnDateTime, () => dto.ProcessedOnDateTime =entity!.ProcessedOnDateTime!.Value);
        SetIfNotNull(entity?.Amount, () => dto.Amount =entity!.Amount!.ToDto());
        SetIfNotNull(entity?.Reference, () => dto.Reference =entity!.Reference!.Value);
        SetIfNotNull(entity?.TransactionForCustomerId, () => dto.TransactionForCustomerId = entity!.TransactionForCustomerId!.Value);
        SetIfNotNull(entity?.TransactionForCustomer, () => dto.TransactionForCustomer = entity!.TransactionForCustomer!.ToDto());
        SetIfNotNull(entity?.TransactionForBookingId, () => dto.TransactionForBookingId = entity!.TransactionForBookingId!.Value);
        SetIfNotNull(entity?.TransactionForBooking, () => dto.TransactionForBooking = entity!.TransactionForBooking!.ToDto());

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