// Generated

#nullable enable

using AutoMapper;
using MediatR;

using Microsoft.AspNetCore.Http;

using System.ComponentModel.DataAnnotations.Schema;

using Nox.Types;
using Nox.Domain;
using SampleWebApp.Application.DataTransferObjects;
using SampleWebApp.Domain;

namespace SampleWebApp.Application.Dto;

/// <summary>
/// The name of a country in other languages.
/// </summary>
[AutoMap(typeof(CountryLocalNamesCreateDto))]
public partial class CountryLocalNamesDto 
{

    /// <summary>
    ///  (Required).
    /// </summary>    
    public System.String Id { get; set; } = default!;

    public System.DateTime? DeletedAtUtc { get; set; }

    public System.Boolean? IsDeleted => DeletedAtUtc is not null;
}