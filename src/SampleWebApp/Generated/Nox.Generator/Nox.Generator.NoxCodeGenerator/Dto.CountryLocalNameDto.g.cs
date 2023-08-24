// Generated

#nullable enable
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Nox.Types;
using Nox.Domain;
using SampleWebApp.Application.DataTransferObjects;
using SampleWebApp.Domain;

namespace SampleWebApp.Application.Dto;

public class CountryLocalNameKeyDto
{

    /// <summary>
    ///  (Required).
    /// </summary>
    [Key]
    public System.String Id { get; set; } = default!;
}

/// <summary>
/// The name of a country in other languages.
/// </summary>
public partial class CountryLocalNameDto : CountryLocalNameKeyDto
{
}