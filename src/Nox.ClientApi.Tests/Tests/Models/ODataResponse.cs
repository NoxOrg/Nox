using System.Text.Json.Serialization;

namespace Nox.ClientApi.Tests.Tests.Models;

public class ODataResponse<T>
{
    public T Value { get; set; } = default!;
    
    [JsonPropertyName("@odata.count")]
    public int Count { get; set; }
}