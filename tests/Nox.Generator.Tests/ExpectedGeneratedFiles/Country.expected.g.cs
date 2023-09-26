// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace SampleWebApp.Domain;

public partial class Country : CountryBase
{

}
/// <summary>
/// Record for Country created event.
/// </summary>
public record CountryCreated(Country Country) : IDomainEvent;
/// <summary>
/// Record for Country updated event.
/// </summary>
public record CountryUpdated(Country Country) : IDomainEvent;
/// <summary>
/// Record for Country deleted event.
/// </summary>
public record CountryDeleted(Country Country) : IDomainEvent;

/// <summary>
/// The list of countries.
/// </summary>
public abstract class CountryBase : AuditableEntityBase, IEntityConcurrent
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

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}