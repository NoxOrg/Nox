// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.DomainEventHandlers;

internal abstract class TestEntityTwoRelationshipsOneToManyUpdatedDomainEventHandlerBase : INotificationHandler<TestEntityTwoRelationshipsOneToManyUpdated>
{
    private readonly IOutboxRepository _outboxRepository;

    protected TestEntityTwoRelationshipsOneToManyUpdatedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(TestEntityTwoRelationshipsOneToManyUpdated domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class TestEntityTwoRelationshipsOneToManyUpdatedDomainEventHandler : TestEntityTwoRelationshipsOneToManyUpdatedDomainEventHandlerBase
{
    public TestEntityTwoRelationshipsOneToManyUpdatedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}