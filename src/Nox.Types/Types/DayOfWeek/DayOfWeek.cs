using Nox.Enums;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="DayOfWeek"/> type and value object.
/// </summary>
/// <remarks>Placeholder, needs to be implemented</remarks>
public sealed class DayOfWeek : ValueObject<int, DayOfWeek>
{
    private DayOfWeekTypeOptions _dayOfWeekTypeOptions = new();

    public DayOfWeek() { Value = 0; }

    /// <summary>
    /// Creates a new instance of <see cref="DayOfWeek"/> using the specified <see cref="DayOfWeekTypeOptions"/>
    /// </summary>
    /// <param name="value">The number to create the <see cref="DayOfWeek"/> with</param>
    /// <param name="options">The <see cref="DayOfWeekTypeOptions"/> containing constraints for the value object</param>
    /// <returns></returns>
    /// <exception cref="ValidationException"></exception>
    public static DayOfWeek From(ushort value, DayOfWeekTypeOptions options)
    {
        var newObject = new DayOfWeek
        {
            Value = value,
            _dayOfWeekTypeOptions = options
        };

        var validationResult = newObject.Validate();

        if (!validationResult.IsValid)
        {
            throw new TypeValidationException(validationResult.Errors);
        }

        return newObject;
    }

    /// <summary>
    /// Validates the <see cref="DayOfWeek"/> object.
    /// </summary>
    /// <returns>A validation result indicating whether the <see cref="DayOfWeek"/> object is valid or not.</returns>
    internal override ValidationResult Validate()
    {
        var result = base.Validate();

        if (Value < _dayOfWeekTypeOptions.MinValue)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox DayOfWeek type as value {Value} is less than the minimum specified value of {_dayOfWeekTypeOptions.MinValue}"));
        }

        if (Value > _dayOfWeekTypeOptions.MaxValue)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox DayOfWeek type a value {Value} is greater than the maximum specified value of {_dayOfWeekTypeOptions.MaxValue}"));
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