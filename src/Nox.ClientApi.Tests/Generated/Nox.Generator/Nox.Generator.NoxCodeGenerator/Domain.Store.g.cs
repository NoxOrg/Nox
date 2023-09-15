// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace ClientApi.Domain;
public partial class Store:StoreBase
{

}
/// <summary>
/// Record for Store created event.
/// </summary>
public record StoreCreated(Store Store) : IDomainEvent;
/// <summary>
/// Record for Store updated event.
/// </summary>
public record StoreUpdated(Store Store) : IDomainEvent;
/// <summary>
/// Record for Store deleted event.
/// </summary>
public record StoreDeleted(Store Store) : IDomainEvent;

/// <summary>
/// Stores.
/// </summary>
public abstract class StoreBase : AuditableEntityBase, IEntityConcurrent
{
    /// <summary>
    ///  (Required).
    /// </summary>
    public DatabaseGuid Id { get; set; } = null!;

    /// <summary>
    /// Store Name (Required).
    /// </summary>
    public Nox.Types.Text Name { get; set; } = null!;

    /// <summary>
    /// Street Address (Required).
    /// </summary>
    public Nox.Types.StreetAddress Address { get; set; } = null!;

    /// <summary>
    /// Location (Required).
    /// </summary>
    public Nox.Types.LatLong Location { get; set; } = null!;

    /// <summary>
    /// Store Owner of the Store ZeroOrOne StoreOwners
    /// </summary>
    public virtual StoreOwner? Ownership { get; set; } = null!;

    /// <summary>
    /// Foreign key for relationship ZeroOrOne to entity StoreOwner
    /// </summary>
    public Nox.Types.Text? OwnershipId { get; set; } = null!;

    public virtual void CreateRefToOwnership(StoreOwner relatedStoreOwner)
    {
        Ownership = relatedStoreOwner;
    }

    /// <summary>
    /// Store Verified emails ZeroOrOne EmailAddresses
    /// </summary>
     public virtual EmailAddress? VerifiedEmails { get; set; } = null!;

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}