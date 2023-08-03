using System.Globalization;
using System;
using System.Collections.Generic;
using System.Text;
using Ical.Net.CalendarComponents;
using Ical.Net;
using Ical.Net.Serialization;
using Ical.Net.DataTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Nox.Types;

public class DateTimeSchedule : ValueObject<(System.DateTime StartDate, System.DateTime EndDate), DateTimeSchedule>
{
    private DateTimeScheduleTypeOptions _dateTimeScheduleTypeOptions = new();

    /// <summary>
    /// Gets the start of the date time range scheduled.
    /// </summary>
    public System.DateTime StartDate
    {
        get => Value.StartDate;
        private set => Value = (StartDate: value, EndDate: Value.EndDate);
    }

    /// <summary>
    /// Gets the end of the date time range scheduled.
    /// </summary>
    public System.DateTime EndDate
    {
        get => Value.EndDate;
        private set => Value = (StartDate: Value.StartDate, EndDate: value);
    }

    /// <summary>
    /// Creates and validates a new instance of <see cref="DateTimeSchedule"/> from <paramref name="startDateTime"/> and <paramref name="endDateTime"/>.
    /// </summary>
    /// <param name="startDateTime">start date of schedule</param>
    /// <param name="endDateTime">end date of scheduled event</param>
    /// <returns>New <see cref="DateTimeSchedule"/> object.</returns>
    public static DateTimeSchedule From(System.DateTime startDateTime, System.DateTime endDateTime) => From(startDateTime, endDateTime, new DateTimeScheduleTypeOptions());

    /// <summary>
    /// Creates and validates a new instance of <see cref="DateTimeSchedule"/> from <paramref name="startDateTime"/> and <paramref name="endDateTime"/>.
    /// </summary>
    /// <param name="startDateTime">start date of schedule</param>
    /// <param name="endDateTime">end date of scheduled event</param>
    /// <param name="options"><see cref="DateTimeScheduleTypeOptions"/> that contains frequency of scheduler</param>
    /// <returns>New <see cref="DateTimeSchedule"/> object.</returns>
    public static DateTimeSchedule From(System.DateTime startDateTime, System.DateTime endDateTime, DateTimeScheduleTypeOptions options)
    {
        var newObject = new DateTimeSchedule
        {
            Value = (startDateTime, endDateTime),
            _dateTimeScheduleTypeOptions = options
        };

        var validationResult = newObject.Validate();

        if (!validationResult.IsValid)
        {
            throw new TypeValidationException(validationResult.Errors);
        }

        return newObject;
    }

    /// <summary>
    /// Validates a <see cref="DateTimeSchedule"/> object.
    /// </summary>
    /// <returns>True if the <see cref="DateTimeSchedule"/> value is valid, otherwise false.</returns>
    internal override ValidationResult Validate()
    {
        var result = base.Validate();

        // validate date by options
        if (Value.StartDate > Value.EndDate)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox DateTimeSchedule type with Start value {Value.StartDate} and End value {Value.EndDate} as start of the time range must be the same or after the end of the time range."));
        }

        return result;
    }

    /// <summary>
    /// Returns a string representation of the custom date and time using <see cref="CultureInfo.InvariantCulture"/>.
    /// </summary>
    public override string ToString()
    {
        return $"Start: {Value.StartDate}, End: {Value.EndDate}, Frequency: {_dateTimeScheduleTypeOptions.Frequency}, Frequency value: {_dateTimeScheduleTypeOptions.FrequencyValue}";
    }

    public DateTimeSchedule GetNextScheduledDate()
    {
        DateTimeSchedule newObject;

        switch (_dateTimeScheduleTypeOptions.Frequency)
        {
            case Frequency.Minutely:
                newObject = new DateTimeSchedule
                {
                    Value = (Value.StartDate.AddMinutes(_dateTimeScheduleTypeOptions.FrequencyValue), Value.EndDate),
                    _dateTimeScheduleTypeOptions = _dateTimeScheduleTypeOptions
                };
                break;
            case Frequency.Hourly:
                newObject = new DateTimeSchedule
                {
                    Value = (Value.StartDate.AddHours(_dateTimeScheduleTypeOptions.FrequencyValue), Value.EndDate),
                    _dateTimeScheduleTypeOptions = _dateTimeScheduleTypeOptions
                };
                break;
            case Frequency.Daily:
                newObject = new DateTimeSchedule
                {
                    Value = (Value.StartDate.AddDays(_dateTimeScheduleTypeOptions.FrequencyValue), Value.EndDate),
                    _dateTimeScheduleTypeOptions = _dateTimeScheduleTypeOptions
                };
                break;
            case Frequency.Weekly:
                newObject = new DateTimeSchedule
                {
                    Value = (Value.StartDate.AddDays(_dateTimeScheduleTypeOptions.FrequencyValue * 7), Value.EndDate),
                    _dateTimeScheduleTypeOptions = _dateTimeScheduleTypeOptions
                };
                break;
            case Frequency.Monthly:
                newObject = new DateTimeSchedule
                {
                    Value = (Value.StartDate.AddMonths(_dateTimeScheduleTypeOptions.FrequencyValue), Value.EndDate),
                    _dateTimeScheduleTypeOptions = _dateTimeScheduleTypeOptions
                };
                break;
            case Frequency.Yearly:
                newObject = new DateTimeSchedule
                {
                    Value = (Value.StartDate.AddYears(_dateTimeScheduleTypeOptions.FrequencyValue), Value.EndDate),
                    _dateTimeScheduleTypeOptions = _dateTimeScheduleTypeOptions
                };
                break;
            default:
                throw new ArgumentException("Invalid frequency.");
        }

        var validationResult = newObject.Validate();

        if (!validationResult.IsValid || _dateTimeScheduleTypeOptions.FrequencyValue == 0)
        {
            throw new TypeValidationException(validationResult.Errors);
        }

        return newObject;
    }

    public List<DateTimeSchedule> GetAllOccurrences()
    {
        List<DateTimeSchedule> occurrences = new List<DateTimeSchedule>
        {
            this
        };

        DateTimeSchedule nextDate = this;

        while (nextDate.Value.StartDate <= nextDate.Value.EndDate && _dateTimeScheduleTypeOptions.FrequencyValue > 0)
        {
            try
            {
                nextDate = nextDate.GetNextScheduledDate();
                occurrences.Add(nextDate);
            }
            catch
            {
                break;
            }
        }

        return occurrences;
    }

    public static void test(string eventTitle, string eventDescription, System.DateTime startDateTime, System.DateTime endDateTime, System.DateTime recurrenceEndDate, FrequencyType frequency, int frequencyInterval)
    {
        var calendar = new Ical.Net.Calendar();

        var icalEvent = new CalendarEvent
        {
            Summary = eventTitle,
            Description = eventDescription,
            // start date of event
            Start = new CalDateTime(startDateTime),
            // end date of event, duration
            End = new CalDateTime(endDateTime),

        };

        var recurrenceRule = new RecurrencePattern(frequency, frequencyInterval)
        {
            Until = recurrenceEndDate
        };

        icalEvent.RecurrenceRules = new List<RecurrencePattern> { recurrenceRule };

        calendar.Events.Add(icalEvent);

        var iCalSerializer = new CalendarSerializer();
        string result = iCalSerializer.SerializeToString(calendar);

        var bytes = Encoding.UTF8.GetBytes(result);
        var fileStream = new System.IO.FileStream(
        @"C:\\Users\\ajla.becic\\OneDrive - Authority Partners Inc\\Documents\\Nova fascikla\\DDayEvent.ics", System.IO.FileMode.Create, System.IO.FileAccess.Write);
        fileStream.Write(bytes, 0, bytes.Length);
        fileStream.Close();
    }
}

