// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using System;
using System.Collections.Generic;

namespace SampleWebApp.Domain;

/// <summary>
/// Stores.
/// </summary>
public partial class Store : AuditableEntityBase
{

    /// <summary>
    /// Store Primary Key (Required).
    /// </summary>
    public Nuid Id {get; private set;} = null!;
    
    	public void EnsureId()
    	{
    		if(Id is null)
    		{
    			Id = Nuid.From("Store." + string.Join(".", Name.Value.ToString(),Address.Value.ToString()));
    		}
    		else
    		{
    			var currentNuid = Nuid.From("Store." + string.Join(".", Name.Value.ToString(),Address.Value.ToString()));
    			if(Id != currentNuid)
    			{
    				throw new NoxNuidTypeException("Immutable nuid property Id value is different since it has been initialized");
    			}
    		}
    	}

    /// <summary>
    /// Store Name (Required).
    /// </summary>
    public Nox.Types.Text Name { get; set; } = null!;

    /// <summary>
    /// Store address (Required).
    /// </summary>
    public Nox.Types.StreetAddress Address { get; set; } = null!;

    /// <summary>
    /// Store location coordinates (Required).
    /// </summary>
    public Nox.Types.LatLong LatLong { get; set; } = null!;

    /// <summary>
    /// Store phone number (Required).
    /// </summary>
    public Nox.Types.Text Phone { get; set; } = null!;

    /// <summary>
    /// Store Set of passwords for this store ExactlyOne StoreSecurityPasswords
    /// </summary>
    public virtual StoreSecurityPasswords StoreSecurityPasswords { get; set; } = null!;
}