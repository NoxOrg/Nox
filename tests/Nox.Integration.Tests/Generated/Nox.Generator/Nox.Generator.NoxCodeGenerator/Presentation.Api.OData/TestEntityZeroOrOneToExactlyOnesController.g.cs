﻿// Generated

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

public abstract partial class TestEntityZeroOrOneToExactlyOnesControllerBase : ODataController
{
    
    #region Relationships
    
    public async Task<ActionResult> CreateRefToTestEntityExactlyOneToZeroOrOne([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefTestEntityZeroOrOneToExactlyOneToTestEntityExactlyOneToZeroOrOneCommand(new TestEntityZeroOrOneToExactlyOneKeyDto(key), new TestEntityExactlyOneToZeroOrOneKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> GetRefToTestEntityExactlyOneToZeroOrOne([FromRoute] System.String key)
    {
        var related = (await _mediator.Send(new GetTestEntityZeroOrOneToExactlyOneByIdQuery(key))).Select(x => x.TestEntityExactlyOneToZeroOrOne).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        var references = new System.Uri($"TestEntityExactlyOneToZeroOrOnes/{related.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    public async Task<ActionResult> DeleteRefToTestEntityExactlyOneToZeroOrOne([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefTestEntityZeroOrOneToExactlyOneToTestEntityExactlyOneToZeroOrOneCommand(new TestEntityZeroOrOneToExactlyOneKeyDto(key), new TestEntityExactlyOneToZeroOrOneKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> DeleteRefToTestEntityExactlyOneToZeroOrOne([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefTestEntityZeroOrOneToExactlyOneToTestEntityExactlyOneToZeroOrOneCommand(new TestEntityZeroOrOneToExactlyOneKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    #endregion
    
}