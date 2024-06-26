﻿// Generated

#nullable enable
using Nox.Ui.Blazor.Lib.Models.NoxTypes;
using Nox.Ui.Blazor.Lib.Contracts;
using System.Text.Json.Serialization;

namespace Cryptocash.Ui.Models;

/// <summary>
/// Customer definition and related data.
/// </summary>
public partial class CustomerModel : CustomerModelBase
{

}

/// <summary>
/// Customer definition and related data
/// </summary>
public abstract class CustomerModelBase: IEntityModel
{

    /// <summary>
    /// Customer's unique identifier
    /// </summary>
    public virtual System.Guid? Id { get; set; }

    /// <summary>
    /// Customer's first name     
    /// </summary>
    public virtual System.String? FirstName { get; set; }

    /// <summary>
    /// Customer's last name     
    /// </summary>
    public virtual System.String? LastName { get; set; }

    /// <summary>
    /// Customer's email address     
    /// </summary>
    public virtual System.String? EmailAddress { get; set; }

    /// <summary>
    /// Customer's street address     
    /// </summary>
    public virtual StreetAddressModel? Address { get; set; }

    /// <summary>
    /// Customer's mobile number     
    /// </summary>
    public virtual System.String? MobileNumber { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; set; }

}