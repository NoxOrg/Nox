// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

namespace ClientApi.Application.Dto;

/// <summary>
/// Currency and related data.
/// </summary>
public partial class CurrencyUpdateDto : CurrencyUpdateDtoBase
{

}

/// <summary>
/// Currency and related data
/// </summary>
public partial class CurrencyUpdateDtoBase: EntityDtoBase
{
    /// <summary>
    /// Currency's name     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public virtual System.String? Name { get; set; }
    /// <summary>
    /// Currency's symbol     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public virtual System.String? Symbol { get; set; }
}