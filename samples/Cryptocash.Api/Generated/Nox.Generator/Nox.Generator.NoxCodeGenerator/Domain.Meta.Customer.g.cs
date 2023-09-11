// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using System;
using System.Collections.Generic;

namespace Cryptocash.Domain;

/// <summary>
/// Static methods for the Customer class.
/// </summary>
public partial class Customer
{
    /// <summary>
    /// Type options and factory for property 'Id'
    /// </summary>
    public static Nox.Types.AutoNumber CreateId(System.Int64 value)
        => Nox.Types.AutoNumber.From(value);
    

    /// <summary>
    /// Type options and factory for property 'FirstName'
    /// </summary>
    public static Nox.Types.TextTypeOptions FirstNameTypeOptions {get; private set;} = new ()
    {
        MinLength = 4,
        MaxLength = 63,
        IsUnicode = true,
        IsLocalized = true,
        Casing = Nox.Types.TextTypeCasing.Normal,
    };
    
    public static Text CreateFirstName(System.String value)
        => Nox.Types.Text.From(value, FirstNameTypeOptions);
    

    /// <summary>
    /// Type options and factory for property 'LastName'
    /// </summary>
    public static Nox.Types.TextTypeOptions LastNameTypeOptions {get; private set;} = new ()
    {
        MinLength = 4,
        MaxLength = 63,
        IsUnicode = true,
        IsLocalized = true,
        Casing = Nox.Types.TextTypeCasing.Normal,
    };
    
    public static Text CreateLastName(System.String value)
        => Nox.Types.Text.From(value, LastNameTypeOptions);
    

    /// <summary>
    /// Type options and factory for property 'EmailAddress'
    /// </summary>
    public static Nox.Types.Email CreateEmailAddress(System.String value)
        => Nox.Types.Email.From(value);
    

    /// <summary>
    /// Type options and factory for property 'Address'
    /// </summary>
    public static Nox.Types.StreetAddress CreateAddress(IStreetAddress value)
        => Nox.Types.StreetAddress.From(value);
    

    /// <summary>
    /// Type options and factory for property 'MobileNumber'
    /// </summary>
    public static Nox.Types.PhoneNumber CreateMobileNumber(System.String value)
        => Nox.Types.PhoneNumber.From(value);
    

    /// <summary>
    /// Type options and factory for property 'CountryId'
    /// </summary>
    public static Nox.Types.CountryCode2 CreateCountryId(System.String value)
        => Nox.Types.CountryCode2.From(value);
    

}