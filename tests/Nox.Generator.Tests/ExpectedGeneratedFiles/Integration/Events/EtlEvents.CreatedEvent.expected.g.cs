//Generated

#nullable enable

using MediatR;
using Nox.Integration.Abstractions.Interfaces;
using Nox.Integration.Abstractions.Models;

namespace TestIntegrationSolution.Application.Integrations;

public class TestIntegrationRecordCreatedEvent: EtlRecordCreatedEvent<IEtlEventDto>, INotification
{
    public TestIntegrationRecordCreatedEvent(TestIntegrationRecordCreatedDto dto)
    {
        IntegrationName = "TestIntegration";
        SetDto(dto);
    }
}