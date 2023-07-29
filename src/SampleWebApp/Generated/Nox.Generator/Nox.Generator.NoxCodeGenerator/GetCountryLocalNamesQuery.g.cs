// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleWebApp.Presentation.Api.OData;

namespace SampleWebApp.Domain;

public record GetCountryLocalNamesQuery() : IRequest<IQueryable<OCountryLocalNames>>;

public class GetCountryLocalNamesQueryHandler : IRequestHandler<GetCountryLocalNamesQuery, IQueryable<OCountryLocalNames>>
{
    public  GetCountryLocalNamesQueryHandler(ODataDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public ODataDbContext DataDbContext { get; }

    public Task<IQueryable<OCountryLocalNames>> Handle(GetCountryLocalNamesQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult((IQueryable<OCountryLocalNames>)DataDbContext.CountryLocalNames);
    }
}