// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace ClientApi.Domain;

/// <summary>
/// Record for StoreOwner created event.
/// </summary>
public record StoreOwnerCreated(StoreOwner StoreOwner) : IDomainEvent;

/// <summary>
/// Record for StoreOwner updated event.
/// </summary>
public record StoreOwnerUpdated(StoreOwner StoreOwner) : IDomainEvent;

/// <summary>
/// Record for StoreOwner deleted event.
/// </summary>
public record StoreOwnerDeleted(StoreOwner StoreOwner) : IDomainEvent;

/// <summary>
/// Store owners.
/// </summary>
public partial class StoreOwner : AuditableEntityBase, IEntityConcurrent
{
    /// <summary>
    ///  (Required).
    /// </summary>
    public Text Id { get; set; } = null!;

    /// <summary>
    /// Owner Name (Required).
    /// </summary>
    public Nox.Types.Text Name { get; set; } = null!;

    /// <summary>
    /// Temporary Owner Name (Required).
    /// </summary>
    public Nox.Types.Text TemporaryOwnerName { get; set; } = null!;

    /// <summary>
    /// Vat Number (Optional).
    /// </summary>
    public Nox.Types.VatNumber? VatNumber { get; set; } = null!;

    /// <summary>
    /// Street Address (Optional).
    /// </summary>
    public Nox.Types.StreetAddress? StreetAddress { get; set; } = null!;

    /// <summary>
    /// Owner Greeting (Optional).
    /// </summary>
    public Nox.Types.TranslatedText? LocalGreeting { get; set; } = null!;

    /// <summary>
    /// Notes (Optional).
    /// </summary>
    public Nox.Types.Text? Notes { get; set; } = null!;

    /// <summary>
    /// StoreOwner Set of stores that this owner owns ZeroOrMany Stores
    /// </summary>
    public virtual List<Store> Stores { get; set; } = new();

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}