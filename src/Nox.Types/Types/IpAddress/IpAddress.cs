namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="IpAddress"/> type and value object.
/// </summary>
/// <remarks>Placeholder, needs to be implemented</remarks>
public sealed class IpAddress : ValueObject<string, IpAddress>
{
    /// <summary>
    /// Creates a new instance of <see cref="IpAddress"/> object.
    /// </summary>
    /// <param name="value">The value to create the <see cref="IpAddress"/> with</param>
    /// <returns></returns>
    /// <exception cref="TypeValidationException"></exception>
    public new static IpAddress From(string value)
    {
        TryParse(value, out var ipAddressValue);

        var newObject = new IpAddress
        {
            Value = ipAddressValue
        };

        var validationResult = newObject.Validate();

        if (!validationResult.IsValid)
        {
            throw new TypeValidationException(validationResult.Errors);
        }

        return newObject;
    }

    /// <summary>
    /// Validates a <see cref="IpAddress"/> object.
    /// </summary>
    /// <returns>true if the <see cref="IpAddress"/> value is valid.</returns>
    internal override ValidationResult Validate()
    {
        var result = base.Validate();

        if (!TryParse(Value, out var _))
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox IP Address type as value {Value} is not a valid IP Address."));
        }

        return result;
    }

    private static bool TryParse(string inputValue, out string ipAddressValue)
    {
        var success = System.Net.IPAddress.TryParse(inputValue, out var ipAddress);
        ipAddressValue = ipAddress?.ToString() ?? inputValue;

        return success;
    }
}
