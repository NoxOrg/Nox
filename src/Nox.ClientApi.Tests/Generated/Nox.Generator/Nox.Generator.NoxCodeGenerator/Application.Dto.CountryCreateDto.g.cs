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

public partial class CountryCreateDto: CountryCreateDtoBase
{

}

/// <summary>
/// Country Entity.
/// </summary>
public abstract class CountryCreateDtoBase : IEntityCreateDto<Country>
{    
    /// <summary>
    /// The Country Name (Required).
    /// </summary>
    [Required(ErrorMessage = "Name is required")]
    
    public virtual System.String Name { get; set; } = default!;    
    /// <summary>
    /// Population (Optional).
    /// </summary>
    public virtual System.Int32? Population { get; set; }    
    /// <summary>
    /// The Money (Optional).
    /// </summary>
    public virtual MoneyDto? CountryDebt { get; set; }    
    /// <summary>
    /// First Official Language (Optional).
    /// </summary>
    public virtual System.String? FirstLanguageCode { get; set; }    
    /// <summary>
    /// The Formula (Optional).
    /// </summary>
    public virtual System.String? ShortDescription { get; set; }

    /// <summary>
    /// Country Country workplaces ZeroOrMany Workplaces
    /// </summary>
    public virtual List<WorkplaceCreateDto> PhysicalWorkplaces { get; set; } = new();

    /// <summary>
    /// Country is also know as ZeroOrMany CountryLocalNames
    /// </summary>
    public virtual List<CountryLocalNameCreateDto> CountryShortNames { get; set; } = new();

    /// <summary>
    /// Country is also coded as ZeroOrOne CountryBarCodes
    /// </summary>
    public virtual CountryBarCodeCreateDto? CountryBarCode { get; set; } = null!;
}