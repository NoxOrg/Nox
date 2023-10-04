// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using Cryptocash.Domain;
using Cryptocash.Application.Dto;

namespace Cryptocash.Application.DomainEventHandlers;

internal abstract class EmployeePhoneNumberCreatedDomainEventHandlerBase : INotificationHandler<EmployeePhoneNumberCreated>
{
    private readonly IOutboxRepository _outboxRepository;

    protected EmployeePhoneNumberCreatedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(EmployeePhoneNumberCreated domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class EmployeePhoneNumberCreatedDomainEventHandler : EmployeePhoneNumberCreatedDomainEventHandlerBase
{
    public EmployeePhoneNumberCreatedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}