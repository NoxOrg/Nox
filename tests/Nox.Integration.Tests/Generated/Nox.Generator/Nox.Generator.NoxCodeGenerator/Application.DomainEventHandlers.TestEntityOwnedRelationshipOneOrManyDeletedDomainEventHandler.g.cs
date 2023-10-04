// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.DomainEventHandlers;

internal abstract class TestEntityOwnedRelationshipOneOrManyDeletedDomainEventHandlerBase : INotificationHandler<TestEntityOwnedRelationshipOneOrManyDeleted>
{
    private readonly IOutboxRepository _outboxRepository;

    protected TestEntityOwnedRelationshipOneOrManyDeletedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(TestEntityOwnedRelationshipOneOrManyDeleted domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class TestEntityOwnedRelationshipOneOrManyDeletedDomainEventHandler : TestEntityOwnedRelationshipOneOrManyDeletedDomainEventHandlerBase
{
    public TestEntityOwnedRelationshipOneOrManyDeletedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}