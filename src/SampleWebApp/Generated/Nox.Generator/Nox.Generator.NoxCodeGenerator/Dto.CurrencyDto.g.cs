﻿// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;
using MediatR;
using Nox.Types;
using Nox.Domain;
using SampleWebApp.Application.DataTransferObjects;
using SampleWebApp.Domain;

namespace SampleWebApp.Application.Dto;

/// <summary>
/// The list of currencies.
/// </summary>
[AutoMap(typeof(CurrencyCreateDto))]
public partial class CurrencyDto : AuditableEntityBase
{

    /// <summary>
    /// The currency's primary key / identifier (Required).
    /// </summary>
    public System.UInt32 Id { get; set; } = default!;

    /// <summary>
    /// The currency's name (Required).
    /// </summary>
    public System.String Name { get; set; } = default!;

    /// <summary>
    /// Currency is legal tender for ZeroOrMany Countries
    /// </summary>
    public virtual List<CountryDto> Countries { get; set; } = new();
}