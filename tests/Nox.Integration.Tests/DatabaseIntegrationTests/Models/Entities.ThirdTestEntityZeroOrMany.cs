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
public partial class ThirdTestEntityZeroOrMany : AuditableEntityBase
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
	/// ThirdTestEntityZeroOrMany Test entity relationship to ThirdTestEntityOneOrMany ZeroOrMany ThirdTestEntityOneOrManies
	/// </summary>
	public virtual List<ThirdTestEntityOneOrMany> ThirdTestEntityOneOrManies { get; set; } = new();

	public List<ThirdTestEntityOneOrMany> ThirdTestEntityOneOrManyRelationship => ThirdTestEntityOneOrManies;
}