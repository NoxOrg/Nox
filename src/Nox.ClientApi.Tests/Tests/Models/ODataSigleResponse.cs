using System.Text.Json.Serialization;

namespace ClientApi.Tests.Tests.Models;

public class ODataSigleResponse
{
    [JsonPropertyName("@odata.context")]
    public string Context { get; set; } = default!;
}