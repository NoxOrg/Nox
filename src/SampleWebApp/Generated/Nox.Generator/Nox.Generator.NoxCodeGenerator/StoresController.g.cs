// Generated

#nullable enable

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using SampleWebApp.Application;
using SampleWebApp.Application.DataTransferObjects;
using SampleWebApp.Domain;
using SampleWebApp.Infrastructure.Persistence;
using Nox.Types;

namespace SampleWebApp.Presentation.Api.OData;

public partial class StoresController : ODataController
{
    
    /// <summary>
    /// The OData DbContext for CRUD operations.
    /// </summary>
    protected readonly ODataDbContext _databaseContext;
    
    /// <summary>
    /// The Automapper.
    /// </summary>
    protected readonly IMapper _mapper;
    
    public StoresController(
        ODataDbContext databaseContext,
        IMapper mapper
    )
    {
        _databaseContext = databaseContext;
        _mapper = mapper;
    }
    
    [EnableQuery]
    public ActionResult<IQueryable<Store>> Get()
    {
        return Ok(_databaseContext.Stores);
    }
    
    public ActionResult<Store> Get([FromRoute] string key)
    {
        var item = _databaseContext.Stores.SingleOrDefault(d => d.Id.Equals(key));
        
        if (item == null)
        {
            return NotFound();
        }
        
        return Ok(item);
    }
    
    public async Task<ActionResult> Post(StoreDto store)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var entity = _mapper.Map<Store>(store);
        
        entity.Id = Guid.NewGuid().ToString().Substring(0, 2);
        
        _databaseContext.Stores.Add(entity);
        
        await _databaseContext.SaveChangesAsync();
        
        return Created(entity);
    }
    
    public async Task<ActionResult> Put([FromRoute] string key, [FromBody] Store updatedStore)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        if (key != updatedStore.Id)
        {
            return BadRequest();
        }
        
        _databaseContext.Entry(updatedStore).State = EntityState.Modified;
        
        try
        {
            await _databaseContext.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!StoreExists(key))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        
        return Updated(updatedStore);
    }
    
    public async Task<ActionResult> Patch([FromRoute] string store, [FromBody] Delta<Store> Id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var entity = await _databaseContext.Stores.FindAsync(store);
        
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
            if (!StoreExists(store))
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
    
    private bool StoreExists(string store)
    {
        return _databaseContext.Stores.Any(p => p.Id == store);
    }
    
    public async Task<ActionResult> Delete([FromRoute] string Id)
    {
        var store = await _databaseContext.Stores.FindAsync(Id);
        if (store == null)
        {
            return NotFound();
        }
        
        _databaseContext.Stores.Remove(store);
        await _databaseContext.SaveChangesAsync();
        return NoContent();
    }
}
