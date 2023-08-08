// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using System;
using System.Collections.Generic;

namespace SampleWebApp.Domain;

/// <summary>
/// The list of countries.
/// </summary>
public partial class Country : AuditableEntityBase
{

    /// <summary>
    ///  (Required).
    /// </summary>
    public Nuid Id {get; private set;} = null!;
    
    	public void EnsureId()
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
}