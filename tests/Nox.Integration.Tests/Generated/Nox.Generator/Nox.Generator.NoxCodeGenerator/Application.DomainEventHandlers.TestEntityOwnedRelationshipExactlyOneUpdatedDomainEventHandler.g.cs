// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.DomainEventHandlers;

internal abstract class TestEntityOwnedRelationshipExactlyOneUpdatedDomainEventHandlerBase : INotificationHandler<TestEntityOwnedRelationshipExactlyOneUpdated>
{
    private readonly IOutboxRepository _outboxRepository;

    protected TestEntityOwnedRelationshipExactlyOneUpdatedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(TestEntityOwnedRelationshipExactlyOneUpdated domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class TestEntityOwnedRelationshipExactlyOneUpdatedDomainEventHandler : TestEntityOwnedRelationshipExactlyOneUpdatedDomainEventHandlerBase
{
    public TestEntityOwnedRelationshipExactlyOneUpdatedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}