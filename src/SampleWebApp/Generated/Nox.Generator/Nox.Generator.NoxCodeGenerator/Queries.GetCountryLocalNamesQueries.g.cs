// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleWebApp.Application.Dto;
using SampleWebApp.Presentation.Api.OData;

namespace SampleWebApp.Application.Queries;

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
        var item = (IQueryable<OCountryLocalNames>)DataDbContext.CountryLocalNames
            .Where(r => !(r.Deleted == true))
            .AsNoTracking();
        return Task.FromResult(item);
    }
}