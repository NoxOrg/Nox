using System.Text.Json.Serialization;

namespace Nox.Application.Dto;

public class ODataCollectionDto<T>
{
    public T Value { get; set; } = default!;

    [JsonPropertyName("@odata.count")]
    public int Count { get; set; }
}
