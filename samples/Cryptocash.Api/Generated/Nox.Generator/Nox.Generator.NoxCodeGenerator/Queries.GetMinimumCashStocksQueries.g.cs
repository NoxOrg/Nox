// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using CryptocashApi.Application.Dto;
using CryptocashApi.Infrastructure.Persistence;

namespace CryptocashApi.Application.Queries;

public record GetMinimumCashStocksQuery() : IRequest<IQueryable<MinimumCashStockDto>>;

public class GetMinimumCashStocksQueryHandler : IRequestHandler<GetMinimumCashStocksQuery, IQueryable<MinimumCashStockDto>>
{
    public  GetMinimumCashStocksQueryHandler(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public Task<IQueryable<MinimumCashStockDto>> Handle(GetMinimumCashStocksQuery request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<MinimumCashStockDto>)DataDbContext.MinimumCashStocks
            .Where(r => r.DeletedAtUtc == null)
            .AsNoTracking();
        return Task.FromResult(item);
    }
}