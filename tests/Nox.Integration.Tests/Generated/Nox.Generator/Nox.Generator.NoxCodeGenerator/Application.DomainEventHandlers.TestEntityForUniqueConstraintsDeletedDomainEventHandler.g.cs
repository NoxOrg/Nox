// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.DomainEventHandlers;

internal abstract class TestEntityForUniqueConstraintsDeletedDomainEventHandlerBase : INotificationHandler<TestEntityForUniqueConstraintsDeleted>
{
    private readonly IOutboxRepository _outboxRepository;

    protected TestEntityForUniqueConstraintsDeletedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(TestEntityForUniqueConstraintsDeleted domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class TestEntityForUniqueConstraintsDeletedDomainEventHandler : TestEntityForUniqueConstraintsDeletedDomainEventHandlerBase
{
    public TestEntityForUniqueConstraintsDeletedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}