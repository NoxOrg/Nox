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
using Nox.Exceptions;

namespace TestWebApp.Domain;

internal partial class TestEntityLocalization : TestEntityLocalizationBase, IEntityHaveDomainEvents
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
/// Record for TestEntityLocalization created event.
/// </summary>
internal record TestEntityLocalizationCreated(TestEntityLocalization TestEntityLocalization) :  IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityLocalization updated event.
/// </summary>
internal record TestEntityLocalizationUpdated(TestEntityLocalization TestEntityLocalization) : IDomainEvent, INotification;
/// <summary>
/// Record for TestEntityLocalization deleted event.
/// </summary>
internal record TestEntityLocalizationDeleted(TestEntityLocalization TestEntityLocalization) : IDomainEvent, INotification;

/// <summary>
/// Entity created for testing localization.
/// </summary>
internal abstract partial class TestEntityLocalizationBase : AuditableEntityBase, IEntityConcurrent
{
    /// <summary>
    ///     
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Text Id { get;  set; } = null!;

    /// <summary>
    ///     
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Text TextFieldToLocalize { get;  set; } = null!;

    /// <summary>
    ///     
    /// </summary>
    /// <remarks>Required.</remarks>   
    public Nox.Types.Number NumberField { get;  set; } = null!;
    /// <summary>
    /// Domain events raised by this entity.
    /// </summary>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => InternalDomainEvents;
    protected readonly List<IDomainEvent> InternalDomainEvents = new();

	protected virtual void InternalRaiseCreateEvent(TestEntityLocalization testEntityLocalization)
	{
		InternalDomainEvents.Add(new TestEntityLocalizationCreated(testEntityLocalization));
    }
	
	protected virtual void InternalRaiseUpdateEvent(TestEntityLocalization testEntityLocalization)
	{
		InternalDomainEvents.Add(new TestEntityLocalizationUpdated(testEntityLocalization));
    }
	
	protected virtual void InternalRaiseDeleteEvent(TestEntityLocalization testEntityLocalization)
	{
		InternalDomainEvents.Add(new TestEntityLocalizationDeleted(testEntityLocalization));
    }
    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public virtual void ClearDomainEvents()
    {
        InternalDomainEvents.Clear();
    }

        /// <summary>
        /// TestEntityLocalization localized entities.
        /// </summary>
        public virtual List<TestEntityLocalizationLocalized> LocalizedTestEntityLocalizations  { get; private set; } = new();
    
    
    	/// <summary>
    	/// Creates a new TestEntityLocalizationLocalized entity.
    	/// </summary>
        public virtual void CreateRefToLocalizedTestEntityLocalizations(TestEntityLocalizationLocalized relatedTestEntityLocalizationLocalized)
    	{
    		LocalizedTestEntityLocalizations.Add(relatedTestEntityLocalizationLocalized);
    	}
        
    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}