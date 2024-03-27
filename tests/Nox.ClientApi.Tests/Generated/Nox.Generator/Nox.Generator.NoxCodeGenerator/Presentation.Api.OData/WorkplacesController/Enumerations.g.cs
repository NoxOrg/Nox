// Generated#nullable enable
using System.Collections.Generic;
using Microsoft.AspNetCore.OData.Query;

using Microsoft.AspNetCore.Mvc;
using Nox.Application.Dto;

using DtoNameSpace = ClientApi.Application.Dto;
using ApplicationQueriesNameSpace = ClientApi.Application.Queries;
using ApplicationCommandsNameSpace = ClientApi.Application.Commands;

namespace ClientApi.Presentation.Api.OData;

public abstract partial class WorkplacesControllerBase
{
    [HttpGet("/api/v1/Workplaces/Ownerships")]
    public virtual async Task<ActionResult<IQueryable<DtoNameSpace.WorkplaceOwnershipDto>>> GetWorkplaceOwnershipsNonConventional()
    {            
        var result = await _mediator.Send(new ApplicationQueriesNameSpace.GetWorkplacesOwnershipsQuery(_cultureCode));                        
        return Ok(result);        
    }
    [EnableQuery]
    [HttpGet("/api/v1/Workplaces/Ownerships/Languages")]
    public virtual async Task<ActionResult<IQueryable<DtoNameSpace.WorkplaceOwnershipLocalizedDto>>> GetWorkplaceOwnershipsLanguagesNonConventional()
    {            
        var result = await _mediator.Send(new ApplicationQueriesNameSpace.GetWorkplacesOwnershipsTranslationsQuery());                        
        return Ok(result);        
    }

    [HttpPut("/api/v1/Workplaces/Ownerships/{relatedKey}/Languages/{cultureCode}")]
    public virtual async Task<ActionResult<DtoNameSpace.WorkplaceOwnershipLocalizedDto>> PutWorkplaceOwnershipsLocalizedNonConventional([FromRoute] System.Int32 relatedKey,[FromRoute] System.String cultureCode, [FromBody] DtoNameSpace.WorkplaceOwnershipLocalizedUpsertDto workplaceOwnershipLocalizedUpsertDto)
    {   
        if (workplaceOwnershipLocalizedUpsertDto is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var upsertedKeyDto = await _mediator.Send(new ApplicationCommandsNameSpace.UpsertWorkplacesOwnershipsTranslationCommand(Nox.Types.Enumeration.FromDatabase(relatedKey), workplaceOwnershipLocalizedUpsertDto, Nox.Types.CultureCode.From(cultureCode)));                        
        var result = (await _mediator.Send(new ApplicationQueriesNameSpace.GetWorkplacesOwnershipsTranslationsQuery())).SingleOrDefault(x => x.Id == upsertedKeyDto.Id && x.CultureCode == upsertedKeyDto.cultureCode);
        return Ok(result);       
    } 
    [HttpDelete("/api/v1/Workplaces/Ownerships/{relatedKey}/Languages/{cultureCode}")]
    public virtual async Task<ActionResult> DeleteWorkplaceOwnershipsLocalizedNonConventional([FromRoute] System.Int32 relatedKey, [FromRoute] System.String cultureCode)
    {   
        Nox.Exceptions.BadRequestException.ThrowIfNotValid(Nox.Types.CultureCode.TryFrom(cultureCode, out var cultureCodeValue));

        var result = await _mediator.Send(new ApplicationCommandsNameSpace.DeleteWorkplacesOwnershipsTranslationsCommand(Nox.Types.Enumeration.FromDatabase(relatedKey), cultureCodeValue!));                        
        return NoContent();     
    }
    [HttpGet("/api/v1/Workplaces/Types")]
    public virtual async Task<ActionResult<IQueryable<DtoNameSpace.WorkplaceTypeDto>>> GetWorkplaceTypesNonConventional()
    {            
        var result = await _mediator.Send(new ApplicationQueriesNameSpace.GetWorkplacesTypesQuery(_cultureCode));                        
        return Ok(result);        
    } 
}
