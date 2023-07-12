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
    public string Id { get; set; } = default!;
    
    /// <summary>
    /// The country's common name.
    /// </summary>
    public string Name { get; set; } = default!;
    
    /// <summary>
    /// is also know as.
    /// </summary>
    public List<TenantWorkplaceContact> Contacts { get; set; } = null!;
}

/// <summary>
/// The tenant workplace.
/// </summary>
[AutoMap(typeof(TenantWorkplaceContactDto))]
public class TenantWorkplaceContact : SampleWebApp.Domain.AuditableEntityBase
{
    public string Id { get; set; } = default!;
    
    /// <summary>
    /// The country's common name.
    /// </summary>
    public string Name { get; set; } = default!;
}

/// <summary>
/// The list of countries.
/// </summary>
[AutoMap(typeof(CountryDto))]
public class Country : SampleWebApp.Domain.AuditableEntityBase
{
    public string Id { get; set; } = default!;
    
    /// <summary>
    /// The country's common name.
    /// </summary>
    public string Name { get; set; } = default!;
    
    /// <summary>
    /// The country's official name.
    /// </summary>
    public string FormalName { get; set; } = default!;
    
    /// <summary>
    /// The country's official ISO 4217 alpha-3 code.
    /// </summary>
    public string AlphaCode3 { get; set; } = default!;
    
    /// <summary>
    /// The country's official ISO 4217 alpha-2 code.
    /// </summary>
    public string AlphaCode2 { get; set; } = default!;
    
    /// <summary>
    /// The country's official ISO 4217 alpha-3 code.
    /// </summary>
    public string NumericCode { get; set; } = default!;
    
    /// <summary>
    /// The country's phone dialing codes (comma-delimited).
    /// </summary>
    public string? DialingCodes { get; set; } = default!;
    
    /// <summary>
    /// The capital city of the country.
    /// </summary>
    public string? Capital { get; set; } = default!;
    
    /// <summary>
    /// Noun denoting the natives of the country.
    /// </summary>
    public string? Demonym { get; set; } = default!;
    
    /// <summary>
    /// Country area in square kilometers.
    /// </summary>
    public string AreaInSquareKilometres { get; set; } = default!;
    
    /// <summary>
    /// The region the country is in.
    /// </summary>
    public string GeoRegion { get; set; } = default!;
    
    /// <summary>
    /// The sub-region the country is in.
    /// </summary>
    public string GeoSubRegion { get; set; } = default!;
    
    /// <summary>
    /// The world region the country is in.
    /// </summary>
    public string GeoWorldRegion { get; set; } = default!;
    
    /// <summary>
    /// The estimated population of the country.
    /// </summary>
    public string? Population { get; set; } = default!;
    
    /// <summary>
    /// The top level internet domains regitered to the country (comma-delimited).
    /// </summary>
    public string? TopLevelDomains { get; set; } = default!;
}

/// <summary>
/// The tenant workplace.
/// </summary>
public class TenantWorkplaceDto
{
    
    /// <summary>
    /// The country's common name.
    /// </summary>
    public string Name { get; set; } = default!;
}

/// <summary>
/// The tenant workplace.
/// </summary>
public class TenantWorkplaceContactDto
{
    
    /// <summary>
    /// The country's common name.
    /// </summary>
    public string Name { get; set; } = default!;
}

/// <summary>
/// The list of countries.
/// </summary>
public class CountryDto
{
    
    /// <summary>
    /// The country's common name.
    /// </summary>
    public string Name { get; set; } = default!;
    
    /// <summary>
    /// The country's official name.
    /// </summary>
    public string FormalName { get; set; } = default!;
    
    /// <summary>
    /// The country's official ISO 4217 alpha-3 code.
    /// </summary>
    public string AlphaCode3 { get; set; } = default!;
    
    /// <summary>
    /// The country's official ISO 4217 alpha-2 code.
    /// </summary>
    public string AlphaCode2 { get; set; } = default!;
    
    /// <summary>
    /// The country's official ISO 4217 alpha-3 code.
    /// </summary>
    public string NumericCode { get; set; } = default!;
    
    /// <summary>
    /// The country's phone dialing codes (comma-delimited).
    /// </summary>
    public string? DialingCodes { get; set; } = default!;
    
    /// <summary>
    /// The capital city of the country.
    /// </summary>
    public string? Capital { get; set; } = default!;
    
    /// <summary>
    /// Noun denoting the natives of the country.
    /// </summary>
    public string? Demonym { get; set; } = default!;
    
    /// <summary>
    /// Country area in square kilometers.
    /// </summary>
    public string AreaInSquareKilometres { get; set; } = default!;
    
    /// <summary>
    /// The region the country is in.
    /// </summary>
    public string GeoRegion { get; set; } = default!;
    
    /// <summary>
    /// The sub-region the country is in.
    /// </summary>
    public string GeoSubRegion { get; set; } = default!;
    
    /// <summary>
    /// The world region the country is in.
    /// </summary>
    public string GeoWorldRegion { get; set; } = default!;
    
    /// <summary>
    /// The estimated population of the country.
    /// </summary>
    public string? Population { get; set; } = default!;
    
    /// <summary>
    /// The top level internet domains regitered to the country (comma-delimited).
    /// </summary>
    public string? TopLevelDomains { get; set; } = default!;
}
