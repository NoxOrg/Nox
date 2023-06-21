// generated

#nullable enable

using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.OData;
using Microsoft.AspNetCore.OData.Extensions;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.OData.UriParser;
using System.Threading.Tasks;
using System.Net;
using Microsoft.EntityFrameworkCore;
using SampleService.Domain;
using SampleService.Infrastructure.Persistence;

namespace SampleWebApp.Presentation.Api.OData;

public class CurrenciesController : ODataController
{
    SampleWebAppDbContext _databaseContext = new SampleWebAppDbContext();

    public CurrenciesController(SampleWebAppDbContext databaseContext)
    {
        _databaseContext = databaseContext;
    }
    
    [EnableQuery]
    public IQueryable<Currency> Get()
    {
        return _databaseContext.Currencies;
    }
    
    [EnableQuery]
    public SingleResult<Currency> Get([FromODataUri] int key)
    {
        IQueryable<Currency> result = _databaseContext.Currencies.Where(p => p.Id == key);
        return SingleResult.Create(result);
    }
    
    public async Task<IHttpActionResult> Post(Currency currency)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        _databaseContext.Currencies.Add(currency);
        await _databaseContext.SaveChangesAsync();
        return Created(currency);
    }
    
    public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Currency> currency)
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
    
    public async Task<IHttpActionResult> Put([FromODataUri] int key, Currency update)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        if (key != update.Id)
        {
            return BadRequest();
        }
        _databaseContext.Entry(update).State = EntityState.Modified;
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
        return Updated(update);
    }
    
    private bool CurrencyExists(int key)
    {
        return _databaseContext.Currencies.Any(p => p.Id == key);
    }
    
    public async Task<IHttpActionResult> Delete([FromODataUri] int key)
    {
        var currency = await _databaseContext.Currencies.FindAsync(key);
        if (currency == null)
        {
            return NotFound();
        }
        
        _databaseContext.Currencies.Remove(currency);
        await _databaseContext.SaveChangesAsync();
        return StatusCode(HttpStatusCode.NoContent);
    }
    
    protected override void Dispose(bool disposing)
    {
        _databaseContext.Dispose();
        base.Dispose(disposing);
    }
}
