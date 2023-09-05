// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using System;
using System.Collections.Generic;

namespace SampleWebApp.Domain;

/// <summary>
/// Static methods for the Country class.
/// </summary>
public partial class Country
{
    /// <summary>
    /// Type options and factory for property 'Id'
    /// </summary>
    public static Nox.Types.DatabaseNumber CreateId(System.Int64 value)
        => Nox.Types.DatabaseNumber.From(value);
    

    /// <summary>
    /// Type options and factory for property 'Name'
    /// </summary>
    public static Nox.Types.TextTypeOptions NameTypeOptions {get; private set;} = new ()
    {
        MinLength = 4,
        MaxLength = 63,
        IsUnicode = true,
        IsLocalized = true,
        Casing = Nox.Types.TextTypeCasing.Normal,
    };
    
    public static Text CreateName(System.String value)
        => Nox.Types.Text.From(value, NameTypeOptions);
    

    /// <summary>
    /// Type options and factory for property 'FormalName'
    /// </summary>
    public static Nox.Types.TextTypeOptions FormalNameTypeOptions {get; private set;} = new ()
    {
        MinLength = 4,
        MaxLength = 63,
        IsUnicode = true,
        IsLocalized = true,
        Casing = Nox.Types.TextTypeCasing.Normal,
    };
    
    public static Text CreateFormalName(System.String value)
        => Nox.Types.Text.From(value, FormalNameTypeOptions);
    

    /// <summary>
    /// Type options and factory for property 'AlphaCode3'
    /// </summary>
    public static Nox.Types.CountryCode3 CreateAlphaCode3(System.String value)
        => Nox.Types.CountryCode3.From(value);
    

    /// <summary>
    /// Type options and factory for property 'AlphaCode2'
    /// </summary>
    public static Nox.Types.CountryCode2 CreateAlphaCode2(System.String value)
        => Nox.Types.CountryCode2.From(value);
    

    /// <summary>
    /// Type options and factory for property 'NumericCode'
    /// </summary>
    public static Nox.Types.NumberTypeOptions NumericCodeTypeOptions {get; private set;} = new ()
    {
        MinValue = 4m,
        MaxValue = 894m,
        DecimalDigits = 0,
    };
    
    public static Number CreateNumericCode(System.Int16 value)
        => Nox.Types.Number.From(value, NumericCodeTypeOptions);
    

    /// <summary>
    /// Type options and factory for property 'DialingCodes'
    /// </summary>
    public static Nox.Types.TextTypeOptions DialingCodesTypeOptions {get; private set;} = new ()
    {
        MinLength = 0,
        MaxLength = 31,
        IsUnicode = false,
        IsLocalized = true,
        Casing = Nox.Types.TextTypeCasing.Normal,
    };
    
    public static Text CreateDialingCodes(System.String value)
        => Nox.Types.Text.From(value, DialingCodesTypeOptions);
    

    /// <summary>
    /// Type options and factory for property 'Capital'
    /// </summary>
    public static Nox.Types.TextTypeOptions CapitalTypeOptions {get; private set;} = new ()
    {
        MinLength = 0,
        MaxLength = 63,
        IsUnicode = true,
        IsLocalized = true,
        Casing = Nox.Types.TextTypeCasing.Normal,
    };
    
    public static Text CreateCapital(System.String value)
        => Nox.Types.Text.From(value, CapitalTypeOptions);
    

    /// <summary>
    /// Type options and factory for property 'Demonym'
    /// </summary>
    public static Nox.Types.TextTypeOptions DemonymTypeOptions {get; private set;} = new ()
    {
        MinLength = 0,
        MaxLength = 63,
        IsUnicode = true,
        IsLocalized = true,
        Casing = Nox.Types.TextTypeCasing.Normal,
    };
    
    public static Text CreateDemonym(System.String value)
        => Nox.Types.Text.From(value, DemonymTypeOptions);
    

    /// <summary>
    /// Type options and factory for property 'AreaInSquareKilometres'
    /// </summary>
    public static Nox.Types.AreaTypeOptions AreaInSquareKilometresTypeOptions {get; private set;} = new ()
    {
        MinValue = 0,
        MaxValue = 20000000,
        Units = Nox.Types.AreaTypeUnit.SquareFoot,
        PersistAs = Nox.Types.AreaTypeUnit.SquareFoot,
    };
    
    public static Area CreateAreaInSquareKilometres(System.Decimal value)
        => Nox.Types.Area.From(value, AreaInSquareKilometresTypeOptions);
    

    /// <summary>
    /// Type options and factory for property 'GeoCoord'
    /// </summary>
    public static Nox.Types.LatLong CreateGeoCoord(ILatLong value)
        => Nox.Types.LatLong.From(value);
    

    /// <summary>
    /// Type options and factory for property 'GeoRegion'
    /// </summary>
    public static Nox.Types.TextTypeOptions GeoRegionTypeOptions {get; private set;} = new ()
    {
        MinLength = 0,
        MaxLength = 8,
        IsUnicode = false,
        IsLocalized = true,
        Casing = Nox.Types.TextTypeCasing.Normal,
    };
    
    public static Text CreateGeoRegion(System.String value)
        => Nox.Types.Text.From(value, GeoRegionTypeOptions);
    

    /// <summary>
    /// Type options and factory for property 'GeoSubRegion'
    /// </summary>
    public static Nox.Types.TextTypeOptions GeoSubRegionTypeOptions {get; private set;} = new ()
    {
        MinLength = 0,
        MaxLength = 32,
        IsUnicode = false,
        IsLocalized = true,
        Casing = Nox.Types.TextTypeCasing.Normal,
    };
    
    public static Text CreateGeoSubRegion(System.String value)
        => Nox.Types.Text.From(value, GeoSubRegionTypeOptions);
    

    /// <summary>
    /// Type options and factory for property 'GeoWorldRegion'
    /// </summary>
    public static Nox.Types.TextTypeOptions GeoWorldRegionTypeOptions {get; private set;} = new ()
    {
        MinLength = 0,
        MaxLength = 4,
        IsUnicode = false,
        IsLocalized = true,
        Casing = Nox.Types.TextTypeCasing.Normal,
    };
    
    public static Text CreateGeoWorldRegion(System.String value)
        => Nox.Types.Text.From(value, GeoWorldRegionTypeOptions);
    

    /// <summary>
    /// Type options and factory for property 'Population'
    /// </summary>
    public static Nox.Types.NumberTypeOptions PopulationTypeOptions {get; private set;} = new ()
    {
        MinValue = 0m,
        MaxValue = 999999999m,
        DecimalDigits = 0,
    };
    
    public static Number CreatePopulation(System.Int32 value)
        => Nox.Types.Number.From(value, PopulationTypeOptions);
    

    /// <summary>
    /// Type options and factory for property 'TopLevelDomains'
    /// </summary>
    public static Nox.Types.TextTypeOptions TopLevelDomainsTypeOptions {get; private set;} = new ()
    {
        MinLength = 0,
        MaxLength = 31,
        IsUnicode = true,
        IsLocalized = true,
        Casing = Nox.Types.TextTypeCasing.Normal,
    };
    
    public static Text CreateTopLevelDomains(System.String value)
        => Nox.Types.Text.From(value, TopLevelDomainsTypeOptions);
    

    /// <summary>
    /// Type options and factory for property 'CountryLocalNameId'
    /// </summary>
    public static Nox.Types.TextTypeOptions CountryLocalNameIdTypeOptions {get; private set;} = new ()
    {
        MinLength = 2,
        MaxLength = 2,
        IsUnicode = false,
        IsLocalized = true,
        Casing = Nox.Types.TextTypeCasing.Normal,
    };
    
    public static Text CreateCountryLocalNameId(System.String value)
        => Nox.Types.Text.From(value, CountryLocalNameIdTypeOptions);
    

    /// <summary>
    /// Type options and factory for property 'CurrencyId'
    /// </summary>
    public static Nox.Types.NuidTypeOptions CurrencyIdTypeOptions {get; private set;} = new ()
    {
        Separator = ".",
        PropertyNames = new System.String[]
        {
            "Name",
        },
    };
    
    public static Nuid CreateCurrencyId(System.UInt32 value)
        => Nox.Types.Nuid.From(value, CurrencyIdTypeOptions);
    

}