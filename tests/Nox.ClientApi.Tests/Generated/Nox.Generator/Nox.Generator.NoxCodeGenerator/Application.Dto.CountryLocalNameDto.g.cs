// Generated

#nullable enable
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;
using ClientApi.Domain;

namespace ClientApi.Application.Dto;

public record CountryLocalNameKeyDto(System.String keyId);

/// <summary>
/// Local names for countries.
/// </summary>
public partial class CountryLocalNameDto
{

    /// <summary>
    /// The unique identifier (Required).
    /// </summary>
    public System.String Id { get; set; } = default!;

    /// <summary>
    /// Local name (Required).
    /// </summary>
    public System.String Name { get; set; } = default!;

    public CountryLocalName ToEntity()
    {
        var entity = new CountryLocalName();
        entity.Id = CountryLocalName.CreateId(Id);
        entity.Name = CountryLocalName.CreateName(Name);
        return entity;
    }

}