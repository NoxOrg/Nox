﻿// Generated

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

public record CountryLocalNamesKeyDto(System.String keyId);

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
    public bool? Deleted { get; set; }
}