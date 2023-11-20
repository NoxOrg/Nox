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

public abstract partial class ThirdTestEntityExactlyOnesControllerBase : ODataController
{
    
    #region Relationships
    
    public async Task<ActionResult> CreateRefToThirdTestEntityZeroOrOne([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefThirdTestEntityExactlyOneToThirdTestEntityZeroOrOneCommand(new ThirdTestEntityExactlyOneKeyDto(key), new ThirdTestEntityZeroOrOneKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToThirdTestEntityZeroOrOne([FromRoute] System.String key, [FromBody] ThirdTestEntityZeroOrOneCreateDto thirdTestEntityZeroOrOne)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        thirdTestEntityZeroOrOne.ThirdTestEntityExactlyOneId = key;
        var createdKey = await _mediator.Send(new CreateThirdTestEntityZeroOrOneCommand(thirdTestEntityZeroOrOne, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetThirdTestEntityZeroOrOneByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    public async Task<ActionResult> GetRefToThirdTestEntityZeroOrOne([FromRoute] System.String key)
    {
        var related = (await _mediator.Send(new GetThirdTestEntityExactlyOneByIdQuery(key))).Select(x => x.ThirdTestEntityZeroOrOne).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        var references = new System.Uri($"ThirdTestEntityZeroOrOnes/{related.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    [EnableQuery]
    public virtual async Task<SingleResult<ThirdTestEntityZeroOrOneDto>> GetThirdTestEntityZeroOrOne(System.String key)
    {
        var related = (await _mediator.Send(new GetThirdTestEntityExactlyOneByIdQuery(key))).Where(x => x.ThirdTestEntityZeroOrOne != null);
        if (!related.Any())
        {
            return SingleResult.Create<ThirdTestEntityZeroOrOneDto>(Enumerable.Empty<ThirdTestEntityZeroOrOneDto>().AsQueryable());
        }
        return SingleResult.Create(related.Select(x => x.ThirdTestEntityZeroOrOne!));
    }
    
    public virtual async Task<ActionResult<ThirdTestEntityZeroOrOneDto>> PutToThirdTestEntityZeroOrOne(System.String key, [FromBody] ThirdTestEntityZeroOrOneUpdateDto thirdTestEntityZeroOrOne)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetThirdTestEntityExactlyOneByIdQuery(key))).Select(x => x.ThirdTestEntityZeroOrOne).SingleOrDefault();
        if (related == null)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateThirdTestEntityZeroOrOneCommand(related.Id, thirdTestEntityZeroOrOne, _cultureCode, etag));
        if (updated == null)
        {
            return NotFound();
        }
        
        return Ok();
    }
    
    #endregion
    
}
