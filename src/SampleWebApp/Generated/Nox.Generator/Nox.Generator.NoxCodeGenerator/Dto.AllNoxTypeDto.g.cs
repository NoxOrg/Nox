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
/// Entity to test all nox types.
/// </summary>
[AutoMap(typeof(AllNoxTypeCreateDto))]
public partial class AllNoxTypeDto 
{

    /// <summary>
    /// DatabaseNumber Nox Type (Required).
    /// </summary>    
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// Second Text Id (Required).
    /// </summary>    
    public System.String TextId { get; set; } = default!;

    /// <summary>
    /// NuidField Type (Optional).
    /// </summary>
    public System.UInt32? NuidField { get; set; } 

    /// <summary>
    /// BooleanField Nox Type (Optional).
    /// </summary>
    public System.Boolean? BooleanField { get; set; } 

    /// <summary>
    /// CountryCode2 Nox Type (Required).
    /// </summary>
    public System.String CountryCode2Field { get; set; } = default!;

    /// <summary>
    /// CountryCode3 Nox Type (Optional).
    /// </summary>
    public System.String? CountryCode3Field { get; set; } 

    /// <summary>
    /// CountryNumber Nox Type (Optional).
    /// </summary>
    public System.Int16? CountryNumberField { get; set; } 

    /// <summary>
    /// CultureCode Nox Type (Optional).
    /// </summary>
    public System.String? CultureCodeField { get; set; } 

    /// <summary>
    /// CurrencyCode3Field Nox Type (Optional).
    /// </summary>
    public System.String? CurrencyCode3Field { get; set; } 

    /// <summary>
    /// DatetimeField Nox Type (Optional).
    /// </summary>
    public System.DateTimeOffset? DateTimeField { get; set; } 

    /// <summary>
    /// Formula Nox Type (Optional).
    /// </summary>
    [NotMapped]public System.String? FormulaField { get; set; } 

    /// <summary>
    /// HtmlField Nox Type (Optional).
    /// </summary>
    public System.String? HtmlField { get; set; } 

    /// <summary>
    /// MarkdownField Nox Type (Optional).
    /// </summary>
    public System.String? MarkdownField { get; set; } 

    /// <summary>
    /// Yaml Nox Type (Optional).
    /// </summary>
    public System.String? YamlField { get; set; } 

    /// <summary>
    /// YearField Nox Type (Optional).
    /// </summary>
    public System.Int16? YearField { get; set; } 

    /// <summary>
    /// Weight Nox Type (Optional).
    /// </summary>
    public System.Double? WeightField { get; set; } 

    /// <summary>
    /// Volume Nox Type (Optional).
    /// </summary>
    public System.Double? VolumeField { get; set; } 

    /// <summary>
    /// Url Nox Type (Optional).
    /// </summary>
    public System.String? UrlField { get; set; } 

    /// <summary>
    /// Uri Nox Type (Optional).
    /// </summary>
    public System.String? UriField { get; set; } 

    /// <summary>
    /// TimeZoneCode Nox Type (Optional).
    /// </summary>
    public System.String? TimeZoneCodeField { get; set; } 

    /// <summary>
    /// Temperature Nox Type (Optional).
    /// </summary>
    public System.Single? TemperatureField { get; set; } 

    /// <summary>
    /// Percentage Nox Type (Optional).
    /// </summary>
    public System.Single? PercentageField { get; set; } 

    /// <summary>
    /// Time Nox Type (Optional).
    /// </summary>
    public System.DateTimeOffset? TimeField { get; set; } 

    /// <summary>
    /// NumberField Nox Type (Optional).
    /// </summary>
    public System.Int32? NumberField { get; set; } 

    /// <summary>
    /// Text Nox Type (Required).
    /// </summary>
    public System.String TextField { get; set; } = default!;

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
    /// Money Nox Type (Optional).
    /// </summary>
    public MoneyDto? MoneyField { get; set; } 

    /// <summary>
    /// LatLongField Nox Type (Optional).
    /// </summary>
    public LatLongDto? LatLongField { get; set; } 
    public bool? Deleted { get; set; }
}