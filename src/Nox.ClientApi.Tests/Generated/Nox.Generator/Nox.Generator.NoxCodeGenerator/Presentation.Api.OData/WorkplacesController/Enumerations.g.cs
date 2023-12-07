// Generated

using System.Collections.Generic;
#nullable enable
using Microsoft.AspNetCore.Mvc;
using Nox.Application.Dto;

using DtoNameSpace = ClientApi.Application.Dto;
using ApplicationQueriesNameSpace = ClientApi.Application.Queries;
using ApplicationCommandsNameSpace = ClientApi.Application.Commands;

namespace ClientApi.Presentation.Api.OData;

public abstract partial class WorkplacesControllerBase
{
    [HttpGet("/api/v1/Workplaces/WorkplaceOwnerships")]
    public virtual async Task<ActionResult<IQueryable<DtoNameSpace.WorkplaceOwnershipDto>>> GetOwnershipsNonConventional()
    {            
        var result = await _mediator.Send(new ApplicationQueriesNameSpace.GetWorkplacesOwnershipsQuery(_cultureCode));                        
        return Ok(result);        
    }
    [HttpGet("/api/v1/Workplaces/WorkplaceOwnershipsLocalized")]
    public virtual async Task<ActionResult<IQueryable<DtoNameSpace.WorkplaceOwnershipLocalizedDto>>> GetOwnershipsLocalizedNonConventional()
    {            
        var result = await _mediator.Send(new ApplicationQueriesNameSpace.GetWorkplacesOwnershipsTranslationsQuery());                        
        return Ok(result);        
    }

    [HttpDelete("/api/v1/Workplaces/WorkplaceOwnershipsLocalized/{cultureCode}")]
    public virtual async Task<ActionResult> DeleteOwnershipsLocalizedNonConventional([FromRoute] System.String cultureCode)
    {   
        if(!Nox.Types.CultureCode.TryFrom(cultureCode, out var cultureCodeValue))
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        var result = await _mediator.Send(new ApplicationCommandsNameSpace.DeleteWorkplacesOwnershipsTranslationsCommand(cultureCodeValue!));                        
        return NoContent();     
    }

    [HttpPut("/api/v1/Workplaces/WorkplaceOwnershipsLocalized")]
    public virtual async Task<ActionResult<IQueryable<DtoNameSpace.WorkplaceOwnershipLocalizedDto>>> PutOwnershipsLocalizedNonConventional([FromBody] EnumerationLocalizedList<DtoNameSpace.WorkplaceOwnershipLocalizedDto> workplaceOwnershipLocalizedDtos)
    {   
        
        if (workplaceOwnershipLocalizedDtos is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var result = await _mediator.Send(new ApplicationCommandsNameSpace.UpsertWorkplacesOwnershipsTranslationsCommand(workplaceOwnershipLocalizedDtos.Items));                        
        return Ok(result);       
    }
    [HttpGet("/api/v1/Workplaces/WorkplaceTypes")]
    public virtual async Task<ActionResult<IQueryable<DtoNameSpace.WorkplaceTypeDto>>> GetTypesNonConventional()
    {            
        var result = await _mediator.Send(new ApplicationQueriesNameSpace.GetWorkplacesTypesQuery(_cultureCode));                        
        return Ok(result);        
    } 
}
