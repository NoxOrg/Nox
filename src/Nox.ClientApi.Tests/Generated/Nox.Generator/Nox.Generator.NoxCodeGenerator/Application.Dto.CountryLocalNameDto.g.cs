﻿// Generated

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

public record CountryLocalNameKeyDto(System.Int64 keyId);

/// <summary>
/// Local names for countries.
/// </summary>
public partial class CountryLocalNameDto
{

    /// <summary>
    /// The unique identifier (Required).
    /// </summary>
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// Local name (Required).
    /// </summary>
    public System.String Name { get; set; } = default!;

    /// <summary>
    /// Local name in native tongue (Optional).
    /// </summary>
    public System.String? NativeName { get; set; }
}