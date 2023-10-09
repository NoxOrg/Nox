// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using ClientApi.Domain;
using ClientApi.Application.Dto;

namespace ClientApi.Application.DomainEventHandlers;

internal abstract class CountryCreatedDomainEventHandlerBase : INotificationHandler<CountryCreated>
{
    protected readonly IOutboxRepository _outboxRepository;

    protected CountryCreatedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(CountryCreated domainEvent, CancellationToken cancellationToken)
    {
        var dto = domainEvent.Country.ToDto();
        var @event = new ClientApi.Application.IntegrationEvents.CountryCreated(dto);
        await _outboxRepository.AddAsync(@event);
    }
}

internal partial class CountryCreatedDomainEventHandler : CountryCreatedDomainEventHandlerBase
{
    public CountryCreatedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}