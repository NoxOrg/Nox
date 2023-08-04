﻿// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using AutoMapper;
using MediatR;
using Nox.Types;
using Nox.Domain;

namespace SampleWebApp.Presentation.Api.OData;


/// <summary>
/// The list of countries.
/// </summary>
[AutoMap(typeof(CountryDto))]
public class OCountry : AuditableEntityBase
{
    public String Id { get; set; } = default!;
    
    /// <summary>
    /// The country's common name.
    /// </summary>
    public String Name { get; set; } = default!;
    
    /// <summary>
    /// The country's official name.
    /// </summary>
    public String FormalName { get; set; } = default!;
    
    /// <summary>
    /// The country's official ISO 4217 alpha-3 code.
    /// </summary>
    public String AlphaCode3 { get; set; } = default!;
    
    /// <summary>
    /// The country's official ISO 4217 alpha-2 code.
    /// </summary>
    public String AlphaCode2 { get; set; } = default!;
    
    /// <summary>
    /// The country's official ISO 4217 alpha-3 code.
    /// </summary>
    public Int16 NumericCode { get; set; } = default!;
    
    /// <summary>
    /// The country's phone dialing codes (comma-delimited).
    /// </summary>
    public String? DialingCodes { get; set; } = default!;
    
    /// <summary>
    /// The capital city of the country.
    /// </summary>
    public String? Capital { get; set; } = default!;
    
    /// <summary>
    /// Noun denoting the natives of the country.
    /// </summary>
    public String? Demonym { get; set; } = default!;
    
    /// <summary>
    /// Country area in square kilometers.
    /// </summary>
    public Decimal AreaInSquareKilometres { get; set; } = default!;
    
    /// <summary>
    /// The region the country is in.
    /// </summary>
    public String GeoRegion { get; set; } = default!;
    
    /// <summary>
    /// The sub-region the country is in.
    /// </summary>
    public String GeoSubRegion { get; set; } = default!;
    
    /// <summary>
    /// The world region the country is in.
    /// </summary>
    public String GeoWorldRegion { get; set; } = default!;
    
    /// <summary>
    /// The estimated population of the country.
    /// </summary>
    public Int32? Population { get; set; } = default!;
    
    /// <summary>
    /// The top level internet domains regitered to the country (comma-delimited).
    /// </summary>
    public String? TopLevelDomains { get; set; } = default!;
    
    /// <summary>
    /// accepts as legal tender.
    /// </summary>
    public List<OCurrency> Currencies { get; set; } = null!;
}

/// <summary>
/// The list of currencies.
/// </summary>
[AutoMap(typeof(CurrencyDto))]
public class OCurrency : AuditableEntityBase
{
    
    /// <summary>
    /// The currency's primary key / identifier.
    /// </summary>
    public String Id { get; set; } = default!;
    
    /// <summary>
    /// The currency's name.
    /// </summary>
    public String Name { get; set; } = default!;
    
    /// <summary>
    /// is legal tender for.
    /// </summary>
    public List<OCountry> Countries { get; set; } = null!;
}

/// <summary>
/// Stores.
/// </summary>
[AutoMap(typeof(StoreDto))]
public class OStore : AuditableEntityBase
{
    
    /// <summary>
    /// Store Primary Key.
    /// </summary>
    public String Id { get; set; } = default!;
    
    /// <summary>
    /// Store Name.
    /// </summary>
    public String Name { get; set; } = default!;
    
    /// <summary>
    /// Physical Money in the Physical Store.
    /// </summary>
    public Decimal PhysicalMoney_Amount { get; set; } = default!;
    
    /// <summary>
    /// Physical Money in the Physical Store.
    /// </summary>
    public CurrencyCode PhysicalMoney_CurrencyCode { get; set; } = default!;
    
    /// <summary>
    /// Set of passwords for this store.
    /// </summary>
    public OStoreSecurityPasswords StoreSecurityPasswords { get; set; } = null!;
}

/// <summary>
/// A set of security passwords to store cameras and databases.
/// </summary>
[AutoMap(typeof(StoreSecurityPasswordsDto))]
public class OStoreSecurityPasswords : AuditableEntityBase
{
    
    /// <summary>
    /// Passwords Primary Key.
    /// </summary>
    public String Id { get; set; } = default!;
    public String Name { get; set; } = default!;
    public String SecurityCamerasPassword { get; set; } = default!;
    
    /// <summary>
    /// Store with this set of passwords.
    /// </summary>
    public OStore Store { get; set; } = null!;
    
    public String StoreId { get; set; } = null!;
}

/// <summary>
/// Entity to test all nox types.
/// </summary>
[AutoMap(typeof(AllNoxTypeDto))]
public class OAllNoxType : AuditableEntityBase
{
    
    /// <summary>
    /// The currency's primary key / identifier.
    /// </summary>
    public String Id { get; set; } = default!;
    
    /// <summary>
    /// Text Nox Type.
    /// </summary>
    public String TextField { get; set; } = default!;
    
    /// <summary>
    /// VatNumber Nox Type.
    /// </summary>
    public String VatNumberField_Number { get; set; } = default!;
    
    /// <summary>
    /// VatNumber Nox Type.
    /// </summary>
    public String VatNumberField_CountryCode2 { get; set; } = default!;
    
    /// <summary>
    /// CountryCode2 Nox Type.
    /// </summary>
    public String CountryCode2Field { get; set; } = default!;
    
    /// <summary>
    /// CountryCode3 Nox Type.
    /// </summary>
    public String CountryCode3Field { get; set; } = default!;
}

/// <summary>
/// The name of a country in other languages.
/// </summary>
[AutoMap(typeof(CountryLocalNamesDto))]
public class OCountryLocalNames : AuditableEntityBase
{
    public String Id { get; set; } = default!;
}

/// <summary>
/// The list of countries.
/// </summary>
public class CountryDto
{
    
    /// <summary>
    /// The country's common name.
    /// </summary>
    public String Name { get; set; } = default!;
    
    /// <summary>
    /// The country's official name.
    /// </summary>
    public String FormalName { get; set; } = default!;
    
    /// <summary>
    /// The country's official ISO 4217 alpha-3 code.
    /// </summary>
    public String AlphaCode3 { get; set; } = default!;
    
    /// <summary>
    /// The country's official ISO 4217 alpha-2 code.
    /// </summary>
    public String AlphaCode2 { get; set; } = default!;
    
    /// <summary>
    /// The country's official ISO 4217 alpha-3 code.
    /// </summary>
    public Int16 NumericCode { get; set; } = default!;
    
    /// <summary>
    /// The country's phone dialing codes (comma-delimited).
    /// </summary>
    public String? DialingCodes { get; set; } = default!;
    
    /// <summary>
    /// The capital city of the country.
    /// </summary>
    public String? Capital { get; set; } = default!;
    
    /// <summary>
    /// Noun denoting the natives of the country.
    /// </summary>
    public String? Demonym { get; set; } = default!;
    
    /// <summary>
    /// Country area in square kilometers.
    /// </summary>
    public Decimal AreaInSquareKilometres { get; set; } = default!;
    
    /// <summary>
    /// The region the country is in.
    /// </summary>
    public String GeoRegion { get; set; } = default!;
    
    /// <summary>
    /// The sub-region the country is in.
    /// </summary>
    public String GeoSubRegion { get; set; } = default!;
    
    /// <summary>
    /// The world region the country is in.
    /// </summary>
    public String GeoWorldRegion { get; set; } = default!;
    
    /// <summary>
    /// The estimated population of the country.
    /// </summary>
    public Int32? Population { get; set; } = default!;
    
    /// <summary>
    /// The top level internet domains regitered to the country (comma-delimited).
    /// </summary>
    public String? TopLevelDomains { get; set; } = default!;
}

/// <summary>
/// The list of currencies.
/// </summary>
public class CurrencyDto
{
    
    /// <summary>
    /// The currency's name.
    /// </summary>
    public String Name { get; set; } = default!;
}

/// <summary>
/// Stores.
/// </summary>
public class StoreDto
{
    
    /// <summary>
    /// Store Name.
    /// </summary>
    public String Name { get; set; } = default!;
    
    /// <summary>
    /// Physical Money in the Physical Store.
    /// </summary>
    public Decimal PhysicalMoney_Amount { get; set; } = default!;
    
    /// <summary>
    /// Physical Money in the Physical Store.
    /// </summary>
    public CurrencyCode PhysicalMoney_CurrencyCode { get; set; } = default!;
}

/// <summary>
/// A set of security passwords to store cameras and databases.
/// </summary>
public class StoreSecurityPasswordsDto
{
    public String Name { get; set; } = default!;
    public String SecurityCamerasPassword { get; set; } = default!;
}

/// <summary>
/// Entity to test all nox types.
/// </summary>
public class AllNoxTypeDto
{
    
    /// <summary>
    /// Text Nox Type.
    /// </summary>
    public String TextField { get; set; } = default!;
    
    /// <summary>
    /// VatNumber Nox Type.
    /// </summary>
    public String VatNumberField_Number { get; set; } = default!;
    
    /// <summary>
    /// VatNumber Nox Type.
    /// </summary>
    public String VatNumberField_CountryCode2 { get; set; } = default!;
    
    /// <summary>
    /// CountryCode2 Nox Type.
    /// </summary>
    public String CountryCode2Field { get; set; } = default!;
    
    /// <summary>
    /// CountryCode3 Nox Type.
    /// </summary>
    public String CountryCode3Field { get; set; } = default!;
}

/// <summary>
/// The name of a country in other languages.
/// </summary>
public class CountryLocalNamesDto
{
}
