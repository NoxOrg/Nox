// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.DomainEventHandlers;

internal abstract class SecondTestEntityOwnedRelationshipZeroOrOneDeletedDomainEventHandlerBase : INotificationHandler<SecondTestEntityOwnedRelationshipZeroOrOneDeleted>
{
    private readonly IOutboxRepository _outboxRepository;

    protected SecondTestEntityOwnedRelationshipZeroOrOneDeletedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(SecondTestEntityOwnedRelationshipZeroOrOneDeleted domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class SecondTestEntityOwnedRelationshipZeroOrOneDeletedDomainEventHandler : SecondTestEntityOwnedRelationshipZeroOrOneDeletedDomainEventHandlerBase
{
    public SecondTestEntityOwnedRelationshipZeroOrOneDeletedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}