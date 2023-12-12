//Generated

#nullable enable

using MediatR;
using Nox.Integration.Abstractions.Interfaces;
using Nox.Integration.Abstractions.Models;

namespace {{codeGeneratorState.ApplicationNameSpace}}.Integrations;

public class {{ className }}: EtlRecordCreatedEvent<IEtlEventDto>, INotification
{
    public {{ className }}({{integration.Name}}RecordCreatedDto dto)
    {
        IntegrationName = "{{integration.Name}}";
        SetDto(dto);
    }
}