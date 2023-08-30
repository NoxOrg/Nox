// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using System;
using System.Collections.Generic;

namespace CryptocashApi.Domain;

/// <summary>
/// Static methods for the Holidays class.
/// </summary>
public partial class Holidays
{
    /// <summary>
    /// Type options and factory for property 'Id'
    /// </summary>
    public static Nox.Types.DatabaseNumber CreateId(System.Int64 value)
        => Nox.Types.DatabaseNumber.From(value);
    

    /// <summary>
    /// Type options and factory for property 'Year'
    /// </summary>
    public static Nox.Types.Year CreateYear(System.UInt16 value)
        => Nox.Types.Year.From(value);
    

    /// <summary>
    /// Type options and factory for property 'DayOff'
    /// </summary>
    public static Nox.Types.DayOfWeek CreateDayOff(System.UInt16 value)
        => Nox.Types.DayOfWeek.From(value);
    

    /// <summary>
    /// Type options and factory for property 'CountryId'
    /// </summary>
    public static Nox.Types.CountryCode2 CreateCountryId(System.String value)
        => Nox.Types.CountryCode2.From(value);
    

    /// <summary>
    /// Type options and factory for property 'CountryHolidayId'
    /// </summary>
    public static Nox.Types.DatabaseNumber CreateCountryHolidayId(System.Int64 value)
        => Nox.Types.DatabaseNumber.From(value);
    

}