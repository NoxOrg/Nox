// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace TestWebApp.Domain;
public partial class TestEntityZeroOrOneToExactlyOne:TestEntityZeroOrOneToExactlyOneBase
{

}
/// <summary>
/// Entity created for testing database.
/// </summary>
public abstract class TestEntityZeroOrOneToExactlyOneBase : AuditableEntityBase, IEntityConcurrent
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
    /// TestEntityZeroOrOneToExactlyOne Test entity relationship to TestEntityExactlyOneToZeroOrOne ZeroOrOne TestEntityExactlyOneToZeroOrOnes
    /// </summary>
    public virtual TestEntityExactlyOneToZeroOrOne? TestEntityExactlyOneToZeroOrOne { get; set; } = null!;

    /// <summary>
    /// Entity tag used as concurrency token.
    /// </summary>
    public System.Guid Etag { get; set; } = System.Guid.NewGuid();
}