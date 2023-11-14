﻿using Nox.Yaml.Attributes;
using Nox.Yaml.Tests.TestDesigns.Nox.Types.TypeDefinitions;
using System.Collections.Generic;

namespace Nox.Yaml.Tests.TestDesigns.Nox.Models;

[GenerateJsonSchema]
[Title("Defines a command that operates on the domain.")]
[Description("Defines a command that operates on the domain. A Command has side effects and doesn't return a value.")]
[AdditionalProperties(false)]
public class DomainCommand : NoxComplexTypeDefinition
{
    public IReadOnlyList<string>? EmitEvents { get; internal set; }
}