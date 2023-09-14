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

public partial class CountryLocalNameCreateDto: CountryLocalNameCreateDtoBase
{

}

/// <summary>
/// Local names for countries.
/// </summary>
public abstract class CountryLocalNameCreateDtoBase : IEntityCreateDto<CountryLocalName>
{    
    /// <summary>
    /// Local name (Required).
    /// </summary>
    [Required(ErrorMessage = "Name is required")]
    
    public virtual System.String Name { get; set; } = default!;    
    /// <summary>
    /// Local name in native tongue (Optional).
    /// </summary>
    public virtual System.String? NativeName { get; set; }
}