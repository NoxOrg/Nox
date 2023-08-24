// Generated

#nullable enable

using System;
using System.Collections.Generic;

using Nox.Types;
using Nox.Domain;

namespace IamApi.Domain;

/// <summary>
/// User Contacts.
/// </summary>
public partial class UserContactSelection:IOwnedEntity
{
    /// <summary>
    /// Role identifier (Required).
    /// </summary>
    public DatabaseGuid Id { get; set; } = null!;

    /// <summary>
    /// what is the contact id? (Required).
    /// </summary>
    public Nox.Types.Guid ContactId { get; set; } = null!;

    /// <summary>
    /// account id (Required).
    /// </summary>
    public Nox.Types.Guid AccountId { get; set; } = null!;

    /// <summary>
    /// selected date (Required).
    /// </summary>
    public Nox.Types.DateTime SelectedDate { get; set; } = null!;
}