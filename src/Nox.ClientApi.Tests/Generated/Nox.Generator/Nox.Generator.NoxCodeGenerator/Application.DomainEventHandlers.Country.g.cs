// Generated

#nullable enable

using System.Threading.Tasks;
using MediatR;
using Nox.Application;
using Nox.Messaging;

using ClientApi.Domain;
using ClientApi.Application.Dto;

namespace ClientApi.Application.DomainEventHandlers;

internal abstract class CountryDomainEventHandlerBase<TEvent> : INotificationHandler<TEvent>
    where TEvent : INotification
{
    private readonly IOutboxRepository _outboxRepository;

    protected CountryDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public abstract Task Handle(TEvent domainEvent, CancellationToken cancellationToken);

    protected async Task RaiseIntegrationEventAsync(IIntegrationEvent @event)
        => await _outboxRepository.AddAsync(@event);
}

internal partial class CountryCreatedDomainEventHandler : CountryDomainEventHandlerBase<CountryCreated>
{
    public CountryCreatedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }

    public override async Task Handle(CountryCreated domainEvent, CancellationToken cancellationToken)
    {      
await RaiseCountryCreatedIntegrationEventAsync(domainEvent.Country);
    }
    
    private static async Task RaiseCountryCreatedIntegrationEventAsync(Country entity)
    {
        var dto = entity.ToDto();
        var @event = new IntegrationEvents.CountryCreated(dto);
        await RaiseIntegrationEventAsync(@event);
    }}
}