using System;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="Number"/> type and value object. 
/// </summary>
public sealed class Number : ValueObject<decimal, Number>
{
    private NumberTypeOptions _numberTypeOptions = new();

    public Number() { Value = 0; }

    /// <summary>
    /// Creates a new instance of <see cref="Number"/> using the specified <see cref="NumberTypeOptions"/>
    /// </summary>
    /// <param name="value">The number to create the <see cref="Number"/> with</param>
    /// <param name="options">The <see cref="NumberTypeOptions"/> containing constraints for the value object</param>
    /// <returns></returns>
    /// <exception cref="ValidationException"></exception>
    public static Number From(decimal value, NumberTypeOptions options)
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

    new public static Number From(decimal value)
        => From(value, new NumberTypeOptions { 
            DecimalDigits = 6,
            MinValue = Math.Min(value, NumberTypeOptions.DefaultMinValue),
            MaxValue = Math.Max(value, NumberTypeOptions.DefaultMaxValue),
        });

    public static Number From(byte value)
    => From((decimal)value, new NumberTypeOptions { DecimalDigits = 0, MinValue = byte.MinValue, MaxValue = byte.MaxValue });

    public static Number From(byte value, NumberTypeOptions options)
        => From((decimal)value, options);

    public static Number From(short value) 
        => From((decimal)value, new NumberTypeOptions { DecimalDigits = 0, MinValue = short.MinValue, MaxValue = short.MaxValue });
    
    public static Number From(short value, NumberTypeOptions options)
        => From((decimal)value, options);

    public static Number From(int value)
      => From((decimal)value, new NumberTypeOptions { 
          DecimalDigits = 0, 
          MinValue = Math.Min(value,NumberTypeOptions.DefaultMinValue),
          MaxValue = Math.Max(value,NumberTypeOptions.DefaultMaxValue),
      });

    public static Number From(int value, NumberTypeOptions options)
        => From((decimal)value, options);

    public static Number From(long value)
        => From((decimal)value, new NumberTypeOptions { 
            DecimalDigits = 0,
            MinValue = Math.Min(value, NumberTypeOptions.DefaultMinValue),
            MaxValue = Math.Max(value, NumberTypeOptions.DefaultMaxValue),
        });

    public static Number From(long value, NumberTypeOptions options)
        => From((decimal)value, options);

    public static Number From(double value)
        => From((decimal)value, new NumberTypeOptions { 
            DecimalDigits = 6,
            MinValue = Math.Min((decimal)value, NumberTypeOptions.DefaultMinValue),
            MaxValue = Math.Max((decimal)value, NumberTypeOptions.DefaultMaxValue),
        });

    public static Number From(double value, NumberTypeOptions options)
        => From((decimal)value, options);

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

        Value = Math.Round(Value, (int)_numberTypeOptions.DecimalDigits);

        return result;
    }

    public override Type GetUnderlyingType()
    {
        if (_numberTypeOptions.DecimalDigits == 0)
        {
            if (_numberTypeOptions.MaxValue <= byte.MaxValue && _numberTypeOptions.MinValue >= byte.MinValue)
                return typeof(byte);

            if (_numberTypeOptions.MaxValue <= short.MaxValue && _numberTypeOptions.MinValue >= short.MinValue)
                return typeof(short);

            else if (_numberTypeOptions.MaxValue <= int.MaxValue && _numberTypeOptions.MinValue >= int.MinValue)
                return typeof(int);
            
            else if (_numberTypeOptions.MaxValue <= long.MaxValue && _numberTypeOptions.MinValue >= long.MinValue) 
                return typeof(long);
        }
        return typeof(decimal);
    }

    public static Type GetUnderlyingType(NumberTypeOptions numberTypeOptions)
    {
        if (numberTypeOptions.DecimalDigits == 0)
        {
            if (numberTypeOptions.MaxValue <= byte.MaxValue && numberTypeOptions.MinValue >= byte.MinValue)
                return typeof(byte);

            if (numberTypeOptions.MaxValue <= short.MaxValue && numberTypeOptions.MinValue >= short.MinValue)
                return typeof(short);

            else if (numberTypeOptions.MaxValue <= int.MaxValue && numberTypeOptions.MinValue >= int.MinValue)
                return typeof(int);

            else if (numberTypeOptions.MaxValue <= long.MaxValue && numberTypeOptions.MinValue >= long.MinValue)
                return typeof(long);
        }
        return typeof(decimal);
    }

}


// int
// Domain Concepts
// Number
// Amount (math)
// Money (Currency and Amount)
// Year (year)
// AgeOfPerson (age)


