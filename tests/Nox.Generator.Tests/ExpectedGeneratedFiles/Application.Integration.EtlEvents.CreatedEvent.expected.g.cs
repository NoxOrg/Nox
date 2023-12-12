//Generated

#nullable enable

using MediatR;
using Nox.Integration.Abstractions.Interfaces;
using Nox.Integration.Abstractions.Models;

namespace TestIntegrationSolution.Application.Integrations;

public class TestEntityRecordCreatedEvent: EtlRecordCreatedEvent<IEtlEventDto>, INotification
{
    public TestEntityRecordCreatedEvent(TestIntegrationRecordCreatedDto dto)
    {
        IntegrationName = "TestIntegration";
        SetDto(dto);
    }
}