// Generated

using System.Linq;
using System.Web.Http;
using Microsoft.AspNet.OData;
using SampleService.Domain;
using System.Threading.Tasks;
using System.Net;
using Microsoft.EntityFrameworkCore;
using SampleService.Infrastructure.Persistence;

namespace SampleService.Presentation.Api.OData;

public class CurrencyCashBalancesController : ODataController
{
    SampleServiceDbContext _databaseContext = new SampleServiceDbContext();

    public CurrencyCashBalancesController(SampleServiceDbContext databaseContext)
    {
        _databaseContext = databaseContext;
    }
    
    [EnableQuery]
    public IQueryable<CurrencyCashBalance> Get()
    {
        return _databaseContext.CurrencyCashBalances;
    }
    
    [EnableQuery]
    public SingleResult<CurrencyCashBalance> Get([FromODataUri] int key)
    {
        IQueryable<CurrencyCashBalance> result = _databaseContext.CurrencyCashBalances.Where(p => p.Id == key);
        return SingleResult.Create(result);
    }
    
    public async Task<IHttpActionResult> Post(CurrencyCashBalance currencycashbalance)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        _databaseContext.CurrencyCashBalances.Add(currencycashbalance);
        await _databaseContext.SaveChangesAsync();
        return Created(currencycashbalance);
    }
    
    public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<CurrencyCashBalance> currencycashbalance)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var entity = await _databaseContext.CurrencyCashBalances.FindAsync(key);
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
    
    public async Task<IHttpActionResult> Put([FromODataUri] int key, CurrencyCashBalance update)
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
            if (!CurrencyCashBalanceExists(key))
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
    
    private bool CurrencyCashBalanceExists(int key)
    {
        return _databaseContext.CurrencyCashBalances.Any(p => p.Id == key);
    }
    
    public async Task<IHttpActionResult> Delete([FromODataUri] int key)
    {
        var currencycashbalance = await _databaseContext.CurrencyCashBalances.FindAsync(key);
        if (currencycashbalance == null)
        {
            return NotFound();
        }
        
        _databaseContext.CurrencyCashBalances.Remove(currencycashbalance);
        await _databaseContext.SaveChangesAsync();
        return StatusCode(HttpStatusCode.NoContent);
    }
    
    protected override void Dispose(bool disposing)
    {
        _databaseContext.Dispose();
        base.Dispose(disposing);
    }
}
