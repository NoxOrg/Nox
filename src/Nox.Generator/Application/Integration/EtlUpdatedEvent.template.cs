//Generated

#nullable enable

using MediatR;
using Nox.Integration.Abstractions.Interfaces;
using Nox.Integration.Abstractions.Models;

namespace {{codeGeneratorState.ApplicationNameSpace}}.Integrations;

public class {{ className }}: EtlRecordUpdatedEvent<IEtlEventDto>, INotification
{
    public {{ className }}({{integration.Name}}RecordUpdatedDto dto)
    {
        IntegrationName = "{{integration.Name}}";
        SetDto(dto);
    }
}