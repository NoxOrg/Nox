// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

/// <summary>
/// Exchange booking and related data.
/// </summary>
public partial class BookingCreateDto : BookingUpdateDto
{

    public Cryptocash.Domain.Booking ToEntity()
    {
        var entity = new Cryptocash.Domain.Booking();
        entity.AmountFrom = Cryptocash.Domain.Booking.CreateAmountFrom(AmountFrom);
        entity.AmountTo = Cryptocash.Domain.Booking.CreateAmountTo(AmountTo);
        entity.RequestedPickUpDate = Cryptocash.Domain.Booking.CreateRequestedPickUpDate(RequestedPickUpDate);
        if (PickedUpDateTime is not null)entity.PickedUpDateTime = Cryptocash.Domain.Booking.CreatePickedUpDateTime(PickedUpDateTime.NonNullValue<DateTimeRangeDto>());
        if (ExpiryDateTime is not null)entity.ExpiryDateTime = Cryptocash.Domain.Booking.CreateExpiryDateTime(ExpiryDateTime.NonNullValue<System.DateTimeOffset>());
        if (CancelledDateTime is not null)entity.CancelledDateTime = Cryptocash.Domain.Booking.CreateCancelledDateTime(CancelledDateTime.NonNullValue<System.DateTimeOffset>());
        if (VatNumber is not null)entity.VatNumber = Cryptocash.Domain.Booking.CreateVatNumber(VatNumber.NonNullValue<VatNumberDto>());
        //entity.Customer = Customer.ToEntity();
        //entity.VendingMachine = VendingMachine.ToEntity();
        //entity.Commission = Commission.ToEntity();
        //entity.Transaction = Transaction.ToEntity();
        return entity;
    }
}