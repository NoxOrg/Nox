﻿// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.DomainEventHandlers;

internal abstract class SecondTestEntityExactlyOneCreatedDomainEventHandlerBase : INotificationHandler<SecondTestEntityExactlyOneCreated>
{
    private readonly IOutboxRepository _outboxRepository;

    protected SecondTestEntityExactlyOneCreatedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(SecondTestEntityExactlyOneCreated domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class SecondTestEntityExactlyOneCreatedDomainEventHandler : SecondTestEntityExactlyOneCreatedDomainEventHandlerBase
{
    public SecondTestEntityExactlyOneCreatedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}