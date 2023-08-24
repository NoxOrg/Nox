// Generated

#nullable enable
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Nox.Types;
using Nox.Domain;
using ClientApi.Application.DataTransferObjects;
using ClientApi.Domain;

namespace ClientApi.Application.Dto;

public class CountryLocalNameKeyDto
{

    /// <summary>
    /// The unique identifier (Required).
    /// </summary>
    [Key]
    public System.String Id { get; set; } = default!;
}

/// <summary>
/// Local names for countries.
/// </summary>
public partial class CountryLocalNameDto : CountryLocalNameKeyDto
{

    /// <summary>
    /// Local name (Required).
    /// </summary>
    public System.String Name { get; set; } = default!;
}