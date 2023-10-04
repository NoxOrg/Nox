// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.DomainEventHandlers;

internal abstract class ThirdTestEntityExactlyOneUpdatedDomainEventHandlerBase : INotificationHandler<ThirdTestEntityExactlyOneUpdated>
{
    private readonly IOutboxRepository _outboxRepository;

    protected ThirdTestEntityExactlyOneUpdatedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(ThirdTestEntityExactlyOneUpdated domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class ThirdTestEntityExactlyOneUpdatedDomainEventHandler : ThirdTestEntityExactlyOneUpdatedDomainEventHandlerBase
{
    public ThirdTestEntityExactlyOneUpdatedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}