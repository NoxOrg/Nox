// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.DomainEventHandlers;

internal abstract class SecondTestEntityZeroOrManyDeletedDomainEventHandlerBase : INotificationHandler<SecondTestEntityZeroOrManyDeleted>
{
    private readonly IOutboxRepository _outboxRepository;

    protected SecondTestEntityZeroOrManyDeletedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(SecondTestEntityZeroOrManyDeleted domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class SecondTestEntityZeroOrManyDeletedDomainEventHandler : SecondTestEntityZeroOrManyDeletedDomainEventHandlerBase
{
    public SecondTestEntityZeroOrManyDeletedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}