// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Infrastructure.Messaging;

using ClientApi.Domain;
using ClientApi.Application.Dto;

namespace ClientApi.Application.DomainEventHandlers;

internal abstract class WorkplaceUpdatedRaiseIntegrationEventDomainEventHandlerBase : INotificationHandler<WorkplaceUpdated>
{
    protected readonly IOutboxRepository _outboxRepository;

    protected WorkplaceUpdatedRaiseIntegrationEventDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(WorkplaceUpdated domainEvent, CancellationToken cancellationToken)
    {
        var dto = domainEvent.Workplace.ToDto();
        var @event = new ClientApi.Application.IntegrationEvents.WorkplaceUpdated(dto);
        await _outboxRepository.AddAsync(@event);
    }
}

internal partial class WorkplaceUpdatedRaiseIntegrationEventDomainEventHandler : WorkplaceUpdatedRaiseIntegrationEventDomainEventHandlerBase
{
    public WorkplaceUpdatedRaiseIntegrationEventDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}