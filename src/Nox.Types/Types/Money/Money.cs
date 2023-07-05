using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;
using System.Threading;

namespace Nox.Types;

/// <summary>
/// Represents a value object for representing monetary values.
/// </summary>
[Serializable]
public sealed class Money : ValueObject<(decimal Amount, CurrencyCode CurrencyCode), Money>
{
    public decimal Amount
    {
        get => Value.Amount;
        private set => Value = (value, Value.CurrencyCode);
    }

    public string CurrencyCode
    {
        get => Value.CurrencyCode.ToString();
        private set => Value = (Value.Amount, (CurrencyCode)Enum.Parse(typeof(CurrencyCode),value));
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="Money"/> class with default values.
    /// </summary>
    public Money() { Value = (0, Types.CurrencyCode.USD); }

    /// <summary>
    /// Creates a new instance of the <see cref="Money"/> class with the specified values.
    /// </summary>
    /// <param name="value">The monetary value.</param>
    /// <param name="currencyCode">The currency code enum.</param>
    /// <returns>A new instance of the <see cref="Money"/> class.</returns>
    public static Money From(decimal value, CurrencyCode currencyCode) =>
            From( (value, currencyCode) );

    public override string ToString()
    {
        return $"{Value.CurrencyCode} {Value.Amount.ToString(CultureInfo.InvariantCulture)}";
    }

    /// <summary>
    /// Returns a string representation of the <see cref="Money"/> object using the specified <paramref name="format"/>.
    /// </summary>
    /// <param name="format">The format specifier for the amount value.</param>
    /// <returns>A string representation of the <see cref="Money"/> object with the amount formatted using the specified format and Invariant culture .</returns>
    public string ToString(string format)
    {
        return ToString(format, Thread.CurrentThread.CurrentCulture); 
    }

    /// <summary>
    /// Returns a string representation of the <see cref="Money"/> object using the specified <paramref name="cultureInfo"/> and <paramref name="amountFormat"/>.
    /// </summary>
    /// <param name="format">The format specifier for the amount value.</param>
    /// <param name="cultureInfo">The culture-specific information used to format the amount.</param>
    /// <returns>A string representation of the <see cref="Money"/> object with the amount formatted using the specified culture and format.</returns>
    public string ToString(string format, CultureInfo cultureInfo)
    {
        if (cultureInfo == null) throw new ArgumentNullException(nameof(cultureInfo));
        
        if (format == null) throw new ArgumentNullException(nameof(format));

        if (format == "C")
            return CurrencySymbol.GetCurrencySymbol(Value.CurrencyCode) + Value.Amount.ToString("N");

        return Value.CurrencyCode + " " + Value.Amount.ToString(format, cultureInfo);
    }
}