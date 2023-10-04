// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.DomainEventHandlers;

internal abstract class TestEntityZeroOrManyToOneOrManyDeletedDomainEventHandlerBase : INotificationHandler<TestEntityZeroOrManyToOneOrManyDeleted>
{
    private readonly IOutboxRepository _outboxRepository;

    protected TestEntityZeroOrManyToOneOrManyDeletedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(TestEntityZeroOrManyToOneOrManyDeleted domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class TestEntityZeroOrManyToOneOrManyDeletedDomainEventHandler : TestEntityZeroOrManyToOneOrManyDeletedDomainEventHandlerBase
{
    public TestEntityZeroOrManyToOneOrManyDeletedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}