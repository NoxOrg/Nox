using Nox.Solution.Models.Application.Jobs;
using Nox.Yaml.Attributes;
using System;
using System.Collections.Generic;

namespace Nox.Solution;

[GenerateJsonSchema]
[Title("A definition for application components used in a Nox solution.")]
[Description("A definition for Integrations, DataTransferObjects and other pertinent components pertaining to a Nox solution application component.")]
[AdditionalProperties(false)]
public class Application
{
    [Title("The definition namespace for application ETL data integrations.")]
    [Description("One or more solution data integrations with common ETL attributes including source, transform and target.")]
    [UniqueItemProperties(nameof(Integration.Name))]
    [AdditionalProperties(false)]
    public IReadOnlyList<Integration>? Integrations { get; internal set; }

    [Title("The definition namespace for application DTOs within a Nox solution.")]
    [Description("One or more DTOs (Data Transfer Objects used to transfer data between processes in a Nox solution.")]
    [UniqueItemProperties(nameof(DataTransferObject.Name))]
    [AdditionalProperties(false)]
    public IReadOnlyList<DataTransferObject>? DataTransferObjects { get; internal set; }
    
    [Title("The events that this application can raise.")]
    [Description("The collection of events that this application can raise to the outside world.")]
    [AdditionalProperties(false)]
    public IReadOnlyList<IntegrationEvent> IntegrationEvents { get; internal set; } = Array.Empty<IntegrationEvent>();

    [Title("The Jobs that this application runs.")]    
    [AdditionalProperties(false)]
    [UniqueItemProperties(nameof(EtlJob.Name))]
    public IReadOnlyList<EtlJob> Jobs { get; internal set; } = Array.Empty<EtlJob>();

    public Localization Localization { get; internal set; } = new Localization();
}