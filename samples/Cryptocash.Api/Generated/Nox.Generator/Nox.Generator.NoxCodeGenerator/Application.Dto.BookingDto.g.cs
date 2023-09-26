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

public record BookingKeyDto(System.Guid keyId);

/// <summary>
/// Exchange booking and related data.
/// </summary>
public partial class BookingDto
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
        ValidateField("AmountFrom", () => Cryptocash.Domain.Booking.CreateAmountFrom(this.AmountFrom), result);
        ValidateField("AmountTo", () => Cryptocash.Domain.Booking.CreateAmountTo(this.AmountTo), result);
        ValidateField("RequestedPickUpDate", () => Cryptocash.Domain.Booking.CreateRequestedPickUpDate(this.RequestedPickUpDate), result);
        if (this.PickedUpDateTime is not null)
            ValidateField("PickedUpDateTime", () => Cryptocash.Domain.Booking.CreatePickedUpDateTime(this.PickedUpDateTime.NonNullValue<DateTimeRangeDto>()), result);
        if (this.ExpiryDateTime is not null)
            ValidateField("ExpiryDateTime", () => Cryptocash.Domain.Booking.CreateExpiryDateTime(this.ExpiryDateTime.NonNullValue<System.DateTimeOffset>()), result);
        if (this.CancelledDateTime is not null)
            ValidateField("CancelledDateTime", () => Cryptocash.Domain.Booking.CreateCancelledDateTime(this.CancelledDateTime.NonNullValue<System.DateTimeOffset>()), result); 
        if (this.VatNumber is not null)
            ValidateField("VatNumber", () => Cryptocash.Domain.Booking.CreateVatNumber(this.VatNumber.NonNullValue<VatNumberDto>()), result);

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
    public System.DateTime? DeletedAtUtc { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}