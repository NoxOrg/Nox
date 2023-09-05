using Microsoft.AspNetCore.OData.Routing.Controllers;
using ClientApi.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace Nox.ClientApi.Tests.Controllers
{

    public partial class TestsController : ODataController
    {
        public TestsController(ClientApiDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public ClientApiDbContext DbContext { get; }

        
        public async Task<IResult> CleanupDatabase()
        {
            DbContext!.Database.EnsureDeleted();
            DbContext!.Database.EnsureCreated();            
            return Results.Ok(true);
        }
    }
}
