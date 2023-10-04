﻿// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.DomainEventHandlers;

internal abstract class TestEntityOneOrManyToZeroOrManyCreatedDomainEventHandlerBase : INotificationHandler<TestEntityOneOrManyToZeroOrManyCreated>
{
    private readonly IOutboxRepository _outboxRepository;

    protected TestEntityOneOrManyToZeroOrManyCreatedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(TestEntityOneOrManyToZeroOrManyCreated domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class TestEntityOneOrManyToZeroOrManyCreatedDomainEventHandler : TestEntityOneOrManyToZeroOrManyCreatedDomainEventHandlerBase
{
    public TestEntityOneOrManyToZeroOrManyCreatedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}