using System.Text.Json.Serialization;

namespace Nox.Application.Dto;

public class ODataSingleDto
{
    [JsonPropertyName("@odata.context")]
    public string Context { get; set; } = default!;
}