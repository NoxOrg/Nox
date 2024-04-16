using Nox.Domain;
using ClientApi.Domain;
using MediatR;


/// <summary>
/// Barcode generated event
/// </summary>
internal record BarcodeGeneratedEvent(CountryBarCode CountryBarCode) : IDomainEvent, INotification;
