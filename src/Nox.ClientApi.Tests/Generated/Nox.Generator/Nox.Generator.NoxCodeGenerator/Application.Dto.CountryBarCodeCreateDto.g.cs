// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using CountryBarCodeEntity = ClientApi.Domain.CountryBarCode;
using ClientApi.Domain;

namespace ClientApi.Application.Dto;

public partial class CountryBarCodeCreateDto : CountryBarCodeCreateDtoBase
{

}

/// <summary>
/// Bar code for country.
/// </summary>
public abstract class CountryBarCodeCreateDtoBase : IEntityDto<CountryBarCodeEntity>
{
    /// <summary>
    /// Bar code name (Required).
    /// </summary>
    [Required(ErrorMessage = "BarCodeName is required")]
    
    public virtual System.String BarCodeName { get; set; } = default!;
    /// <summary>
    /// Bar code number (Optional).
    /// </summary>
    public virtual System.Int32? BarCodeNumber { get; set; }
}