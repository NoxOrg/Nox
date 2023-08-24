// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using System;
using System.Collections.Generic;

namespace ClientApi.Domain;

/// <summary>
/// OwnedEntity.
/// </summary>
public partial class OwnedEntity
{
	/// <summary>
	/// The unique identifier (Required).
	/// </summary>
	public Text Id { get; set; } = null!;

	/// <summary>
	/// The Text (Required).
	/// </summary>
	public Nox.Types.Text Name { get; set; } = null!;
}