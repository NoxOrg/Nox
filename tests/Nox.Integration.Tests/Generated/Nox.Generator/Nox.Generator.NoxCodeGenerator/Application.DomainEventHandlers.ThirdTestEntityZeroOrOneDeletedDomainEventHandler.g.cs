// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.DomainEventHandlers;

internal abstract class ThirdTestEntityZeroOrOneDeletedDomainEventHandlerBase : INotificationHandler<ThirdTestEntityZeroOrOneDeleted>
{
    private readonly IOutboxRepository _outboxRepository;

    protected ThirdTestEntityZeroOrOneDeletedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(ThirdTestEntityZeroOrOneDeleted domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class ThirdTestEntityZeroOrOneDeletedDomainEventHandler : ThirdTestEntityZeroOrOneDeletedDomainEventHandlerBase
{
    public ThirdTestEntityZeroOrOneDeletedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}