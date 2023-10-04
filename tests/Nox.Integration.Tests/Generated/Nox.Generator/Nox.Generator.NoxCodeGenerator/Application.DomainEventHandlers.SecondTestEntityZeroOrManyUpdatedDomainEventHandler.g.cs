// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.DomainEventHandlers;

internal abstract class SecondTestEntityZeroOrManyUpdatedDomainEventHandlerBase : INotificationHandler<SecondTestEntityZeroOrManyUpdated>
{
    private readonly IOutboxRepository _outboxRepository;

    protected SecondTestEntityZeroOrManyUpdatedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(SecondTestEntityZeroOrManyUpdated domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class SecondTestEntityZeroOrManyUpdatedDomainEventHandler : SecondTestEntityZeroOrManyUpdatedDomainEventHandlerBase
{
    public SecondTestEntityZeroOrManyUpdatedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}