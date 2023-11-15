/// <summary>
/// A bare-bones version of a NoxSolution for pre-deserialization processing
/// for environment variable and secret processing.
/// </summary>

using Nox.Yaml.Tests.TestDesigns.Nox.Models;

internal class NoxSolutionBasicsOnly
{
    public IReadOnlyDictionary<string, object>? Variables { get; internal set; }

    public InfrastructureBasicsOnly? Infrastructure { get; internal set; }
}

internal class InfrastructureBasicsOnly
{
    public SecurityBasicsOnly? Security { get; internal set; }
}

internal class SecurityBasicsOnly
{
    public Secrets? Secrets { get; internal set; }
}
