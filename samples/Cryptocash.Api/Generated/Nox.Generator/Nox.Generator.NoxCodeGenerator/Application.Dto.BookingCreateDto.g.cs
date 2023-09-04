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

    public Booking ToEntity()
    {
        var entity = new Booking();
        entity.AmountFrom = Booking.CreateAmountFrom(AmountFrom);
        entity.AmountTo = Booking.CreateAmountTo(AmountTo);
        entity.RequestedPickUpDate = Booking.CreateRequestedPickUpDate(RequestedPickUpDate);
        if (PickedUpDateTime is not null)entity.PickedUpDateTime = Booking.CreatePickedUpDateTime(PickedUpDateTime.NonNullValue<DateTimeRangeDto>());
        if (ExpiryDateTime is not null)entity.ExpiryDateTime = Booking.CreateExpiryDateTime(ExpiryDateTime.NonNullValue<System.DateTimeOffset>());
        if (CancelledDateTime is not null)entity.CancelledDateTime = Booking.CreateCancelledDateTime(CancelledDateTime.NonNullValue<System.DateTimeOffset>());
        if (VatNumber is not null)entity.VatNumber = Booking.CreateVatNumber(VatNumber.NonNullValue<VatNumberDto>());
        //entity.Customer = Customer.ToEntity();
        //entity.VendingMachine = VendingMachine.ToEntity();
        //entity.Commission = Commission.ToEntity();
        //entity.CustomerTransaction = CustomerTransaction.ToEntity();
        return entity;
    }
}