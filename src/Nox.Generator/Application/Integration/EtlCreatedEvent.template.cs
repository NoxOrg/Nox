//Generated

#nullable enable

using MediatR;
using Nox.Integration.Abstractions;
using Nox.Integration.EtlEvents;

namespace {{codeGeneratorState.ApplicationNameSpace}}.Integrations;

public class {{ className }}: NoxEtlRecordCreatedEvent<INoxEtlEventPayload>, INotification
{
    public {{ className }}({{integration.Name}}RecordCreatedPayload payload)
    {
        IntegrationName = "{{integration.Name}}";
        SetPayload(payload);
    }
}