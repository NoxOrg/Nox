﻿// Generated

#nullable enable

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using Nox.Application.Dto;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;


namespace Cryptocash.Application.Dto;

public record PaymentDetailKeyDto(System.Int64 keyId);

/// <summary>
/// Update PaymentDetail
/// Customer payment account related data.
/// </summary>
public partial class PaymentDetailDto : PaymentDetailDtoBase
{

}

/// <summary>
/// Customer payment account related data.
/// </summary>
public abstract class PaymentDetailDtoBase : EntityDtoBase
{
    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.PaymentAccountName is not null)
            CollectValidationExceptions("PaymentAccountName", () => PaymentDetailMetadata.CreatePaymentAccountName(this.PaymentAccountName.NonNullValue<System.String>()), result);
        else
            result.Add("PaymentAccountName", new [] { "PaymentAccountName is Required." });
    
        if (this.PaymentAccountNumber is not null)
            CollectValidationExceptions("PaymentAccountNumber", () => PaymentDetailMetadata.CreatePaymentAccountNumber(this.PaymentAccountNumber.NonNullValue<System.String>()), result);
        else
            result.Add("PaymentAccountNumber", new [] { "PaymentAccountNumber is Required." });
    
        if (this.PaymentAccountSortCode is not null)
            CollectValidationExceptions("PaymentAccountSortCode", () => PaymentDetailMetadata.CreatePaymentAccountSortCode(this.PaymentAccountSortCode.NonNullValue<System.String>()), result);

        return result;
    }
    #endregion

    /// <summary>
    /// Customer payment account unique identifier
    /// </summary>    
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// Payment account name     
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.String PaymentAccountName { get; set; } = default!;

    /// <summary>
    /// Payment account reference number     
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.String PaymentAccountNumber { get; set; } = default!;

    /// <summary>
    /// Payment account sort code     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.String? PaymentAccountSortCode { get; set; }

    /// <summary>
    /// PaymentDetail used by ExactlyOne Customers
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.Guid? CustomerId { get; set; } = default!;
    public virtual CustomerDto? Customer { get; set; } = null!;

    /// <summary>
    /// PaymentDetail related to ExactlyOne PaymentProviders
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.Guid? PaymentProviderId { get; set; } = default!;
    public virtual PaymentProviderDto? PaymentProvider { get; set; } = null!;
    [System.Text.Json.Serialization.JsonIgnore]
    public System.DateTime? DeletedAtUtc { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}