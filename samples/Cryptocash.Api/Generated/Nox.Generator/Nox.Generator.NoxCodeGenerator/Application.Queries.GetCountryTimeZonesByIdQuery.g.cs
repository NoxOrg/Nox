// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using Cryptocash.Application.Dto;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Application.Queries;

public record GetCountryTimeZonesByIdQuery(System.Int64 keyId) : IRequest <CountryTimeZonesDto?>;

public partial class GetCountryTimeZonesByIdQueryHandler:  QueryBase<CountryTimeZonesDto?>, IRequestHandler<GetCountryTimeZonesByIdQuery, CountryTimeZonesDto?>
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
        return Task.FromResult(OnResponse(item));
    }
}