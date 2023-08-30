// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using System;
using System.Collections.Generic;

namespace CryptocashApi.Domain;

/// <summary>
/// Static methods for the EmployeePhoneNumber class.
/// </summary>
public partial class EmployeePhoneNumber
{
    /// <summary>
    /// Type options and factory for property 'Id'
    /// </summary>
    public static Nox.Types.DatabaseNumber CreateId(System.Int64 value)
        => Nox.Types.DatabaseNumber.From(value);
    

    /// <summary>
    /// Type options and factory for property 'PhoneNumberType'
    /// </summary>
    public static Nox.Types.TextTypeOptions PhoneNumberTypeTypeOptions {get; private set;} = new ()
    {
        MinLength = 4,
        MaxLength = 63,
        IsUnicode = true,
        IsLocalized = true,
        Casing = Nox.Types.TextTypeCasing.Normal,
    };
    
    public static Text CreatePhoneNumberType(System.String value)
        => Nox.Types.Text.From(value, PhoneNumberTypeTypeOptions);
    

    /// <summary>
    /// Type options and factory for property 'PhoneNumber'
    /// </summary>
    public static Nox.Types.PhoneNumber CreatePhoneNumber(System.String value)
        => Nox.Types.PhoneNumber.From(value);
    

}