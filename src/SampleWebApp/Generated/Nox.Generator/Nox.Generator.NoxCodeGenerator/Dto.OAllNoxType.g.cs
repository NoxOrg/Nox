// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using AutoMapper;
using MediatR;
using Nox.Types;
using Nox.Domain;
using SampleWebApp.Application.DataTransferObjects;
using SampleWebApp.Domain;

namespace SampleWebApp.Application.Dto;

/// <summary>
/// Entity to test all nox types.
/// </summary>
[AutoMap(typeof(AllNoxTypeCreateDto))]
public partial class OAllNoxType : AuditableEntityBase
{

    /// <summary>
    /// The currency's primary key / identifier (Required).
    /// </summary>
    public System.String Id { get; set; } = null!;

    /// <summary>
    /// Text Nox Type (Required).
    /// </summary>
    public System.String TextField { get; set; } = default!;

    /// <summary>
    /// VatNumber Nox Type (Required).
    /// </summary>
    public VatNumberDto VatNumberField { get; set; } = default!;

    /// <summary>
    /// CountryCode2 Nox Type (Required).
    /// </summary>
    public System.String CountryCode2Field { get; set; } = default!;

    /// <summary>
    /// CountryCode3 Nox Type (Required).
    /// </summary>
    public System.String CountryCode3Field { get; set; } = default!;

    /// <summary>
    /// Formula Nox Type (Optional).
    /// </summary>
    public System.String? FormulaField { get; set; } 
}