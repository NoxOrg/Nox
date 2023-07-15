using System;
using System.Globalization;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="CurrencyNumber"/> type and value object.
/// Supports ETL Process's and allows to get the proper <see cref="CurrencyCode"/>
/// </summary>    
[Serializable]
public sealed class CurrencyNumber : ValueObject<(uint Amount, CurrencyCode CurrencyCode), CurrencyNumber>
{
    public uint Amount
    {
        get => Value.Amount;
        private set => Value = (value, Value.CurrencyCode);
    }

    public string CurrencyCode
    {
        get => Value.CurrencyCode.ToString();
        private set => Value = (Value.Amount, (CurrencyCode)Enum.Parse(typeof(CurrencyCode), value));   
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="CurrencyNumber"/> class with default values.
    /// </summary>
    public CurrencyNumber() { Value = (0, Types.CurrencyCode.USD); }

    /// <summary>
    /// Creates a new instance of the <see cref="CurrencyNumber"/> class with the specified values.
    /// </summary>
    /// <param name="value">The currency value.</param>
    /// <param name="currencyCode">The currency code enum.</param>
    /// <returns>A new instance of the <see cref="CurrencyNumber"/> class.</returns>
    public static CurrencyNumber From(uint value, CurrencyCode currencyCode) =>
            From((value, currencyCode));

    public override string ToString()
    {
        return $"{Value.CurrencyCode} {Value.Amount.ToString(CultureInfo.InvariantCulture)}";
    }

    /// <summary>
    /// Returns a string representation of the <see cref="CurrencyNumber"/> object using the specified <paramref name="format"/>.
    /// </summary>
    /// <param name="format">The format specifier for the amount value.</param>
    /// <returns>A string representation of the <see cref="CurrencyNumber"/> object with the amount formatted using the specified <paramref name="format"/> 
    /// and <see cref="CultureInfo.InvariantCulture"/> .</returns>
    public string ToString(string format)
    {
        return ToString(format, CultureInfo.InvariantCulture);
    }

    /// <summary>
    /// Returns a string representation of the <see cref="CurrencyNumber"/> object using the specified <paramref name="cultureInfo"/> and <paramref name="amountFormat"/>.
    /// </summary>
    /// <param name="format">The format specifier for the amount value.</param>
    /// <param name="cultureInfo">The culture-specific information used to format the amount.</param>
    /// <returns>A string representation of the <see cref="CurrencyNumber"/> object with the amount formatted using the specified culture and format.</returns>
    public string ToString(string format, CultureInfo cultureInfo)
    {
        if (cultureInfo == null) throw new ArgumentNullException(nameof(cultureInfo));

        if (format == null) throw new ArgumentNullException(nameof(format));

        if (format == "C")
            return CurrencySymbol.GetCurrencySymbol(Value.CurrencyCode) + Value.Amount.ToString("N");

        return $"{Value.CurrencyCode} {Value.Amount.ToString(format, cultureInfo)}";
    }
}
