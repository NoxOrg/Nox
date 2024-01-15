//Generated

#nullable enable

using MediatR;
using Nox.Integration.Abstractions.Models;

namespace {{codeGenConventions.ApplicationNameSpace}}.Integrations;

public class {{ className }}: EtlExecuteCompletedEvent, INotification
{
    public {{ className }}(EtlExecuteCompletedDto dto)
    {
        IntegrationName = "{{integration.Name}}";
    }
}