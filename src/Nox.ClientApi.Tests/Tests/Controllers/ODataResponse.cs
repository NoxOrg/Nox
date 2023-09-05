
using Newtonsoft.Json;

namespace Nox.ClientApi.Tests.Tests.Controllers
{
    public class ODataResponse<T>
    {
        public T Value { get; set; } = default!;
        [JsonProperty("@odata.count")]
        public int Count { get; set; }
    }
}