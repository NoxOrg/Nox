// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Infrastructure.Messaging;

using Cryptocash.Domain;
using Cryptocash.Application.Dto;

namespace Cryptocash.Application.DomainEventHandlers;

internal abstract class LandLordCreatedDomainEventHandlerBase : INotificationHandler<LandLordCreated>
{
    protected readonly IOutboxRepository _outboxRepository;

    protected LandLordCreatedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(LandLordCreated domainEvent, CancellationToken cancellationToken)
    {
        var dto = domainEvent.LandLord.ToDto();
        var @event = new Cryptocash.Application.IntegrationEvents.LandLordCreated(dto);
        await _outboxRepository.AddAsync(@event);
    }
}

internal partial class LandLordCreatedDomainEventHandler : LandLordCreatedDomainEventHandlerBase
{
    public LandLordCreatedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}