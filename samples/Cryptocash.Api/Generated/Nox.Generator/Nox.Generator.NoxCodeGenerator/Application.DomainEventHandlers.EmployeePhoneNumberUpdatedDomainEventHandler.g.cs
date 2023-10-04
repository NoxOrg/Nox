// Generated

#nullable enable

using MediatR;
using Nox.Application;
using Nox.Messaging;

using Cryptocash.Domain;
using Cryptocash.Application.Dto;

namespace Cryptocash.Application.DomainEventHandlers;

internal abstract class EmployeePhoneNumberUpdatedDomainEventHandlerBase : INotificationHandler<EmployeePhoneNumberUpdated>
{
    private readonly IOutboxRepository _outboxRepository;

    protected EmployeePhoneNumberUpdatedDomainEventHandlerBase(IOutboxRepository outboxRepository)
    {
        _outboxRepository = outboxRepository;
    }

    public virtual async Task Handle(EmployeePhoneNumberUpdated domainEvent, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    protected async Task RaiseIntegrationEventAsync<TEvent>(TEvent @event) where TEvent : IIntegrationEvent
        => await _outboxRepository.AddAsync(@event);
}

internal partial class EmployeePhoneNumberUpdatedDomainEventHandler : EmployeePhoneNumberUpdatedDomainEventHandlerBase
{
    public EmployeePhoneNumberUpdatedDomainEventHandler(IOutboxRepository outboxRepository)
        : base(outboxRepository)
    {
    }
}