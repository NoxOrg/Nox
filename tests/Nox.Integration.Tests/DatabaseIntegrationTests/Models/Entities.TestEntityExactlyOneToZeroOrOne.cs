// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using System;
using System.Collections.Generic;

namespace TestWebApp.Domain;

/// <summary>
/// .
/// </summary>
public partial class TestEntityExactlyOneToZeroOrOne : AuditableEntityBase
{
	/// <summary>
	///  (Required).
	/// </summary>
	public Text Id { get; set; } = null!;

	/// <summary>
	///  (Required).
	/// </summary>
	public Nox.Types.Text TextTestField2 { get; set; } = null!;

	/// <summary>
	/// TestEntityExactlyOneToZeroOrOne Test entity relationship to TestEntityZeroOrOneToExactlyOne ExactlyOne TestEntityZeroOrOneToExactlyOnes
	/// </summary>
	public virtual TestEntityZeroOrOneToExactlyOne TestEntityZeroOrOneToExactlyOne { get; set; } = null!;

	/// <summary>
	/// Foreign key for relationship ExactlyOne to entity TestEntityZeroOrOneToExactlyOne
	/// </summary>
	public Nox.Types.Text TestEntityZeroOrOneToExactlyOneId { get; set; } = null!;
}