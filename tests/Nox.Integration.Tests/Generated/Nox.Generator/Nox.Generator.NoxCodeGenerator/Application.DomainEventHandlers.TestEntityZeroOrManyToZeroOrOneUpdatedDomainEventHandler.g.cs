// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.DomainEventHandlers;

internal abstract class TestEntityZeroOrManyToZeroOrOneUpdatedDomainEventHandlerBase : INotificationHandler<TestEntityZeroOrManyToZeroOrOneUpdated>
{
    private readonly IOutboxRepository _outboxRepository;

    protected TestEntityZeroOrManyToZeroOrOneUpdatedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(TestEntityZeroOrManyToZeroOrOneUpdated domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class TestEntityZeroOrManyToZeroOrOneUpdatedDomainEventHandler : TestEntityZeroOrManyToZeroOrOneUpdatedDomainEventHandlerBase
{
    public TestEntityZeroOrManyToZeroOrOneUpdatedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}