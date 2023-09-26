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

public record PaymentDetailKeyDto(System.Int64 keyId);

/// <summary>
/// Customer payment account related data.
/// </summary>
public partial class PaymentDetailDto
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
        ValidateField("PaymentAccountName", () => Cryptocash.Domain.PaymentDetail.CreatePaymentAccountName(this.PaymentAccountName), result);
        ValidateField("PaymentAccountNumber", () => Cryptocash.Domain.PaymentDetail.CreatePaymentAccountNumber(this.PaymentAccountNumber), result);
        if (this.PaymentAccountSortCode is not null)
            ValidateField("PaymentAccountSortCode", () => Cryptocash.Domain.PaymentDetail.CreatePaymentAccountSortCode(this.PaymentAccountSortCode.NonNullValue<System.String>()), result);

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
    /// Customer payment account unique identifier (Required).
    /// </summary>
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// Payment account name (Required).
    /// </summary>
    public System.String PaymentAccountName { get; set; } = default!;

    /// <summary>
    /// Payment account reference number (Required).
    /// </summary>
    public System.String PaymentAccountNumber { get; set; } = default!;

    /// <summary>
    /// Payment account sort code (Optional).
    /// </summary>
    public System.String? PaymentAccountSortCode { get; set; }

    /// <summary>
    /// PaymentDetail used by ExactlyOne Customers
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.Int64? PaymentDetailsUsedByCustomerId { get; set; } = default!;
    public virtual CustomerDto? PaymentDetailsUsedByCustomer { get; set; } = null!;

    /// <summary>
    /// PaymentDetail related to ExactlyOne PaymentProviders
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.Int64? PaymentDetailsRelatedPaymentProviderId { get; set; } = default!;
    public virtual PaymentProviderDto? PaymentDetailsRelatedPaymentProvider { get; set; } = null!;
    public System.DateTime? DeletedAtUtc { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}