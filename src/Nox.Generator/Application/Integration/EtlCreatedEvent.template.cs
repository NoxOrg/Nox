//Generated

#nullable enable

using MediatR;
using Nox.Integration.Abstractions.Interfaces;
using Nox.Integration.Abstractions.Models;

namespace {{codeGeneratorState.ApplicationNameSpace}}.Integrations;

public class {{ className }}: NoxEtlRecordCreatedEvent<INoxEtlEventPayload>, INotification
{
    public {{ className }}({{integration.Name}}RecordCreatedPayload payload)
    {
        IntegrationName = "{{integration.Name}}";
        SetPayload(payload);
    }
}