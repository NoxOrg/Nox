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

public record PaymentProviderKeyDto(System.Int64 keyId);

/// <summary>
/// Payment provider related data.
/// </summary>
public partial class PaymentProviderDto
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
        ValidateField("PaymentProviderName", () => Cryptocash.Domain.PaymentProvider.CreatePaymentProviderName(this.PaymentProviderName), result);
        ValidateField("PaymentProviderType", () => Cryptocash.Domain.PaymentProvider.CreatePaymentProviderType(this.PaymentProviderType), result);

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
    /// Payment provider unique identifier (Required).
    /// </summary>
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// Payment provider name (Required).
    /// </summary>
    public System.String PaymentProviderName { get; set; } = default!;

    /// <summary>
    /// Payment provider account type (Required).
    /// </summary>
    public System.String PaymentProviderType { get; set; } = default!;

    /// <summary>
    /// PaymentProvider related to ZeroOrMany PaymentDetails
    /// </summary>
    public virtual List<PaymentDetailDto> PaymentProviderRelatedPaymentDetails { get; set; } = new();
    public System.DateTime? DeletedAtUtc { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}