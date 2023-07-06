using System;

namespace Nox.Solution.Events;

public class NoxSolutionYamlEventArgs: EventArgs, INoxSolutionYamlEventArgs
{
    public NoxSolutionYamlEventArgs(string yaml)
    {
        Yaml = yaml;
    }
    
    public string Yaml { get; }
}