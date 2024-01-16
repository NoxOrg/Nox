using Nox.Domain;
using SampleWebApp.Domain;
using MediatR;


/// <summary>
/// Raised when the name of a country is changes
/// </summary>
internal record CountryNameUpdatedEvent(Country Country) : IDomainEvent, INotification;

/// <summary>
/// CountryAlphaCode3UpdatedEvent
/// </summary>
internal record CountryAlphaCode3UpdatedEvent(Country Country) : IDomainEvent, INotification;
