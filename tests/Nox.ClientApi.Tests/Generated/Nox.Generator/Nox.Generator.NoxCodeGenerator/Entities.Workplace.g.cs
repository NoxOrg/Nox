// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace ClientApi.Domain;

/// <summary>
/// Workplace.
/// </summary>
public partial class Workplace : EntityBase
{
	/// <summary>
	/// Workplace unique identifier (Required).
	/// </summary>
	public DatabaseGuid Id { get; set; } = null!;

	/// <summary>
	/// Workplace Name (Required).
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