using MediatR;
using SampleWebApp.Presentation.Api.OData;

namespace SampleWebApp.Application.Queries
{
    /// <summary>
    /// Custom Query and Handler Example
    /// </summary>
    public record GetCountriesIManageQuery : IRequest<IQueryable<OCountry>>;

    public class GetCountriesIManageQueryHandler : IRequestHandler<GetCountriesIManageQuery, IQueryable<OCountry>>
    {
        public GetCountriesIManageQueryHandler(ODataDbContext dataDbContext)
        {
            DataDbContext = dataDbContext;
        }

        public ODataDbContext DataDbContext { get; }

        public Task<IQueryable<OCountry>> Handle(GetCountriesIManageQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult((IQueryable<OCountry>)DataDbContext.Countries.Where(country => country.Population > 12348));
        }
    }
}
