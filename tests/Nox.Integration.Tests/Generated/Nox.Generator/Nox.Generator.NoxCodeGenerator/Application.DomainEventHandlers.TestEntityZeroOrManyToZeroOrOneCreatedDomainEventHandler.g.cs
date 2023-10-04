﻿// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.DomainEventHandlers;

internal abstract class TestEntityZeroOrManyToZeroOrOneCreatedDomainEventHandlerBase : INotificationHandler<TestEntityZeroOrManyToZeroOrOneCreated>
{
    private readonly IOutboxRepository _outboxRepository;

    protected TestEntityZeroOrManyToZeroOrOneCreatedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(TestEntityZeroOrManyToZeroOrOneCreated domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class TestEntityZeroOrManyToZeroOrOneCreatedDomainEventHandler : TestEntityZeroOrManyToZeroOrOneCreatedDomainEventHandlerBase
{
    public TestEntityZeroOrManyToZeroOrOneCreatedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}