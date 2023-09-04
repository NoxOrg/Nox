// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace SampleWebApp.Domain;

/// <summary>
/// The list of currencies.
/// </summary>
public partial class Currency : AuditableEntityBase
{
    /// <summary>
    /// The currency's primary key / identifier (Required).
    /// </summary>
    public Nuid Id {get; set;} = null!;
    
    	public void EnsureId()
    	{
    		if(Id is null)
    		{
    			Id = Nuid.From("Currency." + string.Join(".", Name.Value.ToString()));
    		}
    		else
    		{
    			var currentNuid = Nuid.From("Currency." + string.Join(".", Name.Value.ToString()));
    			if(Id != currentNuid)
    			{
    				throw new NoxNuidTypeException("Immutable nuid property Id value is different since it has been initialized");
    			}
    		}
    	}

    /// <summary>
    /// The currency's name (Required).
    /// </summary>
    public Nox.Types.Text Name { get; set; } = null!;

    /// <summary>
    /// Currency is legal tender for ZeroOrMany Countries
    /// </summary>
    public virtual List<Country> CurrencyIsLegalTenderForCountry { get; set; } = new();
}