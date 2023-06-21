// Generated

#nullable enable

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using SampleWebApp.Domain;
using SampleWebApp.Infrastructure.Persistence;
using System.Net;
using Nox.Types;

namespace SampleWebApp.Presentation.Api.OData;

public class CurrenciesController : ODataController
{
    SampleWebAppDbContext _databaseContext;

    public CurrenciesController(SampleWebAppDbContext databaseContext)
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
        var parsedKey = CurrencyId.From(Text.From(key));
        var item = _databaseContext.Currencies.SingleOrDefault(d => d.Id.Equals(parsedKey));
        
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
        
        var parsedKey = CurrencyId.From(Text.From(key));
        if (parsedKey != updatedCurrency.Id)
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
        
        var parsedKey = CurrencyId.From(Text.From(key));
        var entity = await _databaseContext.Currencies.FindAsync(parsedKey);
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
        var parsedKey = CurrencyId.From(Text.From(key));
        return _databaseContext.Currencies.Any(p => p.Id == parsedKey);
    }
    
    public async Task<ActionResult> Delete([FromRoute] string key)
    {
        var parsedKey = CurrencyId.From(Text.From(key));
        var currency = await _databaseContext.Currencies.FindAsync(parsedKey);
        if (currency == null)
        {
            return NotFound();
        }
        
        _databaseContext.Currencies.Remove(currency);
        await _databaseContext.SaveChangesAsync();
        return StatusCode((int)HttpStatusCode.NoContent);
    }
}
