// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.DomainEventHandlers;

internal abstract class SecondTestEntityTwoRelationshipsOneToManyDeletedDomainEventHandlerBase : INotificationHandler<SecondTestEntityTwoRelationshipsOneToManyDeleted>
{
    private readonly IOutboxRepository _outboxRepository;

    protected SecondTestEntityTwoRelationshipsOneToManyDeletedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(SecondTestEntityTwoRelationshipsOneToManyDeleted domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class SecondTestEntityTwoRelationshipsOneToManyDeletedDomainEventHandler : SecondTestEntityTwoRelationshipsOneToManyDeletedDomainEventHandlerBase
{
    public SecondTestEntityTwoRelationshipsOneToManyDeletedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}