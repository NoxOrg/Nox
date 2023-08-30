// Generated

#nullable enable
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;
using CryptocashApi.Domain;

namespace CryptocashApi.Application.Dto;

public record PaymentProviderKeyDto(System.Int64 keyId);

/// <summary>
/// Payment provider related data.
/// </summary>
public partial class PaymentProviderDto
{

    /// <summary>
    /// The payment provider unique identifier (Required).
    /// </summary>
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// The payment provider name (Required).
    /// </summary>
    public System.String PaymentProviderName { get; set; } = default!;

    /// <summary>
    /// The payment account type (Required).
    /// </summary>
    public System.String PaymentProviderType { get; set; } = default!;
    public System.DateTime? DeletedAtUtc { get; set; }

    public PaymentProvider ToEntity()
    {
        var entity = new PaymentProvider();
        entity.Id = PaymentProvider.CreateId(Id);
        entity.PaymentProviderName = PaymentProvider.CreatePaymentProviderName(PaymentProviderName);
        entity.PaymentProviderType = PaymentProvider.CreatePaymentProviderType(PaymentProviderType);
        return entity;
    }

}