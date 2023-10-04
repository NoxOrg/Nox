// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using ClientApi.Domain;
using ClientApi.Application.Dto;

namespace ClientApi.Application.DomainEventHandlers;

internal abstract class CountryLocalNameDeletedDomainEventHandlerBase : INotificationHandler<CountryLocalNameDeleted>
{
    private readonly IOutboxRepository _outboxRepository;

    protected CountryLocalNameDeletedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(CountryLocalNameDeleted domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class CountryLocalNameDeletedDomainEventHandler : CountryLocalNameDeletedDomainEventHandlerBase
{
    public CountryLocalNameDeletedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}