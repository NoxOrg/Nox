
using Newtonsoft.Json;

using System.Text.Json.Serialization;

namespace Nox.ClientApi.Tests.Tests.Controllers
{
    public class ODataResponse<T>
    {
        public T Value { get; set; } = default!;

        [JsonProperty("@odata.count")]
        [JsonPropertyName("@odata.count")]
        public int Count { get; set; }
    }
}