using Nox.Types;
using SampleWebApp.Application.DataTransferObjects;
using SampleWebAppDbContext = SampleWebApp.Infrastructure.Persistence.SampleWebAppDbContext;

namespace SampleWebApp.Application
{
    public class GetCountriesByContinentQuery : GetCountriesByContinentQueryBase
    {
        public GetCountriesByContinentQuery(SampleWebAppDbContext dbContext) : base(dbContext)
        {
        }

        public override Task<IEnumerable<CountryInfo>> ExecuteAsync(Text continentName)
        {
            throw new NotImplementedException();
        }
    }
}
