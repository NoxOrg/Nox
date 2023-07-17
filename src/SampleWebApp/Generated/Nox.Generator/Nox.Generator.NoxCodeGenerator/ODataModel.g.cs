// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using AutoMapper;

namespace SampleWebApp.Presentation.Api.OData;


/// <summary>
/// The tenant workplace.
/// </summary>
[AutoMap(typeof(TenantWorkplaceDto))]
public class TenantWorkplace : SampleWebApp.Domain.AuditableEntityBase
{
    public System.String Id { get; set; } = default!;
    
    /// <summary>
    /// The country's common name.
    /// </summary>
    public System.String Name { get; set; } = default!;
    
    /// <summary>
    /// is also know as.
    /// </summary>
    [AutoExpand]
    public List<TenantWorkplaceContact> Contacts { get; set; } = null!;
}

/// <summary>
/// The tenant workplace.
/// </summary>
[AutoMap(typeof(TenantWorkplaceContactDto))]
public class TenantWorkplaceContact : SampleWebApp.Domain.AuditableEntityBase
{
    public System.String Id { get; set; } = default!;
    
    /// <summary>
    /// The country's common name.
    /// </summary>
    public System.String Name { get; set; } = default!;
    
    /// <summary>
    /// The the position of the workplace's point on the surface of the Earth.
    /// </summary>
    public System.Decimal? Balance_Amount { get; set; } = default!;
    
    /// <summary>
    /// The the position of the workplace's point on the surface of the Earth.
    /// </summary>
    public System.String? Balance_CurrencyCode { get; set; } = default!;
}

/// <summary>
/// The list of countries.
/// </summary>
[AutoMap(typeof(CountryDto))]
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
    public System.Double NumericCode { get; set; } = default!;
    
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
    public System.Double AreaInSquareKilometres { get; set; } = default!;
    
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
    public System.Double? Population { get; set; } = default!;
    
    /// <summary>
    /// The top level internet domains regitered to the country (comma-delimited).
    /// </summary>
    public System.String? TopLevelDomains { get; set; } = default!;
}

/// <summary>
/// The tenant workplace.
/// </summary>
public class TenantWorkplaceDto
{
    
    /// <summary>
    /// The country's common name.
    /// </summary>
    public System.String Name { get; set; } = default!;
}

/// <summary>
/// The tenant workplace.
/// </summary>
public class TenantWorkplaceContactDto
{
    
    /// <summary>
    /// The country's common name.
    /// </summary>
    public System.String Name { get; set; } = default!;
    
    /// <summary>
    /// The the position of the workplace's point on the surface of the Earth.
    /// </summary>
    public System.Decimal? Balance_Amount { get; set; } = default!;
    
    /// <summary>
    /// The the position of the workplace's point on the surface of the Earth.
    /// </summary>
    public System.String? Balance_CurrencyCode { get; set; } = default!;
}

/// <summary>
/// The list of countries.
/// </summary>
public class CountryDto
{
    
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
    public System.Double NumericCode { get; set; } = default!;
    
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
    public System.Double AreaInSquareKilometres { get; set; } = default!;
    
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
    public System.Double? Population { get; set; } = default!;
    
    /// <summary>
    /// The top level internet domains regitered to the country (comma-delimited).
    /// </summary>
    public System.String? TopLevelDomains { get; set; } = default!;
}
