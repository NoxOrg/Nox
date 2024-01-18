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

public record CountryQueryToCustomTableKeyDto(System.Int32 keyId);

/// <summary>
/// Update CountryQueryToCustomTable
/// Country and related data.
/// </summary>
public partial class CountryQueryToCustomTableDto : CountryQueryToCustomTableDtoBase
{

}

/// <summary>
/// Country and related data.
/// </summary>
public abstract class CountryQueryToCustomTableDtoBase : EntityDtoBase
{
    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.Name is not null)
            CollectValidationExceptions("Name", () => CountryQueryToCustomTableMetadata.CreateName(this.Name.NonNullValue<System.String>()), result);
        else
            result.Add("Name", new [] { "Name is Required." });
    
        CollectValidationExceptions("Population", () => CountryQueryToCustomTableMetadata.CreatePopulation(this.Population), result);
    
        CollectValidationExceptions("CreateDate", () => CountryQueryToCustomTableMetadata.CreateCreateDate(this.CreateDate), result);
    
        if (this.EditDate is not null)
            CollectValidationExceptions("EditDate", () => CountryQueryToCustomTableMetadata.CreateEditDate(this.EditDate.NonNullValue<System.DateTimeOffset>()), result);

        return result;
    }
    #endregion

    /// <summary>
    /// Country unique identifier
    /// </summary>    
    public System.Int32 Id { get; set; } = default!;

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

    /// <summary>
    /// The date on which the country record was created     
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.DateTimeOffset CreateDate { get; set; } = default!;

    /// <summary>
    /// The date on which the country record was last updated     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.DateTimeOffset? EditDate { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}