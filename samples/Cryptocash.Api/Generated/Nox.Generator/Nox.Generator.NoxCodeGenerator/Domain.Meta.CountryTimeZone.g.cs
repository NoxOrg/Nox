// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using System;
using System.Collections.Generic;

namespace Cryptocash.Domain;

/// <summary>
/// Static methods for the CountryTimeZone class.
/// </summary>
public partial class CountryTimeZone
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
    

}