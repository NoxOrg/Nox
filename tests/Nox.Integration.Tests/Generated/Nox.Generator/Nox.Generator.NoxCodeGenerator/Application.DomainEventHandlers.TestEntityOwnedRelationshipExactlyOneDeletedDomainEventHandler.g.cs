// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.DomainEventHandlers;

internal abstract class TestEntityOwnedRelationshipExactlyOneDeletedDomainEventHandlerBase : INotificationHandler<TestEntityOwnedRelationshipExactlyOneDeleted>
{
    private readonly IOutboxRepository _outboxRepository;

    protected TestEntityOwnedRelationshipExactlyOneDeletedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(TestEntityOwnedRelationshipExactlyOneDeleted domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class TestEntityOwnedRelationshipExactlyOneDeletedDomainEventHandler : TestEntityOwnedRelationshipExactlyOneDeletedDomainEventHandlerBase
{
    public TestEntityOwnedRelationshipExactlyOneDeletedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}