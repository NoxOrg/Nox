// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.DomainEventHandlers;

internal abstract class TestEntityTwoRelationshipsManyToManyCreatedDomainEventHandlerBase : INotificationHandler<TestEntityTwoRelationshipsManyToManyCreated>
{
    private readonly IOutboxRepository _outboxRepository;

    protected TestEntityTwoRelationshipsManyToManyCreatedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(TestEntityTwoRelationshipsManyToManyCreated domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class TestEntityTwoRelationshipsManyToManyCreatedDomainEventHandler : TestEntityTwoRelationshipsManyToManyCreatedDomainEventHandlerBase
{
    public TestEntityTwoRelationshipsManyToManyCreatedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}