
using System.Net;
using System.Text.Json.Serialization;

namespace ClientApi.Tests.Tests.Models;

public class ODataReferenceResponse
{
    [JsonPropertyName("@odata.id")]
    public string ODataId { get; set; } = default!;
}