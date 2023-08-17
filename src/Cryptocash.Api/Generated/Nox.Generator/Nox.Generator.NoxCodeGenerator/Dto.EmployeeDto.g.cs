// Generated

#nullable enable

using AutoMapper;
using MediatR;

using Microsoft.AspNetCore.Http;

using System.ComponentModel.DataAnnotations.Schema;

using Nox.Types;
using Nox.Domain;
using CryptocashApi.Application.DataTransferObjects;
using CryptocashApi.Domain;

namespace CryptocashApi.Application.Dto;

/// <summary>
/// Employee definition and related data.
/// </summary>
[AutoMap(typeof(EmployeeCreateDto))]
public partial class EmployeeDto 
{

    /// <summary>
    /// The employee unique identifier (Required).
    /// </summary>    
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// The employee's first name (Required).
    /// </summary>
    public System.String FirstName { get; set; } = default!;

    /// <summary>
    /// The employee's last name (Required).
    /// </summary>
    public System.String LastName { get; set; } = default!;

    /// <summary>
    /// The employee's email (Required).
    /// </summary>
    public System.String Email { get; set; } = default!;

    /// <summary>
    /// The employee's address (Required).
    /// </summary>
    public StreetAddressDto Address { get; set; } = default!;

    /// <summary>
    /// The employee's first working day (Required).
    /// </summary>
    public System.DateTime FirstWorkingDay { get; set; } = default!;

    /// <summary>
    /// The employee's last working day (Optional).
    /// </summary>
    public System.DateTime? LastWorkingDay { get; set; } 
    public bool? Deleted { get; set; }
}