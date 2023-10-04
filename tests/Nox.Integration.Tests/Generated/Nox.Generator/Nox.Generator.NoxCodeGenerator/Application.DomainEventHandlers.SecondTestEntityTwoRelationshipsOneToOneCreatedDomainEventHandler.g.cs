// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.DomainEventHandlers;

internal abstract class SecondTestEntityTwoRelationshipsOneToOneCreatedDomainEventHandlerBase : INotificationHandler<SecondTestEntityTwoRelationshipsOneToOneCreated>
{
    private readonly IOutboxRepository _outboxRepository;

    protected SecondTestEntityTwoRelationshipsOneToOneCreatedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(SecondTestEntityTwoRelationshipsOneToOneCreated domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class SecondTestEntityTwoRelationshipsOneToOneCreatedDomainEventHandler : SecondTestEntityTwoRelationshipsOneToOneCreatedDomainEventHandlerBase
{
    public SecondTestEntityTwoRelationshipsOneToOneCreatedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}