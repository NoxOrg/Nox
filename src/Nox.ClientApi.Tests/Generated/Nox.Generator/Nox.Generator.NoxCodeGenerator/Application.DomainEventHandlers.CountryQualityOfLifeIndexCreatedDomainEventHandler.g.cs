// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using ClientApi.Domain;
using ClientApi.Application.Dto;

namespace ClientApi.Application.DomainEventHandlers;

internal abstract class CountryQualityOfLifeIndexCreatedDomainEventHandlerBase : INotificationHandler<CountryQualityOfLifeIndexCreated>
{
    private readonly IOutboxRepository _outboxRepository;

    protected CountryQualityOfLifeIndexCreatedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(CountryQualityOfLifeIndexCreated domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class CountryQualityOfLifeIndexCreatedDomainEventHandler : CountryQualityOfLifeIndexCreatedDomainEventHandlerBase
{
    public CountryQualityOfLifeIndexCreatedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}