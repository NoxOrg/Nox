using System;
using System.Data.Common;
using System.Globalization;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="Date" /> type and value object.
/// </summary>
/// <remarks>
/// Contains only the date component, without time.
/// </remarks>
public sealed class Date : ValueObject<DateTime, Date>
{
    // List of time components taken from .NET source
    private static readonly char[] TimeComponentsInDateTimeFormat = new char[] { ':', 't', 'f', 'F', 'h', 'H', 'm', 's', 'z', 'K' };

    private DateTypeOptions _dateTypeOptions = new();

    /// <summary>
    /// Creates a new instance of <see cref="Date"/> object.
    /// </summary>
    /// <param name="dateTime">The date time to create date from.</param>
    /// <param name="dateTypeOptions">The date type options.</param>
    /// <exception cref="TypeValidationException"></exception>
    public static Date From(DateTime dateTime, DateTypeOptions dateTypeOptions)
    {
        var newObject = new Date
        {
            Value = dateTime.Date,
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
    public static Date From(int year, int month, int day, DateTypeOptions dateTypeOptions)
    {
        var dateTime = new DateTime(year, month, day);
        return From(dateTime, dateTypeOptions);
    }

    internal override ValidationResult Validate()
    {
        var result = base.Validate();

        if (Value.Date < _dateTypeOptions.MinValue)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Number type as value {Value.Date.ToString("d", CultureInfo.InvariantCulture)} is less than than the minimum specified value of {_dateTypeOptions.MinValue.Date.ToString("d", CultureInfo.InvariantCulture)}"));
        }

        if (Value.Date > _dateTypeOptions.MaxValue)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Number type as value {Value.Date.ToString("d", CultureInfo.InvariantCulture)} is greater than than the maximum specified value of {_dateTypeOptions.MaxValue.Date.ToString("d", CultureInfo.InvariantCulture)}"));
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

    public override string ToString()
        => ToString("d", CultureInfo.InvariantCulture);

    public string ToString(string format)
        => ToString(format, CultureInfo.InvariantCulture);

    public string ToString(IFormatProvider formatProvider)
        => ToString("d", formatProvider);

    public string ToString(string format, IFormatProvider formatProvider)
    {
        if (!IsValidDateOnlyFormat(format))
        {
            throw new FormatException("Input string was not in a correct format.");
        }

        return Value.Date.ToString(format, formatProvider);
    }

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

    private bool IsValidDateOnlyFormat(string format)
        => format.IndexOfAny(TimeComponentsInDateTimeFormat) == -1;
}
