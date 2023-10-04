// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.DomainEventHandlers;

internal abstract class TestEntityOwnedRelationshipZeroOrOneCreatedDomainEventHandlerBase : INotificationHandler<TestEntityOwnedRelationshipZeroOrOneCreated>
{
    private readonly IOutboxRepository _outboxRepository;

    protected TestEntityOwnedRelationshipZeroOrOneCreatedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(TestEntityOwnedRelationshipZeroOrOneCreated domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class TestEntityOwnedRelationshipZeroOrOneCreatedDomainEventHandler : TestEntityOwnedRelationshipZeroOrOneCreatedDomainEventHandlerBase
{
    public TestEntityOwnedRelationshipZeroOrOneCreatedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}