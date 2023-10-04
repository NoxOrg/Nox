// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.DomainEventHandlers;

internal abstract class TestEntityOneOrManyToZeroOrManyDeletedDomainEventHandlerBase : INotificationHandler<TestEntityOneOrManyToZeroOrManyDeleted>
{
    private readonly IOutboxRepository _outboxRepository;

    protected TestEntityOneOrManyToZeroOrManyDeletedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(TestEntityOneOrManyToZeroOrManyDeleted domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class TestEntityOneOrManyToZeroOrManyDeletedDomainEventHandler : TestEntityOneOrManyToZeroOrManyDeletedDomainEventHandlerBase
{
    public TestEntityOneOrManyToZeroOrManyDeletedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}