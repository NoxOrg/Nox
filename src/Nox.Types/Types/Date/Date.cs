using System;
using System.Globalization;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="Date" /> type and value object.
/// </summary>
/// <remarks>
/// Contains only the date component, without time.
/// </remarks>
public sealed class Date : ValueObject<DateOnly, Date>
{
    private DateTypeOptions _dateTypeOptions = new();

    /// <summary>
    /// Creates a new instance of <see cref="Date"/> object.
    /// </summary>
    /// <param name="date">The date time to create date from.</param>
    /// <param name="dateTypeOptions">The date type options.</param>
    /// <exception cref="TypeValidationException"></exception>
    public static Date From(DateOnly date, DateTypeOptions dateTypeOptions)
    {
        var newObject = new Date
        {
            Value = date,
            _dateTypeOptions = dateTypeOptions
        };

        var validationResult = newObject.Validate();

        if (!validationResult.IsValid)
        {
            throw new TypeValidationException(validationResult.Errors);
        }

        return newObject;
    }

    /// <summary>
    /// Creates a new instance of <see cref="Date"/> object.
    /// </summary>
    /// <param name="year">The year.</param>
    /// <param name="month">The month.</param>
    /// <param name="day">The day.</param>
    /// <param name="dateTypeOptions">The date type options.</param>
    /// <exception cref="TypeValidationException"></exception>
    public static Date From(int year, int month, int day, DateTypeOptions? dateTypeOptions = null)
    {
        var date = new DateOnly(year, month, day);
        return From(date, dateTypeOptions ?? new DateTypeOptions());
    }

    /// <summary>
    /// Creates a new instance of <see cref="Date"/> object.
    /// </summary>
    /// <param name="dateTime">The date time.</param>
    /// <param name="dateTypeOptions">The date type options.</param>
    /// <exception cref="TypeValidationException"></exception>
    public static Date From(System.DateTime dateTime, DateTypeOptions? dateTypeOptions = null)
    {
        var date = DateOnly.FromDateTime(dateTime);
        return From(date, dateTypeOptions ?? new DateTypeOptions());
    }

    internal override ValidationResult Validate()
    {
        var result = base.Validate();

        if (Value < DateOnly.FromDateTime(_dateTypeOptions.MinValue))
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Date type as value {Value.ToString("d", CultureInfo.InvariantCulture)} is less than than the minimum specified value of {_dateTypeOptions.MinValue.Date.ToString("d", CultureInfo.InvariantCulture)}"));
        }

        if (Value > DateOnly.FromDateTime(_dateTypeOptions.MaxValue))
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Date type as value {Value.ToString("d", CultureInfo.InvariantCulture)} is greater than than the maximum specified value of {_dateTypeOptions.MaxValue.Date.ToString("d", CultureInfo.InvariantCulture)}"));
        }

        return result;
    }

    /// <summary>
    /// Gets the year of the date.
    /// </summary>
    public int Year => Value.Year;

    /// <summary>
    /// Gets the month of the date.
    /// </summary>
    public int Month => Value.Month;

    /// <summary>
    /// Gets the day of the date.
    /// </summary>
    public int Day => Value.Day;

    /// <summary>
    /// Gets the day of week.
    /// </summary>
    public System.DayOfWeek DayOfWeek => Value.DayOfWeek;

    /// <summary>
    /// Gets the day of year.
    /// </summary>
    public int DayOfYear => Value.DayOfYear;

    /// <summary>
    /// Returns a string representation of the <see cref="Date"/> in invariant culture.
    /// </summary>
    /// <returns>
    /// A string representation of the <see cref="Date"/> object in invariant culture.
    /// </returns>
    public override string ToString()
        => ToString("d", CultureInfo.InvariantCulture);

    /// <summary>
    /// Returns a string representation of the <see cref="Date"/> in specified format in invariant culture.
    /// </summary>
    /// <param name="format">The format.</param>
    /// <returns>
    /// A string representation of the <see cref="Date"/> object in specified format in invariant culture.
    /// </returns>
    public string ToString(string format)
        => ToString(format, CultureInfo.InvariantCulture);

    /// <summary>
    /// Returns a string representation of the <see cref="Date"/> in using the specified <see cref="IFormatProvider"/>.
    /// </summary>
    /// <param name="format">The format.</param>
    /// <param name="formatProvider">The format provider.</param>
    /// <returns>
    /// A string representation of the <see cref="Date"/> object using the specified <see cref="IFormatProvider"/>.
    /// </returns>
    public string ToString(IFormatProvider formatProvider)
        => ToString("d", formatProvider);

    /// <summary>
    /// Returns a string representation of the <see cref="Date"/> in specified format using the specified <see cref="IFormatProvider"/>.
    /// </summary>
    /// <param name="format">The format.</param>
    /// <param name="formatProvider">The format provider.</param>
    /// <returns>
    /// A string representation of the <see cref="Dat"/> object in specified format using the specified <see cref="IFormatProvider"/>.
    /// </returns>
    public string ToString(string format, IFormatProvider formatProvider)
        => Value.ToString(format, formatProvider);

    /// <summary>
    /// Determines whether one specified Date is later than another specified Date.
    /// </summary>
    /// <param name="left">The first object to compare.</param>
    /// <param name="right">The second object to compare.</param>
    public static bool operator >(Date left, Date right) => left.Value > right.Value;

    /// <summary>
    /// Determines whether one specified Date represents a date that is the same as or later than another specified Date.
    /// </summary>
    /// <param name="left">The first object to compare.</param>
    /// <param name="right">The second object to compare.</param>
    public static bool operator >=(Date left, Date right) => left.Value >= right.Value;

    /// <summary>
    /// Determines whether one specified Date is earlier than another specified Date.
    /// </summary>
    /// <param name="left">The first object to compare.</param>
    /// <param name="right">The second object to compare.</param>
    public static bool operator <(Date left, Date right) => left.Value < right.Value;

    /// <summary>
    /// Determines whether one specified Date represents a date that is the same as or earlier than another specified Date.
    /// </summary>
    /// <param name="left">The first object to compare.</param>
    /// <param name="right">The second object to compare.</param>
    public static bool operator <=(Date left, Date right) => left.Value <= right.Value;
}
