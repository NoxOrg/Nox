using System.Collections.Generic;

namespace Nox.Solution.Events;

public interface INoxSolutionSecretsEventArgs
{
    string Yaml { get; }
    IReadOnlyDictionary<string, string?>? Secrets { get; set; }
    
    Secrets? SecretsConfiguration { get; }
}