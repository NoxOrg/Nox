// Generated
#nullable enable

using Nox.Integration.Abstractions.Models;

namespace TestIntegrationSolution.Application.Integration.CustomTransform;

public sealed class JsonToTableTargetDto: NoxEntityTargetDto
{
    public System.Int64 Id { get; set; }
    public System.String Name { get; set; } = string.Empty;
    public System.Int32 Population { get; set; }
    public System.DateTimeOffset CreateDate { get; set; }
    public System.DateTimeOffset? EditDate { get; set; }
    public System.Int32? PopulationMillions { get; set; }
    public System.String? NameWithLower { get; set; }
}