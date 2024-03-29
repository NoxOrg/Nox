﻿// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Infrastructure.Messaging;

using ClientApi.Domain;
using ClientApi.Application.Dto;

namespace ClientApi.Application.DomainEventHandlers;

internal abstract class CountryDeletedRaiseIntegrationEventDomainEventHandlerBase : INotificationHandler<CountryDeleted>
{
    protected readonly IOutboxRepository _outboxRepository;

    protected CountryDeletedRaiseIntegrationEventDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(CountryDeleted domainEvent, CancellationToken cancellationToken)
    {
        var dto = domainEvent.Country.ToDto();
        var @event = new ClientApi.Application.IntegrationEvents.CountryDeleted(dto);
        await _outboxRepository.AddAsync(@event);
    }
}

internal partial class CountryDeletedRaiseIntegrationEventDomainEventHandler : CountryDeletedRaiseIntegrationEventDomainEventHandlerBase
{
    public CountryDeletedRaiseIntegrationEventDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}