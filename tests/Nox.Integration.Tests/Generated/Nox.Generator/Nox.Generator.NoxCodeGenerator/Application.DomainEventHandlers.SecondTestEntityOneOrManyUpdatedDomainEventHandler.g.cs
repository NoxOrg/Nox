// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.DomainEventHandlers;

internal abstract class SecondTestEntityOneOrManyUpdatedDomainEventHandlerBase : INotificationHandler<SecondTestEntityOneOrManyUpdated>
{
    private readonly IOutboxRepository _outboxRepository;

    protected SecondTestEntityOneOrManyUpdatedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(SecondTestEntityOneOrManyUpdated domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class SecondTestEntityOneOrManyUpdatedDomainEventHandler : SecondTestEntityOneOrManyUpdatedDomainEventHandlerBase
{
    public SecondTestEntityOneOrManyUpdatedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}