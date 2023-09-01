// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public record GetCountryTimeZonesQuery() : IRequest<IQueryable<CountryTimeZonesDto>>;

public partial class GetCountryTimeZonesQueryHandler : QueryBase<IQueryable<CountryTimeZonesDto>>, IRequestHandler<GetCountryTimeZonesQuery, IQueryable<CountryTimeZonesDto>>
{
    public  GetCountryTimeZonesQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<IQueryable<CountryTimeZonesDto>> Handle(GetCountryTimeZonesQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<CountryTimeZonesDto>)DataDbContext.CountryTimeZones
            .Where(r => r.DeletedAtUtc == null)
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}