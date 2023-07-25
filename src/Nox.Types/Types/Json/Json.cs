using System;
using System.Text.Json;

namespace Nox.Types;

/// <summary>
/// Represents a Nox <see cref="Json"/> type and value object.
/// </summary>
public sealed class Json : ValueObject<string, Json>
{
    /// <summary>
    /// Gets or sets the options for processing json.
    /// </summary>
    private JsonTypeOptions Options { get; set; } = null!;

    private string? _prettyValue = null;

    private string? _minifiedValue = null;

    public new static Json From(string value) => From(value, new JsonTypeOptions());


    /// <summary>
    /// Creates the Jsoninstance using the value and options provided.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="options">The options.</param>
    /// <returns>A Json.</returns>
    public static Json From(string value, JsonTypeOptions options)
    {
        var newObject = new Json
        {
            Options = options,
            Value = value
        };

        var validationResult = newObject.Validate();

        if (!validationResult.IsValid)
        {
            throw new TypeValidationException(validationResult.Errors);
        }

        newObject.ApplyOptions();

        return newObject;

    }

    /// <summary>
    /// Applies the options.
    /// </summary>
    private void ApplyOptions()
    {
        if (Options.PersistMinified)
        {
            Value = JsonSerializer.Serialize(JsonSerializer.Deserialize<object>(base.Value!), new JsonSerializerOptions { AllowTrailingCommas = false, WriteIndented = false });
            _minifiedValue = Value;
        }
    }

    /// <summary>
    /// Returns a pretty-fied version of the Json
    /// </summary>
    public override string ToString() 
    {
        return Value;
    }

    /// <summary>
    /// Returns a pretty-fied version of the Json
    /// </summary>
    public string ToString(string format)
    {
        if (string.IsNullOrEmpty(format))
        {
            format = "p";
        }

        if (format!.Length == 1)
        {
            switch (format[0] | 0x20)
            {
                case 'p':
                case 'P':
                    if (_prettyValue is null)
                    {
                        _prettyValue = JsonSerializer.Serialize(JsonSerializer.Deserialize<object>(Value!), new JsonSerializerOptions { WriteIndented = true });
                    }
                    return _prettyValue; 
                case 'm':
                case 'M':
                    if (_minifiedValue is null)
                    {
                        _minifiedValue = JsonSerializer.Serialize(JsonSerializer.Deserialize<object>(base.Value!), new JsonSerializerOptions { AllowTrailingCommas = false, WriteIndented = false });
                    }
                    return _minifiedValue;

                default:
                    throw new FormatException("Invalid json format");
            }
        }
        throw new FormatException("Invalid json format");
    }

    /// <inheritdoc/>
    internal override ValidationResult Validate()
    {
        var result = base.Validate();

        try
        {
            JsonDocument.Parse(Value);
        }
        catch (JsonException ex)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Json type with value {Value} due to JsonException ({ex.Message})."));
        }
        catch (Exception ex)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value), $"Could not create a Nox Json type with value {Value} due to Exception ({ex.Message})."));
        }

        return result;
    }

    /// <inheritdoc/>
    public override bool Equals(object? obj)
    {
        return this.Equals(obj, false);
    }

    public bool Equals(object? obj, bool ignoreArrayOrder)
    {
        if (obj == null || obj.GetType() != GetType())
        {
            return false;
        }

        var other = (ValueObject<string, Json>)obj;

        var comparer = new JsonElementComparer(Options.MaxHashDepth, ignoreArrayOrder);
        using var json1 = JsonDocument.Parse(Value);
        using var json2 = JsonDocument.Parse(other.Value);


        return comparer.Equals(json1.RootElement, json2.RootElement);
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}
