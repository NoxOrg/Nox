//Generated

#nullable enable

using MediatR;
using Nox.Integration.Abstractions.Models;

namespace TestIntegrationSolution.Application.Integrations;

public class TestEntityExecuteCompletedEvent: NoxEtlExecuteCompletedEvent, INotification
{
    public TestEntityExecuteCompletedEvent(NoxEtlExecuteCompletedPayload payload)
    {
        IntegrationName = "TestIntegration";
    }
}