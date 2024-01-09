using System;
using System.Linq;
using System.Text.RegularExpressions;
using Nox.Cron;

namespace Nox.Types;

public class DateTimeSchedule : ValueObject<string, DateTimeSchedule>
{
    private readonly Regex _validSecondsAndMinutes = new(@"^(\*|(?:\*|(?:[0-9]|(?:[1-5][0-9])))\/(?:[0-9]|[1-5][0-9])|(?:[0-9]|[1-5][0-9])(?:(?:\-(?:[0-9]|[1-5][0-9]))?|(?:\,(?:[0-9]|[1-5][0-9]))*)(?:(?:\/(?:[0-9]|[1-5][0-9]))*)((?:\,(?:[0-9]|[1-5][0-9]))*))$", RegexOptions.Compiled, Regex_Default_Timeout_Miliseconds);
    private readonly Regex _validHours = new(@"^(\*|(?:\*|(?:[0-9]|1[0-9]|2[0-3]))\/(?:[0-9]|1[0-9]|2[0-3])|(?:[0-9]|1[0-9]|2[0-3])(?:(?:\-(?:[0-9]|1[0-9]|2[0-3]))?|(?:\,(?:[0-9]|1[0-9]|2[0-3]))*)(?:(?:\/(?:[0-9]|1[0-9]|2[0-3]))*)((?:\,(?:[0-9]|1[0-9]|2[0-3]))*))$", RegexOptions.Compiled, Regex_Default_Timeout_Miliseconds);
    private readonly Regex _validDayOfTheMonth = new(@"^(\*|\?|L(?:W|\-(?:[1-9]|(?:[12][0-9])|3[01]))?|(?:\*|[1-9]|(?:[12][0-9])|3[01])(?:W|\/(?:[1-9]|(?:[12][0-9])|3[01]))?|(?:[1-9]|(?:[12][0-9])|3[01])(?:(?:\-(?:[1-9]|(?:[12][0-9])|3[01]))?|(?:\,(?:[1-9]|(?:[12][0-9])|3[01]))*)(?:(?:\/(?:[1-9]|(?:[12][0-9])|3[01]))*)((?:\,(?:[1-9]|(?:[12][0-9])|3[01]))*))$", RegexOptions.Compiled, Regex_Default_Timeout_Miliseconds);
    private readonly Regex _validMonth = new(@"^(\*|(?:\*|(?:[1-9]|1[012]))\/(?:[1-9]|1[012])|(?:[1-9]|1[012]|JAN|FEB|MAR|APR|MAY|JUN|JUL|AUG|SEP|OCT|NOV|DEC)(?:(?:\-(?:[1-9]|1[012]|JAN|FEB|MAR|APR|MAY|JUN|JUL|AUG|SEP|OCT|NOV|DEC))?|(?:\,(?:[1-9]|1[012]|JAN|FEB|MAR|APR|MAY|JUN|JUL|AUG|SEP|OCT|NOV|DEC))*)(?:(?:\/(?:[1-9]|1[012]))*)((?:\,(?:[1-9]|1[012]|JAN|FEB|MAR|APR|MAY|JUN|JUL|AUG|SEP|OCT|NOV|DEC))*))$", RegexOptions.Compiled, Regex_Default_Timeout_Miliseconds);
    private readonly Regex _validDayOfWeek = new(@"^(\*|\?|[0-6](?:L|\#[1-5])?|(?:[0-6]|SUN|MON|TUE|WED|THU|FRI|SAT)(?:(?:\-(?:[0-6]|SUN|MON|TUE|WED|THU|FRI|SAT))?|(?:\,(?:[0-6]|SUN|MON|TUE|WED|THU|FRI|SAT))*)|(?:[0-6]|SUN|MON|TUE|WED|THU|FRI|SAT)(?:(?:\-(?:[0-6]|SUN|MON|TUE|WED|THU|FRI|SAT))(?:\,(?:[0-6]|SUN|MON|TUE|WED|THU|FRI|SAT))*))$", RegexOptions.Compiled, Regex_Default_Timeout_Miliseconds);
    private readonly Regex _validYear = new(@"^(\*|(?:\*|(?:[1-9][0-9]{3}))\/(?:\d+)|(?:[1-9][0-9]{3})(?:(?:\-(?:[1-9][0-9]{3}))?|(?:\,(?:[1-9][0-9]{3}))*)(?:(?:\/(?:\d+))*)(?:(?:\/(?:[1-9][0-9]{3}))*)((?:\,(?:[1-9][0-9]{3}))*))$", Regex_Default_Timeout_Miliseconds);

    /// <summary>
    ///  Creates and validates a new instance of <see cref="DateTimeSchedule"/>
    /// </summary>
    /// <param name="value">CronJob expression</param>
    /// <returns>New <see cref="DateTimeSchedule"/> object.</returns>
    public static DateTimeSchedule FromEnglishPhrase(string englishPhrase) => From(GetCronExpressionFromPhrase(englishPhrase));

    /// <summary>
    ///  Creates and validates a new instance of <see cref="DateTimeSchedule"/>
    /// </summary>
    /// <param name="value">CronJob expression</param>
    /// <returns>New <see cref="DateTimeSchedule"/> object.</returns>
    public static new DateTimeSchedule From(string value)
    {
        var newObject = new DateTimeSchedule
        {
            Value = value,
        };

        var validationResult = newObject.Validate();

        if (!validationResult.IsValid)
        {
            throw new NoxTypeValidationException(validationResult.Errors);
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

        // Initialize all elements of cronExpressionSegments array to empty strings
        string[] cronExpressionSegments = new string[7].Select(el => "").ToArray();

        try
        {
            cronExpressionSegments = GetcronExpresionSegments();
            if (!string.IsNullOrEmpty(cronExpressionSegments[0]) && !_validSecondsAndMinutes.IsMatch(cronExpressionSegments[0]))
            {
                result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox DateTimeSchedule type with value {Value} because it is incorrect CronJob expression - seconds are incorrect."));
            }

            if (string.IsNullOrEmpty(cronExpressionSegments[1]) || !_validSecondsAndMinutes.IsMatch(cronExpressionSegments[1]))
            {
                result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox DateTimeSchedule type with value {Value} because it is incorrect CronJob expression - minutes are incorrect."));
            }

            if (string.IsNullOrEmpty(cronExpressionSegments[2]) || !_validHours.IsMatch(cronExpressionSegments[2]))
            {
                result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox DateTimeSchedule type with value {Value} because it is incorrect CronJob expression - hours are incorrect."));
            }

            if (string.IsNullOrEmpty(cronExpressionSegments[3]) || !_validDayOfTheMonth.IsMatch(cronExpressionSegments[3]))
            {
                result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox DateTimeSchedule type with value {Value} because it is incorrect CronJob expression - day of the month is incorrect."));
            }

            if (string.IsNullOrEmpty(cronExpressionSegments[4]) || !_validMonth.IsMatch(cronExpressionSegments[4]))
            {
                result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox DateTimeSchedule type with value {Value} because it is incorrect CronJob expression - month is incorrect."));
            }

            if (string.IsNullOrEmpty(cronExpressionSegments[5]) || !_validDayOfWeek.IsMatch(cronExpressionSegments[5]))
            {
                result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox DateTimeSchedule type with value {Value} because it is incorrect CronJob expression - day of the week is incorrect."));
            }

            if (!string.IsNullOrEmpty(cronExpressionSegments[6]) && !_validYear.IsMatch(cronExpressionSegments[6]))
            {
                result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox DateTimeSchedule type with value {Value} because it is incorrect CronJob expression - year is incorrect."));
            }
        }
        catch(Exception ex)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), ex.Message));
        }

        return result;
    }

    private static string GetCronExpressionFromPhrase(string englishPhrase)
    {
        return englishPhrase.ToCronExpression().ToString();
    }

    private string[] GetcronExpresionSegments()
    {
        // There is max 7 segements in Cron expression
        // second minute hour dayofthemonth month dayoftheweek year
        string[] cronExpressionSegments = new string[7].Select(el => "").ToArray();

        if (string.IsNullOrEmpty(Value))
        {
            throw new FormatException("Could not create a Nox DateTimeSchedule type with empty value.");
        }

        string[] tempCronExpressionSegments = Value.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        if (tempCronExpressionSegments.Length < 5)
        {
            throw new FormatException($"Could not create a Nox DateTimeSchedule type with value {Value} because it is incorrect CronJob expression - 5 segements required at least.");
        }
        // if 5 segments, skip seconds and write from minutes
        else if (tempCronExpressionSegments.Length == 5)
        {
            // minute hour dayofthemonth month dayoftheweek
            Array.Copy(tempCronExpressionSegments, 0, cronExpressionSegments, 1, 5);
        }
        else if (tempCronExpressionSegments.Length == 6)
        {
            // check if 6th segment is a year
            if (Regex.IsMatch(tempCronExpressionSegments[5], "\\d{4}$", RegexOptions.Compiled, Regex_Default_Timeout_Miliseconds))
            {
                // minute hour dayofthemonth month dayoftheweek year
                Array.Copy(tempCronExpressionSegments, 0, cronExpressionSegments, 1, 6);
            }
            else
            {
                // second minute hour dayofthemonth month dayoftheweek
                Array.Copy(tempCronExpressionSegments, 0, cronExpressionSegments, 0, 6);
            }
        }
        else if (tempCronExpressionSegments.Length == 7)
        {
            // second minute hour dayofthemonth month dayoftheweek year
            Array.Copy(tempCronExpressionSegments, 0, cronExpressionSegments, 0, 7);
        }
        else
        {
            throw new FormatException($"Could not create a Nox DateTimeSchedule type with value {Value} because it is incorrect CronJob expression - 7 segements is maximum.");
        }
        return cronExpressionSegments;
    }
}