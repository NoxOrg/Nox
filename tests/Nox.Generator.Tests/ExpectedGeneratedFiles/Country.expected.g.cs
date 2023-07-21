﻿// Generated

#nullable enable

using Nox.Types;
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
    public Nuid Id {get; private set;}
    
    	public void PersistId()
    	{
    		if(key.Name == null)
    		{
    			key.Name = Nuid.From(Name.Value.ToString());
    		}
    		else
    		{
    			var currentNuid = Nuid.From(string.Join(".", Name.Value.ToString(),FormalName.Value.ToString()));
    			if(Id != currentNuid)
    			{
    				throw new ApplicationException("Immutable nuid property Id value is different since it has been initialized");
    			}
    		}
    	}

    /// <summary>
    /// The country's common name (Required).
    /// </summary>
    public Text Name { get; set; } = null!;

    /// <summary>
    /// The country's official name (Required).
    /// </summary>
    public Text FormalName { get; set; } = null!;
}