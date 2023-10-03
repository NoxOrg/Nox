// Generated

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

namespace Cryptocash.Application.Dto;

public record TransactionKeyDto(System.Int64 keyId);

public partial class TransactionDto : TransactionDtoBase
{

}

/// <summary>
/// Customer transaction log and related data.
/// </summary>
public abstract class TransactionDtoBase : EntityDtoBase, IEntityDto<Transaction>
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.TransactionType is not null)
            ExecuteActionAndCollectValidationExceptions("TransactionType", () => Cryptocash.Domain.TransactionMetadata.CreateTransactionType(this.TransactionType.NonNullValue<System.String>()), result);
        else
            result.Add("TransactionType", new [] { "TransactionType is Required." });
    
        ExecuteActionAndCollectValidationExceptions("ProcessedOnDateTime", () => Cryptocash.Domain.TransactionMetadata.CreateProcessedOnDateTime(this.ProcessedOnDateTime), result);
    
        if (this.Amount is not null)
            ExecuteActionAndCollectValidationExceptions("Amount", () => Cryptocash.Domain.TransactionMetadata.CreateAmount(this.Amount.NonNullValue<MoneyDto>()), result);
        else
            result.Add("Amount", new [] { "Amount is Required." });
    
        if (this.Reference is not null)
            ExecuteActionAndCollectValidationExceptions("Reference", () => Cryptocash.Domain.TransactionMetadata.CreateReference(this.Reference.NonNullValue<System.String>()), result);
        else
            result.Add("Reference", new [] { "Reference is Required." });
    

        return result;
    }
    #endregion

    /// <summary>
    /// Customer transaction unique identifier (Required).
    /// </summary>
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// Transaction type (Required).
    /// </summary>
    public System.String TransactionType { get; set; } = default!;

    /// <summary>
    /// Transaction processed datetime (Required).
    /// </summary>
    public System.DateTimeOffset ProcessedOnDateTime { get; set; } = default!;

    /// <summary>
    /// Transaction amount (Required).
    /// </summary>
    public MoneyDto Amount { get; set; } = default!;

    /// <summary>
    /// Transaction external reference (Required).
    /// </summary>
    public System.String Reference { get; set; } = default!;

    /// <summary>
    /// Transaction for ExactlyOne Customers
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.Int64? TransactionForCustomerId { get; set; } = default!;
    public virtual CustomerDto? TransactionForCustomer { get; set; } = null!;

    /// <summary>
    /// Transaction for ExactlyOne Bookings
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.Guid? TransactionForBookingId { get; set; } = default!;
    public virtual BookingDto? TransactionForBooking { get; set; } = null!;
    [System.Text.Json.Serialization.JsonIgnore]
    public System.DateTime? DeletedAtUtc { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}