using Nox.Types.Common;
using System;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="Number"/> type and value object.
/// </summary>
public sealed class Number : ValueObject<QuantityValue, Number>
{
    private NumberTypeOptions _numberTypeOptions = new();

    public Number()
    {
        Value = QuantityValue.Zero;
    }

    /// <summary>
    /// Creates a new instance of <see cref="Number"/> using the specified <see cref="NumberTypeOptions"/>
    /// </summary>
    /// <param name="value">The number to create the <see cref="Number"/> with</param>
    /// <param name="options">The <see cref="NumberTypeOptions"/> containing constraints for the value object</param>
    /// <returns></returns>
    /// <exception cref="ValidationException"></exception>
    public static Number From(QuantityValue value, NumberTypeOptions options)
    {
        var newObject = new Number
        {
            Value = value,
            _numberTypeOptions = options
        };

        var validationResult = newObject.Validate();

        if (!validationResult.IsValid)
        {
            throw new TypeValidationException(validationResult.Errors);
        }

        return newObject;
    }

    public new static Number From(QuantityValue value)
        => From(value, new NumberTypeOptions
        {
            DecimalDigits = 6,
            MinValue = Math.Min((decimal)value, NumberTypeOptions.DefaultMinValue),
            MaxValue = Math.Max((decimal)value, NumberTypeOptions.DefaultMaxValue)
        });

    /// <summary>
    /// Validates a <see cref="Number"/> object.
    /// </summary>
    /// <returns>true if the <see cref="Number"/> value is valid according to the default or specified <see cref="NumberTypeOptions"/>.</returns>
    internal override ValidationResult Validate()
    {
        var result = base.Validate();

        if (Value < _numberTypeOptions.MinValue)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Number type as value {Value} is less than than the minimum specified value of {_numberTypeOptions.MinValue}"));
        }

        if (Value > _numberTypeOptions.MaxValue)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Number type a value {Value} is greater than than the maximum specified value of {_numberTypeOptions.MaxValue}"));
        }

        var decimalDigits = (int)_numberTypeOptions.DecimalDigits;
        if (Value.IsDecimal)
        {
            Value = Math.Round((decimal)Value, decimalDigits);
        }
        else
        {
            Value = Math.Round((double)Value, decimalDigits);
        }

        return result;
    }

    public override Type GetUnderlyingType()
    {
        return Value.Type switch
        {
            QuantityValue.UnderlyingDataType.Double => typeof(double),
            QuantityValue.UnderlyingDataType.Decimal => typeof(decimal),
            _ => throw new ArgumentOutOfRangeException($"{Value.Type} is out of range")
        };
    }
}

// int
// Domain Concepts
// Number
// Amount (math)
// Money (Currency and Amount)
// Year (year)
// AgeOfPerson (age)