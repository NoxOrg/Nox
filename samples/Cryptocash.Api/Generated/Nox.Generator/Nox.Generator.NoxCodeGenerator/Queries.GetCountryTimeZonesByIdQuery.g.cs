// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using CryptocashApi.Application.Dto;
using CryptocashApi.Infrastructure.Persistence;

namespace CryptocashApi.Application.Queries;

public record GetCountryTimeZonesByIdQuery(System.Int64 keyId) : IRequest<CountryTimeZonesDto?>;

public class GetCountryTimeZonesByIdQueryHandler: IRequestHandler<GetCountryTimeZonesByIdQuery, CountryTimeZonesDto?>
{
    public  GetCountryTimeZonesByIdQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<CountryTimeZonesDto?> Handle(GetCountryTimeZonesByIdQuery request, CancellationToken cancellationToken)
    {    
        var item = DataDbContext.CountryTimeZones
            .AsNoTracking()
            .SingleOrDefault(r =>
                r.Id.Equals(request.keyId) &&
                r.DeletedAtUtc == null);
        return Task.FromResult(item);
    }
}