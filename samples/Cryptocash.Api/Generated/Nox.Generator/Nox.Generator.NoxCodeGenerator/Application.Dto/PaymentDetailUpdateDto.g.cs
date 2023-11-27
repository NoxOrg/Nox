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
/// Customer payment account related data.
/// </summary>
public partial class PaymentDetailUpdateDto : PaymentDetailUpdateDtoBase
{

}

/// <summary>
/// Patch entity PaymentDetail: Customer payment account related data.
/// </summary>
/// <remarks>Registered in OData for Delta feature. It is not suppose to extend this, extend update Dto instead</remarks>
public partial class PaymentDetailPatchDto: { { className} }
{

}

/// <summary>
/// Customer payment account related data
/// </summary>
public partial class PaymentDetailUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.PaymentDetail>
{
    /// <summary>
    /// Payment account name     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "PaymentAccountName is required")]
    
    public virtual System.String PaymentAccountName { get; set; } = default!;
    /// <summary>
    /// Payment account reference number     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "PaymentAccountNumber is required")]
    
    public virtual System.String PaymentAccountNumber { get; set; } = default!;
    /// <summary>
    /// Payment account sort code     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public virtual System.String? PaymentAccountSortCode { get; set; }
}