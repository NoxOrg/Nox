// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

namespace ClientApi.Application.Dto;

/// <summary>
/// Local names for countries.
/// </summary>
public partial class CountryLocalNameUpsertDto : CountryLocalNameUpsertDtoBase
{

}

/// <summary>
/// Local names for countries
/// </summary>
public abstract class CountryLocalNameUpsertDtoBase: EntityDtoBase
{

    /// <summary>
    /// The unique identifier
    /// </summary>
    public virtual System.Int64? Id { get; set; }

    /// <summary>
    /// Local name     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "Name is required")]
    public virtual System.String? Name { get; set; }

    /// <summary>
    /// Local name in native tongue     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public virtual System.String? NativeName { get; set; }
}