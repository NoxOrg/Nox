// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.DomainEventHandlers;

internal abstract class TestEntityExactlyOneCreatedDomainEventHandlerBase : INotificationHandler<TestEntityExactlyOneCreated>
{
    private readonly IOutboxRepository _outboxRepository;

    protected TestEntityExactlyOneCreatedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(TestEntityExactlyOneCreated domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class TestEntityExactlyOneCreatedDomainEventHandler : TestEntityExactlyOneCreatedDomainEventHandlerBase
{
    public TestEntityExactlyOneCreatedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}