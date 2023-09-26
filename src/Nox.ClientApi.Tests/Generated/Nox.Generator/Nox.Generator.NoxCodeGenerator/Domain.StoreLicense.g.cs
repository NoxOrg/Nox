// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace ClientApi.Domain;

public partial class StoreLicense : StoreLicenseBase
{

}
/// <summary>
/// Record for StoreLicense created event.
/// </summary>
public record StoreLicenseCreated(StoreLicense StoreLicense) : IDomainEvent;
/// <summary>
/// Record for StoreLicense updated event.
/// </summary>
public record StoreLicenseUpdated(StoreLicense StoreLicense) : IDomainEvent;
/// <summary>
/// Record for StoreLicense deleted event.
/// </summary>
public record StoreLicenseDeleted(StoreLicense StoreLicense) : IDomainEvent;

/// <summary>
/// Store license info.
/// </summary>
public abstract class StoreLicenseBase : AuditableEntityBase, IEntityConcurrent
{
    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.AutoNumber Id { get; set; } = null!;

    /// <summary>
    /// License issuer (Required).
    /// </summary>
    public Nox.Types.Text Issuer { get; set; } = null!;

    /// <summary>
    /// StoreLicense Store that this license related to ExactlyOne Stores
    /// </summary>
    public virtual Store StoreWithLicense { get; private set; } = null!;

    /// <summary>
    /// Foreign key for relationship ExactlyOne to entity Store
    /// </summary>
    public Nox.Types.Guid StoreWithLicenseId { get; set; } = null!;

    public virtual void CreateRefToStoreWithLicense(Store relatedStore)
    {
        StoreWithLicense = relatedStore;
    }

    public virtual void DeleteRefToStoreWithLicense(Store relatedStore)
    {
        throw new Exception($"The relationship cannot be deleted.");
    }

    public virtual void DeleteAllRefToStoreWithLicense()
    {
        throw new Exception($"The relationship cannot be deleted.");
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}