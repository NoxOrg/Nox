// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

using MediatR;

using Nox.Types;
using Nox.Domain;
using Nox.Extensions;

using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

public record PaymentProviderKeyDto(System.Int64 keyId);

/// <summary>
/// Payment provider related data.
/// </summary>
public partial class PaymentProviderDto
{

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
    /// PaymentProvider Payment provider ExactlyOne CustomerPaymentDetails
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.Int64 CustomerPaymentDetailsId { get; set; } = default!;
    public virtual CustomerPaymentDetailsDto CustomerPaymentDetails { get; set; } = null!;
    public System.DateTime? DeletedAtUtc { get; set; }    
}