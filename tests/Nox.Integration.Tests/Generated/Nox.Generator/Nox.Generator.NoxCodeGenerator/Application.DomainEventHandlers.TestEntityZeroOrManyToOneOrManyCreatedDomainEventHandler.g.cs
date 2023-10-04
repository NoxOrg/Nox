// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.DomainEventHandlers;

internal abstract class TestEntityZeroOrManyToOneOrManyCreatedDomainEventHandlerBase : INotificationHandler<TestEntityZeroOrManyToOneOrManyCreated>
{
    private readonly IOutboxRepository _outboxRepository;

    protected TestEntityZeroOrManyToOneOrManyCreatedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(TestEntityZeroOrManyToOneOrManyCreated domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class TestEntityZeroOrManyToOneOrManyCreatedDomainEventHandler : TestEntityZeroOrManyToOneOrManyCreatedDomainEventHandlerBase
{
    public TestEntityZeroOrManyToOneOrManyCreatedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}