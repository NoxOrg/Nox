﻿// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Cryptocash.Domain;

using PaymentProviderEntity = Cryptocash.Domain.PaymentProvider;
namespace Cryptocash.Application.Dto;

/// <summary>
/// Payment provider related data.
/// </summary>
public partial class PaymentProviderUpdateDto : IEntityDto<PaymentProviderEntity>
{
    /// <summary>
    /// Payment provider name (Required).
    /// </summary>
    [Required(ErrorMessage = "PaymentProviderName is required")]
    
    public System.String PaymentProviderName { get; set; } = default!;
    /// <summary>
    /// Payment provider account type (Required).
    /// </summary>
    [Required(ErrorMessage = "PaymentProviderType is required")]
    
    public System.String PaymentProviderType { get; set; } = default!;
}