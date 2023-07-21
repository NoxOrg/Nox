using System.Globalization;

namespace Nox.Diagnostics;

public class Guard
{
    public static void Not<TException>(bool assertion, string message) where TException : Exception
    {
        if (!assertion)
        {
            return;
        }

        Exception? exception;

        try
        {
            exception = (TException)Activator.CreateInstance(typeof(TException), !string.IsNullOrWhiteSpace(message) ? message : "(no message specified)")!;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException(
                $"Exception type '{typeof(TException).FullName}' used with Guard possibly does not have a constructor that takes 1 string parameter (message).  Exception reported: {ex.Message}", ex);
        }

        throw exception;
    }

    public static void NotNull(object value, string name)
    {
        if (value == null)
        {
            throw new NullReferenceException($"Value with name '{(!string.IsNullOrWhiteSpace(name) ? name : "(no message specified)")}' may not be null.");
        }
    }

    public static void NotNullOrEmptyString(string value, string name)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new NullReferenceException($"The string with name '{(!string.IsNullOrWhiteSpace(name) ? name : "(no message specified)")}' may not be empty.");
        }
    }

    public static void NotUndefinedEnum<TEnum>(object value, string name)
    {
        if (!Enum.IsDefined(typeof(TEnum), value))
        {
            throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture,
                $"The value '{value ?? "(no value specified)"}' does not exist in enumeration of type '{typeof(TEnum).FullName}' with name '{(!string.IsNullOrWhiteSpace(name) ? name : "(no message specified)")}'."));
        }
    }

    public static void NotNullOrEmptyEnumerable(object enumerable, string name)
    {
        NotNull(enumerable, name);
    }
}