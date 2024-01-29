using System.Text.Json.Serialization;

namespace Nox.Ui.Blazor.Lib.Models;

public class ODataCollectionResponse<T>
{
    public T Value { get; set; } = default!;

    [JsonPropertyName("@odata.count")]
    public int Count { get; set; }
}
