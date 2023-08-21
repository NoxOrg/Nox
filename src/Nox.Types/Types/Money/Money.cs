using System;
using System.Globalization;
using System.Threading;

namespace Nox.Types;

/// <summary>
/// Represents a value object for representing monetary values.
/// </summary>
[Serializable]
public class Money : ValueObject<(decimal Amount, CurrencyCode CurrencyCode), Money>, IMoney
{
    private MoneyTypeOptions _typeOptions = new();


    public decimal Amount
    {
        get => Value.Amount;
        private set => Value = (value, Value.CurrencyCode);
    }

    public CurrencyCode CurrencyCode
    {
        get => Value.CurrencyCode;
        private set => Value = (Value.Amount, value);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Money"/> class with default values.
    /// </summary>
    public Money() { }

    /// <summary>
    /// Creates a new instance of the <see cref="Money"/> class with the specified values.
    /// </summary>
    /// <param name="value">The monetary value.</param>
    /// <param name="currencyCode">The currency code enum.</param>
    /// <returns>A new instance of the <see cref="Money"/> class.</returns>
    public static Money From(decimal value, CurrencyCode currencyCode) =>
            From((value, currencyCode));

    public static Money From(decimal value, MoneyTypeOptions typeOptions)
    {
        return From(value, typeOptions.DefaultCurrency, typeOptions);
    }

    public static Money From(decimal value, CurrencyCode currencyCode, MoneyTypeOptions typeOptions)
    {
        var newObject = new Money
        {
            Value = (value, currencyCode),
            _typeOptions = typeOptions
        };

        var validationResult = newObject.Validate();

        if (!validationResult.IsValid)
        {
            throw new TypeValidationException(validationResult.Errors);
        }

        return newObject;
    }

    /// <summary>
    /// Validates a <see cref="Money"/> object.
    /// </summary>
    /// <returns>true if the <see cref="Money"/> value is valid according to the default or specified <see cref="MoneyTypeOptions"/>.</returns>
    internal override ValidationResult Validate()
    {
        var result = base.Validate();

        if (Value.Amount < _typeOptions.MinValue)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Money is invalid, Min Amount is {_typeOptions.MinValue} "));
        }

        if (Value.Amount > _typeOptions.MaxValue)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Money is invalid, Max Amount is {_typeOptions.MaxValue} "));
        }
        return result;
    }

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