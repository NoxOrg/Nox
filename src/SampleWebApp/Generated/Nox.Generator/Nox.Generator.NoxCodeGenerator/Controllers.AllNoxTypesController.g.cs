// Generated

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

public partial class AllNoxTypesController : ODataController
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
    
    public AllNoxTypesController(
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
    public async  Task<ActionResult<IQueryable<AllNoxTypeDto>>> Get()
    {
        var result = await _mediator.Send(new GetAllNoxTypesQuery());
        return Ok(result);
    }
    
    public async Task<ActionResult<AllNoxTypeDto>> Get([FromRoute] System.UInt64 key)
    {
        var item = await _mediator.Send(new GetAllNoxTypeByIdQuery(key));
        
        if (item == null)
        {
            return NotFound();
        }
        
        return Ok(item);
    }
    
    public async Task<ActionResult> Post([FromBody]AllNoxTypeCreateDto allnoxtype)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var createdKey = await _mediator.Send(new CreateAllNoxTypeCommand(allnoxtype));
        
        return Created(createdKey);
    }
    
    public async Task<ActionResult> Put([FromRoute] System.UInt64 key, [FromBody] AllNoxTypeUpdateDto allNoxType)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var updated = await _mediator.Send(new UpdateAllNoxTypeCommand(key,allNoxType));
        
        if (!updated)
        {
            return NotFound();
        }
        return Updated(allNoxType);
    }
    
    public async Task<ActionResult> Patch([FromRoute] System.UInt64 key, [FromBody] Delta<AllNoxTypeUpdateDto> allNoxType)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
         await Task.Delay(1000);//TODO Map to command
        
        return Updated(allNoxType);
    }
    
    private bool AllNoxTypeExists(System.UInt64 key)
    {
        return _databaseContext.AllNoxTypes.Any(p => p.Id == key);
    }
    
    public async Task<ActionResult> Delete([FromRoute] System.UInt64 key)
    {
        var result = await _mediator.Send(new DeleteAllNoxTypeByIdCommand(key));
        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
}
