// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.DomainEventHandlers;

internal abstract class TestEntityZeroOrOneUpdatedDomainEventHandlerBase : INotificationHandler<TestEntityZeroOrOneUpdated>
{
    private readonly IOutboxRepository _outboxRepository;

    protected TestEntityZeroOrOneUpdatedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(TestEntityZeroOrOneUpdated domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class TestEntityZeroOrOneUpdatedDomainEventHandler : TestEntityZeroOrOneUpdatedDomainEventHandlerBase
{
    public TestEntityZeroOrOneUpdatedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}