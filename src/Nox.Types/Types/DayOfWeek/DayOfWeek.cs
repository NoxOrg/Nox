using Nox.Enums;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="DayOfWeek"/> type and value object.
/// </summary>
/// <remarks>Placeholder, needs to be implemented</remarks>
public sealed class DayOfWeek : ValueObject<int, DayOfWeek>
{
    public DayOfWeek() { Value = 0; }

    /// <summary>
    /// Creates a new instance of <see cref="DayOfWeek"/>
    /// </summary>
    /// <param name="value">The number to create the <see cref="DayOfWeek"/> with</param>
    /// <returns></returns>
    /// <exception cref="ValidationException"></exception>
    public static new DayOfWeek From(int value)
    {
        var newObject = new DayOfWeek
        {
            Value = value
        };

        var validationResult = newObject.Validate();

        if (!validationResult.IsValid)
        {
            throw new TypeValidationException(validationResult.Errors);
        }

        return newObject;
    }

    public static DayOfWeek From(DayOfWeek dayOfTheWeek)
        => From((dayOfTheWeek));

    /// <summary>
    /// Validates the <see cref="DayOfWeek"/> object.
    /// </summary>
    /// <returns>A validation result indicating whether the <see cref="DayOfWeek"/> object is valid or not.</returns>
    internal override ValidationResult Validate()
    {
        var result = base.Validate();

        if (Value < 0)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox DayOfWeek type as value {Value} is less than the minimum specified value of 0"));
        }

        if (Value > 6)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox DayOfWeek type a value {Value} is greater than the maximum specified value of 6"));
        }

        return result;
    }

    public bool IsWeekday()
    {
        switch (Value)
        {
            case (int)DayOfTheWeek.Monday:
            case (int)DayOfTheWeek.Tuesday:
            case (int)DayOfTheWeek.Wednesday:
            case (int)DayOfTheWeek.Thursday:
            case (int)DayOfTheWeek.Friday:
                return true;
            default:
                return false;
        }
    }

    public bool IsWeekend()
    {
        return !IsWeekday();
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return ((DayOfTheWeek)Value).ToString();
    }
}