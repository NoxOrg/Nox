using System;
using System.Globalization;

namespace Nox.Types;

/// <summary>
/// Represents a time of day, as would be read from a clock, within the range 00:00:00 to 23:59:59.9999999.
/// </summary>
public sealed class Time : ValueObject<TimeOnly, Time>
{
    private TimeTypeOptions _timeTypeOptions = new();

    /// <summary>
    /// Creates the Time object.
    /// </summary>
    /// <param name="hours">The hours.</param>
    /// <param name="minutes">The minutes.</param>
    /// <param name="timeTypeOptions">Time options.</param>
    /// <returns>A Time.</returns>
    public static Time From(int hours, int minutes, TimeTypeOptions? timeTypeOptions = null) => From(hours, minutes, 0, 0, timeTypeOptions);

    /// <summary>
    /// Creates the Time object.
    /// </summary>
    /// <param name="hours">The hours.</param>
    /// <param name="minutes">The minutes.</param>
    /// <param name="seconds">The seconds.</param>
    /// <param name="timeTypeOptions">Time options.</param>
    /// <returns>A Time.</returns>
    public static Time From(int hours, int minutes, int seconds, TimeTypeOptions? timeTypeOptions = null) => From(hours, minutes, seconds, 0, timeTypeOptions);

    /// <summary>
    /// Creates the Time object.
    /// </summary>
    /// <param name="hours">The hours.</param>
    /// <param name="minutes">The minutes.</param>
    /// <param name="seconds">The seconds.</param>
    /// <param name="milliseconds">The milliseconds.</param>
    /// <param name="timeTypeOptions">Time options.</param>
    /// <returns>A Time.</returns>
    public static Time From(int hours, int minutes, int seconds, int milliseconds, TimeTypeOptions? timeTypeOptions = null)
    {
        var time = new TimeOnly(hours,minutes,seconds, milliseconds);

        return From(time, timeTypeOptions);

    }

    /// <summary>
    /// Creates the Time object from ticks.
    /// </summary>
    /// <param name="ticks">The ticks.</param>
    /// <param name="timeTypeOptions">Time options.</param>
    /// <returns>A Time.</returns>
    public static Time From(long ticks, TimeTypeOptions? timeTypeOptions = null)
    {
        return From(new TimeOnly(ticks), timeTypeOptions);
    }

    /// <summary>
    /// Creates an instance from DateTime object passed as well as the TimeTypeOptions.
    /// </summary>
    /// <param name="time">The time.</param>
    /// <param name="timeTypeOptions">The time type options.</param>
    /// <returns>A Time.</returns>
    public static Time From(TimeOnly time, TimeTypeOptions? timeTypeOptions)
    {
        var newObject = new Time() { Value = time, _timeTypeOptions = timeTypeOptions ?? new() };

        var result = newObject.Validate();

        if (!result.IsValid)
        {
            throw new TypeValidationException(result.Errors);
        }

        return newObject;
    }

    public static Time From(System.DateTime dateTime, TimeTypeOptions? timeTypeOptions = null)
        => From(TimeOnly.FromDateTime(dateTime), timeTypeOptions); 

    /// <inheritdoc cref="ValueObject{T,TValueObject}.FromDatabase"/>
    public static Time FromDatabase(System.DateTime value) => From(value.Ticks);

    /// <summary>
    /// Validates the contents of the Value object.
    /// </summary>
    /// <returns>A ValidationResult.</returns>
    internal override ValidationResult Validate()
    {
        var result = base.Validate();

        if (Value.Ticks < _timeTypeOptions.MinTimeTicks)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Time type as value {Value.Ticks} is less than than the minimum specified value of {_timeTypeOptions.MinTimeTicks}."));
        }

        if (Value.Ticks > _timeTypeOptions.MaxTimeTicks)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Time type as value {Value.Ticks} is greater than than the maximum specified value of {_timeTypeOptions.MaxTimeTicks}."));
        }

        return result;
    }

    /// <inheritdoc />
    public override string ToString() => ToString(CultureInfo.InvariantCulture);

    /// <summary>
    /// Returns the string in the invariant culture and the format provided.
    /// </summary>
    /// <param name="format">The format.</param>
    /// <returns>
    /// A <see cref="System.String" /> that represents this instance.
    /// </returns>
    public string ToString(string format) => ToString(format, CultureInfo.InvariantCulture);

    /// <summary>
    /// Returns the string in the provided culture and the long time format for the provided culture.
    /// </summary>
    /// <param name="formatProvider">The format provider.</param>
    /// <returns>
    /// A <see cref="System.String" /> that represents this instance.
    /// </returns>
    public string ToString(IFormatProvider formatProvider) => ToString("T", formatProvider);

    /// <summary>
    /// Returns the string in the provided culture and format.
    /// </summary>
    /// <param name="format">The format.</param>
    /// <param name="formatProvider">The format provider.</param>
    /// <returns>
    /// A <see cref="System.String" /> that represents this instance.
    /// </returns>
    public string ToString(string format, IFormatProvider formatProvider) => Value.ToString(format, formatProvider);
}
