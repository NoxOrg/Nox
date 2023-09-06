// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using System;
using System.Collections.Generic;

namespace ClientApi.Domain;

/// <summary>
/// Static methods for the Store class.
/// </summary>
public partial class Store
{
    /// <summary>
    /// Type options and factory for property 'Id'
    /// </summary>
    public static Nox.Types.NuidTypeOptions IdTypeOptions {get; private set;} = new ()
    {
        Separator = ".",
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
    /// Type options and factory for property 'EmailAddressId'
    /// </summary>
    public static Nox.Types.DatabaseNumber CreateEmailAddressId(System.Int64 value)
        => Nox.Types.DatabaseNumber.From(value);
    

    /// <summary>
    /// Type options and factory for property 'StoreOwnerId'
    /// </summary>
    public static Nox.Types.TextTypeOptions StoreOwnerIdTypeOptions {get; private set;} = new ()
    {
        MinLength = 3,
        MaxLength = 3,
        IsUnicode = false,
        IsLocalized = true,
        Casing = Nox.Types.TextTypeCasing.Normal,
    };
    
    public static Text CreateStoreOwnerId(System.String value)
        => Nox.Types.Text.From(value, StoreOwnerIdTypeOptions);
    

}