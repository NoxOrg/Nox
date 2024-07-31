// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

namespace CryptocashIntegration.Application.Dto;

/// <summary>
/// Country and related data for Json file integration.
/// </summary>
public partial class CountryJsonToTableUpdateDto : CountryJsonToTableUpdateDtoBase
{

}

/// <summary>
/// Country and related data for Json file integration
/// </summary>
public partial class CountryJsonToTableUpdateDtoBase: EntityDtoBase
{
    /// <summary>
    /// Country's name     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "Name is required")]
    
    public virtual System.String? Name { get; set; }
    /// <summary>
    /// Country's population     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "Population is required")]
    
    public virtual System.Int32? Population { get; set; }
    /// <summary>
    /// The date on which the country record was created     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "CreateDate is required")]
    
    public virtual System.DateTimeOffset? CreateDate { get; set; }
    /// <summary>
    /// The date on which the country record was last updated     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public virtual System.DateTimeOffset? EditDate { get; set; }
    /// <summary>
    /// This holds a calculated value, set in the transform function. value = NoFoInhabitants / 1million     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public virtual System.Int32? PopulationMillions { get; set; }
    /// <summary>
    /// This holds a concat of CountryName and ConcurrencyStamp, which is set in the transform function     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public virtual System.String? NameWithConcurrency { get; set; }
}