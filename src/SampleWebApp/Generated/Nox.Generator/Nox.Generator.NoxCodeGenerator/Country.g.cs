// Generated

#nullable enable

using Nox.Types;
using System;
using System.Collections.Generic;

namespace SampleWebApp.Domain;

/// <summary>
/// The list of countries.
/// </summary>
public partial class Country : AuditableEntityBase
{

    /// <summary>
    ///  (Required).
    /// </summary>
    public Text Id { get; set; } = null!;

    /// <summary>
    /// The country's common name (Required).
    /// </summary>
    public Text Name { get; set; } = null!;

    /// <summary>
    /// The country's official name (Required).
    /// </summary>
    public Text FormalName { get; set; } = null!;

    /// <summary>
    /// The country's official ISO 4217 alpha-3 code (Required).
    /// </summary>
    public Text AlphaCode3 { get; set; } = null!;

    /// <summary>
    /// The country's official ISO 4217 alpha-2 code (Required).
    /// </summary>
    public Text AlphaCode2 { get; set; } = null!;

    /// <summary>
    /// The country's official ISO 4217 alpha-3 code (Required).
    /// </summary>
    public Number NumericCode { get; set; } = null!;

    /// <summary>
    /// The country's phone dialing codes (comma-delimited) (Optional).
    /// </summary>
    public Text? DialingCodes { get; set; } = null!;

    /// <summary>
    /// The capital city of the country (Optional).
    /// </summary>
    public Text? Capital { get; set; } = null!;

    /// <summary>
    /// Noun denoting the natives of the country (Optional).
    /// </summary>
    public Text? Demonym { get; set; } = null!;

    /// <summary>
    /// Country area in square kilometers (Required).
    /// </summary>
    public Area AreaInSquareKilometres { get; set; } = null!;

    /// <summary>
    /// The region the country is in (Required).
    /// </summary>
    public Text GeoRegion { get; set; } = null!;

    /// <summary>
    /// The sub-region the country is in (Required).
    /// </summary>
    public Text GeoSubRegion { get; set; } = null!;

    /// <summary>
    /// The world region the country is in (Required).
    /// </summary>
    public Text GeoWorldRegion { get; set; } = null!;

    /// <summary>
    /// The estimated population of the country (Optional).
    /// </summary>
    public Number? Population { get; set; } = null!;

    /// <summary>
    /// The top level internet domains regitered to the country (comma-delimited) (Optional).
    /// </summary>
    public Text? TopLevelDomains { get; set; } = null!;
    /// <summary>
    /// Country accepts as legal tender OneOrMany Currencies
    /// </summary>
    public virtual List<Currency> Currencies { get; set; } = new();
    
    public List<Currency> CountryAcceptsCurrency => Currencies;
    /// <summary>
    /// Country is also know as OneOrMany CountryLocalNames
    /// </summary>
    public virtual List<CountryLocalNames> CountryLocalNames { get; set; } = new();
}