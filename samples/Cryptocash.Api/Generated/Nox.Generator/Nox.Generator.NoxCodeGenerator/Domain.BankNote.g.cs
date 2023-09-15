// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Abstractions;
using Nox.Domain;
using Nox.Types;

namespace Cryptocash.Domain;
public partial class BankNote:BankNoteBase
{

}
/// <summary>
/// Record for BankNote created event.
/// </summary>
public record BankNoteCreated(BankNote BankNote) : IDomainEvent;
/// <summary>
/// Record for BankNote updated event.
/// </summary>
public record BankNoteUpdated(BankNote BankNote) : IDomainEvent;
/// <summary>
/// Record for BankNote deleted event.
/// </summary>
public record BankNoteDeleted(BankNote BankNote) : IDomainEvent;

/// <summary>
/// Currencies related frequent and rare bank notes.
/// </summary>
public abstract class BankNoteBase : EntityBase, IOwnedEntity
{
    /// <summary>
    /// Currency bank note unique identifier (Required).
    /// </summary>
    public AutoNumber Id { get; set; } = null!;

    /// <summary>
    /// Currency's cash bank note identifier (Required).
    /// </summary>
    public Nox.Types.Text CashNote { get; set; } = null!;

    /// <summary>
    /// Bank note value (Required).
    /// </summary>
    public Nox.Types.Money Value { get; set; } = null!;

}