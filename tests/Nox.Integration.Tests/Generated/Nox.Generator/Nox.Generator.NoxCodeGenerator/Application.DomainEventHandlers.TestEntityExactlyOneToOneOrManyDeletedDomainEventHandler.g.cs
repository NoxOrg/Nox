// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.DomainEventHandlers;

internal abstract class TestEntityExactlyOneToOneOrManyDeletedDomainEventHandlerBase : INotificationHandler<TestEntityExactlyOneToOneOrManyDeleted>
{
    private readonly IOutboxRepository _outboxRepository;

    protected TestEntityExactlyOneToOneOrManyDeletedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(TestEntityExactlyOneToOneOrManyDeleted domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class TestEntityExactlyOneToOneOrManyDeletedDomainEventHandler : TestEntityExactlyOneToOneOrManyDeletedDomainEventHandlerBase
{
    public TestEntityExactlyOneToOneOrManyDeletedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}