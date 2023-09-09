using Newtonsoft.Json;

namespace ClientApi.Tests.Tests.Models;

public class ODataCollectionResponse<T>
{
    public T Value { get; set; } = default!;
    [JsonProperty("@odata.count")]
    public int Count { get; set; }
}
