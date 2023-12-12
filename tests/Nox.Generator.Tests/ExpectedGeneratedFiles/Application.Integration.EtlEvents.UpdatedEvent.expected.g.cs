//Generated

#nullable enable

using MediatR;
using Nox.Integration.Abstractions.Interfaces;
using Nox.Integration.Abstractions.Models;

namespace TestIntegrationSolution.Application.Integrations;

public class TestEntityRecordUpdatedEvent: EtlRecordUpdatedEvent<IEtlEventDto>, INotification
{
    public TestEntityRecordUpdatedEvent(TestIntegrationRecordUpdatedDto dto)
    {
        IntegrationName = "TestIntegration";
    }
}