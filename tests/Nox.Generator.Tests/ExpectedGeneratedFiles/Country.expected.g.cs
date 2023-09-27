// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Solution;
using Nox.Types;

namespace SampleWebApp.Domain;
internal partial class Country:CountryBase
{

}
/// <summary>
/// Record for Country created event.
/// </summary>
public record CountryCreated(CountryBase Country) : IDomainEvent;
/// <summary>
/// Record for Country updated event.
/// </summary>
public record CountryUpdated(CountryBase Country) : IDomainEvent;
/// <summary>
/// Record for Country deleted event.
/// </summary>
public record CountryDeleted(CountryBase Country) : IDomainEvent;

/// <summary>
/// The list of countries.
/// </summary>
public abstract class CountryBase : AuditableEntityBase, IEntityConcurrent, IEntityHaveDomainEvents
{
    /// <summary>
    ///  (Required).
    /// </summary>
    public Nuid Id {get; set;} = null!;
    
    	public virtual void EnsureId()
    	{
    		if(Id is null)
    		{
    			Id = Nuid.From("Country." + string.Join(".", Name.Value.ToString(),FormalName.Value.ToString()));
    		}
    		else
    		{
    			var currentNuid = Nuid.From("Country." + string.Join(".", Name.Value.ToString(),FormalName.Value.ToString()));
    			if(Id != currentNuid)
    			{
    				throw new NoxNuidTypeException("Immutable nuid property Id value is different since it has been initialized");
    			}
    		}
    	}

    /// <summary>
    /// The country's common name (Required).
    /// </summary>
    public Nox.Types.Text Name { get; set; } = null!;

    /// <summary>
    /// The country's official name (Required).
    /// </summary>
    public Nox.Types.Text FormalName { get; set; } = null!;
	
    ///<inheritdoc/>
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents;
    private readonly List<IDomainEvent> _domainEvents = new();
    
    ///<inheritdoc/>
    public virtual void RaiseCreateEvent()
	{
		_domainEvents.Add(new CountryCreated(this));     
	}

    ///<inheritdoc/>
    public virtual void RaiseUpdateEvent()
    {
	    _domainEvents.Add(new CountryUpdated(this));
    }
    
    ///<inheritdoc/>
    public virtual void RaiseDeleteEvent()
	{
	    _domainEvents.Add(new CountryDeleted(this));
	}
	
	///<inheritdoc />
	public virtual void ClearDomainEvents()
	{
	    _domainEvents.Clear();
	}
	
	/// <summary>
	/// Entity tag used as concurrency token.
	/// </summary>
	public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}