// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Application;
using Nox.Infrastructure.Messaging;
using DomainNamespace = ClientApi.Domain;

using ClientApi.Application.Dto;

namespace ClientApi.Application.IntegrationEvents;

/// <summary>
/// PersonCreated integration event.
/// </summary>
[IntegrationEventType("created", nameof(DomainNamespace.Person))]
internal record PersonCreated(PersonDto Person) :  IIntegrationEvent;