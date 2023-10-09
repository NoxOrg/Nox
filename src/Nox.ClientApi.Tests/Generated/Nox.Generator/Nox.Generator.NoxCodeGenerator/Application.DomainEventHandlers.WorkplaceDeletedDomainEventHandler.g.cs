// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using ClientApi.Domain;
using ClientApi.Application.Dto;

namespace ClientApi.Application.DomainEventHandlers;

internal abstract class WorkplaceDeletedDomainEventHandlerBase : INotificationHandler<WorkplaceDeleted>
{
    protected readonly IOutboxRepository _outboxRepository;

    protected WorkplaceDeletedDomainEventHandlerBase(IOutboxRepository outboxRepository)
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

internal partial class WorkplaceDeletedDomainEventHandler : WorkplaceDeletedDomainEventHandlerBase
{
    public WorkplaceDeletedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}