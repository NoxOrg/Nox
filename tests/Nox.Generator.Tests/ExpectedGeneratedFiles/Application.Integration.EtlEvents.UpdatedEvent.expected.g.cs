//Generated

#nullable enable

using MediatR;
using Nox.Integration.Abstractions.Interfaces;
using Nox.Integration.Abstractions.Models;

namespace TestIntegrationSolution.Application.Integrations;

public class TestEntityRecordUpdatedEvent: NoxEtlRecordUpdatedEvent<INoxEtlEventPayload>, INotification
{
    public TestEntityRecordUpdatedEvent(TestIntegrationRecordUpdatedPayload payload)
    {
        IntegrationName = "TestIntegration";
    }
}