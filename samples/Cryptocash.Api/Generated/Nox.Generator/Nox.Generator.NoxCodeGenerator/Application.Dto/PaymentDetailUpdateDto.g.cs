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
/// Customer payment account related data
/// </summary>
public partial class PaymentDetailUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.PaymentDetail>
{
    /// <summary>
    /// Payment account name 
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "PaymentAccountName is required")]
    
    public virtual System.String PaymentAccountName { get; set; } = default!;
    /// <summary>
    /// Payment account reference number 
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "PaymentAccountNumber is required")]
    
    public virtual System.String PaymentAccountNumber { get; set; } = default!;
    /// <summary>
    /// Payment account sort code 
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public virtual System.String? PaymentAccountSortCode { get; set; }
}