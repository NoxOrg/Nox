// Generated

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
/// Patch entity PaymentProvider: Payment provider related data.
/// </summary>
/// <remarks>Registered in OData for Delta feature. It is not suppose to extend this, extend update Dto instead</remarks>
public partial class PaymentProviderPatchDto: { { className} }
{

}

/// <summary>
/// Payment provider related data
/// </summary>
public partial class PaymentProviderUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.PaymentProvider>
{
    /// <summary>
    /// Payment provider name     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "PaymentProviderName is required")]
    
    public virtual System.String PaymentProviderName { get; set; } = default!;
    /// <summary>
    /// Payment provider account type     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "PaymentProviderType is required")]
    
    public virtual System.String PaymentProviderType { get; set; } = default!;
}