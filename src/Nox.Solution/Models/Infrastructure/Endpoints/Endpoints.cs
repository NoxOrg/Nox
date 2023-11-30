using Nox.Yaml;
using Nox.Yaml.Attributes;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Nox.Solution;

[GenerateJsonSchema]
[Title("The definition namespace for default endpoints pertaining to a Nox solution.")]
[Description("Define default endpoints pertinent to a Nox solution here. These include endpoints for API and BFF servers.")]
[AdditionalProperties(false)]
public class Endpoints : YamlConfigNode<NoxSolution,Infrastructure>
{
    public ApiServer? ApiServer { get; internal set; }
    
    public BffServer? BffServer { get; internal set; }

}