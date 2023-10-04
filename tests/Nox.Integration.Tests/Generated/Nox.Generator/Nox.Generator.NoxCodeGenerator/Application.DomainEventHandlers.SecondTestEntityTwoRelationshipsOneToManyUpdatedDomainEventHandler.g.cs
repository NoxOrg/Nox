// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.DomainEventHandlers;

internal abstract class SecondTestEntityTwoRelationshipsOneToManyUpdatedDomainEventHandlerBase : INotificationHandler<SecondTestEntityTwoRelationshipsOneToManyUpdated>
{
    private readonly IOutboxRepository _outboxRepository;

    protected SecondTestEntityTwoRelationshipsOneToManyUpdatedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(SecondTestEntityTwoRelationshipsOneToManyUpdated domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class SecondTestEntityTwoRelationshipsOneToManyUpdatedDomainEventHandler : SecondTestEntityTwoRelationshipsOneToManyUpdatedDomainEventHandlerBase
{
    public SecondTestEntityTwoRelationshipsOneToManyUpdatedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}