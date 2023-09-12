// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

using MediatR;

using Nox.Types;
using Nox.Domain;
using Nox.Extensions;
using System.Text.Json.Serialization;
using ClientApi.Domain;

namespace ClientApi.Application.Dto;

public record CountryBarCodeKeyDto();

/// <summary>
/// Bar code for country.
/// </summary>
public partial class CountryBarCodeDto
{

    /// <summary>
    /// Bar code name (Required).
    /// </summary>
    public System.String BarCodeName { get; set; } = default!;

    /// <summary>
    /// Bar code number (Optional).
    /// </summary>
    public System.Int32? BarCodeNumber { get; set; }
}