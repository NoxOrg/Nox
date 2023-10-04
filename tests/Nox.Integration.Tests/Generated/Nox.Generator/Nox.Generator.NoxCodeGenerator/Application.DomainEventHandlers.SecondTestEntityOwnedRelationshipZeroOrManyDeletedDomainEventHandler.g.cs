// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.DomainEventHandlers;

internal abstract class SecondTestEntityOwnedRelationshipZeroOrManyDeletedDomainEventHandlerBase : INotificationHandler<SecondTestEntityOwnedRelationshipZeroOrManyDeleted>
{
    private readonly IOutboxRepository _outboxRepository;

    protected SecondTestEntityOwnedRelationshipZeroOrManyDeletedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(SecondTestEntityOwnedRelationshipZeroOrManyDeleted domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class SecondTestEntityOwnedRelationshipZeroOrManyDeletedDomainEventHandler : SecondTestEntityOwnedRelationshipZeroOrManyDeletedDomainEventHandlerBase
{
    public SecondTestEntityOwnedRelationshipZeroOrManyDeletedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}