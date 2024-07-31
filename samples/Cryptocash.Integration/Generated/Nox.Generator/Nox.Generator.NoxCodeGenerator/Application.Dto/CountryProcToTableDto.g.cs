// Generated

#nullable enable

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using Nox.Application.Dto;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;


namespace CryptocashIntegration.Application.Dto;

public record CountryProcToTableKeyDto(System.Int32 keyCountryId);

/// <summary>
/// Update CountryProcToTable
/// Country and related data.
/// </summary>
public partial class CountryProcToTableDto : CountryProcToTableDtoBase
{

}

/// <summary>
/// Country and related data.
/// </summary>
public abstract class CountryProcToTableDtoBase : EntityDtoBase
{
    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.Name is not null)
            CollectValidationExceptions("Name", () => CountryProcToTableMetadata.CreateName(this.Name.NonNullValue<System.String>()), result);
        else
            result.Add("Name", new [] { "Name is Required." });
    
        CollectValidationExceptions("Population", () => CountryProcToTableMetadata.CreatePopulation(this.Population), result);
    

        return result;
    }
    #endregion

    /// <summary>
    /// Country unique identifier
    /// </summary>    
    public System.Int32 CountryId { get; set; } = default!;

    /// <summary>
    /// Country's name     
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.String Name { get; set; } = default!;

    /// <summary>
    /// Country's population     
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.Int32 Population { get; set; } = default!;

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}