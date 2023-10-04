// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.DomainEventHandlers;

internal abstract class TestEntityExactlyOneToOneOrManyUpdatedDomainEventHandlerBase : INotificationHandler<TestEntityExactlyOneToOneOrManyUpdated>
{
    private readonly IOutboxRepository _outboxRepository;

    protected TestEntityExactlyOneToOneOrManyUpdatedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(TestEntityExactlyOneToOneOrManyUpdated domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class TestEntityExactlyOneToOneOrManyUpdatedDomainEventHandler : TestEntityExactlyOneToOneOrManyUpdatedDomainEventHandlerBase
{
    public TestEntityExactlyOneToOneOrManyUpdatedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}