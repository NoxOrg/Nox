﻿// Generated

#nullable enable

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using MediatR;
using Nox.Application;
using SampleWebApp.Application;
using SampleWebApp.Application.Dto;
using SampleWebApp.Application.Queries;
using SampleWebApp.Application.Commands;
using SampleWebApp.Application.DataTransferObjects;
using SampleWebApp.Domain;
using SampleWebApp.Infrastructure.Persistence;
using Nox.Types;

namespace SampleWebApp.Presentation.Api.OData;

public partial class CountryLocalNamesController : ODataController
{
    
    /// <summary>
    /// The OData DbContext for CRUD operations.
    /// </summary>
    protected readonly ODataDbContext _databaseContext;
    
    /// <summary>
    /// The Automapper.
    /// </summary>
    protected readonly IMapper _mapper;
    
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;
    
    public CountryLocalNamesController(
        ODataDbContext databaseContext,
        IMapper mapper,
        IMediator mediator
    )
    {
        _databaseContext = databaseContext;
        _mapper = mapper;
        _mediator = mediator;
    }
    
    [EnableQuery]
    public async  Task<ActionResult<IQueryable<OCountryLocalNames>>> Get()
    {
        var result = await _mediator.Send(new GetCountryLocalNamesQuery());
        return Ok(result);
    }
    
    public async Task<ActionResult<OCountryLocalNames>> Get([FromRoute] String key)
    {
        var item = await _mediator.Send(new GetCountryLocalNamesByIdQuery(key));
        
        if (item == null)
        {
            return NotFound();
        }
        
        return Ok(item);
    }
    
    public async Task<ActionResult> Post([FromBody]CountryLocalNamesCreateDto countrylocalnames)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var createdKey = await _mediator.Send(new CreateCountryLocalNamesCommand(countrylocalnames));
        
        return Created(createdKey);
    }
    
    public async Task<ActionResult> Put([FromRoute] string key, [FromBody] OCountryLocalNames updatedCountryLocalNames)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        if (key != updatedCountryLocalNames.Id)
        {
            return BadRequest();
        }
        
        _databaseContext.Entry(updatedCountryLocalNames).State = EntityState.Modified;
        
        try
        {
            await _databaseContext.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CountryLocalNamesExists(key))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        
        return Updated(updatedCountryLocalNames);
    }
    
    public async Task<ActionResult> Patch([FromRoute] string countrylocalnames, [FromBody] Delta<OCountryLocalNames> Id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var entity = await _databaseContext.CountryLocalNames.FindAsync(countrylocalnames);
        
        if (entity == null)
        {
            return NotFound();
        }
        
        Id.Patch(entity);
        
        try
        {
            await _databaseContext.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CountryLocalNamesExists(countrylocalnames))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        
        return Updated(entity);
    }
    
    private bool CountryLocalNamesExists(string countrylocalnames)
    {
        return _databaseContext.CountryLocalNames.Any(p => p.Id == countrylocalnames);
    }
    
    public async Task<ActionResult> Delete([FromRoute] string key)
    {
        var result = await _mediator.Send(new DeleteCountryLocalNamesByIdCommand(key));
        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
}
