// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.DomainEventHandlers;

internal abstract class TestEntityOneOrManyToZeroOrOneCreatedDomainEventHandlerBase : INotificationHandler<TestEntityOneOrManyToZeroOrOneCreated>
{
    private readonly IOutboxRepository _outboxRepository;

    protected TestEntityOneOrManyToZeroOrOneCreatedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(TestEntityOneOrManyToZeroOrOneCreated domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class TestEntityOneOrManyToZeroOrOneCreatedDomainEventHandler : TestEntityOneOrManyToZeroOrOneCreatedDomainEventHandlerBase
{
    public TestEntityOneOrManyToZeroOrOneCreatedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}