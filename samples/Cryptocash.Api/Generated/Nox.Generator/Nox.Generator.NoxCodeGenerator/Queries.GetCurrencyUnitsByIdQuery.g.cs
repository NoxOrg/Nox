// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using CryptocashApi.Application.Dto;
using CryptocashApi.Infrastructure.Persistence;

namespace CryptocashApi.Application.Queries;

public record GetCurrencyUnitsByIdQuery(System.Int64 keyId) : IRequest<CurrencyUnitsDto?>;

public class GetCurrencyUnitsByIdQueryHandler: IRequestHandler<GetCurrencyUnitsByIdQuery, CurrencyUnitsDto?>
{
    public  GetCurrencyUnitsByIdQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<CurrencyUnitsDto?> Handle(GetCurrencyUnitsByIdQuery request, CancellationToken cancellationToken)
    {    
        var item = DataDbContext.CurrencyUnits
            .AsNoTracking()
            .SingleOrDefault(r =>
                r.Id.Equals(request.keyId) &&
                r.DeletedAtUtc == null);
        return Task.FromResult(item);
    }
}