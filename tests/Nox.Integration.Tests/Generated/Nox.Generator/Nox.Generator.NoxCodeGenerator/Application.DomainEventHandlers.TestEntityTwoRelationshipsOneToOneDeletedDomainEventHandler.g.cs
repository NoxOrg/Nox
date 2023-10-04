// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.DomainEventHandlers;

internal abstract class TestEntityTwoRelationshipsOneToOneDeletedDomainEventHandlerBase : INotificationHandler<TestEntityTwoRelationshipsOneToOneDeleted>
{
    private readonly IOutboxRepository _outboxRepository;

    protected TestEntityTwoRelationshipsOneToOneDeletedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(TestEntityTwoRelationshipsOneToOneDeleted domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class TestEntityTwoRelationshipsOneToOneDeletedDomainEventHandler : TestEntityTwoRelationshipsOneToOneDeletedDomainEventHandlerBase
{
    public TestEntityTwoRelationshipsOneToOneDeletedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}