// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace SampleWebApp.Domain;

/// <summary>
/// The list of countries.
/// </summary>
public partial class Country : AuditableEntityBase, IConcurrent
{
    /// <summary>
    ///  (Required).
    /// </summary>
    public DatabaseNumber Id { get; set; } = null!;

    /// <summary>
    /// The country's common name (Required).
    /// </summary>
    public Nox.Types.Text Name { get; set; } = null!;

    /// <summary>
    /// The country's official name (Required).
    /// </summary>
    public Nox.Types.Text FormalName { get; set; } = null!;

    /// <summary>
    /// The country's official ISO 4217 alpha-3 code (Optional).
    /// </summary>
    public Nox.Types.CountryCode3? AlphaCode3 { get; set; } = null!;

    /// <summary>
    /// The country's official ISO 4217 alpha-2 code (Required).
    /// </summary>
    public Nox.Types.CountryCode2 AlphaCode2 { get; set; } = null!;

    /// <summary>
    /// The country's official ISO 4217 alpha-3 code (Required).
    /// </summary>
    public Nox.Types.Number NumericCode { get; set; } = null!;

    /// <summary>
    /// The country's phone dialing codes (comma-delimited) (Optional).
    /// </summary>
    public Nox.Types.Text? DialingCodes { get; set; } = null!;

    /// <summary>
    /// The capital city of the country (Optional).
    /// </summary>
    public Nox.Types.Text? Capital { get; set; } = null!;

    /// <summary>
    /// Noun denoting the natives of the country (Optional).
    /// </summary>
    public Nox.Types.Text? Demonym { get; set; } = null!;

    /// <summary>
    /// Country area in square kilometers (Required).
    /// </summary>
    public Nox.Types.Area AreaInSquareKilometres { get; set; } = null!;

    /// <summary>
    /// The the position of the workplace's point on the surface of the Earth (Optional).
    /// </summary>
    public Nox.Types.LatLong? GeoCoord { get; set; } = null!;

    /// <summary>
    /// The region the country is in (Required).
    /// </summary>
    public Nox.Types.Text GeoRegion { get; set; } = null!;

    /// <summary>
    /// The sub-region the country is in (Required).
    /// </summary>
    public Nox.Types.Text GeoSubRegion { get; set; } = null!;

    /// <summary>
    /// The world region the country is in (Required).
    /// </summary>
    public Nox.Types.Text GeoWorldRegion { get; set; } = null!;

    /// <summary>
    /// The estimated population of the country (Optional).
    /// </summary>
    public Nox.Types.Number? Population { get; set; } = null!;

    /// <summary>
    /// The top level internet domains regitered to the country (comma-delimited) (Optional).
    /// </summary>
    public Nox.Types.Text? TopLevelDomains { get; set; } = null!;

    /// <summary>
    /// Country accepts as legal tender OneOrMany Currencies
    /// </summary>
    public virtual List<Currency> CountryAcceptsCurrency { get; set; } = new();

    /// <summary>
    /// Country is also know as OneOrMany CountryLocalNames
    /// </summary>
    public virtual List<CountryLocalName> CountryLocalNames { get; set; } = new();

    public List<CountryLocalName> CountryLocalName => CountryLocalNames;

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public Nox.Types.Guid Etag { get; set; } = Nox.Types.Guid.NewGuid();
}