using System;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="Year"/> type and value object.
/// </summary>
public sealed class Year : ValueObject<ushort, Year>
{
    private YearTypeOptions _yearTypeOptions = new();

    public Year() { Value = 0; }

    /// <summary>
    /// Creates a new instance of <see cref="Year"/> using the specified <see cref="YearTypeOptions"/>
    /// </summary>
    /// <param name="value">The number to create the <see cref="Year"/> with</param>
    /// <param name="options">The <see cref="YearTypeOptions"/> containing constraints for the value object</param>
    /// <returns></returns>
    /// <exception cref="ValidationException"></exception>
    public static Year From(ushort value, YearTypeOptions options)
    {
        var newObject = new Year
        {
            Value = value,
            _yearTypeOptions = options
        };

        var validationResult = newObject.Validate();

        if (!validationResult.IsValid)
        {
            throw new TypeValidationException(validationResult.Errors);
        }

        return newObject;
    }

    /// <summary>
    /// Validates the <see cref="Year"/> object.
    /// </summary>
    /// <returns>A validation result indicating whether the <see cref="Year"/> object is valid or not.</returns>
    internal override ValidationResult Validate()
    {
        var result = base.Validate();

        if (Value < _yearTypeOptions.MinValue)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Year type as value {Value} is less than the minimum specified value of {_yearTypeOptions.MinValue}"));
        }

        if (Value > _yearTypeOptions.MaxValue)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Year type a value {Value} is greater than the maximum specified value of {_yearTypeOptions.MaxValue}"));
        }

        if (_yearTypeOptions.AllowFutureOnly && Value < DateTime.Now.Year)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Year type a value {Value} is less than the current year"));
        }


        return result;
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return Value.ToString("0000");
    }
}