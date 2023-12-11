//Generated

#nullable enable

using MediatR;
using Nox.Integration.Abstractions.Models;

namespace {{codeGeneratorState.ApplicationNameSpace}}.Integrations;

public class {{ className }}: NoxEtlExecuteCompletedEvent, INotification
{
    public {{ className }}(NoxEtlExecuteCompletedPayload payload)
    {
        IntegrationName = "{{integration.Name}}";
    }
}