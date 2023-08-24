// Generated

#nullable enable
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using Nox.Types;
using Nox.Domain;
using ClientApi.Application.DataTransferObjects;
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
}