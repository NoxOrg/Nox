﻿// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

using DomainNamespace = Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

/// <summary>
/// Payment provider related data.
/// </summary>
public partial class PaymentProviderUpdateDto : PaymentProviderUpdateDtoBase
{

}

/// <summary>
/// Payment provider related data
/// </summary>
public partial class PaymentProviderUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.PaymentProvider>
{
    /// <summary>
    /// Payment provider name 
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "PaymentProviderName is required")]
    
    public virtual System.String PaymentProviderName { get; set; } = default!;
    /// <summary>
    /// Payment provider account type 
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "PaymentProviderType is required")]
    
    public virtual System.String PaymentProviderType { get; set; } = default!;

    /// <summary>
    /// PaymentProvider related to ZeroOrMany PaymentDetails
    /// </summary>
    public virtual List<System.Int64> PaymentDetailsId { get; set; } = new();
}