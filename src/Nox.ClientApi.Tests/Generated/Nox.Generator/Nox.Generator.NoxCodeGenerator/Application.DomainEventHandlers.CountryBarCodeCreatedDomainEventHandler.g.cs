// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using ClientApi.Domain;
using ClientApi.Application.Dto;

namespace ClientApi.Application.DomainEventHandlers;

internal abstract class CountryBarCodeCreatedDomainEventHandlerBase : INotificationHandler<CountryBarCodeCreated>
{
    private readonly IOutboxRepository _outboxRepository;

    protected CountryBarCodeCreatedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(CountryBarCodeCreated domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class CountryBarCodeCreatedDomainEventHandler : CountryBarCodeCreatedDomainEventHandlerBase
{
    public CountryBarCodeCreatedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}