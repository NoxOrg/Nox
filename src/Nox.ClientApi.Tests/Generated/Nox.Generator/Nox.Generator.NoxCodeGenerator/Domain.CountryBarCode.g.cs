// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace ClientApi.Domain;

public partial class CountryBarCode : CountryBarCodeBase
{

}
/// <summary>
/// Record for CountryBarCode created event.
/// </summary>
public record CountryBarCodeCreated(CountryBarCode CountryBarCode) : IDomainEvent;
/// <summary>
/// Record for CountryBarCode updated event.
/// </summary>
public record CountryBarCodeUpdated(CountryBarCode CountryBarCode) : IDomainEvent;
/// <summary>
/// Record for CountryBarCode deleted event.
/// </summary>
public record CountryBarCodeDeleted(CountryBarCode CountryBarCode) : IDomainEvent;

/// <summary>
/// Bar code for country.
/// </summary>
public abstract class CountryBarCodeBase : EntityBase, IOwnedEntity
{

    /// <summary>
    /// Bar code name (Required).
    /// </summary>
    public Nox.Types.Text BarCodeName { get; set; } = null!;

    /// <summary>
    /// Bar code number (Optional).
    /// </summary>
    public Nox.Types.Number? BarCodeNumber { get; set; } = null!;

}