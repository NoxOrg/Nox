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
    private JsonTypeOptions Options { get; set; } = new JsonTypeOptions();

    private string _returnValue = string.Empty;

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
            base.Value = JsonSerializer.Serialize(JsonSerializer.Deserialize<object>(base.Value!), new JsonSerializerOptions { AllowTrailingCommas = false, WriteIndented = false });
        }
        if (Options.ReturnPretty)
        {
            _returnValue = JsonSerializer.Serialize(JsonSerializer.Deserialize<object>(base.Value!), new JsonSerializerOptions { WriteIndented = true });
        }
    }

    /// <summary>
    /// Gets or sets the value based on the option values.
    /// </summary>
    public override string Value { 
        get => _returnValue;
        protected set { 
                base.Value = _returnValue = value;
        } 
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
    public override bool Equals(object obj)
    {
        if (obj == null || obj.GetType() != GetType())
        {
            return false;
        }

        var other = (ValueObject<string, Json>)obj;

        var comparer = new JsonElementComparer(Options.MaxHashDepth, Options.IgnoreArrayOrder);
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
