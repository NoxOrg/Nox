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
public partial class CountryLocalNameCreateDto : CountryLocalNameUpdateDto
{
    /// <summary>
    /// The unique identifier (Required).
    /// </summary>
    [Required(ErrorMessage = "Id is required")]
    public System.String Id { get; set; } = default!;

    public ClientApi.Domain.CountryLocalName ToEntity()
    {
        var entity = new ClientApi.Domain.CountryLocalName();
        entity.Id = CountryLocalName.CreateId(Id);
        entity.Name = ClientApi.Domain.CountryLocalName.CreateName(Name);
        return entity;
    }
}