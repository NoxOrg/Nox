// Generated

#nullable enable

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using Nox.Application.Dto;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;


using DomainNamespace = TestWebApp.Domain;

namespace TestWebApp.Application.Dto;

public record SecEntityOwnedRelZeroOrManyKeyDto(System.String keyId);

/// <summary>
/// Update SecEntityOwnedRelZeroOrMany
/// .
/// </summary>
public partial class SecEntityOwnedRelZeroOrManyDto : SecEntityOwnedRelZeroOrManyDtoBase
{

}

/// <summary>
/// .
/// </summary>
public abstract class SecEntityOwnedRelZeroOrManyDtoBase : EntityDtoBase, IEntityDto<DomainNamespace.SecEntityOwnedRelZeroOrMany>
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.TextTestField2 is not null)
            ExecuteActionAndCollectValidationExceptions("TextTestField2", () => DomainNamespace.SecEntityOwnedRelZeroOrManyMetadata.CreateTextTestField2(this.TextTestField2.NonNullValue<System.String>()), result);
        else
            result.Add("TextTestField2", new [] { "TextTestField2 is Required." });
    

        return result;
    }
    #endregion

    /// <summary>
    /// 
    /// </summary>    
    public System.String Id { get; set; } = default!;

    /// <summary>
    ///      
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.String TextTestField2 { get; set; } = default!;
}