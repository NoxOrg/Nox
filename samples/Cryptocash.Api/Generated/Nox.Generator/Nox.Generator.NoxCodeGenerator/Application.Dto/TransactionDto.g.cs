// Generated

#nullable enable

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using Nox.Application.Dto;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;


using DomainNamespace = Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

public record TransactionKeyDto(System.Guid keyId);

/// <summary>
/// Update Transaction
/// Customer transaction log and related data.
/// </summary>
public partial class TransactionDto : TransactionDtoBase
{

}

/// <summary>
/// Customer transaction log and related data.
/// </summary>
public abstract class TransactionDtoBase : EntityDtoBase, IEntityDto<DomainNamespace.Transaction>
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.TransactionType is not null)
            ExecuteActionAndCollectValidationExceptions("TransactionType", () => DomainNamespace.TransactionMetadata.CreateTransactionType(this.TransactionType.NonNullValue<System.String>()), result);
        else
            result.Add("TransactionType", new [] { "TransactionType is Required." });
    
        ExecuteActionAndCollectValidationExceptions("ProcessedOnDateTime", () => DomainNamespace.TransactionMetadata.CreateProcessedOnDateTime(this.ProcessedOnDateTime), result);
    
        if (this.Amount is not null)
            ExecuteActionAndCollectValidationExceptions("Amount", () => DomainNamespace.TransactionMetadata.CreateAmount(this.Amount.NonNullValue<MoneyDto>()), result);
        else
            result.Add("Amount", new [] { "Amount is Required." });
    
        if (this.Reference is not null)
            ExecuteActionAndCollectValidationExceptions("Reference", () => DomainNamespace.TransactionMetadata.CreateReference(this.Reference.NonNullValue<System.String>()), result);
        else
            result.Add("Reference", new [] { "Reference is Required." });
    

        return result;
    }
    #endregion

    /// <summary>
    /// Customer transaction unique identifier
    /// </summary>    
    public System.Guid Id { get; set; } = default!;

    /// <summary>
    /// Transaction type     
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.String TransactionType { get; set; } = default!;

    /// <summary>
    /// Transaction processed datetime     
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.DateTimeOffset ProcessedOnDateTime { get; set; } = default!;

    /// <summary>
    /// Transaction amount     
    /// </summary>
    /// <remarks>Required.</remarks>
    public MoneyDto Amount { get; set; } = default!;

    /// <summary>
    /// Transaction external reference     
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.String Reference { get; set; } = default!;

    /// <summary>
    /// Transaction for ExactlyOne Customers
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.Guid? CustomerId { get; set; } = default!;
    public virtual CustomerDto? Customer { get; set; } = null!;

    /// <summary>
    /// Transaction for ExactlyOne Bookings
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.Guid? BookingId { get; set; } = default!;
    public virtual BookingDto? Booking { get; set; } = null!;
    [System.Text.Json.Serialization.JsonIgnore]
    public System.DateTime? DeletedAtUtc { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}