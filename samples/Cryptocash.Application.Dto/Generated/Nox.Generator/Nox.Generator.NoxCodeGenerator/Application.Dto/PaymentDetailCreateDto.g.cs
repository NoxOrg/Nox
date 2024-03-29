﻿// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

namespace Cryptocash.Application.Dto;

/// <summary>
/// Customer payment account related data.
/// </summary>
public partial class PaymentDetailCreateDto : PaymentDetailCreateDtoBase
{

}

/// <summary>
/// Customer payment account related data.
/// </summary>
public abstract class PaymentDetailCreateDtoBase 
{
    /// <summary>
    /// Payment account name     
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "PaymentAccountName is required")]
    
    public virtual System.String? PaymentAccountName { get; set; }
    /// <summary>
    /// Payment account reference number     
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "PaymentAccountNumber is required")]
    
    public virtual System.String? PaymentAccountNumber { get; set; }
    /// <summary>
    /// Payment account sort code     
    /// </summary>
    /// <remarks>Optional</remarks>
    public virtual System.String? PaymentAccountSortCode { get; set; }

    /// <summary>
    /// PaymentDetail used by ExactlyOne Customers
    /// </summary>
    public System.Guid? CustomerId { get; set; } = default!;
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual CustomerCreateDto? Customer { get; set; } = default!;

    /// <summary>
    /// PaymentDetail related to ExactlyOne PaymentProviders
    /// </summary>
    public System.Guid? PaymentProviderId { get; set; } = default!;
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual PaymentProviderCreateDto? PaymentProvider { get; set; } = default!;
}