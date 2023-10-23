﻿// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using PaymentProviderEntity = Cryptocash.Domain.PaymentProvider;
using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

public partial class PaymentProviderCreateDto : PaymentProviderCreateDtoBase
{

}

/// <summary>
/// Payment provider related data.
/// </summary>
public abstract class PaymentProviderCreateDtoBase : IEntityDto<PaymentProviderEntity>
{
    /// <summary>
    /// Payment provider name (Required).
    /// </summary>
    [Required(ErrorMessage = "PaymentProviderName is required")]
    
    public virtual System.String PaymentProviderName { get; set; } = default!;
    /// <summary>
    /// Payment provider account type (Required).
    /// </summary>
    [Required(ErrorMessage = "PaymentProviderType is required")]
    
    public virtual System.String PaymentProviderType { get; set; } = default!;

    /// <summary>
    /// PaymentProvider related to ZeroOrMany PaymentDetails
    /// </summary>
    
    [System.Text.Json.Serialization.JsonIgnore] 
    public virtual List<PaymentDetailCreateDto> PaymentProviderRelatedPaymentDetails { get; set; } = new();
}