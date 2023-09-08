using Newtonsoft.Json;

namespace Nox.ClientApi.Tests.Tests.Models;

public class ODataCollectionResponse<T>
{
    public T Value { get; set; } = default!;
    [JsonProperty("@odata.count")]
    public int Count { get; set; }
}
