// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace ClientApi.Domain;
public partial class StoreDescription:StoreDescriptionBase
{

}
/// <summary>
/// Record for StoreDescription created event.
/// </summary>
public record StoreDescriptionCreated(StoreDescription StoreDescription) : IDomainEvent;
/// <summary>
/// Record for StoreDescription updated event.
/// </summary>
public record StoreDescriptionUpdated(StoreDescription StoreDescription) : IDomainEvent;
/// <summary>
/// Record for StoreDescription deleted event.
/// </summary>
public record StoreDescriptionDeleted(StoreDescription StoreDescription) : IDomainEvent;

/// <summary>
/// Description for store.
/// </summary>
public abstract class StoreDescriptionBase : EntityBase, IEntityConcurrent
{
    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.Guid StoreId { get; set; } = null!;
    
        public virtual Store Store { get; set; } = null!;
    /// <summary>
    /// The unique identifier (Required).
    /// </summary>
    public Nox.Types.AutoNumber Id { get; set; } = null!;

    /// <summary>
    /// Store Decsription (Optional).
    /// </summary>
    public Nox.Types.Text? Description { get; set; } = null!;

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}