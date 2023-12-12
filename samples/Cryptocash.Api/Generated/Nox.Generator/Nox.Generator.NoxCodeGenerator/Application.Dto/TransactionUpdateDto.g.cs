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
/// Customer transaction log and related data.
/// </summary>
public partial class TransactionUpdateDto : TransactionUpdateDtoBase
{

}

/// <summary>
/// Customer transaction log and related data
/// </summary>
public partial class TransactionUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.Transaction>
{
    /// <summary>
    /// Transaction type     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "TransactionType is required")]
    
    public virtual System.String? TransactionType { get; set; }
    /// <summary>
    /// Transaction processed datetime     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "ProcessedOnDateTime is required")]
    
    public virtual System.DateTimeOffset? ProcessedOnDateTime { get; set; }
    /// <summary>
    /// Transaction amount     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "Amount is required")]
    
    public virtual MoneyDto? Amount { get; set; }
    /// <summary>
    /// Transaction external reference     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "Reference is required")]
    
    public virtual System.String? Reference { get; set; }
}