// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.DomainEventHandlers;

internal abstract class ThirdTestEntityZeroOrOneCreatedDomainEventHandlerBase : INotificationHandler<ThirdTestEntityZeroOrOneCreated>
{
    private readonly IOutboxRepository _outboxRepository;

    protected ThirdTestEntityZeroOrOneCreatedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(ThirdTestEntityZeroOrOneCreated domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class ThirdTestEntityZeroOrOneCreatedDomainEventHandler : ThirdTestEntityZeroOrOneCreatedDomainEventHandlerBase
{
    public ThirdTestEntityZeroOrOneCreatedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}