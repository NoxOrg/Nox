using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Nox.Types;

/// <summary>
/// Represents a time of day, as would be read from a clock, within the range 00:00:00 to 23:59:59.9999999.
/// </summary>
public readonly struct TimeOnly
    : IComparable,
      IComparable<TimeOnly>,
      IEquatable<TimeOnly>
{
    // represent the number of ticks map to the time of the day. 1 ticks = 100-nanosecond in time measurements.
    private readonly long _ticks;

    // MinTimeTicks is the ticks for the midnight time 00:00:00.000 AM
    private const long MinTimeTicks = 0;

    // MaxTimeTicks is the max tick value for the time in the day. It is calculated using DateTime.Today.AddTicks(-1).TimeOfDay.Ticks.
    private const long MaxTimeTicks = 863_999_999_999;

    /// <summary>
    /// Represents the smallest possible value of TimeOnly.
    /// </summary>
    public static TimeOnly MinValue => new TimeOnly((ulong)MinTimeTicks);

    /// <summary>
    /// Represents the largest possible value of TimeOnly.
    /// </summary>
    public static TimeOnly MaxValue => new TimeOnly((ulong)MaxTimeTicks);

    /// <summary>
    /// Initializes a new instance of the timeOnly structure to the specified hour and the minute.
    /// </summary>
    /// <param name="hour">The hours (0 through 23).</param>
    /// <param name="minute">The minutes (0 through 59).</param>
    public TimeOnly(int hour, int minute) : this(new TimeSpan(hour, minute, 0, 0).Ticks) { }

    /// <summary>
    /// Initializes a new instance of the timeOnly structure to the specified hour, minute, and second.
    /// </summary>
    /// <param name="hour">The hours (0 through 23).</param>
    /// <param name="minute">The minutes (0 through 59).</param>
    /// <param name="second">The seconds (0 through 59).</param>
    public TimeOnly(int hour, int minute, int second) : this(new TimeSpan(hour, minute, second, 0).Ticks) { }

    /// <summary>
    /// Initializes a new instance of the timeOnly structure to the specified hour, minute, second, and millisecond.
    /// </summary>
    /// <param name="hour">The hours (0 through 23).</param>
    /// <param name="minute">The minutes (0 through 59).</param>
    /// <param name="second">The seconds (0 through 59).</param>
    /// <param name="millisecond">The millisecond (0 through 999).</param>
    public TimeOnly(int hour, int minute, int second, int millisecond) : this(new TimeSpan(days:0, hours:hour, minutes: minute, seconds:second, milliseconds: millisecond ).Ticks) { }

    /// <summary>
    /// Initializes a new instance of the <see cref="TimeOnly"/> structure to the specified hour, minute, second, and millisecond.
    /// </summary>
    /// <param name="hour">The hours (0 through 23).</param>
    /// <param name="minute">The minutes (0 through 59).</param>
    /// <param name="second">The seconds (0 through 59).</param>
    /// <param name="millisecond">The millisecond (0 through 999).</param>
    /// <param name="microsecond">The microsecond (0 through 999).</param>
    public TimeOnly(int hour, int minute, int second, int millisecond, int microsecond) : this(new TimeSpan(hour, minute, second, millisecond, microsecond).Ticks) { }

    /// <summary>
    /// Initializes a new instance of the TimeOnly structure using a specified number of ticks.
    /// </summary>
    /// <param name="ticks">A time of day expressed in the number of 100-nanosecond units since 00:00:00.0000000.</param>
    public TimeOnly(long ticks)
    {
        if ((ulong)ticks > MaxTimeTicks)
        {
            throw new ArgumentOutOfRangeException(nameof(ticks), "Invalid time.");
        }

        _ticks = ticks;
    }

    // exist to bypass the check in the public constructor.
    internal TimeOnly(ulong ticks) => _ticks = (long)ticks;

    /// <summary>
    /// Gets the hour component of the time represented by this instance.
    /// </summary>
    public int Hour => new TimeSpan(_ticks).Hours;

    /// <summary>
    /// Gets the minute component of the time represented by this instance.
    /// </summary>
    public int Minute => new TimeSpan(_ticks).Minutes;

    /// <summary>
    /// Gets the second component of the time represented by this instance.
    /// </summary>
    public int Second => new TimeSpan(_ticks).Seconds;

    /// <summary>
    /// Gets the millisecond component of the time represented by this instance.
    /// </summary>
    public int Millisecond => new TimeSpan(_ticks).Milliseconds;

    ///// <summary>
    ///// Gets the microsecond component of the time represented by this instance.
    ///// </summary>
    //public int Microsecond => new TimeSpan(_ticks).Microseconds;

    ///// <summary>
    ///// Gets the nanosecond component of the time represented by this instance.
    ///// </summary>
    //public int Nanosecond => new TimeSpan(_ticks).Nanoseconds;

    /// <summary>
    /// Gets the number of ticks that represent the time of this instance.
    /// </summary>
    public long Ticks => _ticks;

    private TimeOnly AddTicks(long ticks) => new TimeOnly((_ticks + TimeSpan.TicksPerDay + (ticks % TimeSpan.TicksPerDay)) % TimeSpan.TicksPerDay);

    private TimeOnly AddTicks(long ticks, out int wrappedDays)
    {
        wrappedDays = (int)(ticks / TimeSpan.TicksPerDay);
        long newTicks = _ticks + ticks % TimeSpan.TicksPerDay;
        if (newTicks < 0)
        {
            wrappedDays--;
            newTicks += TimeSpan.TicksPerDay;
        }
        else
        {
            if (newTicks >= TimeSpan.TicksPerDay)
            {
                wrappedDays++;
                newTicks -= TimeSpan.TicksPerDay;
            }
        }

        return new TimeOnly(newTicks);
    }

    /// <summary>
    /// Returns a new TimeOnly that adds the value of the specified TimeSpan to the value of this instance.
    /// </summary>
    /// <param name="value">A positive or negative time interval.</param>
    /// <returns>An object whose value is the sum of the time represented by this instance and the time interval represented by value.</returns>
    public TimeOnly Add(TimeSpan value) => AddTicks(value.Ticks);

    /// <summary>
    /// Returns a new TimeOnly that adds the value of the specified TimeSpan to the value of this instance.
    /// If the result wraps past the end of the day, this method will return the number of excess days as an out parameter.
    /// </summary>
    /// <param name="value">A positive or negative time interval.</param>
    /// <param name="wrappedDays">When this method returns, contains the number of excess days if any that resulted from wrapping during this addition operation.</param>
    /// <returns>An object whose value is the sum of the time represented by this instance and the time interval represented by value.</returns>
    public TimeOnly Add(TimeSpan value, out int wrappedDays) => AddTicks(value.Ticks, out wrappedDays);

    /// <summary>
    /// Returns a new TimeOnly that adds the specified number of hours to the value of this instance.
    /// </summary>
    /// <param name="value">A number of whole and fractional hours. The value parameter can be negative or positive.</param>
    /// <returns>An object whose value is the sum of the time represented by this instance and the number of hours represented by value.</returns>
    public TimeOnly AddHours(double value) => AddTicks((long)(value * TimeSpan.TicksPerHour));

    /// <summary>
    /// Returns a new TimeOnly that adds the specified number of hours to the value of this instance.
    /// If the result wraps past the end of the day, this method will return the number of excess days as an out parameter.
    /// </summary>
    /// <param name="value">A number of whole and fractional hours. The value parameter can be negative or positive.</param>
    /// <param name="wrappedDays">When this method returns, contains the number of excess days if any that resulted from wrapping during this addition operation.</param>
    /// <returns>An object whose value is the sum of the time represented by this instance and the number of hours represented by value.</returns>
    public TimeOnly AddHours(double value, out int wrappedDays) => AddTicks((long)(value * TimeSpan.TicksPerHour), out wrappedDays);

    /// <summary>
    /// Returns a new TimeOnly that adds the specified number of minutes to the value of this instance.
    /// </summary>
    /// <param name="value">A number of whole and fractional minutes. The value parameter can be negative or positive.</param>
    /// <returns>An object whose value is the sum of the time represented by this instance and the number of minutes represented by value.</returns>
    public TimeOnly AddMinutes(double value) => AddTicks((long)(value * TimeSpan.TicksPerMinute));

    /// <summary>
    /// Returns a new TimeOnly that adds the specified number of minutes to the value of this instance.
    /// If the result wraps past the end of the day, this method will return the number of excess days as an out parameter.
    /// </summary>
    /// <param name="value">A number of whole and fractional minutes. The value parameter can be negative or positive.</param>
    /// <param name="wrappedDays">When this method returns, contains the number of excess days if any that resulted from wrapping during this addition operation.</param>
    /// <returns>An object whose value is the sum of the time represented by this instance and the number of minutes represented by value.</returns>
    public TimeOnly AddMinutes(double value, out int wrappedDays) => AddTicks((long)(value * TimeSpan.TicksPerMinute), out wrappedDays);

    /// <summary>
    /// Determines if a time falls within the range provided.
    /// Supports both "normal" ranges such as 10:00-12:00, and ranges that span midnight such as 23:00-01:00.
    /// </summary>
    /// <param name="start">The starting time of day, inclusive.</param>
    /// <param name="end">The ending time of day, exclusive.</param>
    /// <returns>True, if the time falls within the range, false otherwise.</returns>
    /// <remarks>
    /// If <paramref name="start"/> and <paramref name="end"/> are equal, this method returns false, meaning there is zero elapsed time between the two values.
    /// If you wish to treat such cases as representing one or more whole days, then first check for equality before calling this method.
    /// </remarks>
    public bool IsBetween(TimeOnly start, TimeOnly end)
    {
        long startTicks = start._ticks;
        long endTicks = end._ticks;

        return startTicks <= endTicks
            ? (startTicks <= _ticks && endTicks > _ticks)
            : (startTicks <= _ticks || endTicks > _ticks);
    }

    /// <summary>
    /// Determines whether two specified instances of TimeOnly are equal.
    /// </summary>
    /// <param name="left">The first object to compare.</param>
    /// <param name="right">The second object to compare.</param>
    /// <returns>true if left and right represent the same time; otherwise, false.</returns>
    /// <inheritdoc cref="IEqualityOperators{TSelf, TOther, TResult}.op_Equality(TSelf, TOther)" />
    public static bool operator ==(TimeOnly left, TimeOnly right) => left._ticks == right._ticks;

    /// <summary>
    /// Determines whether two specified instances of TimeOnly are not equal.
    /// </summary>
    /// <param name="left">The first object to compare.</param>
    /// <param name="right">The second object to compare.</param>
    /// <returns>true if left and right do not represent the same time; otherwise, false.</returns>
    /// <inheritdoc cref="IEqualityOperators{TSelf, TOther, TResult}.op_Inequality(TSelf, TOther)" />
    public static bool operator !=(TimeOnly left, TimeOnly right) => left._ticks != right._ticks;

    /// <summary>
    /// Determines whether one specified TimeOnly is later than another specified TimeOnly.
    /// </summary>
    /// <param name="left">The first object to compare.</param>
    /// <param name="right">The second object to compare.</param>
    /// <returns>true if left is later than right; otherwise, false.</returns>
    /// <inheritdoc cref="IComparisonOperators{TSelf, TOther, TResult}.op_GreaterThan(TSelf, TOther)" />
    public static bool operator >(TimeOnly left, TimeOnly right) => left._ticks > right._ticks;

    /// <summary>
    /// Determines whether one specified TimeOnly represents a time that is the same as or later than another specified TimeOnly.
    /// </summary>
    /// <param name="left">The first object to compare.</param>
    /// <param name="right">The second object to compare.</param>
    /// <returns>true if left is the same as or later than right; otherwise, false.</returns>
    /// <inheritdoc cref="IComparisonOperators{TSelf, TOther, TResult}.op_GreaterThanOrEqual(TSelf, TOther)" />
    public static bool operator >=(TimeOnly left, TimeOnly right) => left._ticks >= right._ticks;

    /// <summary>
    /// Determines whether one specified TimeOnly is earlier than another specified TimeOnly.
    /// </summary>
    /// <param name="left">The first object to compare.</param>
    /// <param name="right">The second object to compare.</param>
    /// <returns>true if left is earlier than right; otherwise, false.</returns>
    /// <inheritdoc cref="IComparisonOperators{TSelf, TOther, TResult}.op_LessThan(TSelf, TOther)" />
    public static bool operator <(TimeOnly left, TimeOnly right) => left._ticks < right._ticks;

    /// <summary>
    /// Determines whether one specified TimeOnly represents a time that is the same as or earlier than another specified TimeOnly.
    /// </summary>
    /// <param name="left">The first object to compare.</param>
    /// <param name="right">The second object to compare.</param>
    /// <returns>true if left is the same as or earlier than right; otherwise, false.</returns>
    /// <inheritdoc cref="IComparisonOperators{TSelf, TOther, TResult}.op_LessThanOrEqual(TSelf, TOther)" />
    public static bool operator <=(TimeOnly left, TimeOnly right) => left._ticks <= right._ticks;

    /// <summary>
    ///  Gives the elapsed time between two points on a circular clock, which will always be a positive value.
    /// </summary>
    /// <param name="t1">The first TimeOnly instance.</param>
    /// <param name="t2">The second TimeOnly instance..</param>
    /// <returns>The elapsed time between t1 and t2.</returns>
    public static TimeSpan operator -(TimeOnly t1, TimeOnly t2) => new TimeSpan((t1._ticks - t2._ticks + TimeSpan.TicksPerDay) % TimeSpan.TicksPerDay);

    /// <summary>
    /// Deconstructs <see cref="TimeOnly"/> by <see cref="Hour"/> and <see cref="Minute"/>.
    /// </summary>
    /// <param name="hour">
    /// Deconstructed parameter for <see cref="Hour"/>.
    /// </param>
    /// <param name="minute">
    /// Deconstructed parameter for <see cref="Minute"/>.
    /// </param>
    public void Deconstruct(out int hour, out int minute)
    {
        hour = Hour;
        minute = Minute;
    }

    /// <summary>
    /// Deconstructs <see cref="TimeOnly"/> by <see cref="Hour"/>, <see cref="Minute"/> and <see cref="Second"/>.
    /// </summary>
    /// <param name="hour">
    /// Deconstructed parameter for <see cref="Hour"/>.
    /// </param>
    /// <param name="minute">
    /// Deconstructed parameter for <see cref="Minute"/>.
    /// </param>
    /// <param name="second">
    /// Deconstructed parameter for <see cref="Second"/>.
    /// </param>
    public void Deconstruct(out int hour, out int minute, out int second)
    {
        (hour, minute) = this;
        second = Second;
    }

    /// <summary>
    /// Deconstructs <see cref="TimeOnly"/> by <see cref="Hour"/>, <see cref="Minute"/>, <see cref="Second"/> and <see cref="Millisecond"/>.
    /// </summary>
    /// <param name="hour">
    /// Deconstructed parameter for <see cref="Hour"/>.
    /// </param>
    /// <param name="minute">
    /// Deconstructed parameter for <see cref="Minute"/>.
    /// </param>
    /// <param name="second">
    /// Deconstructed parameter for <see cref="Second"/>.
    /// </param>
    /// <param name="millisecond">
    /// Deconstructed parameter for <see cref="Millisecond"/>.
    /// </param>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void Deconstruct(out int hour, out int minute, out int second, out int millisecond)
    {
        (hour, minute, second) = this;
        millisecond = Millisecond;
    }

    ///// <summary>
    ///// Deconstructs <see cref="TimeOnly"/> by <see cref="Hour"/>, <see cref="Minute"/>, <see cref="Second"/>, <see cref="Millisecond"/> and <see cref="Microsecond"/>.
    ///// </summary>
    ///// <param name="hour">
    ///// Deconstructed parameter for <see cref="Hour"/>.
    ///// </param>
    ///// <param name="minute">
    ///// Deconstructed parameter for <see cref="Minute"/>.
    ///// </param>
    ///// <param name="second">
    ///// Deconstructed parameter for <see cref="Second"/>.
    ///// </param>
    ///// <param name="millisecond">
    ///// Deconstructed parameter for <see cref="Millisecond"/>.
    ///// </param>
    ///// <param name="microsecond">
    ///// Deconstructed parameter for <see cref="Microsecond"/>.
    ///// </param>
    //[EditorBrowsable(EditorBrowsableState.Never)]
    //public void Deconstruct(out int hour, out int minute, out int second, out int millisecond, out int microsecond)
    //{
    //    (hour, minute, second, millisecond) = this;
    //    microsecond = Microsecond;
    //}

    /// <summary>
    /// Constructs a TimeOnly object from a TimeSpan representing the time elapsed since midnight.
    /// </summary>
    /// <param name="timeSpan">The time interval measured since midnight. This value has to be positive and not exceeding the time of the day.</param>
    /// <returns>A TimeOnly object representing the time elapsed since midnight using the timeSpan value.</returns>
    public static TimeOnly FromTimeSpan(TimeSpan timeSpan) => new TimeOnly(timeSpan.Ticks);

    /// <summary>
    /// Constructs a TimeOnly object from a DateTime representing the time of the day in this DateTime object.
    /// </summary>
    /// <param name="dateTime">The time DateTime object to extract the time of the day from.</param>
    /// <returns>A TimeOnly object representing time of the day specified in the DateTime object.</returns>
    public static TimeOnly FromDateTime(System.DateTime dateTime) => new TimeOnly(dateTime.TimeOfDay.Ticks);

    /// <summary>
    /// Convert the current TimeOnly instance to a TimeSpan object.
    /// </summary>
    /// <returns>A TimeSpan object spanning to the time specified in the current TimeOnly object.</returns>
    public TimeSpan ToTimeSpan() => new TimeSpan(_ticks);

    /// <summary>
    /// Converts to the date time.
    /// </summary>
    /// <returns>A DateTime.</returns>
    public System.DateTime ToDateTime() => new System.DateTime(_ticks);

    /// <summary>
    /// Compares the value of this instance to a specified TimeOnly value and indicates whether this instance is earlier than, the same as, or later than the specified TimeOnly value.
    /// </summary>
    /// <param name="value">The object to compare to the current instance.</param>
    /// <returns>
    /// A signed number indicating the relative values of this instance and the value parameter.
    /// Less than zero if this instance is earlier than value.
    /// Zero if this instance is the same as value.
    /// Greater than zero if this instance is later than value.
    /// </returns>
    public int CompareTo(TimeOnly value) => _ticks.CompareTo(value._ticks);

    /// <summary>
    /// Compares the value of this instance to a specified object that contains a specified TimeOnly value, and returns an integer that indicates whether this instance is earlier than, the same as, or later than the specified TimeOnly value.
    /// </summary>
    /// <param name="value">A boxed object to compare, or null.</param>
    /// <returns>
    /// A signed number indicating the relative values of this instance and the value parameter.
    /// Less than zero if this instance is earlier than value.
    /// Zero if this instance is the same as value.
    /// Greater than zero if this instance is later than value.
    /// </returns>
    public int CompareTo(object? value)
    {
        if (value == null) return 1;
        if (value is not TimeOnly timeOnly)
        {
            throw new ArgumentException("The value provided must be a TimeOnly instance.");
        }

        return CompareTo(timeOnly);
    }

    /// <summary>
    /// Returns a value indicating whether the value of this instance is equal to the value of the specified TimeOnly instance.
    /// </summary>
    /// <param name="value">The object to compare to this instance.</param>
    /// <returns>true if the value parameter equals the value of this instance; otherwise, false.</returns>
    public bool Equals(TimeOnly value) => _ticks == value._ticks;

    /// <summary>
    /// Returns a value indicating whether this instance is equal to a specified object.
    /// </summary>
    /// <param name="value">The object to compare to this instance.</param>
    /// <returns>true if value is an instance of TimeOnly and equals the value of this instance; otherwise, false.</returns>
    public override bool Equals(object? value) => value is TimeOnly timeOnly && _ticks == timeOnly._ticks;

    /// <summary>
    /// Returns the hash code for this instance.
    /// </summary>
    /// <returns>A 32-bit signed integer hash code.</returns>
    public override int GetHashCode()
    {
        long ticks = _ticks;
        return unchecked((int)ticks) ^ (int)(ticks >> 32);
    }


    private const string OFormat = "HH':'mm':'ss'.'fffffff";
    private const string RFormat = "HH':'mm':'ss";


    /// <summary>
    /// Converts the value of the current TimeOnly object to its equivalent long date string representation.
    /// </summary>
    /// <returns>A string that contains the long time string representation of the current TimeOnly object.</returns>
    public string ToLongTimeString() => ToString("T");

    /// <summary>
    /// Converts the value of the current TimeOnly object to its equivalent short time string representation.
    /// </summary>
    /// <returns>A string that contains the short time string representation of the current TimeOnly object.</returns>
    public string ToShortTimeString() => ToString();

    /// <summary>
    /// Converts the value of the current TimeOnly object to its equivalent string representation using the formatting conventions of the current culture.
    /// The TimeOnly object will be formatted in short form.
    /// </summary>
    /// <returns>A string that contains the short time string representation of the current TimeOnly object.</returns>
    public override string ToString() => ToString("t");

    /// <summary>
    /// Converts the value of the current TimeOnly object to its equivalent string representation using the specified format and the formatting conventions of the current culture.
    /// </summary>
    /// <param name="format">A standard or custom time format string.</param>
    /// <returns>A string representation of value of the current TimeOnly object as specified by format.</returns>
    /// <remarks>The accepted standard formats are 'r', 'R', 'o', 'O', 't' and 'T'. </remarks>
    public string ToString(string? format) => ToString(format, null);

    /// <summary>
    /// Converts the value of the current TimeOnly object to its equivalent string representation using the specified culture-specific format information.
    /// </summary>
    /// <param name="provider">An object that supplies culture-specific formatting information.</param>
    /// <returns>A string representation of value of the current TimeOnly object as specified by provider.</returns>
    public string ToString(IFormatProvider? provider) => ToString("t", provider);

    /// <summary>
    /// Converts the value of the current TimeOnly object to its equivalent string representation using the specified culture-specific format information.
    /// </summary>
    /// <param name="format">A standard or custom time format string.</param>
    /// <param name="provider">An object that supplies culture-specific formatting information.</param>
    /// <returns>A string representation of value of the current TimeOnly object as specified by format and provider.</returns>
    /// <remarks>The accepted standard formats are 'r', 'R', 'o', 'O', 't' and 'T'. </remarks>
    public string ToString(string? format, IFormatProvider? provider)
    {
        if (string.IsNullOrEmpty(format))
        {
            format = "t";
        }

        if (format!.Length == 1)
        {
            switch (format[0] | 0x20)
            {
                case 'o':
                    return ToDateTime().ToString(OFormat, provider);
                case 'r':
                    return ToDateTime().ToString(RFormat, provider);
                case 't':
                    return ToDateTime().ToString(format, provider);

                default:
                    throw new FormatException("Invalid time format");
            }
        }

        return ToDateTime().ToString(format, provider);
    }
}
