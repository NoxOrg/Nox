﻿// Generated

#nullable enable
using System;
using System.Linq;

using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

internal static class BookingExtensions
{
    public static BookingDto ToDto(this Booking entity)
    {
        var dto = new BookingDto();
        SetIfNotNull(entity?.Id, () => dto.Id = entity!.Id.Value);
        SetIfNotNull(entity?.AmountFrom, () => dto.AmountFrom = entity!.AmountFrom!.ToDto());
        SetIfNotNull(entity?.AmountTo, () => dto.AmountTo = entity!.AmountTo!.ToDto());
        SetIfNotNull(entity?.RequestedPickUpDate, () => dto.RequestedPickUpDate = entity!.RequestedPickUpDate!.ToDto());
        SetIfNotNull(entity?.PickedUpDateTime, () => dto.PickedUpDateTime = entity!.PickedUpDateTime!.ToDto());
        SetIfNotNull(entity?.ExpiryDateTime, () => dto.ExpiryDateTime = entity!.ExpiryDateTime!.Value);
        SetIfNotNull(entity?.CancelledDateTime, () => dto.CancelledDateTime = entity!.CancelledDateTime!.Value);
        SetIfNotNull(entity?.Status, () => dto.Status = entity!.Status);
        SetIfNotNull(entity?.VatNumber, () => dto.VatNumber = entity!.VatNumber!.ToDto());
        SetIfNotNull(entity?.BookingForCustomerId, () => dto.BookingForCustomerId = entity!.BookingForCustomerId!.Value);
        SetIfNotNull(entity?.BookingForCustomer, () => dto.BookingForCustomer = entity!.BookingForCustomer!.ToDto());
        SetIfNotNull(entity?.BookingRelatedVendingMachineId, () => dto.BookingRelatedVendingMachineId = entity!.BookingRelatedVendingMachineId!.Value);
        SetIfNotNull(entity?.BookingRelatedVendingMachine, () => dto.BookingRelatedVendingMachine = entity!.BookingRelatedVendingMachine!.ToDto());
        SetIfNotNull(entity?.BookingFeesForCommissionId, () => dto.BookingFeesForCommissionId = entity!.BookingFeesForCommissionId!.Value);
        SetIfNotNull(entity?.BookingFeesForCommission, () => dto.BookingFeesForCommission = entity!.BookingFeesForCommission!.ToDto());
        SetIfNotNull(entity?.BookingRelatedTransaction, () => dto.BookingRelatedTransaction = entity!.BookingRelatedTransaction!.ToDto());

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