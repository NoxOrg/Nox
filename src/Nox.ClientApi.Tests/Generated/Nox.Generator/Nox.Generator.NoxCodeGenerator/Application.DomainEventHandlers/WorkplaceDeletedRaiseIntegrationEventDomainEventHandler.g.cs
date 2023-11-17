// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Infrastructure.Messaging;

using ClientApi.Domain;
using ClientApi.Application.Dto;

namespace ClientApi.Application.DomainEventHandlers;

internal abstract class WorkplaceDeletedRaiseIntegrationEventDomainEventHandlerBase : INotificationHandler<WorkplaceDeleted>
{
    protected readonly IOutboxRepository _outboxRepository;

    protected WorkplaceDeletedRaiseIntegrationEventDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(WorkplaceDeleted domainEvent, CancellationToken cancellationToken)
    {
        var dto = domainEvent.Workplace.ToDto();
        var @event = new ClientApi.Application.IntegrationEvents.WorkplaceDeleted(dto);
        await _outboxRepository.AddAsync(@event);
    }
}

internal partial class WorkplaceDeletedRaiseIntegrationEventDomainEventHandler : WorkplaceDeletedRaiseIntegrationEventDomainEventHandlerBase
{
    public WorkplaceDeletedRaiseIntegrationEventDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}