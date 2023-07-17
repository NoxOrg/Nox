using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

/// <summary>
/// Class for Json and string conversion.
/// </summary>
public class JsonConverter : ValueConverter<Json, string>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="JsonConverter"/> class.
    /// </summary>
    public JsonConverter() : base(json => json.Value, jsonValue => Json.From(jsonValue)) { }
}
