// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleWebApp.Presentation.Api.OData;

namespace SampleWebApp.Application.Queries;

public record GetCountriesQuery() : IRequest<IQueryable<OCountry>>;

public class GetCountriesQueryHandler : IRequestHandler<GetCountriesQuery, IQueryable<OCountry>>
{
    public  GetCountriesQueryHandler(ODataDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public ODataDbContext DataDbContext { get; }

    public Task<IQueryable<OCountry>> Handle(GetCountriesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<OCountry>)DataDbContext.Countries
            .Where(r => !(r.Deleted == true))
            .AsNoTracking();
        return Task.FromResult(item);
    }
}