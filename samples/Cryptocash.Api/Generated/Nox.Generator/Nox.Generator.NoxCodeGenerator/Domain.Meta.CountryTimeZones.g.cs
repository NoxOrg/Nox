// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using System;
using System.Collections.Generic;

namespace CryptocashApi.Domain;

/// <summary>
/// Static methods for the CountryTimeZones class.
/// </summary>
public partial class CountryTimeZones
{
    /// <summary>
    /// Type options and factory for property 'Id'
    /// </summary>
    public static Nox.Types.DatabaseNumber CreateId(System.Int64 value)
        => Nox.Types.DatabaseNumber.From(value);
    

    /// <summary>
    /// Type options and factory for property 'TimeZoneCode'
    /// </summary>
    public static Nox.Types.TimeZoneCode CreateTimeZoneCode(System.String value)
        => Nox.Types.TimeZoneCode.From(value);
    

    /// <summary>
    /// Type options and factory for property 'CountryId'
    /// </summary>
    public static Nox.Types.CountryCode2 CreateCountryId(System.String value)
        => Nox.Types.CountryCode2.From(value);
    

}