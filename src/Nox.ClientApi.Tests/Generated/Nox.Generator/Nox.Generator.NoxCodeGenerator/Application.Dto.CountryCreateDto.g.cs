// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using ClientApi.Domain;

namespace ClientApi.Application.Dto;

/// <summary>
/// Country Entity.
/// </summary>
public partial class CountryCreateDto : IEntityCreateDto <Country>
{    
    /// <summary>
    /// The Country Name (Required).
    /// </summary>
    [Required(ErrorMessage = "Name is required")]
    
    public System.String Name { get; set; } = default!;    
    /// <summary>
    /// Population (Optional).
    /// </summary>
    public System.Int32? Population { get; set; }    
    /// <summary>
    /// The Money (Optional).
    /// </summary>
    public MoneyDto? CountryDebt { get; set; }    
    /// <summary>
    /// First Official Language (Optional).
    /// </summary>
    public System.String? FirstLanguageCode { get; set; }    
    /// <summary>
    /// The Formula (Optional).
    /// </summary>
    public System.String? ShortDescription { get; set; }

    /// <summary>
    /// Country is also know as ZeroOrMany CountryLocalNames
    /// </summary>
    public virtual List<CountryLocalNameCreateDto> CountryLocalNames { get; set; } = new();   
}