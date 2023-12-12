// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

using DomainNamespace = CryptocashIntegration.Domain;

namespace CryptocashIntegration.Application.Dto;

/// <summary>
/// Country and related data.
/// </summary>
public partial class CountryQueryToTableUpdateDto : CountryQueryToTableUpdateDtoBase
{

}

/// <summary>
/// Country and related data
/// </summary>
public partial class CountryQueryToTableUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.CountryQueryToTable>
{
    /// <summary>
    /// Country's name     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "Name is required")]
    
    public virtual System.String Name { get; set; } = default!;
    /// <summary>
    /// Country's population     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "Population is required")]
    
    public virtual System.Int32 Population { get; set; } = default!;
}