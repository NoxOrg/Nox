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

public record PaymentProviderKeyDto(System.Int64 keyId);

public partial class PaymentProviderDto : PaymentProviderDtoBase
{

}

/// <summary>
/// Payment provider related data.
/// </summary>
public abstract class PaymentProviderDtoBase : EntityDtoBase, IEntityDto<DomainNamespace.PaymentProvider>
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.PaymentProviderName is not null)
            ExecuteActionAndCollectValidationExceptions("PaymentProviderName", () => DomainNamespace.PaymentProviderMetadata.CreatePaymentProviderName(this.PaymentProviderName.NonNullValue<System.String>()), result);
        else
            result.Add("PaymentProviderName", new [] { "PaymentProviderName is Required." });
    
        if (this.PaymentProviderType is not null)
            ExecuteActionAndCollectValidationExceptions("PaymentProviderType", () => DomainNamespace.PaymentProviderMetadata.CreatePaymentProviderType(this.PaymentProviderType.NonNullValue<System.String>()), result);
        else
            result.Add("PaymentProviderType", new [] { "PaymentProviderType is Required." });
    

        return result;
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
    [System.Text.Json.Serialization.JsonIgnore]
    public System.DateTime? DeletedAtUtc { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}