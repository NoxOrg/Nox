using Nox.Integration.Abstractions.Interfaces;

namespace Nox.Integration.EtlTests.Json;

public class TargetDto: INoxTransformDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Population { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime? EditDate { get; set; }
}