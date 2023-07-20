using System.Collections.Generic;

namespace Nox.Solution.Events;

public interface INoxSolutionSecretsEventArgs
{
    IReadOnlyDictionary<string, string?>? Secrets { get; set; }

    IReadOnlyList<string> Variables { get; }

    Secrets SecretsConfig { get; }
}