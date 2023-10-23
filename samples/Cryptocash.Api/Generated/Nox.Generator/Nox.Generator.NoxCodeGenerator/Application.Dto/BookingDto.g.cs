﻿// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations.Schema;

using MediatR;

using Nox.Application.Dto;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;
using System.Text.Json.Serialization;
using Cryptocash.Domain;
using BookingEntity = Cryptocash.Domain.Booking;

namespace Cryptocash.Application.Dto;

public record BookingKeyDto(System.Guid keyId);

public partial class BookingDto : BookingDtoBase
{

}

/// <summary>
/// Exchange booking and related data.
/// </summary>
public abstract class BookingDtoBase : EntityDtoBase, IEntityDto<BookingEntity>
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.AmountFrom is not null)
            ExecuteActionAndCollectValidationExceptions("AmountFrom", () => Cryptocash.Domain.BookingMetadata.CreateAmountFrom(this.AmountFrom.NonNullValue<MoneyDto>()), result);
        else
            result.Add("AmountFrom", new [] { "AmountFrom is Required." });
    
        if (this.AmountTo is not null)
            ExecuteActionAndCollectValidationExceptions("AmountTo", () => Cryptocash.Domain.BookingMetadata.CreateAmountTo(this.AmountTo.NonNullValue<MoneyDto>()), result);
        else
            result.Add("AmountTo", new [] { "AmountTo is Required." });
    
        if (this.RequestedPickUpDate is not null)
            ExecuteActionAndCollectValidationExceptions("RequestedPickUpDate", () => Cryptocash.Domain.BookingMetadata.CreateRequestedPickUpDate(this.RequestedPickUpDate.NonNullValue<DateTimeRangeDto>()), result);
        else
            result.Add("RequestedPickUpDate", new [] { "RequestedPickUpDate is Required." });
    
        if (this.PickedUpDateTime is not null)
            ExecuteActionAndCollectValidationExceptions("PickedUpDateTime", () => Cryptocash.Domain.BookingMetadata.CreatePickedUpDateTime(this.PickedUpDateTime.NonNullValue<DateTimeRangeDto>()), result);
        if (this.ExpiryDateTime is not null)
            ExecuteActionAndCollectValidationExceptions("ExpiryDateTime", () => Cryptocash.Domain.BookingMetadata.CreateExpiryDateTime(this.ExpiryDateTime.NonNullValue<System.DateTimeOffset>()), result);
        if (this.CancelledDateTime is not null)
            ExecuteActionAndCollectValidationExceptions("CancelledDateTime", () => Cryptocash.Domain.BookingMetadata.CreateCancelledDateTime(this.CancelledDateTime.NonNullValue<System.DateTimeOffset>()), result); 
        if (this.VatNumber is not null)
            ExecuteActionAndCollectValidationExceptions("VatNumber", () => Cryptocash.Domain.BookingMetadata.CreateVatNumber(this.VatNumber.NonNullValue<VatNumberDto>()), result);

        return result;
    }
    #endregion

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
    /// Booking for ExactlyOne Customers
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.Int64? BookingForCustomerId { get; set; } = default!;
    public virtual CustomerDto? BookingForCustomer { get; set; } = null!;

    /// <summary>
    /// Booking related to ExactlyOne VendingMachines
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.Guid? BookingRelatedVendingMachineId { get; set; } = default!;
    public virtual VendingMachineDto? BookingRelatedVendingMachine { get; set; } = null!;

    /// <summary>
    /// Booking fees for ExactlyOne Commissions
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.Int64? BookingFeesForCommissionId { get; set; } = default!;
    public virtual CommissionDto? BookingFeesForCommission { get; set; } = null!;

    /// <summary>
    /// Booking related to ExactlyOne Transactions
    /// </summary>
    public virtual TransactionDto? BookingRelatedTransaction { get; set; } = null!;
    [System.Text.Json.Serialization.JsonIgnore]
    public System.DateTime? DeletedAtUtc { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}