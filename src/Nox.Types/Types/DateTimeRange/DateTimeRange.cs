using System;
using System.Globalization;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="DateTimeRange"/> type and value object.
/// </summary>
public class DateTimeRange : ValueObject<(DateTime Start, DateTime End), DateTimeRange>
{
    /// <summary>
    /// Gets the start of the date time range.
    /// </summary>
    public DateTime Start
    {
        get => Value.Start;
        private set => Value = (Start: value, End: Value.End);
    }

    /// <summary>
    /// Gets the end of the date time range.
    /// </summary>
    public DateTime End
    {
        get => Value.End;
        private set => Value = (Start: Value.Start, End: value);
    }

    /// <summary>
    /// Gets the duration of the date time range.
    /// </summary>
    public TimeSpan Duration => Value.End - Value.Start;

    /// <summary>
    /// Creates a new instance of <see cref="DateTimeRange"/> with specified start and end date and time
    /// </summary>
    /// <param name="start">The start.</param>
    /// <param name="end">The end.</param>
    /// <returns></returns>
    /// <exception cref="ValidationException"></exception>
    public static DateTimeRange From(DateTime start, DateTime end)
        => From((start, end));

    /// <summary>
    /// Creates a new instance of <see cref="DateTimeRange"/> with specified start duration
    /// </summary>
    /// <param name="start">The start.</param>
    /// <param name="end">The end.</param>
    /// <returns></returns>
    /// <exception cref="ValidationException"></exception>
    public static DateTimeRange From(DateTime start, TimeSpan duration)
        => From((start, start.Add(duration)));

    internal override ValidationResult Validate()
    {
        var result = base.Validate();

        if (Value.Start > Value.End)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox DateTimeRange type with Start value {Value.Start} and End value {Value.End} as start of the time range must be the same or after the end of the time range."));
        }

        return result;
    }

    /// <summary>
    /// Determines whether the specified date time is within the date time range.
    /// </summary>
    /// <param name="dateTime">The date time.</param>
    public bool Contains(DateTime dateTime)
        => dateTime >= Value.Start && dateTime <= Value.End;

    /// <summary>
    /// Intersects the instance with specified date time range.
    /// </summary>
    /// <param name="other">The other date time range.</param>
    public DateTimeRange? Intersect(DateTimeRange other)
    {
        var intersectionStart = Value.Start < other.Start
            ? other.Start
            : Value.Start;
        var intersectionEnd = Value.End < other.End
            ? Value.End
            : other.End;

        if (intersectionEnd < intersectionStart)
        {
            return null;
        }

        return From(intersectionStart, intersectionEnd);
    }

    public override string ToString()
        => $"{Value.Start.ToString(CultureInfo.InvariantCulture)} - {Value.End.ToString(CultureInfo.InvariantCulture)}";

    public string ToString(string format)
    => $"{Value.Start.ToString(format, CultureInfo.InvariantCulture)} - {Value.End.ToString(format, CultureInfo.InvariantCulture)}";

    public string ToString(IFormatProvider formatProvider)
    => $"{Value.Start.ToString(formatProvider)} - {Value.End.ToString(formatProvider)}";

    public string ToString(string format, IFormatProvider formatProvider)
        => $"{Value.Start.ToString(format, formatProvider)} - {Value.End.ToString(format, formatProvider)}";
}
