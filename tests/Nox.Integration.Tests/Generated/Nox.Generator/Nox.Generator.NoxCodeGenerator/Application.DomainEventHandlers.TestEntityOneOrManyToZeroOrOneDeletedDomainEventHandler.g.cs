// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.DomainEventHandlers;

internal abstract class TestEntityOneOrManyToZeroOrOneDeletedDomainEventHandlerBase : INotificationHandler<TestEntityOneOrManyToZeroOrOneDeleted>
{
    private readonly IOutboxRepository _outboxRepository;

    protected TestEntityOneOrManyToZeroOrOneDeletedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(TestEntityOneOrManyToZeroOrOneDeleted domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class TestEntityOneOrManyToZeroOrOneDeletedDomainEventHandler : TestEntityOneOrManyToZeroOrOneDeletedDomainEventHandlerBase
{
    public TestEntityOneOrManyToZeroOrOneDeletedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}