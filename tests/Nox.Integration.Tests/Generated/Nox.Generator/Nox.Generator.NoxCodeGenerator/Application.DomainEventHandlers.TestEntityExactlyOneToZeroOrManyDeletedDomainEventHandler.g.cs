// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.DomainEventHandlers;

internal abstract class TestEntityExactlyOneToZeroOrManyDeletedDomainEventHandlerBase : INotificationHandler<TestEntityExactlyOneToZeroOrManyDeleted>
{
    private readonly IOutboxRepository _outboxRepository;

    protected TestEntityExactlyOneToZeroOrManyDeletedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(TestEntityExactlyOneToZeroOrManyDeleted domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class TestEntityExactlyOneToZeroOrManyDeletedDomainEventHandler : TestEntityExactlyOneToZeroOrManyDeletedDomainEventHandlerBase
{
    public TestEntityExactlyOneToZeroOrManyDeletedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}