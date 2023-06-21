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

namespace SampleService.Presentation.Api.OData;

public class CountryLocalNamesController : ODataController
{
    SampleServiceDbContext _databaseContext = new SampleServiceDbContext();

    public CountryLocalNamesController(SampleServiceDbContext databaseContext)
    {
        _databaseContext = databaseContext;
    }
    
    [EnableQuery]
    public IQueryable<CountryLocalNames> Get()
    {
        return _databaseContext.CountryLocalNames;
    }
    
    [EnableQuery]
    public SingleResult<CountryLocalNames> Get([FromODataUri] int key)
    {
        IQueryable<CountryLocalNames> result = _databaseContext.CountryLocalNames.Where(p => p.Id == key);
        return SingleResult.Create(result);
    }
    
    public async Task<IHttpActionResult> Post(CountryLocalNames countrylocalnames)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        _databaseContext.CountryLocalNames.Add(countrylocalnames);
        await _databaseContext.SaveChangesAsync();
        return Created(countrylocalnames);
    }
    
    public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<CountryLocalNames> countrylocalnames)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var entity = await _databaseContext.CountryLocalNames.FindAsync(key);
        if (entity == null)
        {
            return NotFound();
        }
        countrylocalnames.Patch(entity);
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
        return Updated(entity);
    }
    
    public async Task<IHttpActionResult> Put([FromODataUri] int key, CountryLocalNames update)
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
            if (!CountryLocalNamesExists(key))
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
    
    private bool CountryLocalNamesExists(int key)
    {
        return _databaseContext.CountryLocalNames.Any(p => p.Id == key);
    }
    
    public async Task<IHttpActionResult> Delete([FromODataUri] int key)
    {
        var countrylocalnames = await _databaseContext.CountryLocalNames.FindAsync(key);
        if (countrylocalnames == null)
        {
            return NotFound();
        }
        
        _databaseContext.CountryLocalNames.Remove(countrylocalnames);
        await _databaseContext.SaveChangesAsync();
        return StatusCode(HttpStatusCode.NoContent);
    }
    
    protected override void Dispose(bool disposing)
    {
        _databaseContext.Dispose();
        base.Dispose(disposing);
    }
}
