using System.Collections.Generic;


namespace Nox.Solution;

/// <summary>
/// A bare-bones version of a NoxSolution for pre-deserialization processing
/// for environment variable and secret processing.
/// </summary>
public class NoxSolutionBasicsOnly : DefinitionBase
{
    public IReadOnlyDictionary<string, object>? Variables { get; internal set; }

    public InfrastructureBasicsOnly? Infrastructure { get; internal set; }
}

public class InfrastructureBasicsOnly : DefinitionBase
{
    public SecurityBasicsOnly? Security { get; internal set; }
}

public class SecurityBasicsOnly
{
    public Secrets? Secrets { get; internal set; }
}
