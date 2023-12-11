//Generated

#nullable enable

using MediatR;
using Nox.Integration.Abstractions.Interfaces;
using Nox.Integration.Abstractions.Models;

namespace TestIntegrationSolution.Application.Integrations;

public class TestEntityRecordCreatedEvent: NoxEtlRecordCreatedEvent<INoxEtlEventPayload>, INotification
{
    public TestEntityRecordCreatedEvent(TestIntegrationRecordCreatedPayload payload)
    {
        IntegrationName = "TestIntegration";
        SetPayload(payload);
    }
}