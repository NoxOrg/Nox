// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using ClientApi.Domain;
using ClientApi.Application.Dto;

namespace ClientApi.Application.DomainEventHandlers;

internal abstract class CountryQualityOfLifeIndexUpdatedDomainEventHandlerBase : INotificationHandler<CountryQualityOfLifeIndexUpdated>
{
    private readonly IOutboxRepository _outboxRepository;

    protected CountryQualityOfLifeIndexUpdatedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(CountryQualityOfLifeIndexUpdated domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class CountryQualityOfLifeIndexUpdatedDomainEventHandler : CountryQualityOfLifeIndexUpdatedDomainEventHandlerBase
{
    public CountryQualityOfLifeIndexUpdatedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}