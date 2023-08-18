// Generated

#nullable enable
using MediatR;

using Microsoft.AspNetCore.Http;

using System.ComponentModel.DataAnnotations.Schema;

using Nox.Types;
using Nox.Domain;
using SampleWebApp.Application.DataTransferObjects;
using SampleWebApp.Domain;
using Microsoft.OData.ModelBuilder;

namespace SampleWebApp.Application.Dto;

public record CountryLocalNamesKeyDto(System.String keyId);

/// <summary>
/// The name of a country in other languages.
/// </summary>
public partial class CountryLocalNamesDto 
{

    /// <summary>
    ///  (Required).
    /// </summary>
    public System.String Id { get; set; } = default!;
    public bool? Deleted { get; set; }
}