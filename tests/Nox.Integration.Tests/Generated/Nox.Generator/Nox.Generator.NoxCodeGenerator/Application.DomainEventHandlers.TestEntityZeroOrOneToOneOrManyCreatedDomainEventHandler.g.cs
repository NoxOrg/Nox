// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.DomainEventHandlers;

internal abstract class TestEntityZeroOrOneToOneOrManyCreatedDomainEventHandlerBase : INotificationHandler<TestEntityZeroOrOneToOneOrManyCreated>
{
    private readonly IOutboxRepository _outboxRepository;

    protected TestEntityZeroOrOneToOneOrManyCreatedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(TestEntityZeroOrOneToOneOrManyCreated domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class TestEntityZeroOrOneToOneOrManyCreatedDomainEventHandler : TestEntityZeroOrOneToOneOrManyCreatedDomainEventHandlerBase
{
    public TestEntityZeroOrOneToOneOrManyCreatedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}