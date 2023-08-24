// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using System;
using System.Collections.Generic;

namespace ClientApi.Domain;

/// <summary>
/// Client Nuid Key.
/// </summary>
public partial class ClientNuid : AuditableEntityBase
{
	/// <summary>
	/// NuidField Type (Required).
	/// </summary>
	public Nuid Id {get; private set;} = null!;
	
		public void EnsureId()
		{
			if(Id is null)
			{
				Id = Nuid.From("ClientNuid." + string.Join(".", Name.Value.ToString()));
			}
			else
			{
				var currentNuid = Nuid.From("ClientNuid." + string.Join(".", Name.Value.ToString()));
				if(Id != currentNuid)
				{
					throw new NoxNuidTypeException("Immutable nuid property Id value is different since it has been initialized");
				}
			}
		}

	/// <summary>
	/// The Name (Required).
	/// </summary>
	public Nox.Types.Text Name { get; set; } = null!;
}