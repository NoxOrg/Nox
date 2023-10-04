// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.DomainEventHandlers;

internal abstract class TestEntityZeroOrOneToExactlyOneDeletedDomainEventHandlerBase : INotificationHandler<TestEntityZeroOrOneToExactlyOneDeleted>
{
    private readonly IOutboxRepository _outboxRepository;

    protected TestEntityZeroOrOneToExactlyOneDeletedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(TestEntityZeroOrOneToExactlyOneDeleted domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class TestEntityZeroOrOneToExactlyOneDeletedDomainEventHandler : TestEntityZeroOrOneToExactlyOneDeletedDomainEventHandlerBase
{
    public TestEntityZeroOrOneToExactlyOneDeletedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}