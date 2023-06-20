// Generated

using System.Linq;
using System.Web.Http;
using Microsoft.AspNet.OData;
using SampleService.Domain;
using System.Threading.Tasks;
using System.Net;
using Microsoft.EntityFrameworkCore;

namespace SampleService.Presentation.Api.OData;

public class CountriesController : ODataController
{
    SampleServiceDbContext _databaseContext = new SampleServiceDbContext();

    public CountriesController(SampleServiceDbContext databaseContext)
    {
        _databaseContext = databaseContext;
    }
    
    protected override void Dispose(bool disposing)
    {
        _databaseContext.Dispose();
        base.Dispose(disposing);
    }
}
