﻿// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.DomainEventHandlers;

internal abstract class TestEntityZeroOrOneToZeroOrManyDeletedDomainEventHandlerBase : INotificationHandler<TestEntityZeroOrOneToZeroOrManyDeleted>
{
    private readonly IOutboxRepository _outboxRepository;

    protected TestEntityZeroOrOneToZeroOrManyDeletedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(TestEntityZeroOrOneToZeroOrManyDeleted domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class TestEntityZeroOrOneToZeroOrManyDeletedDomainEventHandler : TestEntityZeroOrOneToZeroOrManyDeletedDomainEventHandlerBase
{
    public TestEntityZeroOrOneToZeroOrManyDeletedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}