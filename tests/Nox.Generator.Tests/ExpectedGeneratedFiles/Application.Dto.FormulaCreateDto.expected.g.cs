// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using DomainNamespace = SampleWebApp.Domain;

namespace SampleWebApp.Application.Dto;

/// <summary>
/// Dto for formulas.
/// </summary>
public partial class FormulaCreateDto : FormulaCreateDtoBase
{

}

/// <summary>
/// Dto for formulas.
/// </summary>
public abstract class FormulaCreateDtoBase : IEntityDto<DomainNamespace.Formula>
{
    /// <summary>
    /// The identity of the formula    
    /// </summary>
    /// <remarks>Required.</remarks>    
    [Required(ErrorMessage = "Id is required")]
    public System.Int32 Id { get; set; } = default!;
    /// <summary>
    /// The name of the formula     
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "Name is required")]
    
    public virtual System.String Name { get; set; } = default!;
}