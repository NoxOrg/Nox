// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.DomainEventHandlers;

internal abstract class TestEntityOwnedRelationshipOneOrManyCreatedDomainEventHandlerBase : INotificationHandler<TestEntityOwnedRelationshipOneOrManyCreated>
{
    private readonly IOutboxRepository _outboxRepository;

    protected TestEntityOwnedRelationshipOneOrManyCreatedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(TestEntityOwnedRelationshipOneOrManyCreated domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class TestEntityOwnedRelationshipOneOrManyCreatedDomainEventHandler : TestEntityOwnedRelationshipOneOrManyCreatedDomainEventHandlerBase
{
    public TestEntityOwnedRelationshipOneOrManyCreatedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}