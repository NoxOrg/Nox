// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using SampleWebApp.Domain;

namespace SampleWebApp.Application.Dto;

/// <summary>
/// The name of a country in other languages.
/// </summary>
public partial class CountryLocalNameCreateDto : CountryLocalNameUpdateDto
{
    /// <summary>
    ///  (Required).
    /// </summary>
    [Required(ErrorMessage = "Id is required")]
    public System.String Id { get; set; } = default!;

    public CountryLocalName ToEntity()
    {
        var entity = new CountryLocalName();
        entity.Id = CountryLocalName.CreateId(Id);
        return entity;
    }
}