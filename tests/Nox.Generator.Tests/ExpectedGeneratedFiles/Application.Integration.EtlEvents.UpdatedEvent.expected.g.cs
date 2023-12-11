//Generated

#nullable enable

using MediatR;
using Nox.Integration.Abstractions;
using Nox.Integration.EtlEvents;

namespace TestIntegrationSolution.Application.Integrations;

public class TestEntityRecordUpdatedEvent: NoxEtlRecordUpdatedEvent<INoxEtlEventPayload>, INotification
{
    public TestEntityRecordUpdatedEvent(TestIntegrationRecordUpdatedPayload payload)
    {
        IntegrationName = "TestIntegration";
    }
}