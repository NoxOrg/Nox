﻿// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace ClientApi.Domain;

/// <summary>
/// Stores.
/// </summary>
public partial class Store : AuditableEntityBase, IConcurrent
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
    /// Store Store owner relationship ZeroOrOne StoreOwners
    /// </summary>
    public virtual StoreOwner? OwnerRel { get; set; } = null!;

    /// <summary>
    /// Foreign key for relationship ZeroOrOne to entity StoreOwner
    /// </summary>
    public Nox.Types.Text? OwnerRelId { get; set; } = null!;

    /// <summary>
    /// Store Verified emails ZeroOrOne EmailAddresses
    /// </summary>
     public virtual EmailAddress? EmailAddress { get; set; } = null!;

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public Nox.Types.Guid Etag { get; set; } = Nox.Types.Guid.NewGuid();
}