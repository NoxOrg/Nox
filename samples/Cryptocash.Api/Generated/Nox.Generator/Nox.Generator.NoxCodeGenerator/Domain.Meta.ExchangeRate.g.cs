// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using System;
using System.Collections.Generic;

namespace Cryptocash.Domain;

/// <summary>
/// Static methods for the ExchangeRate class.
/// </summary>
public partial class ExchangeRate
{
    /// <summary>
    /// Type options and factory for property 'Id'
    /// </summary>
    public static Nox.Types.DatabaseNumber CreateId(System.Int64 value)
        => Nox.Types.DatabaseNumber.From(value);
    

    /// <summary>
    /// Type options and factory for property 'EffectiveRate'
    /// </summary>
    public static Nox.Types.Number CreateEffectiveRate(System.Int32 value)
        => Nox.Types.Number.From(value);
    

    /// <summary>
    /// Type options and factory for property 'EffectiveAt'
    /// </summary>
    public static Nox.Types.DateTime CreateEffectiveAt(System.DateTimeOffset value)
        => Nox.Types.DateTime.From(value);
    

    /// <summary>
    /// Type options and factory for property 'CurrencyId'
    /// </summary>
    public static Nox.Types.CurrencyCode3 CreateCurrencyId(System.String value)
        => Nox.Types.CurrencyCode3.From(value);
    

}