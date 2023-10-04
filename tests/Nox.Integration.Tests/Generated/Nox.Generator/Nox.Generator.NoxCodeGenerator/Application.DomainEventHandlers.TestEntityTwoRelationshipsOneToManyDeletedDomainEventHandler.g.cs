// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.DomainEventHandlers;

internal abstract class TestEntityTwoRelationshipsOneToManyDeletedDomainEventHandlerBase : INotificationHandler<TestEntityTwoRelationshipsOneToManyDeleted>
{
    private readonly IOutboxRepository _outboxRepository;

    protected TestEntityTwoRelationshipsOneToManyDeletedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(TestEntityTwoRelationshipsOneToManyDeleted domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class TestEntityTwoRelationshipsOneToManyDeletedDomainEventHandler : TestEntityTwoRelationshipsOneToManyDeletedDomainEventHandlerBase
{
    public TestEntityTwoRelationshipsOneToManyDeletedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}