// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.DomainEventHandlers;

internal abstract class SecondTestEntityOwnedRelationshipExactlyOneCreatedDomainEventHandlerBase : INotificationHandler<SecondTestEntityOwnedRelationshipExactlyOneCreated>
{
    private readonly IOutboxRepository _outboxRepository;

    protected SecondTestEntityOwnedRelationshipExactlyOneCreatedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(SecondTestEntityOwnedRelationshipExactlyOneCreated domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class SecondTestEntityOwnedRelationshipExactlyOneCreatedDomainEventHandler : SecondTestEntityOwnedRelationshipExactlyOneCreatedDomainEventHandlerBase
{
    public SecondTestEntityOwnedRelationshipExactlyOneCreatedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}