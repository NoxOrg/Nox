﻿using Nox.Types.Schema;
using System;

namespace Nox.Solution;

[GenerateJsonSchema]
[Title("The definition namespace for infrastructure components pertaining to a Nox solution.")]
[Description("Define components pertinent to solution infrastructure here. Examples include persistence, messaging, dependencies and endpoints.")]
[AdditionalProperties(false)]
public class Infrastructure : DefinitionBase
{    
    // These descriptors should be moved to the class when the generator is fixed
    [Title("The definition namespace for persistance settings pertaining to a Nox solution.")]
    [Description("Defines settings pertinent to solution persistence here. These include database, event source, search and cache servers.")]
    [AdditionalProperties(false)]
    public Persistence? Persistence { get; internal set; }

    // These descriptors should be moved to the class when the generator is fixed
    [Title("The definition namespace for messaging settings pertaining to a Nox solution.")]
    [Description("Defines settings pertinent to solution messaging here. These include IntegrationEventServer provider (RabbitMQ, Azure ServiceBus, Amazon SQS etc) and additional server connection details.")]
    [AdditionalProperties(false)]
    public Messaging? Messaging { get; internal set; }

    public Endpoints Endpoints { get; internal set; } = new();

    public Dependencies? Dependencies { get; internal set; }

    public Security? Security { get; internal set; }

    internal void ApplyDefaults(string version)
    {
        Endpoints!.ApplyDefaults(version);
    }
}
