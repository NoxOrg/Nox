// Generated#nullable enable
using System.Collections.Generic;
using Microsoft.AspNetCore.OData.Query;

using Microsoft.AspNetCore.Mvc;
using Nox.Application.Dto;

using DtoNameSpace = ClientApi.Application.Dto;
using ApplicationQueriesNameSpace = ClientApi.Application.Queries;
using ApplicationCommandsNameSpace = ClientApi.Application.Commands;

namespace ClientApi.Presentation.Api.OData;

public abstract partial class CountriesControllerBase
{
    [HttpGet("/api/v1/Countries/Continents")]
    public virtual async Task<ActionResult<IQueryable<DtoNameSpace.CountryContinentDto>>> GetContinentsNonConventional()
    {            
        var result = await _mediator.Send(new ApplicationQueriesNameSpace.GetCountriesContinentsQuery(_cultureCode));                        
        return Ok(result);        
    }
    [EnableQuery]
    [HttpGet("/api/v1/Countries/Continents/Languages")]
    public virtual async Task<ActionResult<IQueryable<DtoNameSpace.CountryContinentLocalizedDto>>> GetContinentsLanguagesNonConventional()
    {            
        var result = await _mediator.Send(new ApplicationQueriesNameSpace.GetCountriesContinentsTranslationsQuery());                        
        return Ok(result);        
    }

    [HttpDelete("/api/v1/Countries/Continents/{relatedKey}/Languages/{cultureCode}")]
    public virtual async Task<ActionResult> DeleteContinentsLocalizedNonConventional([FromRoute] System.Int32 relatedKey, [FromRoute] System.String cultureCode)
    {   
        Nox.Exceptions.BadRequestException.ThrowIfNotValid(Nox.Types.CultureCode.TryFrom(cultureCode, out var cultureCodeValue));

        var result = await _mediator.Send(new ApplicationCommandsNameSpace.DeleteCountriesContinentsTranslationsCommand(Nox.Types.Enumeration.FromDatabase(relatedKey), cultureCodeValue!));                        
        return NoContent();     
    }

    [HttpPut("/api/v1/Countries/Continents/{relatedKey}/Languages/{cultureCode}")]
    public virtual async Task<ActionResult<DtoNameSpace.CountryContinentLocalizedDto>> PutContinentsLocalizedNonConventional([FromRoute] System.Int32 relatedKey,[FromRoute] System.String cultureCode, [FromBody] DtoNameSpace.CountryContinentLocalizedUpsertDto countryContinentLocalizedUpsertDto)
    {   
        
        if (countryContinentLocalizedUpsertDto is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var upsertedKeyDto = await _mediator.Send(new ApplicationCommandsNameSpace.UpsertCountriesContinentsTranslationCommand(Nox.Types.Enumeration.FromDatabase(relatedKey), countryContinentLocalizedUpsertDto, Nox.Types.CultureCode.From(cultureCode)));                        
        var result = (await _mediator.Send(new ApplicationQueriesNameSpace.GetCountriesContinentsTranslationsQuery())).SingleOrDefault(x => x.Id == upsertedKeyDto.Id && x.CultureCode == upsertedKeyDto.cultureCode);
        return Ok(result);       
    } 
}
