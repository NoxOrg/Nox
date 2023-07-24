using System.Collections.Generic;


namespace Nox.Solution;

/// <summary>
/// A bare-bones version of a NoxSolution for pre-deserialization processing
/// for environment variable and secret processing.
/// </summary>
internal class NoxSolutionBasicsOnly : DefinitionBase
{
    public IReadOnlyDictionary<string, object>? Variables { get; internal set; }

    public InfrastructureBasicsOnly? Infrastructure { get; internal set; }
}

internal class InfrastructureBasicsOnly : DefinitionBase
{
    public SecurityBasicsOnly? Security { get; internal set; }
}

internal class SecurityBasicsOnly
{
    public Secrets? Secrets { get; internal set; }
}
