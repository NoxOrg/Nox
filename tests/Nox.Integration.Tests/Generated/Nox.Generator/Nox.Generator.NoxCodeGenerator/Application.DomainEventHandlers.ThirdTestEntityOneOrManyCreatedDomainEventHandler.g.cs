// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.DomainEventHandlers;

internal abstract class ThirdTestEntityOneOrManyCreatedDomainEventHandlerBase : INotificationHandler<ThirdTestEntityOneOrManyCreated>
{
    private readonly IOutboxRepository _outboxRepository;

    protected ThirdTestEntityOneOrManyCreatedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(ThirdTestEntityOneOrManyCreated domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class ThirdTestEntityOneOrManyCreatedDomainEventHandler : ThirdTestEntityOneOrManyCreatedDomainEventHandlerBase
{
    public ThirdTestEntityOneOrManyCreatedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}