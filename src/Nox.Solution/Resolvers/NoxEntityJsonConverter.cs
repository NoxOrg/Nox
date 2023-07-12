using System.Collections.Generic;
using System.Text.Json;
using Nox.Solution.Exceptions;
using System.Text.Json.Serialization;
using System.Linq;
using System;

namespace Nox.Solution.Resolvers;

/// <summary>
/// Deserialize and validates List of Entities
/// </summary>
public class NoxEntityJsonConverter : JsonConverter<IReadOnlyList<Entity>>
{
    public override IReadOnlyList<Entity> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return JsonSerializer.Deserialize<IReadOnlyList<Entity>>(reader.GetString()!, options)!;
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="writer">Utf8JsonWriter writer</param>
    /// <param name="value">IReadOnlyList<Entity> value</param>
    /// <param name="options">JsonSerializerOptions options</param>
    /// <exception cref="NoxSolutionConfigurationException">
    /// Throws exception in case it doesn't satisfy validation rules.
    /// Validation rules:
    /// 1. If any key's property IsRequired is missing or set to false.
    /// </exception>
    public override void Write(Utf8JsonWriter writer, IReadOnlyList<Entity> value, JsonSerializerOptions options)
    {
        var missingItems = value
            .Where(x => x.Keys != null)
            .GroupBy(x => x.Name)
            .Select(x => new { Entity = x, Keys = x.SelectMany(t => t.Keys!).Where(k => !k.IsRequired) })
            .ToArray();

        if (missingItems?.Length > 0)
        {
            var messages = new List<string>();
            foreach (var missingItem in missingItems)
            {
                foreach (var key in missingItem.Keys)
                {
                    var message = $"{nameof(NoxSimpleTypeDefinition.IsRequired)} is missing or set to false in : {missingItem.Entity.Key}, key: {key.Name}.";
                    messages.Add(message);
                }
            }

            throw new NoxSolutionConfigurationException(string.Join("\n", messages));
        }

        writer.WriteStringValue(JsonSerializer.Serialize(value));
    }

    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert == typeof(IReadOnlyList<Entity>);
    }
}
