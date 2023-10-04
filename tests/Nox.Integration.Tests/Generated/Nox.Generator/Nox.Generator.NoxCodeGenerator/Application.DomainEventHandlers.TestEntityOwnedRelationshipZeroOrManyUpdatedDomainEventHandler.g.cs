// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.DomainEventHandlers;

internal abstract class TestEntityOwnedRelationshipZeroOrManyUpdatedDomainEventHandlerBase : INotificationHandler<TestEntityOwnedRelationshipZeroOrManyUpdated>
{
    private readonly IOutboxRepository _outboxRepository;

    protected TestEntityOwnedRelationshipZeroOrManyUpdatedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(TestEntityOwnedRelationshipZeroOrManyUpdated domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class TestEntityOwnedRelationshipZeroOrManyUpdatedDomainEventHandler : TestEntityOwnedRelationshipZeroOrManyUpdatedDomainEventHandlerBase
{
    public TestEntityOwnedRelationshipZeroOrManyUpdatedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}