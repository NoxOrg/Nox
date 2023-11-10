// Generated

#nullable enable

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System;
using System.Net.Http.Headers;
using Nox.Application;
using Nox.Extensions;
using TestWebApp.Application;
using TestWebApp.Application.Dto;
using TestWebApp.Application.Queries;
using TestWebApp.Application.Commands;
using TestWebApp.Domain;
using TestWebApp.Infrastructure.Persistence;
using Nox.Types;

namespace TestWebApp.Presentation.Api.OData;

public abstract partial class ThirdTestEntityOneOrManiesControllerBase : ODataController
{
    
    #region Relationships
    
    public async Task<ActionResult> CreateRefToThirdTestEntityZeroOrManies([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommand(new ThirdTestEntityOneOrManyKeyDto(key), new ThirdTestEntityZeroOrManyKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToThirdTestEntityZeroOrManies([FromRoute] System.String key, [FromBody] ThirdTestEntityZeroOrManyCreateDto thirdTestEntityZeroOrMany)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        thirdTestEntityZeroOrMany.ThirdTestEntityOneOrManiesId = new List<System.String> { key };
        var createdKey = await _mediator.Send(new CreateThirdTestEntityZeroOrManyCommand(thirdTestEntityZeroOrMany, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetThirdTestEntityZeroOrManyByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    public async Task<ActionResult> GetRefToThirdTestEntityZeroOrManies([FromRoute] System.String key)
    {
        var related = (await _mediator.Send(new GetThirdTestEntityOneOrManyByIdQuery(key))).Select(x => x.ThirdTestEntityZeroOrManies).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in related)
        {
            references.Add(new System.Uri($"ThirdTestEntityZeroOrManies/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    public async Task<ActionResult> DeleteRefToThirdTestEntityZeroOrManies([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommand(new ThirdTestEntityOneOrManyKeyDto(key), new ThirdTestEntityZeroOrManyKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> DeleteRefToThirdTestEntityZeroOrManies([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefThirdTestEntityOneOrManyToThirdTestEntityZeroOrManiesCommand(new ThirdTestEntityOneOrManyKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpPut("api/ThirdTestEntityOneOrManies/{key}/ThirdTestEntityZeroOrManies/{relatedKey}")]
    public virtual async Task<ActionResult<ThirdTestEntityZeroOrManyDto>> PutToThirdTestEntityZeroOrManiesNonConventional(System.String key, System.String relatedKey, [FromBody] ThirdTestEntityZeroOrManyUpdateDto thirdTestEntityZeroOrMany)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var related = (await _mediator.Send(new GetThirdTestEntityOneOrManyByIdQuery(key))).Select(x => x.ThirdTestEntityZeroOrManies).SingleOrDefault()?.SingleOrDefault(x => x.Id == relatedKey);
        if (related == null)
        {
            return NotFound();
        }
        
        var updated = await _mediator.Send(new UpdateThirdTestEntityZeroOrManyCommand(relatedKey, thirdTestEntityZeroOrMany, _cultureCode, etag));
        if (updated == null)
        {
            return NotFound();
        }
        
        return Ok();
    }
    
    #endregion
    
}
