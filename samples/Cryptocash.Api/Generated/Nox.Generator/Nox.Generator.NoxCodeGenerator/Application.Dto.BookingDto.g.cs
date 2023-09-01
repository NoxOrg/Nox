// Generated

#nullable enable
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;
using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

public record BookingKeyDto(System.Guid keyId);

/// <summary>
/// Exchange booking and related data.
/// </summary>
public partial class BookingDto
{

    /// <summary>
    /// Booking unique identifier (Required).
    /// </summary>
    public System.Guid Id { get; set; } = default!;

    /// <summary>
    /// Booking's amount exchanged from (Required).
    /// </summary>
    public MoneyDto AmountFrom { get; set; } = default!;

    /// <summary>
    /// Booking's amount exchanged to (Required).
    /// </summary>
    public MoneyDto AmountTo { get; set; } = default!;

    /// <summary>
    /// Booking's requested pick up date (Required).
    /// </summary>
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
    /// Booking Booking's customer ExactlyOne Customers
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.Int64 CustomerId { get; set; } = default!;
    public virtual CustomerDto Customer { get; set; } = null!;

    /// <summary>
    /// Booking Booking's vending machine ExactlyOne VendingMachines
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.Guid VendingMachineId { get; set; } = default!;
    public virtual VendingMachineDto VendingMachine { get; set; } = null!;

    /// <summary>
    /// Booking Booking's fee ExactlyOne Commissions
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.Int64 CommissionId { get; set; } = default!;
    public virtual CommissionDto Commission { get; set; } = null!;

    /// <summary>
    /// Booking Transaction's booking ExactlyOne CustomerTransactions
    /// </summary>
    public virtual CustomerTransactionDto CustomerTransaction { get; set; } = null!;
    public System.DateTime? DeletedAtUtc { get; set; }

    public Booking ToEntity()
    {
        var entity = new Booking();
        entity.Id = Booking.CreateId(Id);
        entity.AmountFrom = Booking.CreateAmountFrom(AmountFrom);
        entity.AmountTo = Booking.CreateAmountTo(AmountTo);
        entity.RequestedPickUpDate = Booking.CreateRequestedPickUpDate(RequestedPickUpDate);
        if (PickedUpDateTime is not null)entity.PickedUpDateTime = Booking.CreatePickedUpDateTime(PickedUpDateTime.NonNullValue<DateTimeRangeDto>());
        if (ExpiryDateTime is not null)entity.ExpiryDateTime = Booking.CreateExpiryDateTime(ExpiryDateTime.NonNullValue<System.DateTimeOffset>());
        if (CancelledDateTime is not null)entity.CancelledDateTime = Booking.CreateCancelledDateTime(CancelledDateTime.NonNullValue<System.DateTimeOffset>());
        if (VatNumber is not null)entity.VatNumber = Booking.CreateVatNumber(VatNumber.NonNullValue<VatNumberDto>());
        entity.Customer = Customer.ToEntity();
        entity.VendingMachine = VendingMachine.ToEntity();
        entity.Commission = Commission.ToEntity();
        entity.CustomerTransaction = CustomerTransaction.ToEntity();
        return entity;
    }

}