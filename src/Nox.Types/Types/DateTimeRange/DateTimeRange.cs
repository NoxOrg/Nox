using System;
using System.Globalization;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="DateTimeRange"/> type and value object.
/// </summary>
public class DateTimeRange : ValueObject<(DateTimeOffset Start, DateTimeOffset End), DateTimeRange>, IDateTimeRange
{
    private DateTimeRangeTypeOptions _dateTimeRangeTypeOptions = new();

    /// <summary>
    /// Gets the start of the date time range.
    /// </summary>
    public DateTimeOffset Start
    {
        get => Value.Start;
        private set => Value = (value, Value.End);
    }

    /// <summary>
    /// Gets the end of the date time range.
    /// </summary>
    public DateTimeOffset End
    {
        get => Value.End;
        private set => Value = (Value.Start, End: value);
    }

    /// <summary>
    /// Gets the duration of the date time range.
    /// </summary>
    public TimeSpan Duration => Value.End - Value.Start;

    public static DateTimeRange From(IDateTimeRange value)
        => From((Start: value.Start, End: value.End));
    public static DateTimeRange From(IDateTimeRange value, DateTimeRangeTypeOptions options)
        => From((Start: value.Start, End: value.End), options);

    /// <summary>
    /// Creates a new instance of <see cref="DateTimeRange"/> with specified start and end date and time and with specified type options.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="dateTimeRangeTypeOptions">The date time range type options.</param>
    /// <exception cref="Nox.Types.NoxTypeValidationException"></exception>
    public static DateTimeRange From((DateTimeOffset Start, DateTimeOffset End) value, DateTimeRangeTypeOptions dateTimeRangeTypeOptions)
    {
        var newObject = new DateTimeRange
        {
            Value = value,
            _dateTimeRangeTypeOptions = dateTimeRangeTypeOptions
        };

        var validationResult = newObject.Validate();

        if (!validationResult.IsValid)
        {
            throw new NoxTypeValidationException(validationResult.Errors);
        }

        return newObject;
    }

    /// <summary>
    /// Creates a new instance of <see cref="DateTimeRange"/> with specified start and end date and time and with default type options.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <exception cref="Nox.Types.NoxTypeValidationException"></exception>
    public new static DateTimeRange From((DateTimeOffset Start, DateTimeOffset End) value)
        => From(value, new DateTimeRangeTypeOptions());

    /// <summary>
    /// Creates a new instance of <see cref="DateTimeRange"/> with specified start and end date and time and with specified type options.
    /// </summary>
    /// <param name="start">The start.</param>
    /// <param name="end">The end.</param>
    /// <param name="dateTimeRangeTypeOptions">The date time range type options.</param>
    /// <exception cref="NoxTypeValidationException"></exception>
    public static DateTimeRange From(DateTimeOffset start, DateTimeOffset end, DateTimeRangeTypeOptions? dateTimeRangeTypeOptions = null)
        => From((start, end), dateTimeRangeTypeOptions ?? new DateTimeRangeTypeOptions());

    /// <summary>
    /// Creates a new instance of <see cref="DateTimeRange"/> with specified start duration and with specified type options.
    /// </summary>
    /// <param name="start">The start.</param>
    /// <param name="duration">The duration of the range.</param>
    /// <param name="dateTimeRangeTypeOptions">The date time range type options.</param>
    /// <exception cref="NoxTypeValidationException"></exception>
    public static DateTimeRange From(DateTimeOffset start, TimeSpan duration, DateTimeRangeTypeOptions? dateTimeRangeTypeOptions = null)
            => From((start, start.Add(duration)), dateTimeRangeTypeOptions ?? new DateTimeRangeTypeOptions());

    internal override ValidationResult Validate()
    {
        var result = base.Validate();

        if (Value.Start > Value.End)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox DateTimeRange type with Start value {Value.Start.ToString(CultureInfo.InvariantCulture)} and End value {Value.End.ToString(CultureInfo.InvariantCulture)} as start of the time range must be the same or before the end of the time range."));
        }

        if (Value.Start < _dateTimeRangeTypeOptions.MinStartValue)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value.Start), $"Could not create a Nox DateTimeRange type as Start value {Value.Start.ToString(CultureInfo.InvariantCulture)} is less than than the minimum specified value of {_dateTimeRangeTypeOptions.MinStartValue.ToString(CultureInfo.InvariantCulture)}."));
        }

        if (Value.End > _dateTimeRangeTypeOptions.MaxEndValue)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value.End), $"Could not create a Nox DateTimeRange type as End value {Value.End.ToString(CultureInfo.InvariantCulture)} is greater than than the maximum specified value of {_dateTimeRangeTypeOptions.MaxEndValue.ToString(CultureInfo.InvariantCulture)}."));
        }

        return result;
    }

    /// <summary>
    /// Determines whether the specified date time is within the date time range.
    /// </summary>
    /// <param name="dateTime">The date time.</param>
    public bool Contains(DateTimeOffset dateTime)
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
