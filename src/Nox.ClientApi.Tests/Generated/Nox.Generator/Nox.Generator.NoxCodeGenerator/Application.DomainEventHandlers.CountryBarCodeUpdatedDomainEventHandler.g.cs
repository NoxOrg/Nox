// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using ClientApi.Domain;
using ClientApi.Application.Dto;

namespace ClientApi.Application.DomainEventHandlers;

internal abstract class CountryBarCodeUpdatedDomainEventHandlerBase : INotificationHandler<CountryBarCodeUpdated>
{
    private readonly IOutboxRepository _outboxRepository;

    protected CountryBarCodeUpdatedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(CountryBarCodeUpdated domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class CountryBarCodeUpdatedDomainEventHandler : CountryBarCodeUpdatedDomainEventHandlerBase
{
    public CountryBarCodeUpdatedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}