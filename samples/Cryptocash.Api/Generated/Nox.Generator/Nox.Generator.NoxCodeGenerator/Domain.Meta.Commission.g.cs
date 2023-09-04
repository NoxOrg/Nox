// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using System;
using System.Collections.Generic;

namespace Cryptocash.Domain;

/// <summary>
/// Static methods for the Commission class.
/// </summary>
public partial class Commission
{
    /// <summary>
    /// Type options and factory for property 'Id'
    /// </summary>
    public static Nox.Types.DatabaseNumber CreateId(System.Int64 value)
        => Nox.Types.DatabaseNumber.From(value);
    

    /// <summary>
    /// Type options and factory for property 'Rate'
    /// </summary>
    public static Nox.Types.Percentage CreateRate(System.Single value)
        => Nox.Types.Percentage.From(value);
    

    /// <summary>
    /// Type options and factory for property 'EffectiveAt'
    /// </summary>
    public static Nox.Types.DateTime CreateEffectiveAt(System.DateTimeOffset value)
        => Nox.Types.DateTime.From(value);
    

    /// <summary>
    /// Type options and factory for property 'CountryId'
    /// </summary>
    public static Nox.Types.CountryCode2 CreateCountryId(System.String value)
        => Nox.Types.CountryCode2.From(value);
    

}