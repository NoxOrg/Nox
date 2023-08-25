// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using CryptocashApi.Application.Dto;
using CryptocashApi.Infrastructure.Persistence;

namespace CryptocashApi.Application.Queries;

public record GetCountryTimeZonesQuery() : IRequest<IQueryable<CountryTimeZonesDto>>;

public class GetCountryTimeZonesQueryHandler : IRequestHandler<GetCountryTimeZonesQuery, IQueryable<CountryTimeZonesDto>>
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
        return Task.FromResult(item);
    }
}