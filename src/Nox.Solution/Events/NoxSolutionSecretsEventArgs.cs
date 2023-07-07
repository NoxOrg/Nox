using System;
using System.Collections.Generic;

namespace Nox.Solution.Events;

public class NoxSolutionSecretsEventArgs: EventArgs, INoxSolutionSecretsEventArgs
{
    public NoxSolutionSecretsEventArgs(string yaml)
    {
        Yaml = yaml;
    }
    public string Yaml { get; set; }
    
    public IReadOnlyDictionary<string, string?>? Secrets { get; set; }
}