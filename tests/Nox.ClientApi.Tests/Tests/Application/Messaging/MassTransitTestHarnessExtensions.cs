using FluentAssertions;
using MassTransit.Testing;
using Nox.Application;
using Nox.Infrastructure.Messaging;

namespace ClientApi.Tests.Application.Messaging
{
    public static class MassTransitTestHarnessExtensions
    {
        public static  void AssertAnyPublished<T>(this ITestHarness testHarness) where T : IIntegrationEvent    
        {
            var events = testHarness.Published.Select<CloudEventMessage<T>>().Select(x => x.MessageObject as CloudEventMessage<T>).ToArray();
            events.Should().Contain(x => x!.Data is T);
        }
    }
}
