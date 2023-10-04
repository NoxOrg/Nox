// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.DomainEventHandlers;

internal abstract class TestEntityZeroOrOneToZeroOrManyUpdatedDomainEventHandlerBase : INotificationHandler<TestEntityZeroOrOneToZeroOrManyUpdated>
{
    private readonly IOutboxRepository _outboxRepository;

    protected TestEntityZeroOrOneToZeroOrManyUpdatedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(TestEntityZeroOrOneToZeroOrManyUpdated domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class TestEntityZeroOrOneToZeroOrManyUpdatedDomainEventHandler : TestEntityZeroOrOneToZeroOrManyUpdatedDomainEventHandlerBase
{
    public TestEntityZeroOrOneToZeroOrManyUpdatedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}