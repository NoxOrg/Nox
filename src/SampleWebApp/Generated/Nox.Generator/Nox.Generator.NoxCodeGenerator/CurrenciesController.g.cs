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

public partial class CurrenciesController : ODataController
{
    protected readonly ODataDbContext _databaseContext;
    
    public CurrenciesController(
        ODataDbContext databaseContext
    )
    {
        _databaseContext = databaseContext;
    }
    
    [EnableQuery]
    public ActionResult<IQueryable<Currency>> Get()
    {
        return Ok(_databaseContext.Currencies);
    }
    
    [EnableQuery]
    public ActionResult<Currency> Get([FromRoute] string key)
    {
        var item = _databaseContext.Currencies.SingleOrDefault(d => d.Id.Equals(key));
        
        if (item == null)
        {
            return NotFound();
        }
        
        return Ok(item);
    }
    
    public async Task<ActionResult> Post(Currency currency)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        _databaseContext.Currencies.Add(currency);
        
        await _databaseContext.SaveChangesAsync();
        
        return Created(currency);
    }
    
    public async Task<ActionResult> Put([FromRoute] string key, [FromBody] Currency updatedCurrency)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        if (key != updatedCurrency.Id)
        {
            return BadRequest();
        }
        
        _databaseContext.Entry(updatedCurrency).State = EntityState.Modified;
        
        try
        {
            await _databaseContext.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CurrencyExists(key))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        
        return Updated(updatedCurrency);
    }
    
    public async Task<ActionResult> Patch([FromRoute] string key, [FromBody] Delta<Currency> currency)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var entity = await _databaseContext.Currencies.FindAsync(key);
        
        if (entity == null)
        {
            return NotFound();
        }
        
        currency.Patch(entity);
        
        try
        {
            await _databaseContext.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CurrencyExists(key))
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
    
    private bool CurrencyExists(string key)
    {
        return _databaseContext.Currencies.Any(p => p.Id == key);
    }
    
    public async Task<ActionResult> Delete([FromRoute] string key)
    {
        var currency = await _databaseContext.Currencies.FindAsync(key);
        if (currency == null)
        {
            return NotFound();
        }
        
        _databaseContext.Currencies.Remove(currency);
        await _databaseContext.SaveChangesAsync();
        return NoContent();
    }
}
