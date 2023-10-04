// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using Cryptocash.Domain;
using Cryptocash.Application.Dto;

namespace Cryptocash.Application.DomainEventHandlers;

internal abstract class HolidayCreatedDomainEventHandlerBase : INotificationHandler<HolidayCreated>
{
    private readonly IOutboxRepository _outboxRepository;

    protected HolidayCreatedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(HolidayCreated domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class HolidayCreatedDomainEventHandler : HolidayCreatedDomainEventHandlerBase
{
    public HolidayCreatedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}