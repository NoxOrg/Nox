// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

using MediatR;

using Nox.Types;
using Nox.Domain;
using Nox.Extensions;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using SampleWebApp.Domain;

namespace SampleWebApp.Application.Dto;

public record CountryLocalNameKeyDto(System.String keyId);

/// <summary>
/// The name of a country in other languages.
/// </summary>
public partial class CountryLocalNameDto
{

    /// <summary>
    ///  (Required).
    /// </summary>
    public System.String Id { get; set; } = default!;

    /// <summary>
    ///  (Optional).
    /// </summary>
    public System.String? Name { get; set; }
}