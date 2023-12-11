//Generated

#nullable enable

using MediatR;
using Nox.Integration.Abstractions;
using Nox.Integration.EtlEvents;

namespace TestIntegrationSolution.Application.Integrations;

public class TestEntityRecordCreatedEvent: NoxEtlRecordCreatedEvent<INoxEtlEventPayload>, INotification
{
    public TestEntityRecordCreatedEvent(TestIntegrationRecordCreatedPayload payload)
    {
        IntegrationName = "TestIntegration";
        SetPayload(payload);
    }
}