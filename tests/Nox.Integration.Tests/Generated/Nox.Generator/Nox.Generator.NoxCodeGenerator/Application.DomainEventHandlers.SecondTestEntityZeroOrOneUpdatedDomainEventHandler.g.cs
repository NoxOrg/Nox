// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.DomainEventHandlers;

internal abstract class SecondTestEntityZeroOrOneUpdatedDomainEventHandlerBase : INotificationHandler<SecondTestEntityZeroOrOneUpdated>
{
    private readonly IOutboxRepository _outboxRepository;

    protected SecondTestEntityZeroOrOneUpdatedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(SecondTestEntityZeroOrOneUpdated domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class SecondTestEntityZeroOrOneUpdatedDomainEventHandler : SecondTestEntityZeroOrOneUpdatedDomainEventHandlerBase
{
    public SecondTestEntityZeroOrOneUpdatedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}