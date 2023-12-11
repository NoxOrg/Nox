//Generated

#nullable enable

using MediatR;
using Nox.Integration.Abstractions.Interfaces;
using Nox.Integration.Abstractions.Models;

namespace {{codeGeneratorState.ApplicationNameSpace}}.Integrations;

public class {{ className }}: NoxEtlRecordUpdatedEvent<INoxEtlEventPayload>, INotification
{
    public {{ className }}({{integration.Name}}RecordUpdatedPayload payload)
    {
        IntegrationName = "{{integration.Name}}";
    }
}