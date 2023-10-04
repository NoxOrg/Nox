// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.DomainEventHandlers;

internal abstract class SecondTestEntityOwnedRelationshipOneOrManyUpdatedDomainEventHandlerBase : INotificationHandler<SecondTestEntityOwnedRelationshipOneOrManyUpdated>
{
    private readonly IOutboxRepository _outboxRepository;

    protected SecondTestEntityOwnedRelationshipOneOrManyUpdatedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(SecondTestEntityOwnedRelationshipOneOrManyUpdated domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class SecondTestEntityOwnedRelationshipOneOrManyUpdatedDomainEventHandler : SecondTestEntityOwnedRelationshipOneOrManyUpdatedDomainEventHandlerBase
{
    public SecondTestEntityOwnedRelationshipOneOrManyUpdatedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}