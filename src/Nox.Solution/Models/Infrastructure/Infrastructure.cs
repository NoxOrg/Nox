﻿using Nox.Solution.Models.Infrastructure.Monitoring;
using Nox.Yaml.Attributes;

namespace Nox.Solution;

[GenerateJsonSchema]
[Title("The definition namespace for infrastructure components pertaining to a Nox solution.")]
[Description("Define components pertinent to solution infrastructure here. Examples include persistence, messaging, dependencies and endpoints.")]
[UniqueChildProperty("Name")]
[AdditionalProperties(false)]
public class Infrastructure
{    
    // These descriptors should be moved to the class when the generator is fixed
    [Title("The definition namespace for persistance settings pertaining to a Nox solution.")]
    [Description("Defines settings pertinent to solution persistence here. These include database, event source, search and cache servers.")]
    [AdditionalProperties(false)]
    public Persistence? Persistence { get; internal set; }

    // These descriptors should be moved to the class when the generator is fixed

    public Messaging? Messaging { get; internal set; }

    [Title("The definition namespace for Monitor and Observability pertaining to a Nox solutionn.")]
    [Description("Specify properties pertinent to the APM server here.")]
    [AdditionalProperties(false)]
    public Monitoring? Monitoring { get; internal set; }

    public Endpoints Endpoints { get; internal set; } = new();

    public Dependencies? Dependencies { get; internal set; }

    public Security? Security { get; internal set; }

}
