
// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations.Schema;

using MediatR;

using Nox.Application.Dto;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;
using System.Text.Json.Serialization;
using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

public record HolidayKeyDto(System.Int64 keyId);

public partial class HolidayDto : HolidayDtoBase
{

}

/// <summary>
/// Holiday related to country.
/// </summary>
public abstract class HolidayDtoBase : EntityDtoBase, IEntityDto<Holiday>
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.Name is not null)
            TryGetValidationExceptions("Name", () => Cryptocash.Domain.HolidayMetadata.CreateName(this.Name.NonNullValue<System.String>()), result);
        else
            result.Add("Name", new [] { "Name is Required." });
    
        if (this.Type is not null)
            TryGetValidationExceptions("Type", () => Cryptocash.Domain.HolidayMetadata.CreateType(this.Type.NonNullValue<System.String>()), result);
        else
            result.Add("Type", new [] { "Type is Required." });
    
        TryGetValidationExceptions("Date", () => Cryptocash.Domain.HolidayMetadata.CreateDate(this.Date), result);
    

        return result;
    }
    #endregion

    /// <summary>
    /// Country's holiday unique identifier (Required).
    /// </summary>
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// Country holiday name (Required).
    /// </summary>
    public System.String Name { get; set; } = default!;

    /// <summary>
    /// Country holiday type (Required).
    /// </summary>
    public System.String Type { get; set; } = default!;

    /// <summary>
    /// Country holiday date (Required).
    /// </summary>
    public System.DateTime Date { get; set; } = default!;
}