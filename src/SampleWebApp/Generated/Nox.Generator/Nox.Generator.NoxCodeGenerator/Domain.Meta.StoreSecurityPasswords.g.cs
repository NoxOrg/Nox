﻿// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using System;
using System.Collections.Generic;

namespace SampleWebApp.Domain;

/// <summary>
/// Static methods for the StoreSecurityPasswords class.
/// </summary>
public partial class StoreSecurityPasswords
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
    /// Type options and factory for property 'SecurityCamerasPassword'
    /// </summary>
    public static Nox.Types.TextTypeOptions SecurityCamerasPasswordTypeOptions {get; private set;} = new ()
    {
        MinLength = 4,
        MaxLength = 63,
        IsUnicode = true,
        IsLocalized = true,
        Casing = Nox.Types.TextTypeCasing.Normal,
    };
    
    public static Text CreateSecurityCamerasPassword(System.String value)
        => Nox.Types.Text.From(value, SecurityCamerasPasswordTypeOptions);
    

    /// <summary>
    /// Type options and factory for property 'StoreId'
    /// </summary>
    public static Nox.Types.TextTypeOptions StoreIdTypeOptions {get; private set;} = new ()
    {
        MinLength = 3,
        MaxLength = 3,
        IsUnicode = false,
        IsLocalized = true,
        Casing = Nox.Types.TextTypeCasing.Normal,
    };
    
    public static Text CreateStoreId(System.String value)
        => Nox.Types.Text.From(value, StoreIdTypeOptions);
    

}