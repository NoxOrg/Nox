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
public partial class TestEntityZeroOrManyToZeroOrOne : AuditableEntityBase
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
	/// TestEntityZeroOrManyToZeroOrOne Test entity relationship to TestEntityZeroOrOneToZeroOrMany ZeroOrMany TestEntityZeroOrOneToZeroOrManies
	/// </summary>
	public virtual List<TestEntityZeroOrOneToZeroOrMany> TestEntityZeroOrOneToZeroOrManies { get; set; } = new();

	public List<TestEntityZeroOrOneToZeroOrMany> TestEntityZeroOrOneToZeroOrMany => TestEntityZeroOrOneToZeroOrManies;
}