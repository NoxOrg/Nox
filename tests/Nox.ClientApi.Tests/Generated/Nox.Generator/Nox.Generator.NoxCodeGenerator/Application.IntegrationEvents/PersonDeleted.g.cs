// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Application;
using Nox.Infrastructure.Messaging;
using DomainNamespace = ClientApi.Domain;

using ClientApi.Application.Dto;

namespace ClientApi.Application.IntegrationEvents;

/// <summary>
/// PersonDeleted integration event.
/// </summary>
[IntegrationEventType("deleted", nameof(DomainNamespace.Person))]
internal record PersonDeleted(PersonDto Person) :  IIntegrationEvent;