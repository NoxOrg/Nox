using Nox.Integration.Abstractions.Interfaces;

namespace Nox.Integration.EtlTests.Json;

public class SourceDto: INoxTransformDto
{
    public int CountryId { get; set; }
    public string CountryName { get; set; } = string.Empty;
    public int NoOfPeople { get; set; }
    public string DateCreated { get; set; } = string.Empty;
    public string? DateChanged { get; set; }
    public string ConcurrencyId { get; set; } = string.Empty;
}