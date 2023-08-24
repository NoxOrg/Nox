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
public partial class TestEntityOneOrManyToExactlyOne : AuditableEntityBase
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
	/// TestEntityOneOrManyToExactlyOne Test entity relationship to TestEntityExactlyOneToOneOrMany OneOrMany TestEntityExactlyOneToOneOrManies
	/// </summary>
	public virtual List<TestEntityExactlyOneToOneOrMany> TestEntityExactlyOneToOneOrManies { get; set; } = new();

	public List<TestEntityExactlyOneToOneOrMany> TestEntityExactlyOneToOneOrMany => TestEntityExactlyOneToOneOrManies;
}