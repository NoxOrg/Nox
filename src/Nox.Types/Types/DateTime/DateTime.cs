using System;
using System.Globalization;

namespace Nox.Types;
public sealed class DateTime : ValueObject<DateTimeOffset, DateTime>
{
    private DateTimeTypeOptions _dateTimeTypeOptions = new();

    public DateTime() { Value = DateTimeOffset.MinValue; }


    /// <summary>
    /// Creates <see cref="DateTime"/> object from sent <see cref="System.DateTime"/>
    /// </summary>
    /// <param name="dateTime"></param>
    /// <param name="options"></param>
    /// <returns>New <see cref="DateTime"/> object</returns>
    public static DateTime From(System.DateTime dateTime, DateTimeTypeOptions? options = null)
    {
        options ??= new DateTimeTypeOptions();
        return From(new DateTimeOffset(dateTime), options);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dateTime"></param>
    /// <param name="timespan"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    /// <exception cref="NoxTypeValidationException"></exception>
    public static DateTime From(System.DateTime dateTime, TimeSpan timespan, DateTimeTypeOptions? options = null)
    {
        options ??= new DateTimeTypeOptions();
        var datetimeoffset = new DateTimeOffset(dateTime, timespan);
        return From(datetimeoffset, options);
    }

    /// <summary>
    /// Creates and validates a new instance of <see cref="DateTime"/> from parsed value of <paramref name="dateTime"/>.
    /// </summary>
    /// <param name="dateTime"></param>
    /// <param name="options"></param>
    /// <returns>New <see cref="DateTime"/> object from parsed value of <paramref name="dateTime"/>.</returns>
    public static DateTime From(DateTimeOffset dateTime, DateTimeTypeOptions? options = null)
    {
        options ??= new DateTimeTypeOptions();
        var newObject = new DateTime
        {
            Value = dateTime,
            _dateTimeTypeOptions = options,
        };

        var validationResult = newObject.Validate();

        if (!validationResult.IsValid)
        {
            throw new NoxTypeValidationException(validationResult.Errors);
        }

        return newObject;
    }

    /// <summary>
    /// Creates and validates a new instance of <see cref="DateTime"/> from parsed value of <paramref name="dateTime"/>.
    /// </summary>
    /// <param name="dateTime"></param>
    /// <param name="options"></param>
    /// <returns>New <see cref="DateTime"/> object parsed from <see cref="dateTime"/>.</returns>
    public static DateTime From(string dateTime, DateTimeTypeOptions? options = null)
    {
        options ??= new DateTimeTypeOptions();
        if (!DateTimeOffset.TryParse(dateTime, CultureInfo.InvariantCulture, out DateTimeOffset dateTimeParse))
        {
            throw new ArgumentOutOfRangeException(nameof(dateTime), dateTime, "Invalid datetime");
        }

        return From(dateTimeParse, options);
    }

    /// <summary>
    /// Validates a <see cref="DateTime"/> object.
    /// </summary>
    /// <returns>True if the <see cref="DateTime"/> value is valid, otherwise false.</returns>
    internal override ValidationResult Validate()
    {
        var result = base.Validate();

        // validate date by options
        if (_dateTimeTypeOptions.AllowFutureOnly && Value < DateTimeOffset.UtcNow)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox DateTime type as value {Value} is in the past"));
        }

        if (Value < _dateTimeTypeOptions.MinValue)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox DateTime type as value {Value} is less than the minimum specified value of {_dateTimeTypeOptions.MinValue}"));
        }

        if (Value > _dateTimeTypeOptions.MaxValue)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox DateTime type a value {Value} is greater than the maximum specified value of {_dateTimeTypeOptions.MaxValue}"));
        }

        return result;
    }

    public static DateTime operator +(DateTime dateTime, TimeSpan timeSpan)
    {
        DateTimeOffset newDateTime = dateTime.Value.Add(timeSpan);
        return From(newDateTime);
    }

    public static TimeSpan operator -(DateTime dateTime1, DateTime dateTime2)
    {
        return dateTime1.Value - dateTime2.Value;
    }

    public static bool operator >(DateTime dateTime1, DateTime dateTime2)
    {
        return dateTime1.Value > dateTime2.Value;
    }

    public static bool operator <(DateTime dateTime1, DateTime dateTime2)
    {
        return dateTime1.Value < dateTime2.Value;
    }

    public static bool operator <=(DateTime dateTime1, DateTime dateTime2)
    {
        return dateTime1.Value <= dateTime2.Value;
    }

    public static bool operator >=(DateTime dateTime1, DateTime dateTime2)
    {
        return dateTime1.Value >= dateTime2.Value;
    }

    /// <summary>
    /// Returns a string representation of the custom date and time using <see cref="CultureInfo.InvariantCulture"/>.
    /// </summary>
    public override string ToString()
    {
        return Value.ToString(CultureInfo.InvariantCulture);
    }

    /// <summary>
    /// Returns a string representation of the custom date and time using the provided <paramref name="cultureInfo"/>.
    /// </summary>
    /// <param name="cultureInfo"></param>
    public string ToString(CultureInfo cultureInfo)
    {
        return Value.ToString(cultureInfo);
    }

    /// <summary>
    /// Returns a string representation of the custom date and time using the provided <paramref name="cultureInfo"/> and <paramref name="format"/>.
    /// </summary>
    /// <param name="format"></param>
    /// <param name="cultureInfo"></param>
    public string ToString(string format, CultureInfo cultureInfo)
    {
        return Value.ToString(format, cultureInfo);
    }

    /// <summary>
    /// Returns a string representation of the custom date and time using <see cref="CultureInfo.InvariantCulture"/> and the provided <paramref name="format"/>.
    /// </summary>
    /// <param name="format"></param>
    public string ToString(string format)
    => Value.ToString(format, CultureInfo.InvariantCulture);

    /// <summary>
    /// Returns a string representation of the custom date and time using <see cref="IFormatProvider"/>.
    /// </summary>
    /// <param name="formatProvider"></param>
    public string ToString(IFormatProvider formatProvider)
    {
        return Value.ToString(formatProvider);
    }

    /// <summary>
    /// Returns a string representation of the custom date and time using <see cref="IFormatProvider"/> and wanted format.
    /// </summary>
    /// <param name="format"></param>
    /// <param name="formatProvider"></param>
    /// <returns></returns>
    public string ToString(string format, IFormatProvider formatProvider)
    {
        return Value.ToString(format, formatProvider);
    }

    private System.DateTime TrimDateForComparison(DateTimeOffset dateTime)
    {
        return new System.DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second, DateTimeKind.Unspecified);
    }
}

