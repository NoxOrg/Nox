// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace ClientApi.Domain;

/// <summary>
/// Stores.
/// </summary>
public partial class Store : AuditableEntityBase, IEntityConcurrent
{
    /// <summary>
    /// NuidField Type (Required).
    /// </summary>
    public Nuid Id {get; set;} = null!;
    
    	public void EnsureId()
    	{
    		if(Id is null)
    		{
    			Id = Nuid.From("Store." + string.Join(".", Name.Value.ToString()));
    		}
    		else
    		{
    			var currentNuid = Nuid.From("Store." + string.Join(".", Name.Value.ToString()));
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
    /// Store Owner of the Store ZeroOrOne StoreOwners
    /// </summary>
    public virtual StoreOwner? Ownership { get; set; } = null!;

    /// <summary>
    /// Foreign key for relationship ZeroOrOne to entity StoreOwner
    /// </summary>
    public Nox.Types.Text? OwnershipId { get; set; } = null!;

    /// <summary>
    /// Store Verified emails ZeroOrOne EmailAddresses
    /// </summary>
     public virtual EmailAddress? EmailAddress { get; set; } = null!;

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}