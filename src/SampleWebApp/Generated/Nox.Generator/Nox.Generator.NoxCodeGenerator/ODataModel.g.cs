// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;

namespace SampleWebApp.Presentation.Api.OData;


/// <summary>
/// The list of countries.
/// </summary>
public class Country : SampleWebApp.Domain.AuditableEntityBase
{
    public System.String Id { get; set; } = default!;
    
    /// <summary>
    /// The country's common name.
    /// </summary>
    public System.String Name { get; set; } = default!;
    
    /// <summary>
    /// The country's official name.
    /// </summary>
    public System.String FormalName { get; set; } = default!;
    
    /// <summary>
    /// The country's official ISO 4217 alpha-3 code.
    /// </summary>
    public System.String AlphaCode3 { get; set; } = default!;
    
    /// <summary>
    /// The country's official ISO 4217 alpha-2 code.
    /// </summary>
    public System.String AlphaCode2 { get; set; } = default!;
    
    /// <summary>
    /// The country's official ISO 4217 alpha-3 code.
    /// </summary>
    public System.Int32 NumericCode { get; set; } = default!;
    
    /// <summary>
    /// The country's phone dialing codes (comma-delimited).
    /// </summary>
    public System.String? DialingCodes { get; set; } = default!;
    
    /// <summary>
    /// The capital city of the country.
    /// </summary>
    public System.String? Capital { get; set; } = default!;
    
    /// <summary>
    /// Noun denoting the natives of the country.
    /// </summary>
    public System.String? Demonym { get; set; } = default!;
    
    /// <summary>
    /// Country area in square kilometers.
    /// </summary>
    public System.Int32 AreaInSquareKilometres { get; set; } = default!;
    
    /// <summary>
    /// The region the country is in.
    /// </summary>
    public System.String GeoRegion { get; set; } = default!;
    
    /// <summary>
    /// The sub-region the country is in.
    /// </summary>
    public System.String GeoSubRegion { get; set; } = default!;
    
    /// <summary>
    /// The world region the country is in.
    /// </summary>
    public System.String GeoWorldRegion { get; set; } = default!;
    
    /// <summary>
    /// The estimated population of the country.
    /// </summary>
    public System.Int32? Population { get; set; } = default!;
    
    /// <summary>
    /// The top level internet domains regitered to the country (comma-delimited).
    /// </summary>
    public System.String? TopLevelDomains { get; set; } = default!;
    
    /// <summary>
    /// accepts as legal tender.
    /// </summary>
    public List<Currency> Currencies { get; set; } = null!;
    
    /// <summary>
    /// is also know as.
    /// </summary>
    public List<CountryLocalNames> CountryLocalNames { get; set; } = null!;
}

/// <summary>
/// The list of currencies.
/// </summary>
public class Currency : SampleWebApp.Domain.AuditableEntityBase
{
    
    /// <summary>
    /// The currency's primary key / identifier.
    /// </summary>
    public System.String Id { get; set; } = default!;
    
    /// <summary>
    /// The currency's name.
    /// </summary>
    public System.String Name { get; set; } = default!;
    
    /// <summary>
    /// is legal tender for.
    /// </summary>
    public List<Country> Countries { get; set; } = null!;
}

/// <summary>
/// Stores.
/// </summary>
public class Store : SampleWebApp.Domain.AuditableEntityBase
{
    
    /// <summary>
    /// Store Primary Key.
    /// </summary>
    public System.String Id { get; set; } = default!;
    
    /// <summary>
    /// Store Name.
    /// </summary>
    public System.String Name { get; set; } = default!;
    
    /// <summary>
    /// Physical Money in the Physical Store.
    /// </summary>
    public System.Decimal PhysicalMoney_Amount { get; set; } = default!;
    
    /// <summary>
    /// Physical Money in the Physical Store.
    /// </summary>
    public System.String PhysicalMoney_CurrencyCode { get; set; } = default!;
}

/// <summary>
/// The name of a country in other languages.
/// </summary>
public class CountryLocalNames : SampleWebApp.Domain.AuditableEntityBase
{
    public System.String Id { get; set; } = default!;
}
