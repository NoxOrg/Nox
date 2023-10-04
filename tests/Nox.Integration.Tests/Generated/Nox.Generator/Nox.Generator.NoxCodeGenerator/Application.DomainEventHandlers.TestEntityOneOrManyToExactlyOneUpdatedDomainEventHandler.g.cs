// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.DomainEventHandlers;

internal abstract class TestEntityOneOrManyToExactlyOneUpdatedDomainEventHandlerBase : INotificationHandler<TestEntityOneOrManyToExactlyOneUpdated>
{
    private readonly IOutboxRepository _outboxRepository;

    protected TestEntityOneOrManyToExactlyOneUpdatedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(TestEntityOneOrManyToExactlyOneUpdated domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class TestEntityOneOrManyToExactlyOneUpdatedDomainEventHandler : TestEntityOneOrManyToExactlyOneUpdatedDomainEventHandlerBase
{
    public TestEntityOneOrManyToExactlyOneUpdatedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}