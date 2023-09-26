// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace ClientApi.Domain;

public partial class Workplace : WorkplaceBase
{

}
/// <summary>
/// Record for Workplace created event.
/// </summary>
public record WorkplaceCreated(Workplace Workplace) : IDomainEvent;
/// <summary>
/// Record for Workplace updated event.
/// </summary>
public record WorkplaceUpdated(Workplace Workplace) : IDomainEvent;
/// <summary>
/// Record for Workplace deleted event.
/// </summary>
public record WorkplaceDeleted(Workplace Workplace) : IDomainEvent;

/// <summary>
/// Workplace.
/// </summary>
public abstract class WorkplaceBase : EntityBase, IEntityConcurrent
{
    /// <summary>
    /// Workplace unique identifier (Required).
    /// </summary>
    public Nuid Id {get; set;} = null!;
    
    	public virtual void EnsureId()
    	{
    		if(Id is null)
    		{
    			Id = Nuid.From("Workplace-" + string.Join("-", Name.Value.ToString()));
    		}
    		else
    		{
    			var currentNuid = Nuid.From("Workplace-" + string.Join("-", Name.Value.ToString()));
    			if(Id != currentNuid)
    			{
    				throw new NoxNuidTypeException("Immutable nuid property Id value is different since it has been initialized");
    			}
    		}
    	}

    /// <summary>
    /// Workplace Name (Required).
    /// </summary>
    public Nox.Types.Text Name { get; set; } = null!;

    /// <summary>
    /// Workplace Description (Optional).
    /// </summary>
    public Nox.Types.Text? Description { get; set; } = null!;

    /// <summary>
    /// The Formula (Optional).
    /// </summary>
    public string? Greeting
    { 
        get { return $"Hello, {Name.Value}!"; }
        private set { }
    }

    /// <summary>
    /// Workplace Workplace country ZeroOrOne Countries
    /// </summary>
    public virtual Country? BelongsToCountry { get; private set; } = null!;

    /// <summary>
    /// Foreign key for relationship ZeroOrOne to entity Country
    /// </summary>
    public Nox.Types.AutoNumber? BelongsToCountryId { get; set; } = null!;

    public virtual void CreateRefToBelongsToCountry(Country relatedCountry)
    {
        BelongsToCountry = relatedCountry;
    }

    public virtual void DeleteRefToBelongsToCountry(Country relatedCountry)
    {
        BelongsToCountry = null;
    }

    public virtual void DeleteAllRefToBelongsToCountry()
    {
        BelongsToCountryId = null;
    }

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}