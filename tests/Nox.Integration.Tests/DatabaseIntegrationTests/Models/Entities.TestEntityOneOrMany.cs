// Generated

#nullable enable

using Nox.Types;
using Nox.Domain;
using System;
using System.Collections.Generic;

namespace TestWebApp.Domain;

/// <summary>
/// Entity created for testing database.
/// </summary>
public partial class TestEntityOneOrMany : AuditableEntityBase
{
	/// <summary>
	///  (Required).
	/// </summary>
	public Text Id { get; set; } = null!;

	/// <summary>
	///  (Required).
	/// </summary>
	public Nox.Types.Text TextTestField { get; set; } = null!;

	/// <summary>
	/// TestEntityOneOrMany Test entity relationship to SecondTestEntityOneOrMany OneOrMany SecondTestEntityOneOrManies
	/// </summary>
	public virtual List<SecondTestEntityOneOrMany> SecondTestEntityOneOrManies { get; set; } = new();

	public List<SecondTestEntityOneOrMany> SecondTestEntityOneOrManyRelationship => SecondTestEntityOneOrManies;
}