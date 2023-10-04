// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.DomainEventHandlers;

internal abstract class TestEntityExactlyOneToZeroOrOneUpdatedDomainEventHandlerBase : INotificationHandler<TestEntityExactlyOneToZeroOrOneUpdated>
{
    private readonly IOutboxRepository _outboxRepository;

    protected TestEntityExactlyOneToZeroOrOneUpdatedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(TestEntityExactlyOneToZeroOrOneUpdated domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class TestEntityExactlyOneToZeroOrOneUpdatedDomainEventHandler : TestEntityExactlyOneToZeroOrOneUpdatedDomainEventHandlerBase
{
    public TestEntityExactlyOneToZeroOrOneUpdatedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}