// Generated

#nullable enable

using System;
using System.Collections.Generic;

using MediatR;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;
using Nox.Extensions;

namespace ClientApi.Domain;

internal partial class Language : LanguageBase, IEntityHaveDomainEvents
{
    ///<inheritdoc/>
    public void RaiseCreateEvent()
    {
        InternalRaiseCreateEvent(this);
    }
    ///<inheritdoc/>
    public void RaiseDeleteEvent()
    {
        InternalRaiseDeleteEvent(this);
    }
    ///<inheritdoc/>
    public void RaiseUpdateEvent()
    {
        InternalRaiseUpdateEvent(this);
    }
}
/// <summary>
/// Record for Language created event.
/// </summary>
internal record LanguageCreated(Language Language) :  IDomainEvent, INotification;
/// <summary>
/// Record for Language updated event.
/// </summary>
internal record LanguageUpdated(Language Language) : IDomainEvent, INotification;
/// <summary>
/// Record for Language deleted event.
/// </summary>
internal record LanguageDeleted(Language Language) : IDomainEvent, INotification;

/// <summary>
/// Language.
/// </summary>
internal abstract partial class LanguageBase : EntityBase, IEntityConcurrent
{
    /// <summary>
    /// Language unique identifier    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.CountryCode2 Id { get; set; } = null!;

    /// <summary>
    /// Country's name    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Text Name { get; set; } = null!;

    /// <summary>
    /// Country's iso number id    
    /// </summary>
    /// <remarks>Optional.</remarks>   
    public Nox.Types.CountryNumber? CountryIsoNumeric { get; set; } = null!;

    /// <summary>
    /// Country's iso alpha3 id    
    /// </summary>
    /// <remarks>Optional.</remarks>   
    public Nox.Types.CountryCode3? CountryIsoAlpha3 { get; set; } = null!;

    /// <summary>
    /// Region of country    
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Text Region { get; set; } = null!;
    /// <summary>
    /// Domain events raised by this entity.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => InternalDomainEvents;
    protected readonly List<IDomainEvent> InternalDomainEvents = new();

	protected virtual void InternalRaiseCreateEvent(Language language)
	{
		InternalDomainEvents.Add(new LanguageCreated(language));
    }
	
	protected virtual void InternalRaiseUpdateEvent(Language language)
	{
		InternalDomainEvents.Add(new LanguageUpdated(language));
    }
	
	protected virtual void InternalRaiseDeleteEvent(Language language)
	{
		InternalDomainEvents.Add(new LanguageDeleted(language));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}