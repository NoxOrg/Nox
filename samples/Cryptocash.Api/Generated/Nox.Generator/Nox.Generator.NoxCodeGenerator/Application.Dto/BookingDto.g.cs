// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using MediatR;

using Nox.Application.Dto;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;


using DomainNamespace = Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

public record BookingKeyDto(System.Guid keyId);

/// <summary>
/// Update Booking
/// Exchange booking and related data.
/// </summary>
public partial class BookingDto : BookingDtoBase
{

}

/// <summary>
/// Exchange booking and related data.
/// </summary>
public abstract class BookingDtoBase : EntityDtoBase, IEntityDto<DomainNamespace.Booking>
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.AmountFrom is not null)
            ExecuteActionAndCollectValidationExceptions("AmountFrom", () => DomainNamespace.BookingMetadata.CreateAmountFrom(this.AmountFrom.NonNullValue<MoneyDto>()), result);
        else
            result.Add("AmountFrom", new [] { "AmountFrom is Required." });
    
        if (this.AmountTo is not null)
            ExecuteActionAndCollectValidationExceptions("AmountTo", () => DomainNamespace.BookingMetadata.CreateAmountTo(this.AmountTo.NonNullValue<MoneyDto>()), result);
        else
            result.Add("AmountTo", new [] { "AmountTo is Required." });
    
        if (this.RequestedPickUpDate is not null)
            ExecuteActionAndCollectValidationExceptions("RequestedPickUpDate", () => DomainNamespace.BookingMetadata.CreateRequestedPickUpDate(this.RequestedPickUpDate.NonNullValue<DateTimeRangeDto>()), result);
        else
            result.Add("RequestedPickUpDate", new [] { "RequestedPickUpDate is Required." });
    
        if (this.PickedUpDateTime is not null)
            ExecuteActionAndCollectValidationExceptions("PickedUpDateTime", () => DomainNamespace.BookingMetadata.CreatePickedUpDateTime(this.PickedUpDateTime.NonNullValue<DateTimeRangeDto>()), result);
        if (this.ExpiryDateTime is not null)
            ExecuteActionAndCollectValidationExceptions("ExpiryDateTime", () => DomainNamespace.BookingMetadata.CreateExpiryDateTime(this.ExpiryDateTime.NonNullValue<System.DateTimeOffset>()), result);
        if (this.CancelledDateTime is not null)
            ExecuteActionAndCollectValidationExceptions("CancelledDateTime", () => DomainNamespace.BookingMetadata.CreateCancelledDateTime(this.CancelledDateTime.NonNullValue<System.DateTimeOffset>()), result); 
        if (this.VatNumber is not null)
            ExecuteActionAndCollectValidationExceptions("VatNumber", () => DomainNamespace.BookingMetadata.CreateVatNumber(this.VatNumber.NonNullValue<VatNumberDto>()), result);

        return result;
    }
    #endregion

    /// <summary>
    /// Booking unique identifier
    /// </summary>    
    public System.Guid Id { get; set; } = default!;

    /// <summary>
    /// Booking's amount exchanged from     
    /// </summary>
    /// <remarks>Required.</remarks>    
    public MoneyDto AmountFrom { get; set; } = default!;

    /// <summary>
    /// Booking's amount exchanged to     
    /// </summary>
    /// <remarks>Required.</remarks>    
    public MoneyDto AmountTo { get; set; } = default!;

    /// <summary>
    /// Booking's requested pick up date     
    /// </summary>
    /// <remarks>Required.</remarks>    
    public DateTimeRangeDto RequestedPickUpDate { get; set; } = default!;

    /// <summary>
    /// Booking's actual pick up date     
    /// </summary>
    /// <remarks>Optional.</remarks>    
    public DateTimeRangeDto? PickedUpDateTime { get; set; }

    /// <summary>
    /// Booking's expiry date     
    /// </summary>
    /// <remarks>Optional.</remarks>    
    public System.DateTimeOffset? ExpiryDateTime { get; set; }

    /// <summary>
    /// Booking's cancelled date     
    /// </summary>
    /// <remarks>Optional.</remarks>    
    public System.DateTimeOffset? CancelledDateTime { get; set; }

    /// <summary>
    /// Booking's status     
    /// </summary>
    /// <remarks>Optional.</remarks>    
    public System.String? Status { get; set; }

    /// <summary>
    /// Booking's related vat number     
    /// </summary>
    /// <remarks>Optional.</remarks>    
    public VatNumberDto? VatNumber { get; set; }

    /// <summary>
    /// Booking for ExactlyOne Customers
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.Int64? CustomerId { get; set; } = default!;
    public virtual CustomerDto? Customer { get; set; } = null!;

    /// <summary>
    /// Booking related to ExactlyOne VendingMachines
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.Guid? VendingMachineId { get; set; } = default!;
    public virtual VendingMachineDto? VendingMachine { get; set; } = null!;

    /// <summary>
    /// Booking fees for ExactlyOne Commissions
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.Int64? CommissionId { get; set; } = default!;
    public virtual CommissionDto? Commission { get; set; } = null!;

    /// <summary>
    /// Booking related to ExactlyOne Transactions
    /// </summary>
    public virtual TransactionDto? Transaction { get; set; } = null!;
    [System.Text.Json.Serialization.JsonIgnore]
    public System.DateTime? DeletedAtUtc { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}