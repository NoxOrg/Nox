// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.DomainEventHandlers;

internal abstract class SecondTestEntityZeroOrOneCreatedDomainEventHandlerBase : INotificationHandler<SecondTestEntityZeroOrOneCreated>
{
    private readonly IOutboxRepository _outboxRepository;

    protected SecondTestEntityZeroOrOneCreatedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(SecondTestEntityZeroOrOneCreated domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class SecondTestEntityZeroOrOneCreatedDomainEventHandler : SecondTestEntityZeroOrOneCreatedDomainEventHandlerBase
{
    public SecondTestEntityZeroOrOneCreatedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}