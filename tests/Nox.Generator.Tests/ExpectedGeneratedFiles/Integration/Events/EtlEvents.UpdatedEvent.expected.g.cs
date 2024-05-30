//Generated

#nullable enable

using MediatR;
using Nox.Integration.Abstractions.Interfaces;
using Nox.Integration.Abstractions.Models;

namespace TestIntegrationSolution.Application.Integrations;

public class TestIntegrationRecordUpdatedEvent: EtlRecordUpdatedEvent<IEtlEventDto>, INotification
{
    public TestIntegrationRecordUpdatedEvent(TestIntegrationRecordUpdatedDto dto)
    {
        IntegrationName = "TestIntegration";
        SetDto(dto);
    }
}