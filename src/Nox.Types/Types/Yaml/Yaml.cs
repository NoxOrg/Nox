using System.IO;
using YamlDotNet.Core;
using YamlDotNet.Serialization;

namespace Nox.Types;

/// <summary>
///  Represents a Nox <see cref="Yaml"/> type and value object.
/// </summary>
public class Yaml : ValueObject<string, Yaml>
{
    private static readonly IDeserializer Deserializer = new DeserializerBuilder().Build();
    /// <summary>
    /// Validates the YAML object and returns the validation result.
    /// </summary>
    /// <returns>The validation result.</returns>
    internal override ValidationResult Validate()
    {
        var result = base.Validate();

        try
        {
            Deserializer.Deserialize(new StringReader(Value));
        }
        catch (YamlException)
        {
            result.Errors.Add(new ValidationFailure(nameof(Value),
                $"Could not create a Nox Yaml type with invalid yaml value '{Value}'."));
        }

        return result;
    }
}