// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.DomainEventHandlers;

internal abstract class TestEntityForUniqueConstraintsUpdatedDomainEventHandlerBase : INotificationHandler<TestEntityForUniqueConstraintsUpdated>
{
    private readonly IOutboxRepository _outboxRepository;

    protected TestEntityForUniqueConstraintsUpdatedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(TestEntityForUniqueConstraintsUpdated domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class TestEntityForUniqueConstraintsUpdatedDomainEventHandler : TestEntityForUniqueConstraintsUpdatedDomainEventHandlerBase
{
    public TestEntityForUniqueConstraintsUpdatedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}