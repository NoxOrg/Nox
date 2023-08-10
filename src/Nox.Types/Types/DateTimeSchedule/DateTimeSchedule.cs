using System;
using Nox.Cron;
using Quartz;

namespace Nox.Types;

public class DateTimeSchedule : ValueObject<string, DateTimeSchedule>
{
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
        try
        {
            CronExpression.ValidateExpression(Value);
        }
        catch(Exception ex)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox DateTimeSchedule type with value {Value} because it is incorrect CronJob expression: " + ex.Message));
        }

        return result;
    }

    private static string GetCronExpressionFromPhrase(string englishPhrase)
    {
        return englishPhrase.ToCronExpression().ToString();
    }
}