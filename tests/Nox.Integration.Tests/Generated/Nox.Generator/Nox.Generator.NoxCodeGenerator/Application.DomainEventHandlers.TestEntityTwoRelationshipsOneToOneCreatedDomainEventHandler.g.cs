// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.DomainEventHandlers;

internal abstract class TestEntityTwoRelationshipsOneToOneCreatedDomainEventHandlerBase : INotificationHandler<TestEntityTwoRelationshipsOneToOneCreated>
{
    private readonly IOutboxRepository _outboxRepository;

    protected TestEntityTwoRelationshipsOneToOneCreatedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(TestEntityTwoRelationshipsOneToOneCreated domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class TestEntityTwoRelationshipsOneToOneCreatedDomainEventHandler : TestEntityTwoRelationshipsOneToOneCreatedDomainEventHandlerBase
{
    public TestEntityTwoRelationshipsOneToOneCreatedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}