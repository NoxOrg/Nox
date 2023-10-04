// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.DomainEventHandlers;

internal abstract class SecondTestEntityOwnedRelationshipExactlyOneUpdatedDomainEventHandlerBase : INotificationHandler<SecondTestEntityOwnedRelationshipExactlyOneUpdated>
{
    private readonly IOutboxRepository _outboxRepository;

    protected SecondTestEntityOwnedRelationshipExactlyOneUpdatedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(SecondTestEntityOwnedRelationshipExactlyOneUpdated domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class SecondTestEntityOwnedRelationshipExactlyOneUpdatedDomainEventHandler : SecondTestEntityOwnedRelationshipExactlyOneUpdatedDomainEventHandlerBase
{
    public SecondTestEntityOwnedRelationshipExactlyOneUpdatedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}