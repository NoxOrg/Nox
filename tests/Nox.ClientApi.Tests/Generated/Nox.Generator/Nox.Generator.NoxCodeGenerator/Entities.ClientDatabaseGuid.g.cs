// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using System;
using System.Collections.Generic;

namespace ClientApi.Domain;

/// <summary>
/// Client DatabaseGuid Key.
/// </summary>
public partial class ClientDatabaseGuid : EntityBase
{
	/// <summary>
	/// The unique identifier (Required).
	/// </summary>
	public DatabaseGuid Id { get; set; } = null!;

	/// <summary>
	/// The Text (Required).
	/// </summary>
	public Nox.Types.Text Name { get; set; } = null!;

	/// <summary>
	/// The Formula (Optional).
	/// </summary>
	public string? Greeting 
	{ 
		get { return $"Hello, {Name.Value}!"; }
		private set { }
	}
}