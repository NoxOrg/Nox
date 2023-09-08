using Newtonsoft.Json;

namespace Nox.ClientApi.Tests.Tests.Models;

public class ODataSigleResponse
{
    [JsonProperty("@odata.context")]
    public string Context { get; set; } = default!;
}