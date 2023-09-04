// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

using MediatR;

using Nox.Types;
using Nox.Domain;
using Nox.Extensions;

using SampleWebApp.Domain;

namespace SampleWebApp.Application.Dto;

public record CountryKeyDto(System.String keyId);

/// <summary>
/// The list of countries.
/// </summary>
public partial class CountryDto
{

    /// <summary>
    ///  (Required).
    /// </summary>
    public System.String Id { get; set; } = default!;

    /// <summary>
    /// The country's common name (Required).
    /// </summary>
    public System.String Name { get; set; } = default!;

    /// <summary>
    /// The country's official name (Required).
    /// </summary>
    public System.String FormalName { get; set; } = default!;

    /// <summary>
    /// The country's official ISO 4217 alpha-3 code (Required).
    /// </summary>
    public System.String AlphaCode3 { get; set; } = default!;

    /// <summary>
    /// The country's official ISO 4217 alpha-2 code (Required).
    /// </summary>
    public System.String AlphaCode2 { get; set; } = default!;

    /// <summary>
    /// The country's official ISO 4217 alpha-3 code (Required).
    /// </summary>
    public System.Int16 NumericCode { get; set; } = default!;

    /// <summary>
    /// The country's phone dialing codes (comma-delimited) (Optional).
    /// </summary>
    public System.String? DialingCodes { get; set; }

    /// <summary>
    /// The capital city of the country (Optional).
    /// </summary>
    public System.String? Capital { get; set; }

    /// <summary>
    /// Noun denoting the natives of the country (Optional).
    /// </summary>
    public System.String? Demonym { get; set; }

    /// <summary>
    /// Country area in square kilometers (Required).
    /// </summary>
    public System.Int32 AreaInSquareKilometres { get; set; } = default!;

    /// <summary>
    /// The the position of the workplace's point on the surface of the Earth (Optional).
    /// </summary>
    public LatLongDto? GeoCoord { get; set; }

    /// <summary>
    /// The region the country is in (Required).
    /// </summary>
    public System.String GeoRegion { get; set; } = default!;

    /// <summary>
    /// The sub-region the country is in (Required).
    /// </summary>
    public System.String GeoSubRegion { get; set; } = default!;

    /// <summary>
    /// The world region the country is in (Required).
    /// </summary>
    public System.String GeoWorldRegion { get; set; } = default!;

    /// <summary>
    /// The estimated population of the country (Optional).
    /// </summary>
    public System.Int32? Population { get; set; }

    /// <summary>
    /// The top level internet domains regitered to the country (comma-delimited) (Optional).
    /// </summary>
    public System.String? TopLevelDomains { get; set; }
    public System.DateTime? DeletedAtUtc { get; set; }    
}