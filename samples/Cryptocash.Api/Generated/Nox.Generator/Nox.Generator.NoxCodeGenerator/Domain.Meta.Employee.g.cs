// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using System;
using System.Collections.Generic;

namespace Cryptocash.Domain;

/// <summary>
/// Static methods for the Employee class.
/// </summary>
public partial class Employee
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
    /// Type options and factory for property 'FirstWorkingDay'
    /// </summary>
    public static Nox.Types.Date CreateFirstWorkingDay(System.DateTime value)
        => Nox.Types.Date.From(value);
    

    /// <summary>
    /// Type options and factory for property 'LastWorkingDay'
    /// </summary>
    public static Nox.Types.Date CreateLastWorkingDay(System.DateTime value)
        => Nox.Types.Date.From(value);
    

    /// <summary>
    /// Type options and factory for property 'EmployeePhoneNumberId'
    /// </summary>
    public static Nox.Types.AutoNumber CreateEmployeePhoneNumberId(System.Int64 value)
        => Nox.Types.AutoNumber.From(value);
    

}