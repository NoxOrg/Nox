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

    public CountryLocalName ToEntity()
    {
        var entity = new CountryLocalName();
        entity.Id = CountryLocalName.CreateId(Id);
        entity.Name = CountryLocalName.CreateName(Name);
        return entity;
    }
}