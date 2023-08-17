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

public partial class StoreSecurityPasswordsController : ODataController
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
    
    public StoreSecurityPasswordsController(
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
    public async  Task<ActionResult<IQueryable<StoreSecurityPasswordsDto>>> Get()
    {
        var result = await _mediator.Send(new GetStoreSecurityPasswordsQuery());
        return Ok(result);
    }
    
    public async Task<ActionResult<StoreSecurityPasswordsDto>> Get([FromRoute] System.String key)
    {
        var item = await _mediator.Send(new GetStoreSecurityPasswordsByIdQuery(key));
        
        if (item == null)
        {
            return NotFound();
        }
        
        return Ok(item);
    }
    
    public async Task<ActionResult> Post([FromBody]StoreSecurityPasswordsCreateDto storesecuritypasswords)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var createdKey = await _mediator.Send(new CreateStoreSecurityPasswordsCommand(storesecuritypasswords));
        
        return Created(createdKey);
    }
    
    public async Task<ActionResult> Put([FromRoute] System.String key, [FromBody] StoreSecurityPasswordsUpdateDto storeSecurityPasswords)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var updated = await _mediator.Send(new UpdateStoreSecurityPasswordsCommand(key, storeSecurityPasswords));
        
        if (updated is null)
        {
            return NotFound();
        }
        return Updated(storeSecurityPasswords);
    }
    
    public async Task<ActionResult> Patch([FromRoute] System.String key, [FromBody] Delta<StoreSecurityPasswordsUpdateDto> storeSecurityPasswords)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var updateProperties = new Dictionary<string, dynamic>();
        var deletedProperties = new List<string>();

        foreach (var propertyName in storeSecurityPasswords.GetChangedPropertyNames())
        {
            if(storeSecurityPasswords.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updateProperties[propertyName] = value;                
            }
            else
            {
                deletedProperties.Add(propertyName);
            }
        }
        
        var updated = await _mediator.Send(new PartialUpdateStoreSecurityPasswordsCommand(key, updateProperties, deletedProperties));
        
        if (updated is null)
        {
            return NotFound();
        }
        return Updated(storeSecurityPasswords);
    }
    
    private bool StoreSecurityPasswordsExists(System.String key)
    {
        return _databaseContext.StoreSecurityPasswords.Any(p => p.Id == key);
    }
    
    public async Task<ActionResult> Delete([FromRoute] System.String key)
    {
        var result = await _mediator.Send(new DeleteStoreSecurityPasswordsByIdCommand(key));
        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
}
