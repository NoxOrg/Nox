// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using Cryptocash.Domain;
using Cryptocash.Application.Dto;

namespace Cryptocash.Application.DomainEventHandlers;

internal abstract class EmployeePhoneNumberDeletedDomainEventHandlerBase : INotificationHandler<EmployeePhoneNumberDeleted>
{
    private readonly IOutboxRepository _outboxRepository;

    protected EmployeePhoneNumberDeletedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(EmployeePhoneNumberDeleted domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class EmployeePhoneNumberDeletedDomainEventHandler : EmployeePhoneNumberDeletedDomainEventHandlerBase
{
    public EmployeePhoneNumberDeletedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}