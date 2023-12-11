//Generated

#nullable enable

using MediatR;
using Nox.Integration.Abstractions;
using Nox.Integration.EtlEvents;

namespace {{codeGeneratorState.ApplicationNameSpace}}.Integrations;

public class {{ className }}: NoxEtlRecordUpdatedEvent<INoxEtlEventPayload>, INotification
{
    public {{ className }}({{integration.Name}}RecordUpdatedPayload payload)
    {
        IntegrationName = "{{integration.Name}}";
    }
}