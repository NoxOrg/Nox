// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using DomainNamespace = CryptocashIntegration.Domain;

namespace CryptocashIntegration.Application.Dto;

/// <summary>
/// Country and related data.
/// </summary>
public partial class CountryQueryToTableCreateDto : CountryQueryToTableCreateDtoBase
{

}

/// <summary>
/// Country and related data.
/// </summary>
public abstract class CountryQueryToTableCreateDtoBase : IEntityDto<DomainNamespace.CountryQueryToTable>
{
    /// <summary>
    /// Country unique identifier    
    /// </summary>
    /// <remarks>Required.</remarks>    
    [Required(ErrorMessage = "Id is required")]
    public virtual System.Int32? Id { get; set; }
    /// <summary>
    /// Country's name     
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "Name is required")]
    
    public virtual System.String? Name { get; set; }
    /// <summary>
    /// Country's population     
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "Population is required")]
    
    public virtual System.Int32? Population { get; set; }
}