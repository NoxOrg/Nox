// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using MediatR;

using Nox.Application.Dto;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;


using DomainNamespace = Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

public record HolidayKeyDto(System.Int64 keyId);

public partial class HolidayDto : HolidayDtoBase
{

}

/// <summary>
/// Holiday related to country.
/// </summary>
public abstract class HolidayDtoBase : EntityDtoBase, IEntityDto<DomainNamespace.Holiday>
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.Name is not null)
            ExecuteActionAndCollectValidationExceptions("Name", () => DomainNamespace.HolidayMetadata.CreateName(this.Name.NonNullValue<System.String>()), result);
        else
            result.Add("Name", new [] { "Name is Required." });
    
        if (this.Type is not null)
            ExecuteActionAndCollectValidationExceptions("Type", () => DomainNamespace.HolidayMetadata.CreateType(this.Type.NonNullValue<System.String>()), result);
        else
            result.Add("Type", new [] { "Type is Required." });
    
        ExecuteActionAndCollectValidationExceptions("Date", () => DomainNamespace.HolidayMetadata.CreateDate(this.Date), result);
    

        return result;
    }
    #endregion

    /// <summary>
    /// Country's holiday unique identifier
    /// </summary>    
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// Country holiday name 
    /// <remarks>Required.</remarks>    
    /// </summary>
    public System.String Name { get; set; } = default!;

    /// <summary>
    /// Country holiday type 
    /// <remarks>Required.</remarks>    
    /// </summary>
    public System.String Type { get; set; } = default!;

    /// <summary>
    /// Country holiday date 
    /// <remarks>Required.</remarks>    
    /// </summary>
    public System.DateTime Date { get; set; } = default!;
}