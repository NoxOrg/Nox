// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

using MediatR;

using Nox.Types;
using Nox.Domain;
using Nox.Extensions;
using System.Text.Json.Serialization;
using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

public record TransactionKeyDto(System.Int64 keyId);

/// <summary>
/// Customer transaction log and related data.
/// </summary>
public partial class TransactionDto
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
        ValidateField("TransactionType", () => Cryptocash.Domain.Transaction.CreateTransactionType(this.TransactionType), result);
        ValidateField("ProcessedOnDateTime", () => Cryptocash.Domain.Transaction.CreateProcessedOnDateTime(this.ProcessedOnDateTime), result);
        ValidateField("Amount", () => Cryptocash.Domain.Transaction.CreateAmount(this.Amount), result);
        ValidateField("Reference", () => Cryptocash.Domain.Transaction.CreateReference(this.Reference), result);

        return result;
    }

    private void ValidateField<T>(string fieldName, Func<T> action, Dictionary<string, IEnumerable<string>> result)
    {
        try
        {
            action();
        }
        catch (TypeValidationException ex)
        {
            result.Add(fieldName, ex.Errors.Select(x => x.ErrorMessage));
        }
        catch (NullReferenceException)
        {
            result.Add(fieldName, new List<string> { $"{fieldName} is Required." });
        }
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
    public System.DateTime? DeletedAtUtc { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}