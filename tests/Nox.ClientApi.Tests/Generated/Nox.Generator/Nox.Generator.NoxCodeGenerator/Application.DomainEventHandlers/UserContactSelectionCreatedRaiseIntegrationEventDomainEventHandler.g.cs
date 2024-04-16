// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Infrastructure.Messaging;

using ClientApi.Domain;
using ClientApi.Application.Dto;

namespace ClientApi.Application.DomainEventHandlers;

internal abstract class UserContactSelectionCreatedRaiseIntegrationEventDomainEventHandlerBase : INotificationHandler<UserContactSelectionCreated>
{
    protected readonly IOutboxRepository _outboxRepository;

    protected UserContactSelectionCreatedRaiseIntegrationEventDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(UserContactSelectionCreated domainEvent, CancellationToken cancellationToken)
    {
        var dto = domainEvent.UserContactSelection.ToDto();
        var @event = new ClientApi.Application.IntegrationEvents.UserContactSelectionCreated(dto);
        await _outboxRepository.AddAsync(@event);
    }
}

internal partial class UserContactSelectionCreatedRaiseIntegrationEventDomainEventHandler : UserContactSelectionCreatedRaiseIntegrationEventDomainEventHandlerBase
{
    public UserContactSelectionCreatedRaiseIntegrationEventDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}