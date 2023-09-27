// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace ClientApi.Domain;
internal partial class CountryQualityOfLifeIndex:CountryQualityOfLifeIndexBase
{

}
/// <summary>
/// Record for CountryQualityOfLifeIndex created event.
/// </summary>
internal record CountryQualityOfLifeIndexCreated(CountryQualityOfLifeIndex CountryQualityOfLifeIndex) : IDomainEvent;
/// <summary>
/// Record for CountryQualityOfLifeIndex updated event.
/// </summary>
internal record CountryQualityOfLifeIndexUpdated(CountryQualityOfLifeIndex CountryQualityOfLifeIndex) : IDomainEvent;
/// <summary>
/// Record for CountryQualityOfLifeIndex deleted event.
/// </summary>
internal record CountryQualityOfLifeIndexDeleted(CountryQualityOfLifeIndex CountryQualityOfLifeIndex) : IDomainEvent;

/// <summary>
/// Country Quality Of Life Index.
/// </summary>
internal abstract class CountryQualityOfLifeIndexBase : EntityBase, IEntityConcurrent
{
    /// <summary>
    ///  (Required).
    /// </summary>
    public Nox.Types.AutoNumber CountryId { get; set; } = null!;
    
        public virtual Country Country { get; set; } = null!;
    /// <summary>
    /// The unique identifier (Required).
    /// </summary>
    public Nox.Types.AutoNumber Id { get; set; } = null!;

    /// <summary>
    /// Rating Index (Required).
    /// </summary>
    public Nox.Types.Number IndexRating { get; set; } = null!;

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}