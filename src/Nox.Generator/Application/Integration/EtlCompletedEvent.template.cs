//Generated

#nullable enable

using MediatR;
using Nox.Integration.EtlEvents;

namespace {{codeGeneratorState.ApplicationNameSpace}}.Integrations;

public class {{ className }}: NoxEtlExecuteCompletedEvent, INotification
{
    public {{ className }}(NoxEtlExecuteCompletedPayload payload)
    {
        IntegrationName = "{{integration.Name}}";
    }
}