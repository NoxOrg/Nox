// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.DomainEventHandlers;

internal abstract class ThirdTestEntityZeroOrManyCreatedDomainEventHandlerBase : INotificationHandler<ThirdTestEntityZeroOrManyCreated>
{
    private readonly IOutboxRepository _outboxRepository;

    protected ThirdTestEntityZeroOrManyCreatedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(ThirdTestEntityZeroOrManyCreated domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class ThirdTestEntityZeroOrManyCreatedDomainEventHandler : ThirdTestEntityZeroOrManyCreatedDomainEventHandlerBase
{
    public ThirdTestEntityZeroOrManyCreatedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}