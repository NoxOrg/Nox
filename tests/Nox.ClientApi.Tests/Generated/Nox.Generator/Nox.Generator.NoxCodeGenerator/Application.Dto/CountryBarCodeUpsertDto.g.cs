﻿// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

namespace ClientApi.Application.Dto;

/// <summary>
/// Bar code for country.
/// </summary>
public partial class CountryBarCodeUpsertDto : CountryBarCodeUpsertDtoBase
{

}

/// <summary>
/// Bar code for country
/// </summary>
public abstract class CountryBarCodeUpsertDtoBase: EntityDtoBase
{

    /// <summary>
    /// Bar code name     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "BarCodeName is required")]
    public virtual System.String? BarCodeName { get; set; }

    /// <summary>
    /// Bar code number     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public virtual System.Int32? BarCodeNumber { get; set; }
}