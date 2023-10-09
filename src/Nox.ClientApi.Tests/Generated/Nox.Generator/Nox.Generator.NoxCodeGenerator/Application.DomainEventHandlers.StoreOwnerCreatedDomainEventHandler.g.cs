// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using ClientApi.Domain;
using ClientApi.Application.Dto;

namespace ClientApi.Application.DomainEventHandlers;

internal abstract class StoreOwnerCreatedDomainEventHandlerBase : INotificationHandler<StoreOwnerCreated>
{
    protected readonly IOutboxRepository _outboxRepository;

    protected StoreOwnerCreatedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(StoreOwnerCreated domainEvent, CancellationToken cancellationToken)
    {
        var dto = domainEvent.StoreOwner.ToDto();
        var @event = new ClientApi.Application.IntegrationEvents.StoreOwnerCreated(dto);
        await _outboxRepository.AddAsync(@event);
    }
}

internal partial class StoreOwnerCreatedDomainEventHandler : StoreOwnerCreatedDomainEventHandlerBase
{
    public StoreOwnerCreatedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}