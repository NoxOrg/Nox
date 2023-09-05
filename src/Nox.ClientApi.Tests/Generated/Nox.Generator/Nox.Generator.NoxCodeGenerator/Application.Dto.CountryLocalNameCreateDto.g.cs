// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using ClientApi.Domain;

namespace ClientApi.Application.Dto;

/// <summary>
/// Local names for countries.
/// </summary>
public partial class CountryLocalNameCreateDto 
{    
    /// <summary>
    /// Local name (Required).
    /// </summary>
    [Required(ErrorMessage = "Name is required")]
    
    public System.String Name { get; set; } = default!;

    public ClientApi.Domain.CountryLocalName ToEntity()
    {
        var entity = new ClientApi.Domain.CountryLocalName();
        entity.Name = ClientApi.Domain.CountryLocalName.CreateName(Name);
        return entity;
    }
}