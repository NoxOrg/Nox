// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using System;
using System.Collections.Generic;

namespace ClientApi.Domain;

/// <summary>
/// Static methods for the StoreOwner class.
/// </summary>
public partial class StoreOwner
{
    /// <summary>
    /// Type options and factory for property 'Id'
    /// </summary>
    public static Nox.Types.TextTypeOptions IdTypeOptions {get; private set;} = new ()
    {
        MinLength = 3,
        MaxLength = 3,
        IsUnicode = false,
        IsLocalized = true,
        Casing = Nox.Types.TextTypeCasing.Normal,
    };
    
    public static Text CreateId(System.String value)
        => Nox.Types.Text.From(value, IdTypeOptions);
    

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
    /// Type options and factory for property 'TemporaryOwnerName'
    /// </summary>
    public static Nox.Types.Text CreateTemporaryOwnerName(System.String value)
        => Nox.Types.Text.From(value);
    

    /// <summary>
    /// Type options and factory for property 'VatNumber'
    /// </summary>
    public static Nox.Types.VatNumber CreateVatNumber(IVatNumber value)
        => Nox.Types.VatNumber.From(value);
    

    /// <summary>
    /// Type options and factory for property 'StreetAddress'
    /// </summary>
    public static Nox.Types.StreetAddress CreateStreetAddress(IStreetAddress value)
        => Nox.Types.StreetAddress.From(value);
    

    /// <summary>
    /// Type options and factory for property 'LocalGreeting'
    /// </summary>
    public static Nox.Types.TranslatedTextTypeOptions LocalGreetingTypeOptions {get; private set;} = new ()
    {
        MinLength = 4,
        MaxLength = 63,
        CharacterCasing = Nox.Types.TextTypeCasing.Normal,
    };
    
    public static TranslatedText CreateLocalGreeting(ITranslatedText value)
        => Nox.Types.TranslatedText.From(value, LocalGreetingTypeOptions);
    

    /// <summary>
    /// Type options and factory for property 'Notes'
    /// </summary>
    public static Nox.Types.Text CreateNotes(System.String value)
        => Nox.Types.Text.From(value);
    

}