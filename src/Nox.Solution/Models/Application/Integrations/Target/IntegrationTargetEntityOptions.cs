﻿using Nox.Yaml.Attributes;

namespace Nox.Solution;

[Title("Definition namespace for an entity integration target.")]
[Description("This section specified attributes related to an integration target of type Entity. Attributes include the entity name.")]
public class IntegrationTargetEntityOptions
{
    [Required]
    [Title("The entity name.")]
    [Description("The name of the entity to which data will be synchronized.")]
    [ExistInCollection(nameof(NoxSolution.Domain), nameof(NoxSolution.Domain.Entities), nameof(Entity.Name))]
    public string EntityName { get; set; } = null!;
}