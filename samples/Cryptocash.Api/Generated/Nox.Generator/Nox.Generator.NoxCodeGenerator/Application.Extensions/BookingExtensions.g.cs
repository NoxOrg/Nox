// Generated

#nullable enable
using System;
using System.Linq;

using Nox.Extensions;

namespace Cryptocash.Application.Dto;

internal static class BookingExtensions
{
    public static BookingDto ToDto(this Cryptocash.Domain.Booking entity)
    {
        var dto = new BookingDto();
        dto.SetIfNotNull(entity?.Id, (dto) => dto.Id = entity!.Id.Value);
        dto.SetIfNotNull(entity?.AmountFrom, (dto) => dto.AmountFrom =entity!.AmountFrom!.ToDto());
        dto.SetIfNotNull(entity?.AmountTo, (dto) => dto.AmountTo =entity!.AmountTo!.ToDto());
        dto.SetIfNotNull(entity?.RequestedPickUpDate, (dto) => dto.RequestedPickUpDate =entity!.RequestedPickUpDate!.ToDto());
        dto.SetIfNotNull(entity?.PickedUpDateTime, (dto) => dto.PickedUpDateTime =entity!.PickedUpDateTime!.ToDto());
        dto.SetIfNotNull(entity?.ExpiryDateTime, (dto) => dto.ExpiryDateTime =entity!.ExpiryDateTime!.Value);
        dto.SetIfNotNull(entity?.CancelledDateTime, (dto) => dto.CancelledDateTime =entity!.CancelledDateTime!.Value);
        dto.SetIfNotNull(entity?.Status, (dto) => dto.Status =entity!.Status!.ToString());
        dto.SetIfNotNull(entity?.VatNumber, (dto) => dto.VatNumber =entity!.VatNumber!.ToDto());

        return dto;
    }
}