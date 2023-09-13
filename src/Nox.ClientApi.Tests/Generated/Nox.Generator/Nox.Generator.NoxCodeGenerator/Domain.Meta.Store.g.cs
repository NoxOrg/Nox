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
    public static Nox.Types.DatabaseGuid CreateId(System.Guid value)
        => Nox.Types.DatabaseGuid.From(value);
    

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
    /// Type options and factory for property 'Address'
    /// </summary>
    public static Nox.Types.StreetAddress CreateAddress(IStreetAddress value)
        => Nox.Types.StreetAddress.From(value);
    

    /// <summary>
    /// Type options and factory for property 'Location'
    /// </summary>
    public static Nox.Types.LatLong CreateLocation(ILatLong value)
        => Nox.Types.LatLong.From(value);
    

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