// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.DomainEventHandlers;

internal abstract class SecondTestEntityTwoRelationshipsOneToOneDeletedDomainEventHandlerBase : INotificationHandler<SecondTestEntityTwoRelationshipsOneToOneDeleted>
{
    private readonly IOutboxRepository _outboxRepository;

    protected SecondTestEntityTwoRelationshipsOneToOneDeletedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(SecondTestEntityTwoRelationshipsOneToOneDeleted domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class SecondTestEntityTwoRelationshipsOneToOneDeletedDomainEventHandler : SecondTestEntityTwoRelationshipsOneToOneDeletedDomainEventHandlerBase
{
    public SecondTestEntityTwoRelationshipsOneToOneDeletedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}