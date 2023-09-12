// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using System;
using System.Collections.Generic;

namespace ClientApi.Domain;

/// <summary>
/// Static methods for the Workplace class.
/// </summary>
public partial class Workplace
{
    /// <summary>
    /// Type options and factory for property 'Id'
    /// </summary>
    public static Nox.Types.NuidTypeOptions IdTypeOptions {get; private set;} = new ()
    {
        Separator = "-",
        PropertyNames = new System.String[]
        {
            "Name",
        },
    };
    
    public static Nuid CreateId(System.UInt32 value)
        => Nox.Types.Nuid.From(value, IdTypeOptions);
    

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
    /// Type options and factory for property 'Greeting'
    /// </summary>
    public static Nox.Types.FormulaTypeOptions GreetingTypeOptions {get; private set;} = new ()
    {
        Expression = "$\"Hello, {Name.Value}!\"",
        Returns = Nox.Types.FormulaReturnType.@string,
    };
    
    public static Formula CreateGreeting(System.String value)
        => Nox.Types.Formula.From(value, GreetingTypeOptions);
    

}