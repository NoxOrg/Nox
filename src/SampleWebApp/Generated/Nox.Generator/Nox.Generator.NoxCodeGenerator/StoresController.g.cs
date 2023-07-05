// Generated

#nullable enable

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using SampleWebApp.Application;
using SampleWebApp.Application.DataTransferObjects;
using SampleWebApp.Domain;
using SampleWebApp.Infrastructure.Persistence;
using Nox.Types;

namespace SampleWebApp.Presentation.Api.OData;

public partial class StoresController : ODataController
{
    protected readonly ODataDbContext _databaseContext;
    
    public StoresController(
        ODataDbContext databaseContext
    )
    {
        databaseContext = databaseContext;
    }
    
    [EnableQuery]
    public ActionResult<IQueryable<Store>> Get()
    {
        return Ok(_databaseContext.Stores);
    }
    
    [EnableQuery]
    public ActionResult<Store> Get([FromRoute] string key)
    {
        var item = _databaseContext.Stores.SingleOrDefault(d => d.Id.Equals(key));
        
        if (item == null)
        {
            return NotFound();
        }
        
        return Ok(item);
    }
    
    public async Task<ActionResult> Post(Store store)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        _databaseContext.Stores.Add(store);
        
        await _databaseContext.SaveChangesAsync();
        
        return Created(store);
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
    
    public async Task<ActionResult> Patch([FromRoute] string key, [FromBody] Delta<Store> store)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var entity = await _databaseContext.Stores.FindAsync(key);
        
        if (entity == null)
        {
            return NotFound();
        }
        
        store.Patch(entity);
        
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
        
        return Updated(entity);
    }
    
    private bool StoreExists(string key)
    {
        return _databaseContext.Stores.Any(p => p.Id == key);
    }
    
    public async Task<ActionResult> Delete([FromRoute] string key)
    {
        var store = await _databaseContext.Stores.FindAsync(key);
        if (store == null)
        {
            return NotFound();
        }
        
        _databaseContext.Stores.Remove(store);
        await _databaseContext.SaveChangesAsync();
        return NoContent();
    }
}
