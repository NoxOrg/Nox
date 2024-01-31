// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Application;
using Nox.Infrastructure.Messaging;
using DomainNamespace = ClientApi.Domain;

using ClientApi.Application.Dto;

namespace ClientApi.Application.IntegrationEvents;

/// <summary>
/// PersonUpdated integration event.
/// </summary>
[IntegrationEventType("updated", nameof(DomainNamespace.Person))]
internal record PersonUpdated(PersonDto Person) :  IIntegrationEvent;