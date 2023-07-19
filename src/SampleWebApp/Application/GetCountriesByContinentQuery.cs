using Nox.Types;
using SampleWebAppDbContext = SampleWebApp.SampleWebAppDbContext;

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
