// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.DomainEventHandlers;

internal abstract class SecondTestEntityTwoRelationshipsOneToOneUpdatedDomainEventHandlerBase : INotificationHandler<SecondTestEntityTwoRelationshipsOneToOneUpdated>
{
    private readonly IOutboxRepository _outboxRepository;

    protected SecondTestEntityTwoRelationshipsOneToOneUpdatedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(SecondTestEntityTwoRelationshipsOneToOneUpdated domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class SecondTestEntityTwoRelationshipsOneToOneUpdatedDomainEventHandler : SecondTestEntityTwoRelationshipsOneToOneUpdatedDomainEventHandlerBase
{
    public SecondTestEntityTwoRelationshipsOneToOneUpdatedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}