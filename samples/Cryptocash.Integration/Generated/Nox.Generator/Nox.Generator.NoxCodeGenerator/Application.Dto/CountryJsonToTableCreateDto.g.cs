// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

namespace CryptocashIntegration.Application.Dto;

/// <summary>
/// Country and related data for Json file integration.
/// </summary>
public partial class CountryJsonToTableCreateDto : CountryJsonToTableCreateDtoBase
{

}

/// <summary>
/// Country and related data for Json file integration.
/// </summary>
public abstract class CountryJsonToTableCreateDtoBase 
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
    /// <summary>
    /// The date on which the country record was created     
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "CreateDate is required")]
    
    public virtual System.DateTimeOffset? CreateDate { get; set; }
    /// <summary>
    /// The date on which the country record was last updated     
    /// </summary>
    /// <remarks>Optional</remarks>
    public virtual System.DateTimeOffset? EditDate { get; set; }
}