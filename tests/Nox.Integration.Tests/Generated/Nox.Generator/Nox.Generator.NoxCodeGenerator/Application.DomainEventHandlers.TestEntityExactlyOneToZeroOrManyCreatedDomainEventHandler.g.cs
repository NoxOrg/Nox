// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.DomainEventHandlers;

internal abstract class TestEntityExactlyOneToZeroOrManyCreatedDomainEventHandlerBase : INotificationHandler<TestEntityExactlyOneToZeroOrManyCreated>
{
    private readonly IOutboxRepository _outboxRepository;

    protected TestEntityExactlyOneToZeroOrManyCreatedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(TestEntityExactlyOneToZeroOrManyCreated domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class TestEntityExactlyOneToZeroOrManyCreatedDomainEventHandler : TestEntityExactlyOneToZeroOrManyCreatedDomainEventHandlerBase
{
    public TestEntityExactlyOneToZeroOrManyCreatedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}