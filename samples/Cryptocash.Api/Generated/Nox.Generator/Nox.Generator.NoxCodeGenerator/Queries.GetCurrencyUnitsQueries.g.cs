// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using CryptocashApi.Application.Dto;
using CryptocashApi.Infrastructure.Persistence;

namespace CryptocashApi.Application.Queries;

public record GetCurrencyUnitsQuery() : IRequest<IQueryable<CurrencyUnitsDto>>;

public class GetCurrencyUnitsQueryHandler : IRequestHandler<GetCurrencyUnitsQuery, IQueryable<CurrencyUnitsDto>>
{
    public  GetCurrencyUnitsQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<IQueryable<CurrencyUnitsDto>> Handle(GetCurrencyUnitsQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<CurrencyUnitsDto>)DataDbContext.CurrencyUnits
            .Where(r => r.DeletedAtUtc == null)
            .AsNoTracking();
        return Task.FromResult(item);
    }
}