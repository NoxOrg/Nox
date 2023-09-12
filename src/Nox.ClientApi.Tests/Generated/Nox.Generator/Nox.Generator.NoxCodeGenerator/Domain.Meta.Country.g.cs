// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using System;
using System.Collections.Generic;

namespace ClientApi.Domain;

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
    /// Type options and factory for property 'Population'
    /// </summary>
    public static Nox.Types.Number CreatePopulation(System.Int32 value)
        => Nox.Types.Number.From(value);
    

    /// <summary>
    /// Type options and factory for property 'CountryDebt'
    /// </summary>
    public static Nox.Types.Money CreateCountryDebt(IMoney value)
        => Nox.Types.Money.From(value);
    

    /// <summary>
    /// Type options and factory for property 'FirstLanguageCode'
    /// </summary>
    public static Nox.Types.LanguageCode CreateFirstLanguageCode(System.String value)
        => Nox.Types.LanguageCode.From(value);
    

    /// <summary>
    /// Type options and factory for property 'ShortDescription'
    /// </summary>
    public static Nox.Types.FormulaTypeOptions ShortDescriptionTypeOptions {get; private set;} = new ()
    {
        Expression = "$\"{Name} has a population of {Population} people.\"",
        Returns = Nox.Types.FormulaReturnType.@string,
    };
    
    public static Formula CreateShortDescription(System.String value)
        => Nox.Types.Formula.From(value, ShortDescriptionTypeOptions);
    

    /// <summary>
    /// Type options and factory for property 'CountryLocalNameId'
    /// </summary>
    public static Nox.Types.DatabaseNumber CreateCountryLocalNameId(System.Int64 value)
        => Nox.Types.DatabaseNumber.From(value);
    

}