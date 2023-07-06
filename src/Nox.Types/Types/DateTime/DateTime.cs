using System;
using System.Collections.Generic;
using System.Globalization;

namespace Nox.Types;
public class DateTime : ValueObject<System.DateTime, DateTime>
{
    public int Year
    {
        get { return Value.Year; }
        set { Value = new System.DateTime(value, Value.Month, Value.Day, Value.Hour, Value.Minute, Value.Second); }
    }
    public int Month
    {
        get { return Value.Month; }
        set { Value = new System.DateTime(Value.Year, value, Value.Day, Value.Hour, Value.Minute, Value.Second); }
    }
    public int Day
    {
        get { return Value.Day; }
        set { Value = new System.DateTime(Value.Year, Value.Month, value, Value.Hour, Value.Minute, Value.Second); }
    }
    public int Hour
    {
        get { return Value.Hour; }
        set { Value = new System.DateTime(Value.Year, Value.Month, Value.Day, value, Value.Minute, Value.Second); }
    }
    public int Minute
    {
        get { return Value.Minute; }
        set { Value = new System.DateTime(Value.Year, Value.Month, Value.Day, Value.Hour, value, Value.Second); }
    }
    public int Second
    {
        get { return Value.Second; }
        set { Value = new System.DateTime(Value.Year, Value.Month, Value.Day, Value.Hour, Value.Minute, value); }
    }

    public DateTime() { Value = System.DateTime.MinValue; }

    public static DateTime From(int year, int month, int day, int hour = 0, int minute = 0, int second = 0)
    {
        var yearObject = Types.Year.From((ushort)year);
        var validationResultYear = yearObject.Validate();
        var monthObject = Types.Month.From((byte)month);
        var validationResultMonth = monthObject.Validate();

        if (!validationResultYear.IsValid || !validationResultMonth.IsValid || !IsValidDate(year, month, day, hour, minute, second))
        {
            validationResultYear.Errors.AddRange(validationResultMonth.Errors);
            throw new TypeValidationException(validationResultYear.Errors);
        }

        if(!IsValidDate(year, month, day, hour, minute, second))
        {
            throw new TypeValidationException(new List<ValidationFailure>
            {
                new ValidationFailure(nameof(year), "Year, Month, and Day parameters describe an un-representable DateTime.")
            });
        }

        var newObject = new DateTime
        {
            Value = new System.DateTime(year, month, day, hour, minute, second),
        };

        return newObject;
    }

    public static DateTime From(string datetime)
    {
        if (!System.DateTime.TryParse(datetime, out System.DateTime dateTime))
        {
            throw new ArgumentOutOfRangeException(nameof(datetime), datetime, "Invalid datetime");
        }

        return new DateTime
        {
            Value = dateTime,
        };
    }

    private static bool IsValidDate(int year, int month, int day, int hour = 0, int minute = 0, int second = 0)
    {
        try
        {
            _ = new System.DateTime(year, month, day, hour, minute, second);
            return true;
        }
        catch
        {
            return false;
        }
    }

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

    public static bool operator ==(DateTime dateTime1, DateTime dateTime2)
    {
        if (dateTime1 is null && dateTime2 is null)
            return true;

        if (dateTime1 is not null)
            return dateTime1.Equals(dateTime2);

        return false;
    }

    public static bool operator !=(DateTime dateTime1, DateTime dateTime2)
    {
        return !(dateTime1 == dateTime2);
    }

    public static bool operator <=(DateTime dateTime1, DateTime dateTime2)
    {
        return dateTime1.Value <= dateTime2.Value;
    }

    public static bool operator >=(DateTime dateTime1, DateTime dateTime2)
    {
        return dateTime1.Value >= dateTime2.Value;
    }

    public override string ToString()
    {
        return Value.ToString(CultureInfo.InvariantCulture);
    }

    public string ToString(CultureInfo cultureInfo)
    {
        return Value.ToString(cultureInfo);
    }

    public string ToString(string format, CultureInfo cultureInfo)
    {
        return Value.ToString(format, cultureInfo);
    }

    public string ToString(string format)
    => Value.ToString(format, CultureInfo.InvariantCulture);

    public string ToString(IFormatProvider formatProvider)
    {
        return Value.ToString(formatProvider);
    }

    public string ToString(string format, IFormatProvider formatProvider)
    {
        return Value.ToString(format, formatProvider);
    }

    public DateTime Add(TimeSpan ts)
    {
        Value = Value.Add(ts);
        return this;
    }

    public override bool Equals(object obj)
    {
        return obj is DateTime time &&
               base.Equals(obj) &&
               Value == time.Value &&
               Year == time.Year &&
               Month == time.Month &&
               Day == time.Day &&
               Hour == time.Hour &&
               Minute == time.Minute &&
               Second == time.Second;
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }
}

