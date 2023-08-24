// Generated

#nullable enable
using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using Nox.Types;
using Nox.Domain;
using IamApi.Application.DataTransferObjects;
using IamApi.Domain;

namespace IamApi.Application.Dto;

public record UserContactSelectionKeyDto(System.Guid keyId);

/// <summary>
/// User Contacts.
/// </summary>
public partial class UserContactSelectionDto
{

    /// <summary>
    /// Role identifier (Required).
    /// </summary>
    public System.Guid Id { get; set; } = default!;

    /// <summary>
    /// what is the contact id? (Required).
    /// </summary>
    public System.Guid ContactId { get; set; } = default!;

    /// <summary>
    /// account id (Required).
    /// </summary>
    public System.Guid AccountId { get; set; } = default!;

    /// <summary>
    /// selected date (Required).
    /// </summary>
    public System.DateTimeOffset SelectedDate { get; set; } = default!;
}