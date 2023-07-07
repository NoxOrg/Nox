using System;
using System.Collections.Generic;

namespace Nox.Solution.Events;

public class NoxSolutionSecretsEventArgs: EventArgs, INoxSolutionSecretsEventArgs
{
    public NoxSolutionSecretsEventArgs(string yaml, Secrets? secretsConfiguration)
    {
        Yaml = yaml;
        SecretsConfiguration = secretsConfiguration;
    }
    public string Yaml { get; }
    
    public IReadOnlyDictionary<string, string?>? Secrets { get; set; }
    
    public Secrets? SecretsConfiguration { get; }
}