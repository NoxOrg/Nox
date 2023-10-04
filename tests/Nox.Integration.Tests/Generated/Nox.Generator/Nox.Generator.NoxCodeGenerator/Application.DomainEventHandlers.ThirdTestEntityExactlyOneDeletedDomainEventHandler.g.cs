// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.DomainEventHandlers;

internal abstract class ThirdTestEntityExactlyOneDeletedDomainEventHandlerBase : INotificationHandler<ThirdTestEntityExactlyOneDeleted>
{
    private readonly IOutboxRepository _outboxRepository;

    protected ThirdTestEntityExactlyOneDeletedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(ThirdTestEntityExactlyOneDeleted domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class ThirdTestEntityExactlyOneDeletedDomainEventHandler : ThirdTestEntityExactlyOneDeletedDomainEventHandlerBase
{
    public ThirdTestEntityExactlyOneDeletedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}