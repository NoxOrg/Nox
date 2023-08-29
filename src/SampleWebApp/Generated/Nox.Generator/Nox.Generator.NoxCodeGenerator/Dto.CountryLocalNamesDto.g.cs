﻿// Generated

#nullable enable
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;
using SampleWebApp.Application.DataTransferObjects;
using SampleWebApp.Domain;

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

    public CountryLocalNames ToEntity()
    {
        var entity = new CountryLocalNames();
        entity.Id = CountryLocalNames.CreateId(Id);
        return entity;
    }
}