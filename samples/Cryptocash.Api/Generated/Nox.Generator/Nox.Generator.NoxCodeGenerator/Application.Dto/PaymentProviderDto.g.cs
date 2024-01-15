// Generated

#nullable enable

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using Nox.Application.Dto;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;


namespace Cryptocash.Application.Dto;

public record PaymentProviderKeyDto(System.Guid keyId);

/// <summary>
/// Update PaymentProvider
/// Payment provider related data.
/// </summary>
public partial class PaymentProviderDto : PaymentProviderDtoBase
{

}

/// <summary>
/// Payment provider related data.
/// </summary>
public abstract class PaymentProviderDtoBase : EntityDtoBase
{
    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.PaymentProviderName is not null)
            CollectValidationExceptions("PaymentProviderName", () => PaymentProviderMetadata.CreatePaymentProviderName(this.PaymentProviderName.NonNullValue<System.String>()), result);
        else
            result.Add("PaymentProviderName", new [] { "PaymentProviderName is Required." });
    
        if (this.PaymentProviderType is not null)
            CollectValidationExceptions("PaymentProviderType", () => PaymentProviderMetadata.CreatePaymentProviderType(this.PaymentProviderType.NonNullValue<System.String>()), result);
        else
            result.Add("PaymentProviderType", new [] { "PaymentProviderType is Required." });
    

        return result;
    }
    #endregion

    /// <summary>
    /// Payment provider unique identifier
    /// </summary>    
    public System.Guid Id { get; set; } = default!;

    /// <summary>
    /// Payment provider name     
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.String PaymentProviderName { get; set; } = default!;

    /// <summary>
    /// Payment provider account type     
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.String PaymentProviderType { get; set; } = default!;

    /// <summary>
    /// PaymentProvider related to ZeroOrMany PaymentDetails
    /// </summary>
    public virtual List<PaymentDetailDto> PaymentDetails { get; set; } = new();
    [System.Text.Json.Serialization.JsonIgnore]
    public System.DateTime? DeletedAtUtc { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}