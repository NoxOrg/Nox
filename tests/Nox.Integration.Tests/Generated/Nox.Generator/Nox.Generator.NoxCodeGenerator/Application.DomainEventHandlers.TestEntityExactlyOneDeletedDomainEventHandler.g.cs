﻿// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.DomainEventHandlers;

internal abstract class TestEntityExactlyOneDeletedDomainEventHandlerBase : INotificationHandler<TestEntityExactlyOneDeleted>
{
    private readonly IOutboxRepository _outboxRepository;

    protected TestEntityExactlyOneDeletedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(TestEntityExactlyOneDeleted domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class TestEntityExactlyOneDeletedDomainEventHandler : TestEntityExactlyOneDeletedDomainEventHandlerBase
{
    public TestEntityExactlyOneDeletedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}