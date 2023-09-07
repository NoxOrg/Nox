using Newtonsoft.Json;

namespace Nox.ClientApi.Tests.Models;

public class ODataResponse<T>
{
    public T Value { get; set; } = default!;
    [JsonProperty("@odata.count")]
    public int Count { get; set; }
}