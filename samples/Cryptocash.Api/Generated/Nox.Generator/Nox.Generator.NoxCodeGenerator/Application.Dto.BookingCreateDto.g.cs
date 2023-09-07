// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

/// <summary>
/// Exchange booking and related data.
/// </summary>
public partial class BookingCreateDto : IEntityCreateDto <Booking>
{    
    /// <summary>
    /// Booking's amount exchanged from (Required).
    /// </summary>
    [Required(ErrorMessage = "AmountFrom is required")]
    
    public MoneyDto AmountFrom { get; set; } = default!;    
    /// <summary>
    /// Booking's amount exchanged to (Required).
    /// </summary>
    [Required(ErrorMessage = "AmountTo is required")]
    
    public MoneyDto AmountTo { get; set; } = default!;    
    /// <summary>
    /// Booking's requested pick up date (Required).
    /// </summary>
    [Required(ErrorMessage = "RequestedPickUpDate is required")]
    
    public DateTimeRangeDto RequestedPickUpDate { get; set; } = default!;    
    /// <summary>
    /// Booking's actual pick up date (Optional).
    /// </summary>
    public DateTimeRangeDto? PickedUpDateTime { get; set; }    
    /// <summary>
    /// Booking's expiry date (Optional).
    /// </summary>
    public System.DateTimeOffset? ExpiryDateTime { get; set; }    
    /// <summary>
    /// Booking's cancelled date (Optional).
    /// </summary>
    public System.DateTimeOffset? CancelledDateTime { get; set; }    
    /// <summary>
    /// Booking's status (Optional).
    /// </summary>
    public System.String? Status { get; set; }    
    /// <summary>
    /// Booking's related vat number (Optional).
    /// </summary>
    public VatNumberDto? VatNumber { get; set; }

    /// <summary>
    /// Booking for ExactlyOne Customers
    /// </summary>
    [Required(ErrorMessage = "BookingForCustomer is required")]
    public System.Int64 BookingForCustomerId { get; set; } = default!;

    /// <summary>
    /// Booking related to ExactlyOne VendingMachines
    /// </summary>
    [Required(ErrorMessage = "BookingRelatedVendingMachine is required")]
    public System.Guid BookingRelatedVendingMachineId { get; set; } = default!;

    /// <summary>
    /// Booking fees for ExactlyOne Commissions
    /// </summary>
    [Required(ErrorMessage = "BookingFeesForCommission is required")]
    public System.Int64 BookingFeesForCommissionId { get; set; } = default!;

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