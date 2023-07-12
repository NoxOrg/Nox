using System;
using System.Globalization;

namespace Nox.Types;

public sealed class DateTimeDuration : ValueObject<TimeSpan, DateTimeDuration>
{
    /// <summary>
    /// Creates a new instance of <see cref="DateTimeDuration"/> object.
    /// </summary>
    /// <param name="dateTime">The time span to create date time duration from.</param>
    /// <exception cref="TypeValidationException"></exception>
    public new static DateTimeDuration From(TimeSpan value)
    {
        var newObject = new DateTimeDuration
        {
            Value = value.Duration()
        };

        var validationResult = newObject.Validate();

        if (!validationResult.IsValid)
        {
            throw new TypeValidationException(validationResult.Errors);
        }

        return newObject;
    }

    /// <summary>
    /// Creates a new instance of <see cref="DateTimeDuration"/> object to a specified number of days, hours, minutes, seconds and milliseconds.
    /// </summary>
    /// <param name="days">The days.</param>
    /// <param name="hours">The hours.</param>
    /// <param name="minutes">The minutes.</param>
    /// <param name="seconds">The seconds.</param>
    /// <param name="milliseconds">The milliseconds.</param>
    /// <exception cref="TypeValidationException"></exception>
    public static DateTimeDuration From(int days, int hours, int minutes, int seconds, int milliseconds)
        => From(new TimeSpan(days, hours, minutes, seconds, milliseconds));

    /// <summary>
    /// Creates a new instance of <see cref="DateTimeDuration"/> object to a specified number of days, hours, minutes and seconds.
    /// </summary>
    /// <param name="days">The days.</param>
    /// <param name="hours">The hours.</param>
    /// <param name="minutes">The minutes.</param>
    /// <param name="seconds">The seconds.</param>
    /// <exception cref="TypeValidationException"></exception>
    public static DateTimeDuration From(int days, int hours, int minutes, int seconds)
        => From(new TimeSpan(days, hours, minutes, seconds));

    /// <summary>
    /// Creates a new instance of <see cref="DateTimeDuration"/> object to a specified number of hours, minutes and seconds.
    /// </summary>
    /// <param name="hours">The hours.</param>
    /// <param name="minutes">The minutes.</param>
    /// <param name="seconds">The seconds.</param>
    /// <exception cref="TypeValidationException"></exception>
    public static DateTimeDuration From(int hours, int minutes, int seconds)
        => From(new TimeSpan(hours, minutes, seconds));

    /// <summary>
    /// Creates a new instance of <see cref="DateTimeDuration"/> object to a specified number of days accurate to nearest millisecond.
    /// </summary>
    /// <param name="days">The days.</param>
    /// <exception cref="TypeValidationException"></exception>
    public static DateTimeDuration FromDays(double days)
        => From(TimeSpan.FromDays(days));

    /// <summary>
    /// Creates a new instance of <see cref="DateTimeDuration"/> object to a specified number of hours accurate to nearest millisecond.
    /// </summary>
    /// <param name="hours">The hours.</param>
    /// <exception cref="TypeValidationException"></exception>
    public static DateTimeDuration FromHours(double hours)
        => From(TimeSpan.FromHours(hours));

    /// <summary>
    /// Creates a new instance of <see cref="DateTimeDuration"/> object to a specified number of minutes accurate to nearest millisecond.
    /// </summary>
    /// <param name="minutes">The minutes.</param>
    /// <exception cref="TypeValidationException"></exception>
    public static DateTimeDuration FromMinutes(double minutes)
        => From(TimeSpan.FromMinutes(minutes));

    /// <summary>
    /// Creates a new instance of <see cref="DateTimeDuration"/> object to a specified number of seconds accurate to nearest millisecond.
    /// </summary>
    /// <param name="seconds">The seconds.</param>
    /// <exception cref="TypeValidationException"></exception>
    public static DateTimeDuration FromSeconds(double seconds)
        => From(TimeSpan.FromSeconds(seconds));

    /// <summary>
    /// Creates a new instance of <see cref="DateTimeDuration"/> object to a specified number of milliseconds.
    /// </summary>
    /// <param name="milliseconds">The milliseconds.</param>
    /// <exception cref="TypeValidationException"></exception>
    public static DateTimeDuration FromMilliseconds(double milliseconds)
        => From(TimeSpan.FromMilliseconds(milliseconds));

    /// <summary>
    /// Gets the days component of the duration.
    /// </summary>
    public int Days => Value.Days;

    /// <summary>
    /// Gets the hours component of the duration.
    /// </summary>
    public int Hours => Value.Hours;

    /// <summary>
    /// Gets the minutes component of the duration.
    /// </summary>
    public int Minutes => Value.Minutes;

    /// <summary>
    /// Gets the seconds component of the duration.
    /// </summary>
    public int Seconds => Value.Seconds;

    /// <summary>
    /// Gets the milliseconds component of the duration.
    /// </summary>
    public int Milliseconds => Value.Milliseconds;

    /// <summary>
    /// Gets the value of current instance in whole and fractional days.
    /// </summary>
    public double TotalDays => Value.TotalDays;

    /// <summary>
    /// Gets the value of current instance in whole and fractional hours.
    /// </summary>
    public double TotalHours => Value.TotalHours;

    /// <summary>
    /// Gets the value of current instance in whole and fractional minutes.
    /// </summary>
    public double TotalMinutes => Value.TotalMinutes;

    /// <summary>
    /// Gets the value of current instance in whole and fractional seconds.
    /// </summary>
    public double TotalSeconds => Value.TotalSeconds;

    /// <summary>
    /// Gets the value of current instance in whole and fractional milliseconds.
    /// </summary>
    public double TotalMilliseconds => Value.TotalMilliseconds;

    /// <summary>
    /// Determines whether one specified DateTimeDuration is less than another specified DateTimeDuration.
    /// </summary>
    /// <param name="left">The first object to compare.</param>
    /// <param name="right">The second object to compare.</param>
    public static bool operator <(DateTimeDuration left, DateTimeDuration right) => left.Value < right.Value;

    /// <summary>
    /// Determines whether one specified DateTimeDuration is less than or equal to another specified DateTimeDuration.
    /// </summary>
    /// <param name="left">The first object to compare.</param>
    /// <param name="right">The second object to compare.</param>
    public static bool operator <=(DateTimeDuration left, DateTimeDuration right) => left.Value <= right.Value;

    /// <summary>
    /// Determines whether one specified DateTimeDuration is greater than another specified DateTimeDuration.
    /// </summary>
    /// <param name="left">The first object to compare.</param>
    /// <param name="right">The second object to compare.</param>
    public static bool operator >(DateTimeDuration left, DateTimeDuration right) => left.Value > right.Value;

    /// <summary>
    /// Determines whether one specified DateTimeDuration is greater than or equal to another specified DateTimeDuration.
    /// </summary>
    /// <param name="left">The first object to compare.</param>
    /// <param name="right">The second object to compare.</param>
    public static bool operator >=(DateTimeDuration left, DateTimeDuration right) => left.Value >= right.Value;

    /// <summary>
    /// Adds two DateTimeDuration objects and returns it as a new object.
    /// </summary>
    /// <param name="left">The first object to compare.</param>
    /// <param name="right">The second object to compare.</param>
    public static DateTimeDuration operator +(DateTimeDuration left, DateTimeDuration right) => From(left.Value + right.Value);

    /// <summary>
    /// Subtracts a specified DateTimeDuration object from another and returns the result as a new object.
    /// </summary>
    /// <param name="left">The first object to compare.</param>
    /// <param name="right">The second object to compare.</param>
    public static DateTimeDuration operator -(DateTimeDuration left, DateTimeDuration right) => From(left.Value - right.Value);

    /// <summary>
    /// Returns a string representation of the <see cref="DateTimeDuration"/> in invariant culture.
    /// </summary>
    /// <returns>
    /// A string representation of the <see cref="DateTimeDuration"/> object in invariant culture.
    /// </returns>
    public new string ToString()
        => Value.ToString("c", CultureInfo.InvariantCulture);

    /// <summary>
    /// Returns a string representation of the <see cref="DateTimeDuration"/> in specified format in invariant culture.
    /// </summary>
    /// <param name="format">The format.</param>
    /// <returns>
    /// A string representation of the <see cref="DateTimeDuration"/> object in specified format in invariant culture.
    /// </returns>
    public string ToString(string format)
        => Value.ToString(format, CultureInfo.InvariantCulture);

    /// <summary>
    /// Returns a string representation of the <see cref="DateTimeDuration"/> in specified format using the specified <see cref="IFormatProvider"/>.
    /// </summary>
    /// <param name="format">The format.</param>
    /// <param name="formatProvider">The format provider.</param>
    /// <returns>
    /// A string representation of the <see cref="DateTimeDuration"/> object in specified format using the specified <see cref="IFormatProvider"/>.
    /// </returns>
    public string ToString(string format, IFormatProvider formatProvider)
        => Value.ToString(format, formatProvider);
}
