//Generated

#nullable enable

using MediatR;
using Nox.Integration.Abstractions.Models;

namespace TestIntegrationSolution.Application.Integrations;

public class TestEntityExecuteCompletedEvent: EtlExecuteCompletedEvent, INotification
{
    public TestEntityExecuteCompletedEvent(EtlExecuteCompletedDto dto)
    {
        IntegrationName = "TestIntegration";
    }
}