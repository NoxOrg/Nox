using MediatR;
using SampleWebApp.Application.Dto;
using SampleWebApp.Presentation.Api.OData;

namespace SampleWebApp.Application.Queries
{
    /// <summary>
    /// Custom Query and Handler Example
    /// </summary>
    public record GetCountriesIManageQuery : IRequest<IQueryable<CountryDto>>;

    public class GetCountriesIManageQueryHandler : IRequestHandler<GetCountriesIManageQuery, IQueryable<CountryDto>>
    {
        public GetCountriesIManageQueryHandler(ODataDbContext dataDbContext)
        {
            DataDbContext = dataDbContext;
        }

        public ODataDbContext DataDbContext { get; }

        public Task<IQueryable<CountryDto>> Handle(GetCountriesIManageQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult((IQueryable<CountryDto>)DataDbContext.Countries.Where(country => country.Population > 12348));
        }
    }
}
