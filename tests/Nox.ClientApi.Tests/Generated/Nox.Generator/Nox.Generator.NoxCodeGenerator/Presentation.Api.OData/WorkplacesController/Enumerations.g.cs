// Generated
#nullable enable
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
    public virtual async Task<ActionResult<IQueryable<DtoNameSpace.WorkplaceOwnershipDto>>> GetOwnershipsNonConventional()
    {            
        var result = await _mediator.Send(new ApplicationQueriesNameSpace.GetWorkplacesOwnershipsQuery(_cultureCode));                        
        return Ok(result);        
    }
    [EnableQuery]
    [HttpGet("/api/v1/Workplaces/Ownerships/Languages")]
    public virtual async Task<ActionResult<IQueryable<DtoNameSpace.WorkplaceOwnershipLocalizedDto>>> GetOwnershipsLanguagesNonConventional()
    {            
        var result = await _mediator.Send(new ApplicationQueriesNameSpace.GetWorkplacesOwnershipsTranslationsQuery());                        
        return Ok(result);        
    }

    [HttpDelete("/api/v1/Workplaces/WorkplaceOwnershipsLocalized/{cultureCode}")]
    public virtual async Task<ActionResult> DeleteOwnershipsLocalizedNonConventional([FromRoute] System.String cultureCode)
    {   
        Nox.Exceptions.BadRequestException.ThrowIfNotValid(Nox.Types.CultureCode.TryFrom(cultureCode, out var cultureCodeValue));

        var result = await _mediator.Send(new ApplicationCommandsNameSpace.DeleteWorkplacesOwnershipsTranslationsCommand(cultureCodeValue!));                        
        return NoContent();     
    }

    [HttpPut("/api/v1/Workplaces/WorkplaceOwnershipsLocalized")]
    public virtual async Task<ActionResult<IQueryable<DtoNameSpace.WorkplaceOwnershipLocalizedDto>>> PutOwnershipsLocalizedNonConventional([FromBody] EnumerationLocalizedListDto<DtoNameSpace.WorkplaceOwnershipLocalizedDto> workplaceOwnershipLocalizedDtos)
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
    [HttpGet("/api/v1/Workplaces/Types")]
    public virtual async Task<ActionResult<IQueryable<DtoNameSpace.WorkplaceTypeDto>>> GetTypesNonConventional()
    {            
        var result = await _mediator.Send(new ApplicationQueriesNameSpace.GetWorkplacesTypesQuery(_cultureCode));                        
        return Ok(result);        
    } 
}
