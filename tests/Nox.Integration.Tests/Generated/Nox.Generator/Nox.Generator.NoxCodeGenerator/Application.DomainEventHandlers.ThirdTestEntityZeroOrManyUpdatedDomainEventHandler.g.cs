// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.DomainEventHandlers;

internal abstract class ThirdTestEntityZeroOrManyUpdatedDomainEventHandlerBase : INotificationHandler<ThirdTestEntityZeroOrManyUpdated>
{
    private readonly IOutboxRepository _outboxRepository;

    protected ThirdTestEntityZeroOrManyUpdatedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(ThirdTestEntityZeroOrManyUpdated domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class ThirdTestEntityZeroOrManyUpdatedDomainEventHandler : ThirdTestEntityZeroOrManyUpdatedDomainEventHandlerBase
{
    public ThirdTestEntityZeroOrManyUpdatedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}