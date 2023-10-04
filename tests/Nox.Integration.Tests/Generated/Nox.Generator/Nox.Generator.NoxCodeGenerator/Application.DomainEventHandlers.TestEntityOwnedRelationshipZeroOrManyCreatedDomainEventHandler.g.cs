// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.DomainEventHandlers;

internal abstract class TestEntityOwnedRelationshipZeroOrManyCreatedDomainEventHandlerBase : INotificationHandler<TestEntityOwnedRelationshipZeroOrManyCreated>
{
    private readonly IOutboxRepository _outboxRepository;

    protected TestEntityOwnedRelationshipZeroOrManyCreatedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(TestEntityOwnedRelationshipZeroOrManyCreated domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class TestEntityOwnedRelationshipZeroOrManyCreatedDomainEventHandler : TestEntityOwnedRelationshipZeroOrManyCreatedDomainEventHandlerBase
{
    public TestEntityOwnedRelationshipZeroOrManyCreatedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}