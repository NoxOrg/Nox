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
    /// DatabaseNumber Nox Type (Required).
    /// </summary>
    public System.Int32 Id { get; set; } = default!;

    /// <summary>
    /// Text Nox Type (Required).
    /// </summary>
    public System.String TextField { get; set; } = default!;

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

    /// <summary>
    /// StreetAddress Nox Type (Optional).
    /// </summary>
    public StreetAddressDto? StreetAddressField { get; set; } 

    /// <summary>
    /// File Nox Type (Optional).
    /// </summary>
    public FileDto? FileField { get; set; } 

    /// <summary>
    /// TranslatedText Nox Type (Optional).
    /// </summary>
    public TranslatedTextDto? TranslatedTextField { get; set; } 

    /// <summary>
    /// VatNumber Nox Type (Optional).
    /// </summary>
    public VatNumberDto? VatNumberField { get; set; } 

    /// <summary>
    /// Password Nox Type (Optional).
    /// </summary>
    public PasswordDto? PasswordField { get; set; } 

    /// <summary>
    /// Money Nox Type (Optional).
    /// </summary>
    public MoneyDto? MoneyField { get; set; } 

    /// <summary>
    /// HashedTex Nox Type (Optional).
    /// </summary>
    public HashedTextDto? HashedTexField { get; set; } 

    /// <summary>
    /// LatLongField Nox Type (Optional).
    /// </summary>
    public LatLongDto? LatLongField { get; set; } 
}