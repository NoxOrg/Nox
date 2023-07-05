// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;

namespace SampleWebApp.Presentation.Api.OData;


/// <summary>
/// The list of countries.
/// </summary>
public class Country
{
    public System.String Id { get; set; }
    
    /// <summary>
    /// The country's common name.
    /// </summary>
    public System.String Name { get; set; }
    
    /// <summary>
    /// The country's official name.
    /// </summary>
    public System.String FormalName { get; set; }
    
    /// <summary>
    /// The country's official ISO 4217 alpha-3 code.
    /// </summary>
    public System.String AlphaCode3 { get; set; }
    
    /// <summary>
    /// The country's official ISO 4217 alpha-2 code.
    /// </summary>
    public System.String AlphaCode2 { get; set; }
    
    /// <summary>
    /// The country's official ISO 4217 alpha-3 code.
    /// </summary>
    public System.Int32 NumericCode { get; set; }
    
    /// <summary>
    /// The country's phone dialing codes (comma-delimited).
    /// </summary>
    public System.String? DialingCodes { get; set; }
    
    /// <summary>
    /// The capital city of the country.
    /// </summary>
    public System.String? Capital { get; set; }
    
    /// <summary>
    /// Noun denoting the natives of the country.
    /// </summary>
    public System.String? Demonym { get; set; }
    
    /// <summary>
    /// Country area in square kilometers.
    /// </summary>
    public System.Int32 AreaInSquareKilometres { get; set; }
    
    /// <summary>
    /// The region the country is in.
    /// </summary>
    public System.String GeoRegion { get; set; }
    
    /// <summary>
    /// The sub-region the country is in.
    /// </summary>
    public System.String GeoSubRegion { get; set; }
    
    /// <summary>
    /// The world region the country is in.
    /// </summary>
    public System.String GeoWorldRegion { get; set; }
    
    /// <summary>
    /// The estimated population of the country.
    /// </summary>
    public System.Int32? Population { get; set; }
    
    /// <summary>
    /// The top level internet domains regitered to the country (comma-delimited).
    /// </summary>
    public System.String? TopLevelDomains { get; set; }
}

/// <summary>
/// The list of currencies.
/// </summary>
public class Currency
{
    
    /// <summary>
    /// The currency's primary key / identifier.
    /// </summary>
    public System.String Id { get; set; }
    
    /// <summary>
    /// The currency's name.
    /// </summary>
    public System.String Name { get; set; }
    
    /// <summary>
    /// is legal tender for.
    /// </summary>
    public List<Country> Countries { get; set; } = null!;
}

/// <summary>
/// Stores.
/// </summary>
public class Store
{
    
    /// <summary>
    /// Store Primary Key.
    /// </summary>
    public System.String Id { get; set; }
    
    /// <summary>
    /// Store Name.
    /// </summary>
    public System.String Name { get; set; }
    
    /// <summary>
    /// Physical Money in the Physical Store.
    /// </summary>
    public string PhysicalMoney { get; set; }
}

/// <summary>
/// The name of a country in other languages.
/// </summary>
public class CountryLocalNames
{
    public System.String Id { get; set; }
}
