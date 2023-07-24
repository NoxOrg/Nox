// Generated

#nullable enable

using Nox.Types;
using System;
using System.Collections.Generic;

namespace TestWebApp.Domain;

/// <summary>
/// Entity created for testing nuid.
/// </summary>
public partial class TestEntityWithNuid : AuditableEntityBase
{

    /// <summary>
    ///  (Required).
    /// </summary>
    public Nuid Id {get; private set;} = null!;
    
    	public void EnsureId()
    	{
    		if(Id is null)
    		{
    			Id = Nuid.From("TestEntityWithNuid."+string.Join(".", Name.Value.ToString()));
    		}
    		else
    		{
    			var currentNuid = Nuid.From("TestEntityWithNuid."+string.Join(".", Name.Value.ToString()));
    			if(Id != currentNuid)
    			{
    				throw new ApplicationException("Immutable nuid property Id value is different since it has been initialized");
    			}
    		}
    	}

    /// <summary>
    ///  (Required).
    /// </summary>
    public Text Name { get; set; } = null!;
}