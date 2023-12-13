﻿// Generated

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
public partial class CountryQueryToCustomTableCreateDto : CountryQueryToCustomTableCreateDtoBase
{

}

/// <summary>
/// Country and related data.
/// </summary>
public abstract class CountryQueryToCustomTableCreateDtoBase : IEntityDto<DomainNamespace.CountryQueryToCustomTable>
{
    /// <summary>
    /// Country unique identifier    
    /// </summary>
    /// <remarks>Required.</remarks>    
    [Required(ErrorMessage = "Id is required")]
    public System.Int32 Id { get; set; } = default!;
    /// <summary>
    /// Country's name     
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "Name is required")]
    
    public virtual System.String Name { get; set; } = default!;
    /// <summary>
    /// Country's population     
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "Population is required")]
    
    public virtual System.Int32 Population { get; set; } = default!;
    /// <summary>
    /// The date on which the country record was created     
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "CreateDate is required")]
    
    public virtual System.DateTimeOffset CreateDate { get; set; } = default!;
    /// <summary>
    /// The date on which the country record was last updated     
    /// </summary>
    /// <remarks>Optional</remarks>
    public virtual System.DateTimeOffset? EditDate { get; set; }
}