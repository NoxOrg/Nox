using System;
using System.Globalization;

namespace Nox.Types;

public sealed class DateTimeDuration : ValueObject<long, DateTimeDuration>
{
    private DateTimeDurationTypeOptions _dateTimeDurationTypeOptions = new();
    private TimeSpan _duration;

    /// <inheritdocs />
    public new static DateTimeDuration FromDatabase(long value)
    {
        return new DateTimeDuration 
        { 
            Value = value,
            _duration = new TimeSpan(value)
        };
    }

    /// <summary>
    /// Creates a new instance of <see cref="DateTimeDuration"/> object.
    /// </summary>
    /// <param name="ticks">The number of ticks to create date time duration from.</param>
    /// <param name="options">The options.</param>
    /// <remarks>
    /// There are 10 000 ticks in a millisecond
    /// </remarks>
    /// <exception cref="Nox.Types.TypeValidationException"></exception>
    public static DateTimeDuration From(long ticks, DateTimeDurationTypeOptions options)
    {
        var newObject = new DateTimeDuration
        {
            _duration = new TimeSpan(ticks).Duration(),
            Value = new TimeSpan(ticks).Duration().Ticks,
            _dateTimeDurationTypeOptions = options
        };

        var validationResult = newObject.Validate();

        if (!validationResult.IsValid)
        {
            throw new TypeValidationException(validationResult.Errors);
        }

        return newObject;
    }

    /// <summary>
    /// Creates a new instance of <see cref="DateTimeDuration"/> object.
    /// </summary>
    /// <param name="ticks">The number of ticks to create date time duration from.</param>
    /// <remarks>
    /// There are 10 000 ticks in a millisecond
    /// </remarks>
    /// <exception cref="TypeValidationException"></exception>
    public new static DateTimeDuration From(long ticks)
        => From(ticks, new());

    /// <summary>
    /// Creates a new instance of <see cref="DateTimeDuration"/> object.
    /// </summary>
    /// <param name="timeSpan">The time span to create date time duration from.</param>
    /// <param name="options">The options.</param>
    /// <returns></returns>
    /// <exception cref="Nox.Types.TypeValidationException"></exception>
    public static DateTimeDuration From(TimeSpan timeSpan, DateTimeDurationTypeOptions options)
        => From(timeSpan.Duration().Ticks, options);

    /// <summary>
    /// Creates a new instance of <see cref="DateTimeDuration"/> object.
    /// </summary>
    /// <param name="timeSpan">The time span to create date time duration from.</param>
    /// <exception cref="TypeValidationException"></exception>
    public static DateTimeDuration From(TimeSpan timeSpan)
        => From(timeSpan, new());

    /// <summary>
    /// Creates a new instance of <see cref="DateTimeDuration"/> object to a specified number of days, hours, minutes, seconds and milliseconds.
    /// </summary>
    /// <param name="days">The days.</param>
    /// <param name="hours">The hours.</param>
    /// <param name="minutes">The minutes.</param>
    /// <param name="seconds">The seconds.</param>
    /// <param name="milliseconds">The milliseconds.</param>
    /// <param name="options">The options.</param>
    /// <exception cref="TypeValidationException"></exception>
    public static DateTimeDuration From(int days, int hours, int minutes, int seconds, int milliseconds, DateTimeDurationTypeOptions? options = null)
        => From(new TimeSpan(days, hours, minutes, seconds, milliseconds), options ?? new());

    /// <summary>
    /// Creates a new instance of <see cref="DateTimeDuration"/> object to a specified number of days, hours, minutes and seconds.
    /// </summary>
    /// <param name="days">The days.</param>
    /// <param name="hours">The hours.</param>
    /// <param name="minutes">The minutes.</param>
    /// <param name="seconds">The seconds.</param>
    /// <param name="options">The options.</param>
    /// <exception cref="TypeValidationException"></exception>
    public static DateTimeDuration From(int days, int hours, int minutes, int seconds, DateTimeDurationTypeOptions? options = null)
        => From(new TimeSpan(days, hours, minutes, seconds), options ?? new());

    /// <summary>
    /// Creates a new instance of <see cref="DateTimeDuration"/> object to a specified number of hours, minutes and seconds.
    /// </summary>
    /// <param name="hours">The hours.</param>
    /// <param name="minutes">The minutes.</param>
    /// <param name="seconds">The seconds.</param>
    /// <param name="options">The options.</param>
    /// <exception cref="TypeValidationException"></exception>
    public static DateTimeDuration From(int hours, int minutes, int seconds, DateTimeDurationTypeOptions? options = null)
        => From(new TimeSpan(hours, minutes, seconds), options ?? new());

    /// <summary>
    /// Creates a new instance of <see cref="DateTimeDuration"/> object to a specified number of days accurate to nearest millisecond.
    /// </summary>
    /// <param name="days">The days.</param>
    /// <param name="options">The options.</param>
    /// <exception cref="TypeValidationException"></exception>
    public static DateTimeDuration FromDays(double days, DateTimeDurationTypeOptions? options = null)
        => From(TimeSpan.FromDays(days), options ?? new());

    /// <summary>
    /// Creates a new instance of <see cref="DateTimeDuration" /> object to a specified number of hours accurate to nearest millisecond.
    /// </summary>
    /// <param name="hours">The hours.</param>
    /// <param name="options">The options.</param>
    /// <exception cref="TypeValidationException"></exception>
    public static DateTimeDuration FromHours(double hours, DateTimeDurationTypeOptions? options = null)
        => From(TimeSpan.FromHours(hours), options ?? new());

    /// <summary>
    /// Creates a new instance of <see cref="DateTimeDuration" /> object to a specified number of minutes accurate to nearest millisecond.
    /// </summary>
    /// <param name="minutes">The minutes.</param>
    /// <param name="options">The options.</param>
    /// <exception cref="TypeValidationException"></exception>
    public static DateTimeDuration FromMinutes(double minutes, DateTimeDurationTypeOptions? options = null)
        => From(TimeSpan.FromMinutes(minutes), options ?? new());

    /// <summary>
    /// Creates a new instance of <see cref="DateTimeDuration"/> object to a specified number of seconds accurate to nearest millisecond.
    /// </summary>
    /// <param name="seconds">The seconds.</param>
    /// <param name="options">The options.</param>
    /// <exception cref="TypeValidationException"></exception>
    public static DateTimeDuration FromSeconds(double seconds, DateTimeDurationTypeOptions? options = null)
        => From(TimeSpan.FromSeconds(seconds), options ?? new());

    /// <summary>
    /// Creates a new instance of <see cref="DateTimeDuration"/> object to a specified number of milliseconds.
    /// </summary>
    /// <param name="milliseconds">The milliseconds.</param>
    /// <param name="options">The options.</param>
    /// <exception cref="TypeValidationException"></exception>
    public static DateTimeDuration FromMilliseconds(double milliseconds, DateTimeDurationTypeOptions? options = null)
        => From(TimeSpan.FromMilliseconds(milliseconds), options ?? new());

    /// <summary>
    /// Gets the days component of the duration.
    /// </summary>
    public int Days => _duration.Days;

    /// <summary>
    /// Gets the hours component of the duration.
    /// </summary>
    public int Hours => _duration.Hours;

    /// <summary>
    /// Gets the minutes component of the duration.
    /// </summary>
    public int Minutes => _duration.Minutes;

    /// <summary>
    /// Gets the seconds component of the duration.
    /// </summary>
    public int Seconds => _duration.Seconds;

    /// <summary>
    /// Gets the milliseconds component of the duration.
    /// </summary>
    public int Milliseconds => _duration.Milliseconds;

    /// <summary>
    /// Gets the value of current instance in whole and fractional days.
    /// </summary>
    public double TotalDays => _duration.TotalDays;

    /// <summary>
    /// Gets the value of current instance in whole and fractional hours.
    /// </summary>
    public double TotalHours => _duration.TotalHours;

    /// <summary>
    /// Gets the value of current instance in whole and fractional minutes.
    /// </summary>
    public double TotalMinutes => _duration.TotalMinutes;

    /// <summary>
    /// Gets the value of current instance in whole and fractional seconds.
    /// </summary>
    public double TotalSeconds => _duration.TotalSeconds;

    /// <summary>
    /// Gets the value of current instance in whole and fractional milliseconds.
    /// </summary>
    public double TotalMilliseconds => _duration.TotalMilliseconds;

    /// <summary>
    /// Gets the number of ticks in the duration.
    /// </summary>
    public long Ticks => _duration.Ticks;

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
        => _duration.ToString("c", CultureInfo.InvariantCulture);

    /// <summary>
    /// Returns a string representation of the <see cref="DateTimeDuration"/> in specified format in invariant culture.
    /// </summary>
    /// <param name="format">The format.</param>
    /// <returns>
    /// A string representation of the <see cref="DateTimeDuration"/> object in specified format in invariant culture.
    /// </returns>
    public string ToString(string format)
        => _duration.ToString(format, CultureInfo.InvariantCulture);

    /// <summary>
    /// Returns a string representation of the <see cref="DateTimeDuration"/> in specified format using the specified <see cref="IFormatProvider"/>.
    /// </summary>
    /// <param name="format">The format.</param>
    /// <param name="formatProvider">The format provider.</param>
    /// <returns>
    /// A string representation of the <see cref="DateTimeDuration"/> object in specified format using the specified <see cref="IFormatProvider"/>.
    /// </returns>
    public string ToString(string format, IFormatProvider formatProvider)
        => _duration.ToString(format, formatProvider);

    /// <summary>
    /// Validates a <see cref="DateTimeDuration"/> object.
    /// </summary>
    /// <returns>
    /// true if the <see cref="DateTimeDuration"/> value is valid.
    /// </returns>
    internal override ValidationResult Validate()
    {
        var result = base.Validate();

        if (_duration < _dateTimeDurationTypeOptions.GetMinDuration())
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox DateTimeDuration type as value {_duration.ToString("c", CultureInfo.InvariantCulture)} is less than than the minimum specified value of {_dateTimeDurationTypeOptions.GetMinDuration().ToString("c", CultureInfo.InvariantCulture)}"));
        }

        if (_duration > _dateTimeDurationTypeOptions.GetMaxDuration())
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox DateTimeDuration type as value {_duration.ToString("c", CultureInfo.InvariantCulture)} is greater than than the maximum specified value of {_dateTimeDurationTypeOptions.GetMaxDuration().ToString("c", CultureInfo.InvariantCulture)}"));
        }

        return result;
    }
}
