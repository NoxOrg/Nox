using System;
using System.Globalization;

namespace Nox.Types;

public abstract class Measurement<TValueObject, TUnitType> : ValueObject<QuantityValue, TValueObject>
    where TValueObject : Measurement<TValueObject, TUnitType>, new()
    where TUnitType : MeasurementUnit
{
    private const int QuantityValueDecimalPrecision = 6;

    public TUnitType Unit { get; private set; } = default!;

    protected Measurement() : base() { Value = 0; }

    /// <summary>
    /// Creates a new instance of <see cref="TValueObject"/> object with the specified <see cref="TUnitType"/>.
    /// </summary>
    /// <param name="value">The value to create the <see cref="TValueObject"/> with</param>
    /// <param name="unit">The <see cref="TUnitType"/> to create the <see cref="TValueObject"/> with</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public static TValueObject From(QuantityValue value, TUnitType unit)
    {
        var newObject = new TValueObject
        {
            Value = Round(value),
            Unit = unit,
        };

        var validationResult = newObject.Validate();

        if (!validationResult.IsValid)
        {
            throw new TypeValidationException(validationResult.Errors);
        }

        return newObject;
    }

    /// <summary>
    /// Validates a <see cref="TValueObject"/> object.
    /// </summary>
    /// <returns>true if the <see cref="TValueObject"/> value is valid.</returns>
    internal override ValidationResult Validate()
    {
        var result = Value.Validate();

        if (Value < 0 && !double.IsNaN((double)Value) && !double.IsInfinity((double)Value))
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox {typeof(TValueObject).Name} type as negative {typeof(TValueObject).Name.ToLower()} value {Value} is not allowed."));
        }

        return result;
    }

    public override string ToString()
        => $"{Value.ToString($"0.{new string('#', QuantityValueDecimalPrecision)}", CultureInfo.InvariantCulture)} {Unit}";

    /// <summary>
    /// Returns a string representation of the <see cref="TValueObject"/> object using the specified <see cref="IFormatProvider"/>.
    /// </summary>
    /// <param name="formatProvider">The format provider for the measurement value.</param>
    /// <returns>A string representation of the <see cref="TValueObject"/> object with the value formatted using the specified <see cref="IFormatProvider"/>.</returns>
    public string ToString(IFormatProvider formatProvider)
        => $"{Value.ToString(formatProvider)} {Unit}";

    protected QuantityValue GetMeasurementIn(TUnitType targetUnit)
    {
        var factor = ResolveUnitConversionFactor(Unit, targetUnit);
        return Round(Value * factor);
    }

    private static QuantityValue Round(QuantityValue value)
        => Math.Round((double)value, QuantityValueDecimalPrecision);

    protected abstract MeasurementConversionFactor<TUnitType> ResolveUnitConversionFactor(TUnitType sourceUnit, TUnitType targetUnit);
}
