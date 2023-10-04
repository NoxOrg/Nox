// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.DomainEventHandlers;

internal abstract class TestEntityZeroOrManyToExactlyOneDeletedDomainEventHandlerBase : INotificationHandler<TestEntityZeroOrManyToExactlyOneDeleted>
{
    private readonly IOutboxRepository _outboxRepository;

    protected TestEntityZeroOrManyToExactlyOneDeletedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(TestEntityZeroOrManyToExactlyOneDeleted domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class TestEntityZeroOrManyToExactlyOneDeletedDomainEventHandler : TestEntityZeroOrManyToExactlyOneDeletedDomainEventHandlerBase
{
    public TestEntityZeroOrManyToExactlyOneDeletedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}