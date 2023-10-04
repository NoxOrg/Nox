// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.DomainEventHandlers;

internal abstract class TestEntityZeroOrManyToExactlyOneUpdatedDomainEventHandlerBase : INotificationHandler<TestEntityZeroOrManyToExactlyOneUpdated>
{
    private readonly IOutboxRepository _outboxRepository;

    protected TestEntityZeroOrManyToExactlyOneUpdatedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(TestEntityZeroOrManyToExactlyOneUpdated domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class TestEntityZeroOrManyToExactlyOneUpdatedDomainEventHandler : TestEntityZeroOrManyToExactlyOneUpdatedDomainEventHandlerBase
{
    public TestEntityZeroOrManyToExactlyOneUpdatedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}