// Generated

#nullable enable

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using SampleService.Domain;
using SampleService.Infrastructure.Persistence;
using System.Net;
using Nox.Types;

namespace SampleService.Presentation.Api.OData;

public class CurrencyCashBalancesController : ODataController
{
    SampleServiceDbContext _databaseContext;

    public CurrencyCashBalancesController(SampleServiceDbContext databaseContext)
    {
        _databaseContext = databaseContext;
    }
    
    [EnableQuery]
    public ActionResult<IQueryable<CurrencyCashBalance>> Get()
    {
        return Ok(_databaseContext.CurrencyCashBalances);
    }
    
    [EnableQuery]
    public ActionResult<CurrencyCashBalance> Get([FromRoute] string key)
    {
        var parsedKey = CurrencyCashBalanceId.From(Entity.From(key));
        var item = _databaseContext.CurrencyCashBalances.SingleOrDefault(d => d.Id.Equals(parsedKey));
        
        if (item == null)
        {
            return NotFound();
        }
        return Ok(item);
    }
    
    public async Task<ActionResult> Post(CurrencyCashBalance currencycashbalance)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        _databaseContext.CurrencyCashBalances.Add(currencycashbalance);
        
        await _databaseContext.SaveChangesAsync();
        
        return Created(currencycashbalance);
    }
    
    public async Task<ActionResult> Put([FromRoute] string key, [FromBody] CurrencyCashBalance updatedCurrencyCashBalance)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var parsedKey = CurrencyCashBalanceId.From(Entity.From(key));
        if (parsedKey != updatedCurrencyCashBalance.Id)
        {
            return BadRequest();
        }
        _databaseContext.Entry(updatedCurrencyCashBalance).State = EntityState.Modified;
        try
        {
            await _databaseContext.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CurrencyCashBalanceExists(key))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        return Updated(updatedCurrencyCashBalance);
    }
    
    public async Task<ActionResult> Patch([FromRoute] string key, [FromBody] Delta<CurrencyCashBalance> currencycashbalance)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var parsedKey = CurrencyCashBalanceId.From(Entity.From(key));
        var entity = await _databaseContext.CurrencyCashBalances.FindAsync(parsedKey);
        if (entity == null)
        {
            return NotFound();
        }
        currencycashbalance.Patch(entity);
        try
        {
            await _databaseContext.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CurrencyCashBalanceExists(key))
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
    
    private bool CurrencyCashBalanceExists(string key)
    {
        var parsedKey = CurrencyCashBalanceId.From(Entity.From(key));
        return _databaseContext.CurrencyCashBalances.Any(p => p.Id == parsedKey);
    }
    
    public async Task<ActionResult> Delete([FromRoute] string key)
    {
        var parsedKey = CurrencyCashBalanceId.From(Entity.From(key));
        var currencycashbalance = await _databaseContext.CurrencyCashBalances.FindAsync(parsedKey);
        if (currencycashbalance == null)
        {
            return NotFound();
        }
        
        _databaseContext.CurrencyCashBalances.Remove(currencycashbalance);
        await _databaseContext.SaveChangesAsync();
        return StatusCode((int)HttpStatusCode.NoContent);
    }
}
