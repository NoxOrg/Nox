//Generated

#nullable enable

using MediatR;
using Nox.Integration.Abstractions.Models;

namespace TestIntegrationSolution.Application.Integrations;

public class TestIntegrationExecuteCompletedEvent: EtlExecuteCompletedEvent, INotification
{
    public TestIntegrationExecuteCompletedEvent(EtlExecuteCompletedDto dto)
    {
        IntegrationName = "TestIntegration";
    }
}