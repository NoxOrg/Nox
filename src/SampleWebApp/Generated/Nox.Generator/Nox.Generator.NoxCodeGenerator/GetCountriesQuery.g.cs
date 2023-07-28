// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleWebApp.Presentation.Api.OData;

namespace SampleWebApp.Domain;

public record GetCountriesQuery() : IRequest<IQueryable<OCountry>>;

public class GetCountriesHandler : IRequestHandler<GetCountriesQuery, IQueryable<OCountry>>
{
    public  GetCountriesHandler(ODataDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public ODataDbContext DataDbContext { get; }

    public Task<IQueryable<OCountry>> Handle(GetCountriesQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult((IQueryable<OCountry>)DataDbContext.Countries);
    }
}