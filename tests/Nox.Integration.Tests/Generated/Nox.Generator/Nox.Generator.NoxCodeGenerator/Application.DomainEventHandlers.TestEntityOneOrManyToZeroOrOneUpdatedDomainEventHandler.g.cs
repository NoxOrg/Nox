﻿// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.DomainEventHandlers;

internal abstract class TestEntityOneOrManyToZeroOrOneUpdatedDomainEventHandlerBase : INotificationHandler<TestEntityOneOrManyToZeroOrOneUpdated>
{
    private readonly IOutboxRepository _outboxRepository;

    protected TestEntityOneOrManyToZeroOrOneUpdatedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(TestEntityOneOrManyToZeroOrOneUpdated domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class TestEntityOneOrManyToZeroOrOneUpdatedDomainEventHandler : TestEntityOneOrManyToZeroOrOneUpdatedDomainEventHandlerBase
{
    public TestEntityOneOrManyToZeroOrOneUpdatedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}