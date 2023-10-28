using FluentAssertions;
using MassTransit.Testing;
using Nox.Infrastructure.Messaging;

namespace ClientApi.Tests.Application.Messaging
{
    public static class MassTransitTestHarnessExtensions
    {
        public static  void AssertAnyPublished<T>(this ITestHarness testHarness)
        {
            var events = testHarness.Published.Select<CloudEventMessage>().Select(x => x.MessageObject as CloudEventMessage).ToArray();
            events.Should().Contain(x => x!.IntegrationEvent is T);
        }
    }
}
