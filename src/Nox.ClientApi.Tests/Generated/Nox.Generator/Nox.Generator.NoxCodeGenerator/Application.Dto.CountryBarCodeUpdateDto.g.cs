// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ClientApi.Domain;

namespace ClientApi.Application.Dto;

/// <summary>
/// Bar code for country.
/// </summary>
public partial class CountryBarCodeUpdateDto : IEntityDto<CountryBarCode>
{
    /// <summary>
    /// Bar code name (Required).
    /// </summary>
    [Required(ErrorMessage = "BarCodeName is required")]
    
    public System.String BarCodeName { get; set; } = default!;
    /// <summary>
    /// Bar code number (Optional).
    /// </summary>
    public System.Int32? BarCodeNumber { get; set; }
}