// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using TestWebApp.Domain;
using TestWebApp.Application.Dto;

namespace TestWebApp.Application.DomainEventHandlers;

internal abstract class TestEntityZeroOrOneToExactlyOneCreatedDomainEventHandlerBase : INotificationHandler<TestEntityZeroOrOneToExactlyOneCreated>
{
    private readonly IOutboxRepository _outboxRepository;

    protected TestEntityZeroOrOneToExactlyOneCreatedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(TestEntityZeroOrOneToExactlyOneCreated domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class TestEntityZeroOrOneToExactlyOneCreatedDomainEventHandler : TestEntityZeroOrOneToExactlyOneCreatedDomainEventHandlerBase
{
    public TestEntityZeroOrOneToExactlyOneCreatedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}