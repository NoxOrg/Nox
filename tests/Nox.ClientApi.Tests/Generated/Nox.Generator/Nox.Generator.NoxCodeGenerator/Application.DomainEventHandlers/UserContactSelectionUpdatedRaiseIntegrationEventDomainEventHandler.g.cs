// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Infrastructure.Messaging;

using ClientApi.Domain;
using ClientApi.Application.Dto;

namespace ClientApi.Application.DomainEventHandlers;

internal abstract class UserContactSelectionUpdatedRaiseIntegrationEventDomainEventHandlerBase : INotificationHandler<UserContactSelectionUpdated>
{
    protected readonly IOutboxRepository _outboxRepository;

    protected UserContactSelectionUpdatedRaiseIntegrationEventDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(UserContactSelectionUpdated domainEvent, CancellationToken cancellationToken)
    {
        var dto = domainEvent.UserContactSelection.ToDto();
        var @event = new ClientApi.Application.IntegrationEvents.UserContactSelectionUpdated(dto);
        await _outboxRepository.AddAsync(@event);
    }
}

internal partial class UserContactSelectionUpdatedRaiseIntegrationEventDomainEventHandler : UserContactSelectionUpdatedRaiseIntegrationEventDomainEventHandlerBase
{
    public UserContactSelectionUpdatedRaiseIntegrationEventDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}