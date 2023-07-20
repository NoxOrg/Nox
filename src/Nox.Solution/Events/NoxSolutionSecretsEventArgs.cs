using System;
using System.Collections.Generic;

namespace Nox.Solution.Events;

public class NoxSolutionSecretsEventArgs: EventArgs, INoxSolutionSecretsEventArgs
{
    public NoxSolutionSecretsEventArgs(Secrets secretsConfig, IReadOnlyList<string> variables)
    {
        SecretsConfig = secretsConfig;
        Variables = variables;
    }

    public Secrets SecretsConfig { get; }

    public IReadOnlyList<string> Variables { get; }

    public IReadOnlyDictionary<string, string?>? Secrets { get; set; }
    
}