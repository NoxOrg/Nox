using System;
using System.Collections.Generic;
using System.Globalization;

namespace Nox.Types;
public sealed class DateTime : ValueObject<System.DateTime, DateTime>
{
    private DateTimeTypeOptions _dateTimeTypeOptions = new();

    public int Year
    {
        get { return Value.Year; }
        private set { Value = new System.DateTime(value, Value.Month, Value.Day, Value.Hour, Value.Minute, Value.Second); }
    }
    public int Month
    {
        get { return Value.Month; }
        private set => Value = new System.DateTime(Value.Year, value, Value.Day, Value.Hour, Value.Minute, Value.Second);
    }
    public int Day
    {
        get { return Value.Day; }
        private set { Value = new System.DateTime(Value.Year, Value.Month, value, Value.Hour, Value.Minute, Value.Second); }
    }
    public int Hour
    {
        get { return Value.Hour; }
        private set { Value = new System.DateTime(Value.Year, Value.Month, Value.Day, value, Value.Minute, Value.Second); }
    }
    public int Minute
    {
        get { return Value.Minute; }
        private set { Value = new System.DateTime(Value.Year, Value.Month, Value.Day, Value.Hour, value, Value.Second); }
    }
    public int Second
    {
        get { return Value.Second; }
        private set { Value = new System.DateTime(Value.Year, Value.Month, Value.Day, Value.Hour, Value.Minute, value); }
    }

    public DateTime() { Value = System.DateTime.MinValue; }

    /// <summary>
    /// Creates and validates a new instance of <see cref="DateTime"/>./>.
    /// </summary>
    /// <param name="year"></param>
    /// <param name="month"></param>
    /// <param name="day"></param>
    /// <param name="hour"></param>
    /// <param name="minute"></param>
    /// <param name="second"></param>
    /// <returns>New <see cref="DateTime"/> object with default <see cref="DateTimeTypeOptions"/> .</returns> 
    /// <exception cref="TypeValidationException"></exception>
    public static DateTime From(int year, int month, int day, int hour = 0, int minute = 0, int second = 0) => From(new DateTimeTypeOptions(), year, month, day, hour, minute, second);
    
    /// <summary>
    /// Creates and validates a new instance of <see cref="DateTime"/>./>.
    /// </summary>
    /// <param name="options"></param>
    /// <param name="year"></param>
    /// <param name="month"></param>
    /// <param name="day"></param>
    /// <param name="hour"></param>
    /// <param name="minute"></param>
    /// <param name="second"></param>
    /// <returns>New <see cref="DateTime"/> object with sent <see cref="DateTimeTypeOptions"/>.</returns> 
    /// <exception cref="TypeValidationException"></exception>
    public static DateTime From(DateTimeTypeOptions options, int year, int month, int day, int hour = 0, int minute = 0, int second = 0)
    {
        var newObject = new DateTime();

        // check if it is a valid System.DateTime
        var validationResult = ValidateDateTime(year, month, day, hour, minute, second);

        if (validationResult.IsValid)
        {
            newObject = new DateTime
            {
                Value = new System.DateTime(year, month, day, hour, minute, second),
                _dateTimeTypeOptions = options
            };

            validationResult = newObject.Validate();
        }

        if (!validationResult.IsValid)
        {
            throw new TypeValidationException(validationResult.Errors);
        }

        return newObject;
    }

    /// <summary>
    /// Creates and validates a new instance of <see cref="DateTime"/> from sent System.DateTime.
    /// </summary>
    /// <param name="dateTime"></param>
    /// <param name="options"></param>
    /// <returns>New <see cref="DateTime"/> object using sent <see cref="System.DateTime"/>.</returns>
    public static DateTime From(System.DateTime dateTime, DateTimeTypeOptions? options = null)
    {
        options ??= new DateTimeTypeOptions();
        return From(options, dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second);
    }

    /// <summary>
    /// Creates and validates a new instance of <see cref="DateTime"/> from parsed value of <see cref="datetime"/>.
    /// </summary>
    /// <param name="dateTime"></param>
    /// <param name="options"></param>
    /// <returns>New <see cref="DateTime"/> object using sent <see cref="datetime"/>.</returns>
    public static DateTime From(string datetime, DateTimeTypeOptions? options = null)
    {
        options ??= new DateTimeTypeOptions();
        if (!System.DateTime.TryParse(datetime, out System.DateTime dateTimeParse))
        {
            throw new ArgumentOutOfRangeException(nameof(datetime), datetime, "Invalid datetime");
        }

        return From(dateTimeParse, options);
    }

    /// <summary>
    /// Validates the if it is possible to create System.DateTime from sent parameters/> object.
    /// </summary>
    /// <returns>A validation result indicating whether the <see cref="System.DateTime"/> is valid or not.</returns>
    private static ValidationResult ValidateDateTime(int year, int month, int day, int hour = 0, int minute = 0, int second = 0)
    {
        var result = new ValidationResult() { };

        try
        {
            // validate month
            if (month < 1 || month > 12)
            {
                result.Errors.Add(new ValidationFailure(nameof(month), $"Could not create a Nox DateTime type as value {month} is not in range 1-12"));
            }

            // validate year
            if (year < System.DateTime.MinValue.Year || year > System.DateTime.MaxValue.Year)
            {
                result.Errors.Add(new ValidationFailure(nameof(year), $"Could not create a Nox DateTime type as value {year} is not valid"));
            }

            _ = new System.DateTime(year, month, day, hour, minute, second);
        }
        catch
        {
            result.Errors.Add(new ValidationFailure(nameof(day), $"Could not create a Nox DateTime type a value {day} is not valid"));
        }

        return result;
    }

    /// <summary>
    /// Validates a <see cref="DateTime"/> object.
    /// </summary>
    /// <returns>True if the <see cref="DateTime"/> value is valid, otherwise false.</returns>
    internal override ValidationResult Validate()
    {
        var result = base.Validate();

        // validate date by options
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

    /// <summary>
    /// 
    /// </summary>
    /// <param name="dt"></param>
    /// <param name="ts"></param>
    /// <returns></returns>
    public static DateTime operator +(DateTime dt, TimeSpan ts)
    {
        System.DateTime newDateTime = dt.Value.Add(ts);
        return DateTime.From(newDateTime);
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
    /// Returns a string representation of the custom date and time using sent <see cref="CultureInfo"/>.
    /// </summary>
    /// <param name="cultureInfo"></param>
    public string ToString(CultureInfo cultureInfo)
    {
        return Value.ToString(cultureInfo);
    }

    /// <summary>
    /// Returns a string representation of the custom date and time using sent <see cref="CultureInfo"/> and wanted format.
    /// </summary>
    /// <param name="format"></param>
    /// <param name="cultureInfo"></param>
    public string ToString(string format, CultureInfo cultureInfo)
    {
        return Value.ToString(format, cultureInfo);
    }

    /// <summary>
    /// Returns a string representation of the custom date and time using <see cref="CultureInfo.InvariantCulture"/> and wanted format.
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
    /// <param name="formatProvider"></param>
    /// <returns></returns>
    public string ToString(string format, IFormatProvider formatProvider)
    {
        return Value.ToString(format, formatProvider);
    }

    /// <summary>
    /// Adds sent Timespan on <see cref="DateTime.Value"/>
    /// </summary>
    /// <param name="ts"></param>
    public void Add(TimeSpan ts)
    {
        Value = Value.Add(ts);
    }
}

