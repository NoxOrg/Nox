using System.Text.Json.Serialization;

namespace Cryptocash.Ui.Data;

/// <summary>
/// Data class to organise returned Api results into entities list and overall total required for pagination
/// </summary>
public class EntityData<T>
{
    /// <summary>
    /// Property EntityTotal as total of entities from Api across all pages
    /// </summary>
    [JsonPropertyName("@odata.count")]
    public int EntityTotal { get; set; } = 0;

    /// <summary>
    /// Property EntityList as list of entities returned from APi query result
    /// </summary>
    [JsonPropertyName("value")]
    public List<T>? EntityList { get; set; }
}