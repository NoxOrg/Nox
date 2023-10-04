// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.DomainEventHandlers;

internal abstract class TestEntityOneOrManyToExactlyOneCreatedDomainEventHandlerBase : INotificationHandler<TestEntityOneOrManyToExactlyOneCreated>
{
    private readonly IOutboxRepository _outboxRepository;

    protected TestEntityOneOrManyToExactlyOneCreatedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(TestEntityOneOrManyToExactlyOneCreated domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class TestEntityOneOrManyToExactlyOneCreatedDomainEventHandler : TestEntityOneOrManyToExactlyOneCreatedDomainEventHandlerBase
{
    public TestEntityOneOrManyToExactlyOneCreatedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}