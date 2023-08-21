// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using SampleWebApp.Application.Dto;
using SampleWebApp.Presentation.Api.OData;

namespace SampleWebApp.Application.Queries;

public record GetCountryLocalNamesQuery() : IRequest<IQueryable<CountryLocalNamesDto>>;

public class GetCountryLocalNamesQueryHandler : IRequestHandler<GetCountryLocalNamesQuery, IQueryable<CountryLocalNamesDto>>
{
    public  GetCountryLocalNamesQueryHandler(ODataDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public ODataDbContext DataDbContext { get; }

    public Task<IQueryable<CountryLocalNamesDto>> Handle(GetCountryLocalNamesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<CountryLocalNamesDto>)DataDbContext.CountryLocalNames
            .Where(r => r.DeletedAtUtc == null)
            .AsNoTracking();
        return Task.FromResult(item);
    }
}