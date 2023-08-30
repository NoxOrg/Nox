using MediatR;
using SampleWebApp.Application.Dto;
using SampleWebApp.Infrastructure.Persistence;

namespace SampleWebApp.Application.Queries
{
    /// <summary>
    /// Custom Query and Handler Example
    /// </summary>
    public record GetCountriesIManageQuery : IRequest<IQueryable<CountryDto>>;

    public class GetCountriesIManageQueryHandler : IRequestHandler<GetCountriesIManageQuery, IQueryable<CountryDto>>
    {
        public GetCountriesIManageQueryHandler(DtoDbContext dataDbContext)
        {
            DataDbContext = dataDbContext;
        }

        public DtoDbContext DataDbContext { get; }

        public Task<IQueryable<CountryDto>> Handle(GetCountriesIManageQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(DataDbContext.Countries.Where(country => country.Population > 12348));
        }
    }
}
